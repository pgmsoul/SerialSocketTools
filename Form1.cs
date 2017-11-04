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

namespace SocketSerialTools {
	public partial class TransferForm : Form {
		#region variable
		private static List<TransferForm> formList = new List<TransferForm>();
		public string EditConfName;
		private Config cfg = null;
		private SendDataStorage sds = null;
		private bool initComplete = false;
		private int sumRecv = 0, sumSend = 0;
		#endregion
		
		#region SerialPort
		private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) {
			byte[] buffer = new byte[1024];
			int n = serialPort.Read(buffer, 0, 1024);
			if (cfg.recv_encode == "ascii") {
				string str = System.Text.Encoding.GetEncoding("GBK").GetString(buffer, 0, n);
				tbRecv.AppendText(str);
			} else if (cfg.recv_encode == "utf8") {
				string str = System.Text.Encoding.UTF8.GetString(buffer,0,n);
				tbRecv.AppendText(str);
			} else if (cfg.recv_encode == "hex") {
				string hex = byteToHex(buffer,n);
				tbRecv.AppendText(hex);
			}
			Debug.Print(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
			showRecvCount(n);
		}
		private void close_Serial() {
			if (serialPort.IsOpen) {
				serialPort.Close();
				btnStartSerial.ImageIndex = 0;
				showSuccessTip("串口关闭成功");
			} else {
				showRedTip("串口已经关闭");
				btnStartSerial.ImageIndex = 1;
			}
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
			serialPort.PortName = SerialPortTool.GetSerialPortByName(cbCom.Text);
			serialPort.BaudRate = baud;
			try {
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
				}
			}
			for (int i = cbCom.Items.Count - 1; i >= 0; i--) {
				string com = cbCom.Items[i].ToString();
				if (sl.IndexOf(com) == -1) {
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
				File.Copy(src,path);
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
				fi.MoveTo(path);
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
			init_Serial_List();
			int select = cbCom.Items.IndexOf(cfg.select_serial_port);
			if(select!=-1){
				cbCom.SelectedIndex = select;
			}
			for (int i = 0; i < cfg.serial_baud_rate.Count; i++) {
				cbBits.Items.Add(cfg.serial_baud_rate[i]);
			}
			cbBits.Text = "" + cfg.select_baud_rate;

			cbEscape.Checked = cfg.use_escape;

			initConfList();

			this.Text = this.Text + " - [" + c.file_name + "]";
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
		#endregion

		#region Events
		public TransferForm() {
			InitializeComponent();
			loadConfig("");
			loadData("");
			System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
		}
		public TransferForm(string conf) {
			InitializeComponent();
			loadConfig(conf);
			loadData(conf);
			initComplete = true;
			System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
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
		private void TransferForm_FormClosing(object sender, FormClosingEventArgs e) {
			close_Serial();
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
				result = sendSerialPortData(data,0,data.Length);
			}else if(cfg.send_encode=="utf8"){
				string str = getEscapeString(tbSend.Text);
				if (str == null)
					return;
				data = System.Text.Encoding.UTF8.GetBytes(str);
				result = sendSerialPortData(data, 0, data.Length);
			} else if (cfg.send_encode == "hex") {
				string error;
				data = hexToByte(tbSend.Text,out error);
				if (error != null) {
					showRedTip(error);
					return;
				}
				result = sendSerialPortData(data, 0, data.Length);
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
			using (JavascriptContext context = new JavascriptContext()) {

				// Setting external parameters for the context
				context.SetParameter("console", new SystemConsole());
				context.SetParameter("message", "Hello World !");
				context.SetParameter("number", 1);

				// Script
				string script = @"
        var i;
        for (i = 0; i < 5; i++)
            console.Print(message + ' (' + i + ')');
        number += i;
    ";

				// Running the script
				context.Run(script);

				// Getting a parameter
				Console.WriteLine("number: " + context.GetParameter("number"));
			}
		}
		#endregion
	}
}
