namespace SocketSerialTools {
	partial class TransferForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferForm));
			this.ofDlg = new System.Windows.Forms.OpenFileDialog();
			this.sfDlg = new System.Windows.Forms.SaveFileDialog();
			this.cbBits = new System.Windows.Forms.ComboBox();
			this.cbCom = new System.Windows.Forms.ComboBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cbEscape = new System.Windows.Forms.CheckBox();
			this.btnSaveData = new System.Windows.Forms.Button();
			this.btnDeleteData = new System.Windows.Forms.Button();
			this.btnDownData = new System.Windows.Forms.Button();
			this.btnUpData = new System.Windows.Forms.Button();
			this.historyDataBox = new System.Windows.Forms.ListView();
			this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.sendNameBox = new System.Windows.Forms.TextBox();
			this.btnSendData = new System.Windows.Forms.Button();
			this.srbGbk = new System.Windows.Forms.RadioButton();
			this.srbUtf8 = new System.Windows.Forms.RadioButton();
			this.btnClearSend = new System.Windows.Forms.Button();
			this.tbSend = new System.Windows.Forms.TextBox();
			this.srbHex = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.测试 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.tbPackDuration = new System.Windows.Forms.TextBox();
			this.jsLabel = new System.Windows.Forms.Label();
			this.cbJs = new System.Windows.Forms.ComboBox();
			this.rbGbk = new System.Windows.Forms.RadioButton();
			this.rbUtf8 = new System.Windows.Forms.RadioButton();
			this.rbHex = new System.Windows.Forms.RadioButton();
			this.btnClearRecv = new System.Windows.Forms.Button();
			this.tbRecv = new System.Windows.Forms.TextBox();
			this.confList = new System.Windows.Forms.ListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnNew = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnCopy = new System.Windows.Forms.Button();
			this.serialPort = new System.IO.Ports.SerialPort(this.components);
			this.timerRefreshSerialPort = new System.Windows.Forms.Timer(this.components);
			this.infoBox = new System.Windows.Forms.ToolStripStatusLabel();
			this.recvInfoBox = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.sendInfoBox = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btnStartSerial = new System.Windows.Forms.Button();
			this.pngList = new System.Windows.Forms.ImageList(this.components);
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.cbUdpClientIP = new System.Windows.Forms.ComboBox();
			this.btnStartUDPServ = new System.Windows.Forms.Button();
			this.fsWatcher = new System.IO.FileSystemWatcher();
			this.tabMode = new System.Windows.Forms.TabControl();
			this.tabSerial = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.tabUdpClient = new System.Windows.Forms.TabPage();
			this.label12 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.cbUdpClientPort = new System.Windows.Forms.ComboBox();
			this.tabTcpServ = new System.Windows.Forms.TabPage();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.tabTcpClient = new System.Windows.Forms.TabPage();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.comboBox5 = new System.Windows.Forms.ComboBox();
			this.comboBox6 = new System.Windows.Forms.ComboBox();
			this.btnSendHexToStr = new System.Windows.Forms.Button();
			this.btnRecvHexToStr = new System.Windows.Forms.Button();
			this.btnRecvStrToHex = new System.Windows.Forms.Button();
			this.btnSendStrToHex = new System.Windows.Forms.Button();
			this.groupBox4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fsWatcher)).BeginInit();
			this.tabMode.SuspendLayout();
			this.tabSerial.SuspendLayout();
			this.tabUdpClient.SuspendLayout();
			this.tabTcpServ.SuspendLayout();
			this.tabTcpClient.SuspendLayout();
			this.SuspendLayout();
			// 
			// ofDlg
			// 
			this.ofDlg.DefaultExt = "lay";
			this.ofDlg.Filter = "配置文件|*.lay";
			this.ofDlg.RestoreDirectory = true;
			// 
			// sfDlg
			// 
			this.sfDlg.DefaultExt = "lay";
			this.sfDlg.Filter = "配置文件|*.lay";
			this.sfDlg.RestoreDirectory = true;
			// 
			// cbBits
			// 
			this.cbBits.FormattingEnabled = true;
			this.cbBits.Location = new System.Drawing.Point(81, 29);
			this.cbBits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cbBits.Name = "cbBits";
			this.cbBits.Size = new System.Drawing.Size(212, 23);
			this.cbBits.TabIndex = 3;
			// 
			// cbCom
			// 
			this.cbCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCom.DropDownWidth = 160;
			this.cbCom.FormattingEnabled = true;
			this.cbCom.Location = new System.Drawing.Point(360, 29);
			this.cbCom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cbCom.Name = "cbCom";
			this.cbCom.Size = new System.Drawing.Size(721, 23);
			this.cbCom.TabIndex = 1;
			this.cbCom.SelectedIndexChanged += new System.EventHandler(this.cbCom_SelectedIndexChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.btnSendStrToHex);
			this.groupBox4.Controls.Add(this.btnSendHexToStr);
			this.groupBox4.Controls.Add(this.cbEscape);
			this.groupBox4.Controls.Add(this.btnSaveData);
			this.groupBox4.Controls.Add(this.btnDeleteData);
			this.groupBox4.Controls.Add(this.btnDownData);
			this.groupBox4.Controls.Add(this.btnUpData);
			this.groupBox4.Controls.Add(this.historyDataBox);
			this.groupBox4.Controls.Add(this.sendNameBox);
			this.groupBox4.Controls.Add(this.btnSendData);
			this.groupBox4.Controls.Add(this.srbGbk);
			this.groupBox4.Controls.Add(this.srbUtf8);
			this.groupBox4.Controls.Add(this.btnClearSend);
			this.groupBox4.Controls.Add(this.tbSend);
			this.groupBox4.Controls.Add(this.srbHex);
			this.groupBox4.Location = new System.Drawing.Point(360, 441);
			this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox4.Size = new System.Drawing.Size(888, 478);
			this.groupBox4.TabIndex = 8;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "发送数据";
			// 
			// cbEscape
			// 
			this.cbEscape.AutoSize = true;
			this.cbEscape.Location = new System.Drawing.Point(144, 35);
			this.cbEscape.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cbEscape.Name = "cbEscape";
			this.cbEscape.Size = new System.Drawing.Size(101, 19);
			this.cbEscape.TabIndex = 14;
			this.cbEscape.Text = "使用转义符";
			this.cbEscape.UseVisualStyleBackColor = true;
			this.cbEscape.CheckedChanged += new System.EventHandler(this.cbEscape_CheckedChanged);
			// 
			// btnSaveData
			// 
			this.btnSaveData.ForeColor = System.Drawing.Color.Green;
			this.btnSaveData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSaveData.Location = new System.Drawing.Point(781, 68);
			this.btnSaveData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnSaveData.Name = "btnSaveData";
			this.btnSaveData.Size = new System.Drawing.Size(100, 29);
			this.btnSaveData.TabIndex = 13;
			this.btnSaveData.Text = "保存";
			this.btnSaveData.UseVisualStyleBackColor = true;
			this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
			// 
			// btnDeleteData
			// 
			this.btnDeleteData.ForeColor = System.Drawing.Color.Red;
			this.btnDeleteData.Location = new System.Drawing.Point(780, 429);
			this.btnDeleteData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnDeleteData.Name = "btnDeleteData";
			this.btnDeleteData.Size = new System.Drawing.Size(100, 29);
			this.btnDeleteData.TabIndex = 12;
			this.btnDeleteData.Text = "删除";
			this.btnDeleteData.UseVisualStyleBackColor = true;
			this.btnDeleteData.Click += new System.EventHandler(this.btnDeleteData_Click);
			// 
			// btnDownData
			// 
			this.btnDownData.ForeColor = System.Drawing.Color.LightSeaGreen;
			this.btnDownData.Location = new System.Drawing.Point(783, 334);
			this.btnDownData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnDownData.Name = "btnDownData";
			this.btnDownData.Size = new System.Drawing.Size(100, 29);
			this.btnDownData.TabIndex = 11;
			this.btnDownData.Text = "下移";
			this.btnDownData.UseVisualStyleBackColor = true;
			this.btnDownData.Click += new System.EventHandler(this.btnDownData_Click);
			// 
			// btnUpData
			// 
			this.btnUpData.ForeColor = System.Drawing.Color.LightSeaGreen;
			this.btnUpData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnUpData.Location = new System.Drawing.Point(781, 298);
			this.btnUpData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnUpData.Name = "btnUpData";
			this.btnUpData.Size = new System.Drawing.Size(100, 29);
			this.btnUpData.TabIndex = 10;
			this.btnUpData.Text = "上移";
			this.btnUpData.UseVisualStyleBackColor = true;
			this.btnUpData.Click += new System.EventHandler(this.btnUpData_Click);
			// 
			// historyDataBox
			// 
			this.historyDataBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colData});
			this.historyDataBox.FullRowSelect = true;
			this.historyDataBox.GridLines = true;
			this.historyDataBox.HideSelection = false;
			this.historyDataBox.Location = new System.Drawing.Point(21, 298);
			this.historyDataBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.historyDataBox.Name = "historyDataBox";
			this.historyDataBox.Size = new System.Drawing.Size(737, 159);
			this.historyDataBox.TabIndex = 9;
			this.historyDataBox.UseCompatibleStateImageBehavior = false;
			this.historyDataBox.View = System.Windows.Forms.View.Details;
			this.historyDataBox.SelectedIndexChanged += new System.EventHandler(this.historyDataBox_SelectedIndexChanged);
			// 
			// colName
			// 
			this.colName.Text = "名称";
			this.colName.Width = 100;
			// 
			// colData
			// 
			this.colData.Text = "数据";
			this.colData.Width = 235;
			// 
			// sendNameBox
			// 
			this.sendNameBox.Location = new System.Drawing.Point(21, 66);
			this.sendNameBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.sendNameBox.Name = "sendNameBox";
			this.sendNameBox.Size = new System.Drawing.Size(199, 25);
			this.sendNameBox.TabIndex = 8;
			this.toolTip1.SetToolTip(this.sendNameBox, "设置当前数据的名称");
			// 
			// btnSendData
			// 
			this.btnSendData.ForeColor = System.Drawing.Color.Green;
			this.btnSendData.Location = new System.Drawing.Point(781, 30);
			this.btnSendData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnSendData.Name = "btnSendData";
			this.btnSendData.Size = new System.Drawing.Size(100, 29);
			this.btnSendData.TabIndex = 6;
			this.btnSendData.Text = "发送";
			this.btnSendData.UseVisualStyleBackColor = true;
			this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
			// 
			// srbGbk
			// 
			this.srbGbk.AutoSize = true;
			this.srbGbk.Location = new System.Drawing.Point(625, 72);
			this.srbGbk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.srbGbk.Name = "srbGbk";
			this.srbGbk.Size = new System.Drawing.Size(65, 19);
			this.srbGbk.TabIndex = 4;
			this.srbGbk.TabStop = true;
			this.srbGbk.Text = "ASCII";
			this.srbGbk.UseVisualStyleBackColor = true;
			this.srbGbk.CheckedChanged += new System.EventHandler(this.sendEncode_Changed);
			// 
			// srbUtf8
			// 
			this.srbUtf8.AutoSize = true;
			this.srbUtf8.Location = new System.Drawing.Point(700, 72);
			this.srbUtf8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.srbUtf8.Name = "srbUtf8";
			this.srbUtf8.Size = new System.Drawing.Size(57, 19);
			this.srbUtf8.TabIndex = 3;
			this.srbUtf8.TabStop = true;
			this.srbUtf8.Text = "UTF8";
			this.srbUtf8.UseVisualStyleBackColor = true;
			this.srbUtf8.CheckedChanged += new System.EventHandler(this.sendEncode_Changed);
			// 
			// btnClearSend
			// 
			this.btnClearSend.Location = new System.Drawing.Point(21, 30);
			this.btnClearSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnClearSend.Name = "btnClearSend";
			this.btnClearSend.Size = new System.Drawing.Size(100, 29);
			this.btnClearSend.TabIndex = 1;
			this.btnClearSend.Text = "清空";
			this.btnClearSend.UseVisualStyleBackColor = true;
			this.btnClearSend.Click += new System.EventHandler(this.btnClearSend_Click);
			// 
			// tbSend
			// 
			this.tbSend.Location = new System.Drawing.Point(21, 98);
			this.tbSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tbSend.Multiline = true;
			this.tbSend.Name = "tbSend";
			this.tbSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbSend.Size = new System.Drawing.Size(737, 192);
			this.tbSend.TabIndex = 0;
			// 
			// srbHex
			// 
			this.srbHex.AutoSize = true;
			this.srbHex.Location = new System.Drawing.Point(563, 72);
			this.srbHex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.srbHex.Name = "srbHex";
			this.srbHex.Size = new System.Drawing.Size(49, 19);
			this.srbHex.TabIndex = 2;
			this.srbHex.TabStop = true;
			this.srbHex.Text = "HEX";
			this.srbHex.UseVisualStyleBackColor = true;
			this.srbHex.CheckedChanged += new System.EventHandler(this.sendEncode_Changed);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnRecvStrToHex);
			this.groupBox2.Controls.Add(this.btnRecvHexToStr);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.tbPackDuration);
			this.groupBox2.Controls.Add(this.jsLabel);
			this.groupBox2.Controls.Add(this.cbJs);
			this.groupBox2.Controls.Add(this.rbGbk);
			this.groupBox2.Controls.Add(this.rbUtf8);
			this.groupBox2.Controls.Add(this.rbHex);
			this.groupBox2.Controls.Add(this.btnClearRecv);
			this.groupBox2.Controls.Add(this.tbRecv);
			this.groupBox2.Location = new System.Drawing.Point(360, 169);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox2.Size = new System.Drawing.Size(888, 256);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "接收数据";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(853, 95);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(23, 15);
			this.label3.TabIndex = 9;
			this.label3.Text = "ms";
			// 
			// 测试
			// 
			this.测试.Location = new System.Drawing.Point(1143, 431);
			this.测试.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.测试.Name = "测试";
			this.测试.Size = new System.Drawing.Size(75, 22);
			this.测试.TabIndex = 3;
			this.测试.Text = "btnTest";
			this.测试.UseVisualStyleBackColor = true;
			this.测试.Visible = false;
			this.测试.Click += new System.EventHandler(this.测试_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(780, 58);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 15);
			this.label1.TabIndex = 8;
			this.label1.Text = "分包间隔";
			this.toolTip1.SetToolTip(this.label1, "每次接收的数据自然分包不一定和发送的时候相同，\r\n速率较慢的时候，接收端可能分多次接收一个数据包，\r\n设置一个时间，来定义间隔多少毫秒算一个数据包");
			// 
			// tbPackDuration
			// 
			this.tbPackDuration.Location = new System.Drawing.Point(781, 90);
			this.tbPackDuration.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tbPackDuration.Name = "tbPackDuration";
			this.tbPackDuration.Size = new System.Drawing.Size(68, 25);
			this.tbPackDuration.TabIndex = 7;
			this.tbPackDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbPackDuration.TextChanged += new System.EventHandler(this.tbPackDuration_TextChanged);
			this.tbPackDuration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPackDuration_KeyPress);
			// 
			// jsLabel
			// 
			this.jsLabel.AutoSize = true;
			this.jsLabel.Location = new System.Drawing.Point(161, 26);
			this.jsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.jsLabel.Name = "jsLabel";
			this.jsLabel.Size = new System.Drawing.Size(95, 15);
			this.jsLabel.TabIndex = 6;
			this.jsLabel.Text = "JavaScript:";
			// 
			// cbJs
			// 
			this.cbJs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbJs.FormattingEnabled = true;
			this.cbJs.Items.AddRange(new object[] {
            ""});
			this.cbJs.Location = new System.Drawing.Point(264, 22);
			this.cbJs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cbJs.Name = "cbJs";
			this.cbJs.Size = new System.Drawing.Size(239, 23);
			this.cbJs.TabIndex = 5;
			this.cbJs.SelectedIndexChanged += new System.EventHandler(this.cbJs_SelectedIndexChanged);
			// 
			// rbGbk
			// 
			this.rbGbk.AutoSize = true;
			this.rbGbk.Location = new System.Drawing.Point(624, 24);
			this.rbGbk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.rbGbk.Name = "rbGbk";
			this.rbGbk.Size = new System.Drawing.Size(65, 19);
			this.rbGbk.TabIndex = 4;
			this.rbGbk.TabStop = true;
			this.rbGbk.Text = "ASCII";
			this.rbGbk.UseVisualStyleBackColor = true;
			this.rbGbk.CheckedChanged += new System.EventHandler(this.recvEncode_Changed);
			// 
			// rbUtf8
			// 
			this.rbUtf8.AutoSize = true;
			this.rbUtf8.Location = new System.Drawing.Point(704, 24);
			this.rbUtf8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.rbUtf8.Name = "rbUtf8";
			this.rbUtf8.Size = new System.Drawing.Size(57, 19);
			this.rbUtf8.TabIndex = 3;
			this.rbUtf8.TabStop = true;
			this.rbUtf8.Text = "UTF8";
			this.rbUtf8.UseVisualStyleBackColor = true;
			this.rbUtf8.CheckedChanged += new System.EventHandler(this.recvEncode_Changed);
			// 
			// rbHex
			// 
			this.rbHex.AutoSize = true;
			this.rbHex.Location = new System.Drawing.Point(561, 25);
			this.rbHex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.rbHex.Name = "rbHex";
			this.rbHex.Size = new System.Drawing.Size(49, 19);
			this.rbHex.TabIndex = 2;
			this.rbHex.TabStop = true;
			this.rbHex.Text = "HEX";
			this.rbHex.UseVisualStyleBackColor = true;
			this.rbHex.CheckedChanged += new System.EventHandler(this.recvEncode_Changed);
			// 
			// btnClearRecv
			// 
			this.btnClearRecv.Location = new System.Drawing.Point(21, 20);
			this.btnClearRecv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnClearRecv.Name = "btnClearRecv";
			this.btnClearRecv.Size = new System.Drawing.Size(100, 29);
			this.btnClearRecv.TabIndex = 1;
			this.btnClearRecv.Text = "清空";
			this.btnClearRecv.UseVisualStyleBackColor = true;
			this.btnClearRecv.Click += new System.EventHandler(this.btnClearRecv_Click);
			// 
			// tbRecv
			// 
			this.tbRecv.Location = new System.Drawing.Point(21, 58);
			this.tbRecv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tbRecv.Multiline = true;
			this.tbRecv.Name = "tbRecv";
			this.tbRecv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbRecv.Size = new System.Drawing.Size(737, 174);
			this.tbRecv.TabIndex = 0;
			// 
			// confList
			// 
			this.confList.FormattingEnabled = true;
			this.confList.ItemHeight = 15;
			this.confList.Location = new System.Drawing.Point(17, 190);
			this.confList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.confList.Name = "confList";
			this.confList.Size = new System.Drawing.Size(281, 409);
			this.confList.TabIndex = 10;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnNew);
			this.groupBox1.Controls.Add(this.btnDelete);
			this.groupBox1.Controls.Add(this.btnEdit);
			this.groupBox1.Controls.Add(this.btnLoad);
			this.groupBox1.Controls.Add(this.btnCopy);
			this.groupBox1.Controls.Add(this.confList);
			this.groupBox1.Location = new System.Drawing.Point(16, 169);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox1.Size = new System.Drawing.Size(315, 620);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "保存的配置";
			// 
			// btnNew
			// 
			this.btnNew.Location = new System.Drawing.Point(19, 38);
			this.btnNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(281, 38);
			this.btnNew.TabIndex = 15;
			this.btnNew.Text = "新建";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(168, 138);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(135, 38);
			this.btnDelete.TabIndex = 14;
			this.btnDelete.Text = "删除";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(19, 138);
			this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(135, 38);
			this.btnEdit.TabIndex = 13;
			this.btnEdit.Text = "重命名";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(167, 88);
			this.btnLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(135, 38);
			this.btnLoad.TabIndex = 12;
			this.btnLoad.Text = "加载";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(17, 88);
			this.btnCopy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(135, 38);
			this.btnCopy.TabIndex = 11;
			this.btnCopy.Text = "复制";
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// serialPort
			// 
			this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
			// 
			// timerRefreshSerialPort
			// 
			this.timerRefreshSerialPort.Enabled = true;
			this.timerRefreshSerialPort.Interval = 5000;
			this.timerRefreshSerialPort.Tick += new System.EventHandler(this.timerRefreshSerialPort_Tick);
			// 
			// infoBox
			// 
			this.infoBox.AutoSize = false;
			this.infoBox.Name = "infoBox";
			this.infoBox.Size = new System.Drawing.Size(400, 17);
			this.infoBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// recvInfoBox
			// 
			this.recvInfoBox.AutoSize = false;
			this.recvInfoBox.ForeColor = System.Drawing.Color.Green;
			this.recvInfoBox.Name = "recvInfoBox";
			this.recvInfoBox.Size = new System.Drawing.Size(160, 17);
			this.recvInfoBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoBox,
            this.recvInfoBox,
            this.sendInfoBox});
			this.statusStrip1.Location = new System.Drawing.Point(0, 936);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
			this.statusStrip1.Size = new System.Drawing.Size(1264, 22);
			this.statusStrip1.TabIndex = 12;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// sendInfoBox
			// 
			this.sendInfoBox.AutoSize = false;
			this.sendInfoBox.ForeColor = System.Drawing.Color.LightSeaGreen;
			this.sendInfoBox.Name = "sendInfoBox";
			this.sendInfoBox.Size = new System.Drawing.Size(160, 17);
			this.sendInfoBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnStartSerial
			// 
			this.btnStartSerial.FlatAppearance.BorderSize = 0;
			this.btnStartSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnStartSerial.ImageIndex = 0;
			this.btnStartSerial.ImageList = this.pngList;
			this.btnStartSerial.Location = new System.Drawing.Point(1119, 20);
			this.btnStartSerial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnStartSerial.Name = "btnStartSerial";
			this.btnStartSerial.Size = new System.Drawing.Size(41, 40);
			this.btnStartSerial.TabIndex = 2;
			this.toolTip1.SetToolTip(this.btnStartSerial, "打开串口");
			this.btnStartSerial.UseVisualStyleBackColor = true;
			this.btnStartSerial.Click += new System.EventHandler(this.btnStartSerial_Click);
			// 
			// pngList
			// 
			this.pngList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("pngList.ImageStream")));
			this.pngList.TransparentColor = System.Drawing.Color.Transparent;
			this.pngList.Images.SetKeyName(0, "play.png");
			this.pngList.Images.SetKeyName(1, "stop.png");
			// 
			// button2
			// 
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.ImageIndex = 0;
			this.button2.ImageList = this.pngList;
			this.button2.Location = new System.Drawing.Point(751, 18);
			this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(41, 40);
			this.button2.TabIndex = 13;
			this.toolTip1.SetToolTip(this.button2, "打开串口");
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.FlatAppearance.BorderSize = 0;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.ImageIndex = 0;
			this.button3.ImageList = this.pngList;
			this.button3.Location = new System.Drawing.Point(751, 22);
			this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(41, 40);
			this.button3.TabIndex = 13;
			this.toolTip1.SetToolTip(this.button3, "打开串口");
			this.button3.UseVisualStyleBackColor = true;
			// 
			// cbUdpClientIP
			// 
			this.cbUdpClientIP.FormattingEnabled = true;
			this.cbUdpClientIP.Items.AddRange(new object[] {
            "255.255.255.255",
            "127.0.0.1"});
			this.cbUdpClientIP.Location = new System.Drawing.Point(73, 30);
			this.cbUdpClientIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cbUdpClientIP.Name = "cbUdpClientIP";
			this.cbUdpClientIP.Size = new System.Drawing.Size(212, 23);
			this.cbUdpClientIP.TabIndex = 10;
			this.toolTip1.SetToolTip(this.cbUdpClientIP, "255.255.255.255表示广播");
			this.cbUdpClientIP.SelectedIndexChanged += new System.EventHandler(this.cbUdpClientIP_SelectedIndexChanged);
			// 
			// btnStartUDPServ
			// 
			this.btnStartUDPServ.FlatAppearance.BorderSize = 0;
			this.btnStartUDPServ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnStartUDPServ.ImageIndex = 0;
			this.btnStartUDPServ.ImageList = this.pngList;
			this.btnStartUDPServ.Location = new System.Drawing.Point(656, 21);
			this.btnStartUDPServ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnStartUDPServ.Name = "btnStartUDPServ";
			this.btnStartUDPServ.Size = new System.Drawing.Size(41, 40);
			this.btnStartUDPServ.TabIndex = 14;
			this.toolTip1.SetToolTip(this.btnStartUDPServ, "启动接收");
			this.btnStartUDPServ.UseVisualStyleBackColor = true;
			this.btnStartUDPServ.Click += new System.EventHandler(this.btnStartUDPServ_Click);
			// 
			// fsWatcher
			// 
			this.fsWatcher.EnableRaisingEvents = true;
			this.fsWatcher.Filter = "*.js";
			this.fsWatcher.NotifyFilter = ((System.IO.NotifyFilters)((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.LastWrite)));
			this.fsWatcher.Path = ".\\js";
			this.fsWatcher.SynchronizingObject = this;
			this.fsWatcher.Changed += new System.IO.FileSystemEventHandler(this.fsWatcher_Changed);
			this.fsWatcher.Created += new System.IO.FileSystemEventHandler(this.fsWatcher_Created);
			this.fsWatcher.Deleted += new System.IO.FileSystemEventHandler(this.fsWatcher_Deleted);
			this.fsWatcher.Renamed += new System.IO.RenamedEventHandler(this.fsWatcher_Renamed);
			// 
			// tabMode
			// 
			this.tabMode.Controls.Add(this.tabSerial);
			this.tabMode.Controls.Add(this.tabUdpClient);
			this.tabMode.Controls.Add(this.tabTcpServ);
			this.tabMode.Controls.Add(this.tabTcpClient);
			this.tabMode.Location = new System.Drawing.Point(16, 15);
			this.tabMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabMode.Name = "tabMode";
			this.tabMode.SelectedIndex = 0;
			this.tabMode.Size = new System.Drawing.Size(1232, 126);
			this.tabMode.TabIndex = 14;
			this.tabMode.SelectedIndexChanged += new System.EventHandler(this.tabMode_SelectedIndexChanged);
			// 
			// tabSerial
			// 
			this.tabSerial.Controls.Add(this.cbCom);
			this.tabSerial.Controls.Add(this.label2);
			this.tabSerial.Controls.Add(this.btnStartSerial);
			this.tabSerial.Controls.Add(this.cbBits);
			this.tabSerial.Location = new System.Drawing.Point(4, 25);
			this.tabSerial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabSerial.Name = "tabSerial";
			this.tabSerial.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabSerial.Size = new System.Drawing.Size(1224, 97);
			this.tabSerial.TabIndex = 0;
			this.tabSerial.Text = "串口模式";
			this.tabSerial.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "波特率";
			// 
			// tabUdpClient
			// 
			this.tabUdpClient.Controls.Add(this.btnStartUDPServ);
			this.tabUdpClient.Controls.Add(this.label12);
			this.tabUdpClient.Controls.Add(this.label6);
			this.tabUdpClient.Controls.Add(this.label7);
			this.tabUdpClient.Controls.Add(this.cbUdpClientIP);
			this.tabUdpClient.Controls.Add(this.cbUdpClientPort);
			this.tabUdpClient.Location = new System.Drawing.Point(4, 25);
			this.tabUdpClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabUdpClient.Name = "tabUdpClient";
			this.tabUdpClient.Size = new System.Drawing.Size(1224, 97);
			this.tabUdpClient.TabIndex = 2;
			this.tabUdpClient.Text = "UDP通讯";
			this.tabUdpClient.UseVisualStyleBackColor = true;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.ForeColor = System.Drawing.Color.ForestGreen;
			this.label12.Location = new System.Drawing.Point(767, 18);
			this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(409, 60);
			this.label12.TabIndex = 13;
			this.label12.Text = "UDP 通讯不分客户端和服务器，所有 UDP 组件都是平等的，\r\n不需要连接，选好服务器地址和端口后即可发送/接收数\r\n据。作为服务器时，IP 地址参数无效，默认" +
    "接收任何 IP\r\n的 UDP 数据";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(344, 34);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 15);
			this.label6.TabIndex = 12;
			this.label6.Text = "端口";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(11, 34);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 15);
			this.label7.TabIndex = 11;
			this.label7.Text = "目的IP";
			// 
			// cbUdpClientPort
			// 
			this.cbUdpClientPort.FormattingEnabled = true;
			this.cbUdpClientPort.Location = new System.Drawing.Point(411, 30);
			this.cbUdpClientPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cbUdpClientPort.Name = "cbUdpClientPort";
			this.cbUdpClientPort.Size = new System.Drawing.Size(212, 23);
			this.cbUdpClientPort.TabIndex = 9;
			this.cbUdpClientPort.SelectedIndexChanged += new System.EventHandler(this.cbUdpClientPort_SelectedIndexChanged);
			// 
			// tabTcpServ
			// 
			this.tabTcpServ.Controls.Add(this.button2);
			this.tabTcpServ.Controls.Add(this.label8);
			this.tabTcpServ.Controls.Add(this.label9);
			this.tabTcpServ.Controls.Add(this.comboBox3);
			this.tabTcpServ.Controls.Add(this.comboBox4);
			this.tabTcpServ.Location = new System.Drawing.Point(4, 25);
			this.tabTcpServ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabTcpServ.Name = "tabTcpServ";
			this.tabTcpServ.Size = new System.Drawing.Size(1224, 97);
			this.tabTcpServ.TabIndex = 3;
			this.tabTcpServ.Text = "TCP服务器";
			this.tabTcpServ.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(387, 30);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(37, 15);
			this.label8.TabIndex = 12;
			this.label8.Text = "端口";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(11, 30);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(23, 15);
			this.label9.TabIndex = 11;
			this.label9.Text = "IP";
			// 
			// comboBox3
			// 
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Items.AddRange(new object[] {
            "0.0.0.0"});
			this.comboBox3.Location = new System.Drawing.Point(81, 26);
			this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(212, 23);
			this.comboBox3.TabIndex = 10;
			// 
			// comboBox4
			// 
			this.comboBox4.FormattingEnabled = true;
			this.comboBox4.Location = new System.Drawing.Point(453, 26);
			this.comboBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(212, 23);
			this.comboBox4.TabIndex = 9;
			// 
			// tabTcpClient
			// 
			this.tabTcpClient.Controls.Add(this.button3);
			this.tabTcpClient.Controls.Add(this.label10);
			this.tabTcpClient.Controls.Add(this.label11);
			this.tabTcpClient.Controls.Add(this.comboBox5);
			this.tabTcpClient.Controls.Add(this.comboBox6);
			this.tabTcpClient.Location = new System.Drawing.Point(4, 25);
			this.tabTcpClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabTcpClient.Name = "tabTcpClient";
			this.tabTcpClient.Size = new System.Drawing.Size(1224, 97);
			this.tabTcpClient.TabIndex = 4;
			this.tabTcpClient.Text = "TCP客户端";
			this.tabTcpClient.UseVisualStyleBackColor = true;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(387, 35);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(37, 15);
			this.label10.TabIndex = 12;
			this.label10.Text = "端口";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(11, 35);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(23, 15);
			this.label11.TabIndex = 11;
			this.label11.Text = "IP";
			// 
			// comboBox5
			// 
			this.comboBox5.FormattingEnabled = true;
			this.comboBox5.Items.AddRange(new object[] {
            "0.0.0.0"});
			this.comboBox5.Location = new System.Drawing.Point(81, 31);
			this.comboBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBox5.Name = "comboBox5";
			this.comboBox5.Size = new System.Drawing.Size(212, 23);
			this.comboBox5.TabIndex = 10;
			// 
			// comboBox6
			// 
			this.comboBox6.FormattingEnabled = true;
			this.comboBox6.Location = new System.Drawing.Point(453, 31);
			this.comboBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBox6.Name = "comboBox6";
			this.comboBox6.Size = new System.Drawing.Size(212, 23);
			this.comboBox6.TabIndex = 9;
			// 
			// btnSendHexToStr
			// 
			this.btnSendHexToStr.ForeColor = System.Drawing.Color.Green;
			this.btnSendHexToStr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSendHexToStr.Location = new System.Drawing.Point(781, 161);
			this.btnSendHexToStr.Margin = new System.Windows.Forms.Padding(4);
			this.btnSendHexToStr.Name = "btnSendHexToStr";
			this.btnSendHexToStr.Size = new System.Drawing.Size(100, 29);
			this.btnSendHexToStr.TabIndex = 15;
			this.btnSendHexToStr.Text = "HEX转字串";
			this.btnSendHexToStr.UseVisualStyleBackColor = true;
			this.btnSendHexToStr.Click += new System.EventHandler(this.btnSendHexToStr_Click);
			// 
			// btnRecvHexToStr
			// 
			this.btnRecvHexToStr.ForeColor = System.Drawing.Color.Green;
			this.btnRecvHexToStr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRecvHexToStr.Location = new System.Drawing.Point(781, 147);
			this.btnRecvHexToStr.Margin = new System.Windows.Forms.Padding(4);
			this.btnRecvHexToStr.Name = "btnRecvHexToStr";
			this.btnRecvHexToStr.Size = new System.Drawing.Size(100, 29);
			this.btnRecvHexToStr.TabIndex = 16;
			this.btnRecvHexToStr.Text = "HEX转字串";
			this.btnRecvHexToStr.UseVisualStyleBackColor = true;
			this.btnRecvHexToStr.Click += new System.EventHandler(this.btnRecvHexToStr_Click);
			// 
			// btnRecvStrToHex
			// 
			this.btnRecvStrToHex.ForeColor = System.Drawing.Color.Green;
			this.btnRecvStrToHex.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRecvStrToHex.Location = new System.Drawing.Point(783, 184);
			this.btnRecvStrToHex.Margin = new System.Windows.Forms.Padding(4);
			this.btnRecvStrToHex.Name = "btnRecvStrToHex";
			this.btnRecvStrToHex.Size = new System.Drawing.Size(100, 29);
			this.btnRecvStrToHex.TabIndex = 17;
			this.btnRecvStrToHex.Text = "字串转HEX";
			this.btnRecvStrToHex.UseVisualStyleBackColor = true;
			this.btnRecvStrToHex.Click += new System.EventHandler(this.btnRecvStrToHex_Click);
			// 
			// btnSendStrToHex
			// 
			this.btnSendStrToHex.ForeColor = System.Drawing.Color.Green;
			this.btnSendStrToHex.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSendStrToHex.Location = new System.Drawing.Point(781, 198);
			this.btnSendStrToHex.Margin = new System.Windows.Forms.Padding(4);
			this.btnSendStrToHex.Name = "btnSendStrToHex";
			this.btnSendStrToHex.Size = new System.Drawing.Size(100, 29);
			this.btnSendStrToHex.TabIndex = 18;
			this.btnSendStrToHex.Text = "字串转HEX";
			this.btnSendStrToHex.UseVisualStyleBackColor = true;
			this.btnSendStrToHex.Click += new System.EventHandler(this.btnSendStrToHex_Click);
			// 
			// TransferForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1264, 958);
			this.Controls.Add(this.tabMode);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.测试);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox4);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.Name = "TransferForm";
			this.Text = "串口和网络调试工具 1.0";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TransferForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TransferForm_FormClosed);
			this.Load += new System.EventHandler(this.TransferForm_Load);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.fsWatcher)).EndInit();
			this.tabMode.ResumeLayout(false);
			this.tabSerial.ResumeLayout(false);
			this.tabSerial.PerformLayout();
			this.tabUdpClient.ResumeLayout(false);
			this.tabUdpClient.PerformLayout();
			this.tabTcpServ.ResumeLayout(false);
			this.tabTcpServ.PerformLayout();
			this.tabTcpClient.ResumeLayout(false);
			this.tabTcpClient.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog ofDlg;
		private System.Windows.Forms.SaveFileDialog sfDlg;
		private System.Windows.Forms.ComboBox cbBits;
		private System.Windows.Forms.ComboBox cbCom;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btnSendData;
		private System.Windows.Forms.RadioButton srbGbk;
		private System.Windows.Forms.RadioButton srbUtf8;
		private System.Windows.Forms.RadioButton srbHex;
		private System.Windows.Forms.Button btnClearSend;
		private System.Windows.Forms.TextBox tbSend;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rbGbk;
		private System.Windows.Forms.RadioButton rbUtf8;
		private System.Windows.Forms.RadioButton rbHex;
		private System.Windows.Forms.Button btnClearRecv;
		private System.Windows.Forms.TextBox tbRecv;
		private System.Windows.Forms.TextBox sendNameBox;
		private System.Windows.Forms.ListBox confList;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnCopy;
		private System.IO.Ports.SerialPort serialPort;
		private System.Windows.Forms.Timer timerRefreshSerialPort;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.ToolStripStatusLabel infoBox;
		private System.Windows.Forms.ToolStripStatusLabel recvInfoBox;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel sendInfoBox;
		private System.Windows.Forms.ListView historyDataBox;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ColumnHeader colData;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btnDeleteData;
		private System.Windows.Forms.Button btnDownData;
		private System.Windows.Forms.Button btnUpData;
		private System.Windows.Forms.Button btnSaveData;
		private System.Windows.Forms.ImageList pngList;
		private System.Windows.Forms.CheckBox cbEscape;
		private System.Windows.Forms.Button 测试;
		private System.Windows.Forms.Label jsLabel;
		private System.Windows.Forms.ComboBox cbJs;
		private System.IO.FileSystemWatcher fsWatcher;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbPackDuration;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabControl tabMode;
		private System.Windows.Forms.TabPage tabSerial;
		private System.Windows.Forms.TabPage tabUdpClient;
		private System.Windows.Forms.TabPage tabTcpServ;
		private System.Windows.Forms.TabPage tabTcpClient;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnStartSerial;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.ComboBox comboBox4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox comboBox5;
		private System.Windows.Forms.ComboBox comboBox6;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbUdpClientIP;
		private System.Windows.Forms.ComboBox cbUdpClientPort;
		private System.Windows.Forms.Button btnStartUDPServ;
		private System.Windows.Forms.Button btnSendHexToStr;
		private System.Windows.Forms.Button btnRecvHexToStr;
		private System.Windows.Forms.Button btnRecvStrToHex;
		private System.Windows.Forms.Button btnSendStrToHex;

    }
}

