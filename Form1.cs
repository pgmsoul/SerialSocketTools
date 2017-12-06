using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Noesis.Javascript;
using System.Net;
using System.Net.Sockets;

namespace SocketSerialTools {
	public partial class TransferForm : Form {
		#region variable
		private static List<TransferForm> formList = new List<TransferForm>();
		public string EditConfName,recvJs = "";
		private Config cfg = null;
		private SendDataStorage sds = null;
		private bool initComplete = false;
		private int sumRecv = 0, sumSend = 0;
		enum TransferMode {
			Serial,
			UDP,
			TCPServ,
			TCPClient
		}
		#endregion
		
		#region SerialPort
		private class PackParser {
			public byte[] buffer = new byte[1024 * 16];
			public long lastPackTick = 0;
			public int offset = 0;
		}
		PackParser pack = new PackParser();
		MicroTimer packTimer = new MicroTimer();
		private void initPackTimer() {
			packTimer.MicroTimerElapsed += new MicroTimer.MicroTimerElapsedEventHandler(OnPackTimer);
			packTimer.Interval = 1000;
			packTimer.Enabled = true;
		}
		private void OnPackTimer(object sender, MicroTimerEventArgs timerEventArgs) {
				//this.BeginInvoke(new MethodInvoker(delegate {
					//Debug.Print(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
				//}));
			checkPackData();
		}
		private void checkPackData() {
			lock (recvLock) {
				if (pack.offset == 0)
					return;
				long span = DateTime.Now.Ticks - pack.lastPackTick;
				if (span > cfg.pack_duration * 10000 || pack.offset >= 1024 * 16) {
					Debug.Print("span: " + span);
					parsePack(pack.buffer, pack.offset);
					pack.offset = 0;
					pack.lastPackTick = DateTime.Now.Ticks;
				}
			}
		}
		object recvLock = new object();
		private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) {
			lock (recvLock) {
				pack.offset += serialPort.Read(pack.buffer, pack.offset, 1024 * 16 - pack.offset);
				pack.lastPackTick = DateTime.Now.Ticks;
			}
		}
		private void parsePack(byte[] buffer,int n) {
			string str = "";
			if (cfg.recv_encode == "ascii") {
				str = System.Text.Encoding.GetEncoding("GBK").GetString(buffer, 0, n);
			} else if (cfg.recv_encode == "utf8") {
				str = System.Text.Encoding.UTF8.GetString(buffer, 0, n);
			} else if (cfg.recv_encode == "hex") {
				str = byteToHex(buffer, n);
			} else {
				return;
			}
			if (recvJs != null && recvJs != "") {
				str = handleJs(recvJs, str);
			}
			tbRecv.AppendText(str);
			showRecvCount(n);
		}
		private void close_Serial() {
			if (serialPort.IsOpen) {
				serialPort.Close();
				showSuccessTip("串口关闭成功");
			} else {
				showRedTip("串口已经关闭");
			}
			cbCom.Enabled = true;
			btnStartSerial.ImageIndex = 0;
			toolTip1.SetToolTip(btnStartSerial, "打开串口");
		}
		private bool open_Serial() {
			if (serialPort.IsOpen) {
				return true;
			}
			int baud;
			if (!int.TryParse(cbBits.Text, out baud)) {
				return false;
			}
			try {
				serialPort.PortName = SerialPortTool.GetSerialPortByName(cbCom.Text);
				serialPort.BaudRate = baud;
				serialPort.Open();
			} catch (System.IO.IOException ioe) {
				showRedTip(ioe.Message);
			} catch (System.UnauthorizedAccessException ioe) {
				showRedTip(ioe.Message);
				return false;
			} catch (System.Exception e) {
				showRedTip(e.Message);
				return false;
			}
			if (!serialPort.IsOpen) {
				showRedTip(serialPort.PortName + ": 打开串口失败");
				return false;
			}
			btnStartSerial.ImageIndex = 1;
			cbCom.Enabled = false;
			toolTip1.SetToolTip(btnStartSerial, "关闭串口");
			showSuccessTip(serialPort.PortName + ": 打开成功, 速率: " + baud);
			int index = cfg.serial_baud_rate.IndexOf(baud.ToString());
			if (index == -1 || baud != cfg.select_baud_rate || cbCom.Text != cfg.select_serial_port) {
				if (index == -1) {
					//添加新的速率到列表
					for (int i = cfg.serial_baud_rate.Count - 1; i >= 0; i--) {
						int br = 0;
						if (int.TryParse(cfg.serial_baud_rate[i], out br)) {
							if (br == baud) //事实上不可能，因为前面 index = -1
								break;
							if (baud > br) {
								cfg.serial_baud_rate.Insert(i + 1, baud.ToString());
								cbBits.Items.Insert(i + 1, baud.ToString());
								break;
							}
							if (i == 0) {
								cfg.serial_baud_rate.Insert(0, baud.ToString());
								cbBits.Items.Insert(0, baud.ToString());
							}
						} else {
							cfg.serial_baud_rate.RemoveAt(i);
							cbBits.Items.RemoveAt(i);
						}
					}
				}
				cfg.select_baud_rate = baud;
				cfg.select_serial_port = cbCom.Text;
				cfg.Save();
			}
			recvInfoBox.Text = "接收: 0 字节";
			sendInfoBox.Text = "发送: 0 字节";
			return true;
		}
		private void init_Serial_List() {
			List<string> sl = SerialPortTool.GetSerialPortList();
			if (sl == null) {
				showRedTip("读取串口列表失败");
				return;
			}
			for (int i = 0; i < sl.Count; i++) {
				string com = sl[i];
				if (cbCom.Items.IndexOf(com) == -1) {
					cbCom.Items.Add(com);
					if (cfg.select_serial_port == com) {
						cbCom.SelectedItem = com;
					}
				}
			}
			for (int i = cbCom.Items.Count - 1; i >= 0; i--) {
				string com = cbCom.Items[i].ToString();
				if (sl.IndexOf(com) == -1) {
					if (cbCom.SelectedIndex == i) {
						cbCom.Enabled = true;
						btnStartSerial.ImageIndex = 0;
						toolTip1.SetToolTip(btnStartSerial, "打开串口");
						showRedTip("串口被移除");
					}
					cbCom.Items.RemoveAt(i);
				}
			}
		}
		#endregion

		#region public method
		public string SetConfName(ConfEditor editor,string name) {
			if(name==null||name.Length<4){
				return "名称必须以 '.cfg' 作为后缀";
			}
			string ext = name.Substring(name.Length - 4, 4);
			if (ext.ToLower() != ".cfg") {
				return "名称必须以 '.cfg' 作为后缀";
			}
			string path = ".\\conf\\" + name;
			bool exist = File.Exists(path);
			if (editor.Type == ConfEditor.EditType.New) {
				//新建配置
				if (exist) {
					return "名称为 ["+name+"] 的配置已经存在，请使用其它名称";
				}
				File.Create(path);
				refreshAllConfList(ConfListChangeType.Add, name);
			}else if(editor.Type==ConfEditor.EditType.Copy){
				if (exist) {
					return "名称为 [" + name + "] 的配置已经存在，请使用其它名称";
				}
				string src = ".\\conf\\" + EditConfName;
				try {
					//File.Copy(src, path);
					FileInfo file = new FileInfo(src);
					if (file.Exists) {
						file.CopyTo(path);
						
					} else {
						return "源文件不存在: "+src;
					}
				} catch (Exception e) {
					return e.Message+"(不能是 COM1 等串口名称)";
				}
				refreshAllConfList(ConfListChangeType.Add, name);
			} else {
				//编辑配置
				if (name.ToLower() == EditConfName.ToLower()) {
					//名字没有变化
					return "";
				}
				if (exist) {
					return "名称为 ["+name+"] 的配置已经存在，请使用其它名称";
				}
				FileInfo fi = new FileInfo(".\\conf\\"+EditConfName);

				try {
					fi.MoveTo(path);
				} catch (Exception e) {
					return e.Message + "(不能是 COM1 等串口名称)";
				}
				refreshAllConfList(ConfListChangeType.Rename, name,EditConfName);
			}
			return "";
		}
		private void saveHistoryData() {
			string hash = Utf8Sha1(tbSend.Text);
			string name = sendNameBox.Text;
			SendDataStruct sd = new SendDataStruct(hash, name, tbSend.Text, cfg.send_encode);
			int index = sds.IndexOf(hash);
			if (-1 == index) {
				sds.dataList.Insert(0, sd);
				sds.Save();
				addHistoryBox(sd, true);
			} else {
				SendDataStruct sd0 = sds.dataList[index];
				if (sd0.name != sd.name) {
					sd0.name = sd.name;
					sds.Save();
					ListViewItem item = historyDataBox.Items[index];
					item.Text = sd.name;
				}
			}
		}
		private void showSendCount(int n) {
			sumSend += n;
			sendInfoBox.Text = "发送: " + n + "/" + sumSend + " 字节";
		}
		private void showRecvCount(int n) {
			sumRecv += n;
			recvInfoBox.Text = "接收: " + n + "/" + sumRecv + " 字节";
		}
		#endregion

		#region Method
		private TransferMode curMode = TransferMode.Serial;
		private void setTransferMode() {
			if (tabMode.SelectedTab == tabUdpClient) {
				cfg.select_tab = "udp_client";
				curMode = TransferMode.UDP;
				initUdpClientPage();
			} else if (tabMode.SelectedTab == tabSerial) {
				cfg.select_tab = "serial";
				curMode = TransferMode.Serial;
				initSerialPage();
			} else if (tabMode.SelectedTab == tabTcpClient) {
				cfg.select_tab = "tcp_client";
				curMode = TransferMode.TCPClient;
			} else if (tabMode.SelectedTab == tabTcpServ) {
				curMode = TransferMode.TCPServ;
				cfg.select_tab = "tcp_serv";
			}
		}
		JavascriptContext context = new JavascriptContext();
		private string handleJs(string js, string raw) {
			string str = "";
			context.SetParameter("input", raw);
			try {
				context.Run(js);
				str = context.GetParameter("output").ToString();
			} catch (JavascriptException je) {
				str = "\r\n\r\ninput: " + raw;
				str += "\r\n" + je.Message;
				str += "\r\nLine: " + je.Line;
				str += "\r\nColum: " + je.StartColumn + " - " + je.EndColumn;
				string[] lines = js.Split('\n');
				str += "\r\nSource:\r\n" + lines[je.Line-1];
				return str;
			}
			return str;
		}
		private static void refreshAllConfList(ConfListChangeType type, string confName, string oldName = "") {
			for (int i = 0; i < formList.Count; i++) {
				TransferForm form = formList[i];
				form.refreshConfList(type,confName,oldName);
			}
		}
		private enum ConfListChangeType {
			Add,
			Rename,
			Delete
		}
		private void refreshConfList(ConfListChangeType type,string confName,string oldName = "") {
			if (type == ConfListChangeType.Add) {
				confList.Items.Add(confName);
			} else if (type == ConfListChangeType.Delete) {
				confList.Items.Remove(confName);
			} else if (type == ConfListChangeType.Rename) {
				int index = confList.Items.IndexOf(oldName);
				if (index != -1) {
					confList.Items[index] = confName;
				}
			}
		}
		private string getEscapeString(string str) {
			if (!cbEscape.Checked)
				return str;
			str = lib.getEscapeString(str);
			if (str == null) {
				showRedTip("转义字符串有错误，无法正确解析");
			}
			return str;
		}
		private byte[] hexToByte(string hex, out string error) {
			string str = "";
			error = null;
			for (int i = 0; i < hex.Length; i++) {
				if (hex[i] == ' ' || hex[i] == '\t' || hex[i] == '\r' || hex[i] == '\n')
					continue;
				str += hex[i];
			}
			byte[] data = new byte[str.Length / 2];
			for (int i = 0; i < data.Length; i++) {
				try {
					data[i] = Convert.ToByte(str.Substring(i * 2, 2), 16);
				} catch (System.FormatException e) {
					error = e.Message;
					return data;
				}
			}
			return data;
		}
		public string byteToHex(byte[] bytes,int n) {
			string returnStr = "";
			if (bytes != null) {
				for (int i = 0; i < n; i++) {
					returnStr += bytes[i].ToString("X2");
				}
			}
			return returnStr;
		}
		private string Utf8Sha1(string str) {
			byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
			return Sha1(data,0,data.Length);
		}
		private string Sha1(byte[] data,int index,int length) {
			SHA1 sha = new SHA1CryptoServiceProvider();
			byte[] hash = sha.ComputeHash(data, index, length);
			return byteToHex(hash,hash.Length);
		}
		private void setSendEncode(string encode) {
			cfg.send_encode = encode;
			if (encode == "ascii") {
				srbGbk.Checked = true;
			} else if (encode == "utf8") {
				srbUtf8.Checked = true;
			} else {
				srbHex.Checked = true;
			}
		}
		private void setRecvEncode(string encode) {
			cfg.recv_encode = encode;
			if (encode == "ascii") {
				rbGbk.Checked = true;
			} else if (encode == "utf8") {
				rbUtf8.Checked = true;
			} else {
				rbHex.Checked = true;
			}
		}
		private void initConfList() {
			DirectoryInfo di = new DirectoryInfo(".\\conf");
			FileInfo[] fi = di.GetFiles("*.cfg");
			foreach (var f in fi) {
				confList.Items.Add(f.ToString());
			}
		}
		private void loadJs() {
			DirectoryInfo di = new DirectoryInfo(".\\js");
			FileInfo[] fi = di.GetFiles("*.js");
			foreach (var f in fi) {
				cbJs.Items.Add(f.ToString());
			}
			cbJs.SelectedItem = cfg.recv_js;
		}
		private string confNameToDataName(string conf) {
			conf = conf.ToLower();
			if (conf == "")
				conf = ".cfg";
			if (conf.Length < 4)
				return null;
			if (conf.Substring(conf.Length - 4, 4) != ".cfg") {
				return null;
			}
			return conf.Substring(0, conf.Length - 4) + ".sd";
		}
		private void loadData(string conf) {
			conf = confNameToDataName(conf);
			if (conf == null)
				return;
			SendDataStorage s = SendDataStorage.Load(conf);
			if (s == null) {
				s = new SendDataStorage();
				s.file_name = conf;
				s.Save();
			}
			sds = s;
			historyDataBox.BeginUpdate();
			for (int i = 0; i < sds.dataList.Count; i++) {
				SendDataStruct sd = sds.dataList[i];
				addHistoryBox(sd);
			}
			historyDataBox.EndUpdate();
		}
		private void addHistoryBox(SendDataStruct sd,bool before = false) {
			ListViewItem lvi = new ListViewItem();
			lvi.Text = sd.name;
			lvi.SubItems.Add(sd.data);
			if (before)
				historyDataBox.Items.Insert(0, lvi);
			else
				historyDataBox.Items.Add(lvi);
		}
		private void loadConfig(string name) {
			if (name == "")
				name = ".cfg";
			Config c = Config.Load(name);
			if (c == null) {
				showRedTip("加载配置失败，已设置为确实配置: " + name);
				c = new Config();
				c.file_name = name;
				c.Save();
			}
			cfg = c;
			setRecvEncode(cfg.recv_encode);
			setSendEncode(cfg.send_encode);

			cbEscape.Checked = cfg.use_escape;

			initConfList();

			tbPackDuration.Text = cfg.pack_duration.ToString();

			this.Text = "" + c.file_name + " -- " + this.Text;
		}
		private void initSerialPage() {
			init_Serial_List();
			int select = cbCom.Items.IndexOf(cfg.select_serial_port);
			if (select != -1) {
				cbCom.SelectedIndex = select;
			}
			cbBits.Items.Clear();
			for (int i = 0; i < cfg.serial_baud_rate.Count; i++) {
				cbBits.Items.Add(cfg.serial_baud_rate[i]);
			}
			cbBits.Text = "" + cfg.select_baud_rate;
		}
		private void initUdpClientPage() {
			cbUdpClientIP.Items.Clear();
			cbUdpClientIP.Items.Add("127.0.0.1");
			cbUdpClientIP.Items.Add("255.255.255.255");
			string[] ips = lib.getIPAddress();
			for (int i = 0; i < ips.Length; i++) {
				string ip = ips[i];
				if (ip.IndexOf(":") == -1)
					cbUdpClientIP.Items.Add(ip);
			}
			for (int i = 0; i < cfg.udp_client_ips.Count; i++) {
					String ip = cfg.udp_client_ips[i];
					if (cbUdpClientIP.Items.IndexOf(ip) == -1) {
						cbUdpClientIP.Items.Add(ip);
					}
				}
			cbUdpClientIP.Text = cfg.select_udp_client_ip;

			cbUdpClientPort.Items.Clear();
			for (int i = 0; i < cfg.udp_client_ports.Count; i++) {
				string port = cfg.udp_client_ports[i];
				if (cbUdpClientPort.Items.IndexOf(port) == -1) {
					cbUdpClientPort.Items.Add(port);
				}
			}
			cbUdpClientPort.Text = cfg.select_udp_client_port;
		}
		private void showTip(string tip) {
			infoBox.Text = tip;
			infoBox.ForeColor = Color.Black;
		}
		private void showSuccessTip(string tip) {
			infoBox.Text = tip;
			infoBox.ForeColor = Color.DarkGreen;
		}
		private void showRedTip(string tip) {
			//此函数可能在其它线程调用，所以可能造成死锁，如果检测到已经关闭操作，不再执行
			if (closeFlag)
				return;
			infoBox.Text = tip;
			infoBox.ForeColor = Color.Red;
		}
		private bool sendSerialPortData(byte[] data,int offset,int length){
			if (!serialPort.IsOpen) {
				showRedTip("串口尚未打开");
				return false;
			}
			serialPort.Write(data, offset, length);
			return true;
		}
		private UdpClient udpClient;
		private bool sendUDPData(byte[] data, int offset, int length) {
			if (length > 8192) {
				showRedTip("UDP 最大包长度不能超过 8192");
				return false;
			}
			UDPAddr ua = getCurrentIPAndPort();
			IPEndPoint ipep = new IPEndPoint(ua.ip, ua.port);
			if (udpClient == null)
				udpClient = new UdpClient();
			try {
				udpClient.Send(data, length, ipep);
			} catch (Exception e) {
				showRedTip(e.Message);
				return false;
			}
			return true;
		}
		private bool recvThreadRunning = false;
		private void startUdpRecv() {
			if (recvThreadRunning)
				return;
			recvThreadRunning = true;
			new Thread(() => onUdpRecv()).Start();
		}
		private void onUdpRecv() {
			btnStartUDPServ.ImageIndex = 1;
			cbUdpClientPort.Enabled = false;
			toolTip1.SetToolTip(btnStartUDPServ, "关闭接收");

			UDPAddr ua = getCurrentIPAndPort();
			if (udpClient == null) {//
				IPEndPoint localIpep = new IPEndPoint(IPAddress.Parse("0.0.0.0"), ua.port);
				udpClient = new UdpClient(localIpep);
			}
			IPEndPoint remotePoint = new IPEndPoint(IPAddress.Any, 0);
			while (true) {
				try {
					byte[] data = udpClient.Receive(ref remotePoint);
					parsePack(data, data.Length);
				} catch(Exception e) {
					showRedTip(e.Message);
					break;
				}
			}
			recvThreadRunning = false;
			if (closeFlag) {
				return;
			}
			btnStartUDPServ.ImageIndex = 0;
			cbUdpClientPort.Enabled = true;
			toolTip1.SetToolTip(btnStartUDPServ, "启动接收");
			udpClient = null;
		}
		private void closeUdpRecv() {
			if (udpClient != null)
				udpClient.Close();
		}
		class UDPAddr {
			public IPAddress ip;
			public ushort port;
			public UDPAddr(IPAddress _ip, ushort _port) {
				ip = _ip;
				port = _port;
			}
		}
		private UDPAddr getCurrentIPAndPort() {
			//验证 ip 地址字串
			string sip = cbUdpClientIP.Text;
			IPAddress ip = lib.getValidIP(sip);
			if (ip == null) {
				showRedTip("IP 地址不正确");
				return null;
			}
			//验证端口数字
			string sport = cbUdpClientPort.Text;
			ushort port = lib.getValidPort(sport);
			if (port == 0xffff) {
				showRedTip("端口必须是不大于 65535 的整数不正确");
				return null;
			}
			//保存
			bool newItem = false;
			if (cbUdpClientIP.Items.IndexOf(sip) == -1) {
				cbUdpClientIP.Items.Insert(0, sip);
				cfg.udp_client_ips.Insert(0, sip);
				newItem = true;
			}
			if (cbUdpClientPort.Items.IndexOf(sport) == -1) {
				cbUdpClientPort.Items.Insert(0, sport);
				cfg.udp_client_ports.Insert(0, sport);
				newItem = true;
			}
			if (sport != cfg.select_udp_client_port) {
				cfg.select_udp_client_port = sport;
				newItem = true;
			}
			if (sip != cfg.select_udp_client_ip) {
				cfg.select_udp_client_ip = sip;
				newItem = true;
			}
			if (newItem) {
				saveConfig();
			}

			return new UDPAddr(ip,port);
		}
		#endregion

		#region Events
		public TransferForm() {
			Construct("");
		}
		public TransferForm(string conf) {
			Construct(conf);
		}
		private void Construct(string conf) {
			Directory.CreateDirectory(".\\js");
			InitializeComponent();
			loadConfig(conf);
			loadData(conf);
			loadJs();
			initPackTimer();
			initTabPage();
			initComplete = true;
			System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
		}
		private void initTabPage() {
			if (cfg.select_tab == "udp_client") {
				tabMode.SelectedTab = tabUdpClient;
				curMode = TransferMode.UDP;
				initUdpClientPage();
			} else if (cfg.select_tab == "tcp_serv") {
			} else if (cfg.select_tab == "tcp_client") {
			} else if (cfg.select_tab == "serial") {
				tabMode.SelectedTab = tabSerial;
				curMode = TransferMode.Serial;
				initSerialPage();
			}
		}
		private void btnStartUDPServ_Click(object sender, EventArgs e) {
			if (btnStartUDPServ.ImageIndex == 0) {
				startUdpRecv();
			} else {
				closeUdpRecv();
			}
		}
		private void tsbAddForm_Click(object sender, EventArgs e) {
			new Thread(() => Application.Run(new TransferForm())).Start();
		}
		private void cbCom_SelectedIndexChanged(object sender, EventArgs e) {
			string name = cbCom.Text;
			if (name == "" || cfg.select_serial_port == name)
				return;
			string portName = SerialPortTool.GetSerialPortByName(name);
			if (portName == null) {
				showRedTip("无效端口");
				return;
			}
		}
		private void timerRefreshSerialPort_Tick(object sender, EventArgs e) {
			if (curMode == TransferMode.Serial)
				init_Serial_List();
		}
		private void recvEncode_Changed(object sender, EventArgs e) {
			if (sender == rbGbk) {
				cfg.recv_encode = "ascii";
			} else if (sender == rbUtf8) {
				cfg.recv_encode = "utf8";
			} else {
				cfg.recv_encode = "hex";
			}
			saveConfig();
		}
		private void saveConfig() {
			if (initComplete)
				cfg.Save();
		}
		private void sendEncode_Changed(object sender, EventArgs e) {
			if (sender == srbGbk) {
				cfg.send_encode = "ascii";
			} else if (sender == srbUtf8) {
				cfg.send_encode = "utf8";
			} else {
				cfg.send_encode = "hex";
			}
			saveConfig();
		}
		private void btnLoad_Click(object sender, EventArgs e) {
			if (confList.SelectedItem == null) {
				showRedTip("请选择一个要加载的配置");
				return;
			}
			string conf = confList.SelectedItem.ToString();
			new Thread(() => Application.Run(new TransferForm(conf))).Start();

		}
		private void btnNew_Click(object sender, EventArgs e) {
			EditConfName = "";
			ConfEditor ce = new ConfEditor(this,ConfEditor.EditType.New);
			ce.ShowDialog(this);
		}
		private void btnCopy_Click(object sender, EventArgs e) {
			ConfEditor ce = new ConfEditor(this,ConfEditor.EditType.Copy);
			if (-1 == confList.SelectedIndex) {
				showRedTip("在下面的列表选择一个配置");
				return;
			}
			EditConfName = confList.SelectedItem.ToString();
			ce.ShowDialog(this);
		}
		private void btnEdit_Click(object sender, EventArgs e) {
			ConfEditor ce = new ConfEditor(this,ConfEditor.EditType.Rename);
			if (-1 == confList.SelectedIndex) {
				showRedTip("在下面的列表选择一个配置");
				return;
			}
			if (confList.SelectedItem.ToString() == ".cfg") {
				showRedTip("缺省配置不能重命名");
				return;
			}
			EditConfName = confList.SelectedItem.ToString();
			ce.ShowDialog(this);
		}
		private void btnDelete_Click(object sender, EventArgs e) {
			if (-1 == confList.SelectedIndex) {
				showRedTip("在下面的列表选择一个配置");
				return;
			}
			string confName = confList.SelectedItem.ToString();
			if (confName == ".cfg") {
				showRedTip("缺省配置不能重命名");
				return;
			}
			if (DialogResult.Yes == MessageBox.Show(this,"确实要删除配置 [" + confName + "] 吗？此操作不可恢复。\n如果有打开此配置的窗口，并且对窗口进行了某些操作，此文件可能会被重新创建。","警告",MessageBoxButtons.YesNo)) {
				string path = ".\\conf\\" + confName;
				File.Delete(path);
				refreshAllConfList(ConfListChangeType.Delete,confName);
			}
		}
		private void TransferForm_Load(object sender, EventArgs e) {
			formList.Add(this);
		}
		bool closeFlag = false;
		private void TransferForm_FormClosing(object sender, FormClosingEventArgs e) {
			packTimer.Enabled = false;
			closeFlag = true;
			close_Serial();
			closeUdpRecv();
			while (recvThreadRunning) {
				Thread.Sleep(10);
			}
		}
		private void TransferForm_FormClosed(object sender, FormClosedEventArgs e) {
			formList.Remove(this);
		}
		private void btnClearRecv_Click(object sender, EventArgs e) {
			tbRecv.Text = "";
			sumRecv = 0;
			showRecvCount(0);
		}
		private void btnClearSend_Click(object sender, EventArgs e) {
			tbSend.Text = "";
			sendNameBox.Text = "";
			sumSend = 0;
			showSendCount(0);
		}
		private string hexToString(string hex,Encoding en) {
			string error;
			byte[] data = hexToByte(hex, out error);
			if (error != null) {
				showRedTip(error);
				return null;
			}
			try {
				return en.GetString(data);
			} catch (Exception e) {
				showRedTip(e.Message);
			}
			return null;
		}
		private string StringToHex(string str,Encoding en) {
			byte[] data = en.GetBytes(str);
			return byteToHex(data, data.Length);
		}
		private void tbHexToStr(TextBox tb) {
			string str = tb.Text;
			//当前文本转换为目的编码
			if (cfg.recv_encode == "hex") {
				showRedTip("编码选择 ASCII 或者 UTF8");
				return;
			} else if(cfg.recv_encode=="ascii"){
				str = hexToString(str, Encoding.GetEncoding("GBK"));
			} else if (cfg.recv_encode == "utf8") {
				str = hexToString(str,Encoding.UTF8);
			}
			if (str == null) {
				showRedTip("编码转换失败");
				return;
			}
			tb.Text = str;
		}
		private void tbStrToHex(TextBox tb) {
			string str = tb.Text;
			//当前文本转换为目的编码
			if (cfg.recv_encode == "hex") {
				showRedTip("编码选择 ASCII 或者 UTF8");
				return;
			} else if (cfg.recv_encode == "ascii") {
				str = StringToHex(str, Encoding.GetEncoding("GBK"));
			} else if (cfg.recv_encode == "utf8") {
				str = StringToHex(str, Encoding.UTF8);
			}
			if (str == null) {
				showRedTip("编码转换失败");
				return;
			}
			tb.Text = str;
		}
		private void btnSendData_Click(object sender, EventArgs e) {
			if (tbSend.Text.Length == 0) {
				showRedTip("请输入传输内容");
				return;
			}
			byte[] data = null;
			bool result = false;
			if(cfg.send_encode=="ascii"){
				string str = getEscapeString(tbSend.Text);
				if (str == null)
					return;
				data = System.Text.Encoding.GetEncoding("GBK").GetBytes(str);
			}else if(cfg.send_encode=="utf8"){
				string str = getEscapeString(tbSend.Text);
				if (str == null)
					return;
				data = System.Text.Encoding.UTF8.GetBytes(str);
			} else if (cfg.send_encode == "hex") {
				string error;
				data = hexToByte(tbSend.Text,out error);
				if (error != null) {
					showRedTip(error);
					return;
				}
			} else {
				showRedTip("选择编码方式");
				return;
			}
			if (curMode == TransferMode.Serial) {
				result = sendSerialPortData(data, 0, data.Length);
			} else if (curMode == TransferMode.UDP) {
				result = sendUDPData(data, 0, data.Length);
			} else {
				showRedTip("选择传输方式：串口、UDP、TCP服务器、TCP客户端");
				return;
			}
			if (!result) {
				return;
			}
			showSendCount(data.Length);
			saveHistoryData();
		}
		private void historyDataBox_SelectedIndexChanged(object sender, EventArgs e) {
			if(historyDataBox.SelectedItems.Count>0){
				string data = historyDataBox.SelectedItems[0].SubItems[1].Text;
				string name = historyDataBox.SelectedItems[0].Text;
				sendNameBox.Text = name;
				tbSend.Text = data;
			}
		}
		private void btnUpData_Click(object sender, EventArgs e) {
			if (historyDataBox.SelectedItems.Count < 1) {
				showRedTip("需要选择一个调整项目");
				return;
			}
			ListViewItem lvi = historyDataBox.SelectedItems[0];
			if (lvi.Index == 0) {
				showRedTip("项已经在最顶部");
				return;
			}
			int index = lvi.Index; //一旦lvi被移除，Index属性就会被置为-1，保存这个索引值
			historyDataBox.BeginUpdate();
			historyDataBox.Items.RemoveAt(index);
			historyDataBox.Items.Insert(index - 1,lvi);
			historyDataBox.EndUpdate();

			SendDataStruct sd = sds.dataList[index];
			sds.dataList.RemoveAt(index);
			sds.dataList.Insert(index - 1, sd);
			sds.Save();
		}
		private void btnDownData_Click(object sender, EventArgs e) {
			if (historyDataBox.SelectedItems.Count < 1) {
				showRedTip("需要选择一个调整项目");
				return;
			}
			ListViewItem lvi = historyDataBox.SelectedItems[0];
			if (lvi.Index == historyDataBox.Items.Count - 1) {
				showRedTip("项已经在最底部");
				return;
			}
			int index = lvi.Index; //一旦lvi被移除，Index属性就会被置为-1，保存这个索引值
			historyDataBox.BeginUpdate();
			historyDataBox.Items.RemoveAt(index);
			historyDataBox.Items.Insert(index + 1, lvi);
			historyDataBox.EndUpdate();

			SendDataStruct sd = sds.dataList[index];
			sds.dataList.RemoveAt(index);
			sds.dataList.Insert(index + 1, sd);
			sds.Save();
		}
		private void btnDeleteData_Click(object sender, EventArgs e) {
			if (historyDataBox.SelectedItems.Count < 1) {
				showRedTip("选择一个要删除项目");
				return;
			}
			int index = historyDataBox.SelectedItems[0].Index;
			historyDataBox.BeginUpdate();
			historyDataBox.Items.RemoveAt(index);
			historyDataBox.EndUpdate();

			sds.dataList.RemoveAt(index);
			sds.Save();
		}
		private void btnSaveData_Click(object sender, EventArgs e) {
			saveHistoryData();
		}
		private void btnStartSerial_Click(object sender, EventArgs e) {
			if (btnStartSerial.ImageIndex == 0) {
				open_Serial();
			} else {
				close_Serial();
			}
		}
		private void cbEscape_CheckedChanged(object sender, EventArgs e) {
			cfg.use_escape = cbEscape.Checked;
			cfg.Save();
		}
		private void cbJs_SelectedIndexChanged(object sender, EventArgs e) {
			cfg.recv_js = cbJs.Text;
			cfg.Save();
			loadJsContent();
		}
		long lastLoadTime = 0;
		private void loadJsContent() {
			if (DateTime.Now.Ticks - lastLoadTime < 10000) {//小于一毫秒跳过
				return;
			}
			if (cfg.recv_js == "")
				return;
			string path = ".\\js\\" + cfg.recv_js;
			FileStream fs = null;
			try {
				fs = new FileStream(path, FileMode.Open);
				//防止文件太大（16M）
				if (fs.Length > 0x1000000) {
					fs.Close();
					return;
				}
				byte[] data = new byte[fs.Length];
				fs.Seek(0, SeekOrigin.Begin);
				fs.Read(data, 0, data.Length);
				recvJs = System.Text.Encoding.UTF8.GetString(data);
				fs.Close();
			} catch (IOException err) {
				showRedTip(err.ToString());
			}
			lastLoadTime = DateTime.Now.Ticks;
		}
		private void fsWatcher_Changed(object sender, FileSystemEventArgs e) {
			Debug.Print("changed:" + e.Name);
			if (e.ChangeType == WatcherChangeTypes.Changed && e.Name.ToLower() == cfg.recv_js.ToLower()) {
				loadJsContent();
			}
		}
		private void fsWatcher_Renamed(object sender, RenamedEventArgs e) {
			Debug.Print("renamed:" + e.Name);
			if (e.ChangeType == WatcherChangeTypes.Renamed) {
				int index = cbJs.Items.IndexOf(e.OldName);
				if (index != -1) {
					cbJs.Items[index] = e.Name;
				} else {
					cbJs.Items.Add(e.Name);
				}
			}
		}
		private void fsWatcher_Created(object sender, FileSystemEventArgs e) {
			int index = cbJs.Items.IndexOf(e.Name);
			if (index == -1) {
				cbJs.Items.Add(e.Name);
			}
			Debug.Print("create:" + e.Name);
		}
		private void fsWatcher_Deleted(object sender, FileSystemEventArgs e) {
			int index = cbJs.Items.IndexOf(e.Name);
			if (index != -1) {
				cbJs.Items.RemoveAt(index);
				cfg.recv_js = "";
				recvJs = "";
			}
			Debug.Print("delete:" + e.Name);
		}
		private void tbPackDuration_TextChanged(object sender, EventArgs e) {
			int ms = 0;
			if (int.TryParse(tbPackDuration.Text,out ms)) {
				cfg.pack_duration = ms;
				cfg.Save();
			}
		}
		private void tbPackDuration_KeyPress(object sender, KeyPressEventArgs e) {
			if (Char.IsNumber(e.KeyChar) || e.KeyChar == 8) {
				e.Handled = false;
			} else {
				e.Handled = true;
			}
		}
		private void tabMode_SelectedIndexChanged(object sender, EventArgs e) {
			setTransferMode();
			saveConfig();
		}
		private void cbUdpClientIP_SelectedIndexChanged(object sender, EventArgs e) {
			cfg.select_udp_client_ip = cbUdpClientIP.Text;
			saveConfig();
		}
		private void cbUdpClientPort_SelectedIndexChanged(object sender, EventArgs e) {
			cfg.select_udp_client_port = cbUdpClientPort.Text;
			saveConfig();
		}
		private void btnRecvHexToStr_Click(object sender, EventArgs e) {
			tbHexToStr(tbRecv);
		}
		private void btnRecvStrToHex_Click(object sender, EventArgs e) {
			tbStrToHex(tbRecv);
		}
		private void btnSendHexToStr_Click(object sender, EventArgs e) {
			tbHexToStr(tbSend);
		}
		private void btnSendStrToHex_Click(object sender, EventArgs e) {
			tbStrToHex(tbSend);
		}
		#endregion

		#region Test
		public class SystemConsole {
			public SystemConsole() {
			}

			public void Print(string iString) {
				Console.WriteLine(iString);
			}
		}
		private void 测试_Click(object sender, EventArgs e) {
			packTimer.Enabled = !packTimer.Enabled;
		}
		private void js_test(){
			using (JavascriptContext context = new JavascriptContext()) {

				// Setting external parameters for the context
				context.SetParameter("console", new SystemConsole());
				context.SetParameter("message", "Hello World !");
				context.SetParameter("number", 1);

				// Script
				string script = @"
        var i;
        for (i = 0; i < 5; i++)
            console.Print(message + ' (' + i + j')');
        number += i;
    ";
				try {
					// Running the script
					context.Run(script);
				} catch (JavascriptException je) {
					string msg = je.Message;
					msg += "\r\nLine: " + je.Line;
					msg += "\r\nColum: " + je.StartColumn + " - " + je.EndColumn;
					msg += "\r\n文件:" + je.Source;
					MessageBox.Show(msg);
				}

				// Getting a parameter
				Console.WriteLine("number: " + context.GetParameter("number"));
			}
		}
		#endregion

	}
}
