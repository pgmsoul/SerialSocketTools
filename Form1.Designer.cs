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
			this.configGroup = new System.Windows.Forms.GroupBox();
			this.cbBits = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
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
			this.groupBoxSerial = new System.Windows.Forms.GroupBox();
			this.测试 = new System.Windows.Forms.Button();
			this.configGroup.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.groupBoxSerial.SuspendLayout();
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
			// configGroup
			// 
			this.configGroup.Controls.Add(this.cbBits);
			this.configGroup.Controls.Add(this.label2);
			this.configGroup.Location = new System.Drawing.Point(12, 78);
			this.configGroup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.configGroup.Name = "configGroup";
			this.configGroup.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.configGroup.Size = new System.Drawing.Size(238, 70);
			this.configGroup.TabIndex = 1;
			this.configGroup.TabStop = false;
			this.configGroup.Text = "串口设置";
			// 
			// cbBits
			// 
			this.cbBits.FormattingEnabled = true;
			this.cbBits.Location = new System.Drawing.Point(66, 35);
			this.cbBits.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.cbBits.Name = "cbBits";
			this.cbBits.Size = new System.Drawing.Size(160, 20);
			this.cbBits.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 37);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "波特率";
			// 
			// cbCom
			// 
			this.cbCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCom.DropDownWidth = 160;
			this.cbCom.FormattingEnabled = true;
			this.cbCom.Location = new System.Drawing.Point(14, 27);
			this.cbCom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.cbCom.Name = "cbCom";
			this.cbCom.Size = new System.Drawing.Size(542, 20);
			this.cbCom.TabIndex = 1;
			this.cbCom.SelectedIndexChanged += new System.EventHandler(this.cbCom_SelectedIndexChanged);
			// 
			// groupBox4
			// 
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
			this.groupBox4.Location = new System.Drawing.Point(270, 307);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(464, 382);
			this.groupBox4.TabIndex = 8;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "发送数据";
			// 
			// cbEscape
			// 
			this.cbEscape.AutoSize = true;
			this.cbEscape.Location = new System.Drawing.Point(108, 28);
			this.cbEscape.Name = "cbEscape";
			this.cbEscape.Size = new System.Drawing.Size(84, 16);
			this.cbEscape.TabIndex = 14;
			this.cbEscape.Text = "使用转义符";
			this.cbEscape.UseVisualStyleBackColor = true;
			this.cbEscape.CheckedChanged += new System.EventHandler(this.cbEscape_CheckedChanged);
			// 
			// btnSaveData
			// 
			this.btnSaveData.ForeColor = System.Drawing.Color.Green;
			this.btnSaveData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSaveData.Location = new System.Drawing.Point(379, 54);
			this.btnSaveData.Name = "btnSaveData";
			this.btnSaveData.Size = new System.Drawing.Size(75, 23);
			this.btnSaveData.TabIndex = 13;
			this.btnSaveData.Text = "保存";
			this.btnSaveData.UseVisualStyleBackColor = true;
			this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
			// 
			// btnDeleteData
			// 
			this.btnDeleteData.ForeColor = System.Drawing.Color.Red;
			this.btnDeleteData.Location = new System.Drawing.Point(378, 343);
			this.btnDeleteData.Name = "btnDeleteData";
			this.btnDeleteData.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteData.TabIndex = 12;
			this.btnDeleteData.Text = "删除";
			this.btnDeleteData.UseVisualStyleBackColor = true;
			this.btnDeleteData.Click += new System.EventHandler(this.btnDeleteData_Click);
			// 
			// btnDownData
			// 
			this.btnDownData.ForeColor = System.Drawing.Color.LightSeaGreen;
			this.btnDownData.Location = new System.Drawing.Point(379, 214);
			this.btnDownData.Name = "btnDownData";
			this.btnDownData.Size = new System.Drawing.Size(75, 23);
			this.btnDownData.TabIndex = 11;
			this.btnDownData.Text = "下移";
			this.btnDownData.UseVisualStyleBackColor = true;
			this.btnDownData.Click += new System.EventHandler(this.btnDownData_Click);
			// 
			// btnUpData
			// 
			this.btnUpData.ForeColor = System.Drawing.Color.LightSeaGreen;
			this.btnUpData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnUpData.Location = new System.Drawing.Point(378, 185);
			this.btnUpData.Name = "btnUpData";
			this.btnUpData.Size = new System.Drawing.Size(75, 23);
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
			this.historyDataBox.Location = new System.Drawing.Point(16, 185);
			this.historyDataBox.Name = "historyDataBox";
			this.historyDataBox.Size = new System.Drawing.Size(356, 181);
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
			this.sendNameBox.Location = new System.Drawing.Point(16, 53);
			this.sendNameBox.Name = "sendNameBox";
			this.sendNameBox.Size = new System.Drawing.Size(150, 21);
			this.sendNameBox.TabIndex = 8;
			this.toolTip1.SetToolTip(this.sendNameBox, "设置当前数据的名称");
			// 
			// btnSendData
			// 
			this.btnSendData.ForeColor = System.Drawing.Color.Green;
			this.btnSendData.Location = new System.Drawing.Point(379, 24);
			this.btnSendData.Name = "btnSendData";
			this.btnSendData.Size = new System.Drawing.Size(75, 23);
			this.btnSendData.TabIndex = 6;
			this.btnSendData.Text = "发送";
			this.btnSendData.UseVisualStyleBackColor = true;
			this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
			// 
			// srbGbk
			// 
			this.srbGbk.AutoSize = true;
			this.srbGbk.Location = new System.Drawing.Point(236, 54);
			this.srbGbk.Name = "srbGbk";
			this.srbGbk.Size = new System.Drawing.Size(53, 16);
			this.srbGbk.TabIndex = 4;
			this.srbGbk.TabStop = true;
			this.srbGbk.Text = "ASCII";
			this.srbGbk.UseVisualStyleBackColor = true;
			this.srbGbk.CheckedChanged += new System.EventHandler(this.sendEncode_Changed);
			// 
			// srbUtf8
			// 
			this.srbUtf8.AutoSize = true;
			this.srbUtf8.Location = new System.Drawing.Point(292, 54);
			this.srbUtf8.Name = "srbUtf8";
			this.srbUtf8.Size = new System.Drawing.Size(47, 16);
			this.srbUtf8.TabIndex = 3;
			this.srbUtf8.TabStop = true;
			this.srbUtf8.Text = "UTF8";
			this.srbUtf8.UseVisualStyleBackColor = true;
			this.srbUtf8.CheckedChanged += new System.EventHandler(this.sendEncode_Changed);
			// 
			// btnClearSend
			// 
			this.btnClearSend.Location = new System.Drawing.Point(16, 24);
			this.btnClearSend.Name = "btnClearSend";
			this.btnClearSend.Size = new System.Drawing.Size(75, 23);
			this.btnClearSend.TabIndex = 1;
			this.btnClearSend.Text = "清空";
			this.btnClearSend.UseVisualStyleBackColor = true;
			this.btnClearSend.Click += new System.EventHandler(this.btnClearSend_Click);
			// 
			// tbSend
			// 
			this.tbSend.Location = new System.Drawing.Point(16, 78);
			this.tbSend.Multiline = true;
			this.tbSend.Name = "tbSend";
			this.tbSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbSend.Size = new System.Drawing.Size(356, 101);
			this.tbSend.TabIndex = 0;
			// 
			// srbHex
			// 
			this.srbHex.AutoSize = true;
			this.srbHex.Location = new System.Drawing.Point(189, 54);
			this.srbHex.Name = "srbHex";
			this.srbHex.Size = new System.Drawing.Size(41, 16);
			this.srbHex.TabIndex = 2;
			this.srbHex.TabStop = true;
			this.srbHex.Text = "HEX";
			this.srbHex.UseVisualStyleBackColor = true;
			this.srbHex.CheckedChanged += new System.EventHandler(this.sendEncode_Changed);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rbGbk);
			this.groupBox2.Controls.Add(this.rbUtf8);
			this.groupBox2.Controls.Add(this.rbHex);
			this.groupBox2.Controls.Add(this.btnClearRecv);
			this.groupBox2.Controls.Add(this.tbRecv);
			this.groupBox2.Location = new System.Drawing.Point(270, 78);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(464, 205);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "接收数据";
			// 
			// rbGbk
			// 
			this.rbGbk.AutoSize = true;
			this.rbGbk.Location = new System.Drawing.Point(236, 20);
			this.rbGbk.Name = "rbGbk";
			this.rbGbk.Size = new System.Drawing.Size(53, 16);
			this.rbGbk.TabIndex = 4;
			this.rbGbk.TabStop = true;
			this.rbGbk.Text = "ASCII";
			this.rbGbk.UseVisualStyleBackColor = true;
			this.rbGbk.CheckedChanged += new System.EventHandler(this.recvEncode_Changed);
			// 
			// rbUtf8
			// 
			this.rbUtf8.AutoSize = true;
			this.rbUtf8.Location = new System.Drawing.Point(296, 20);
			this.rbUtf8.Name = "rbUtf8";
			this.rbUtf8.Size = new System.Drawing.Size(47, 16);
			this.rbUtf8.TabIndex = 3;
			this.rbUtf8.TabStop = true;
			this.rbUtf8.Text = "UTF8";
			this.rbUtf8.UseVisualStyleBackColor = true;
			this.rbUtf8.CheckedChanged += new System.EventHandler(this.recvEncode_Changed);
			// 
			// rbHex
			// 
			this.rbHex.AutoSize = true;
			this.rbHex.Location = new System.Drawing.Point(189, 21);
			this.rbHex.Name = "rbHex";
			this.rbHex.Size = new System.Drawing.Size(41, 16);
			this.rbHex.TabIndex = 2;
			this.rbHex.TabStop = true;
			this.rbHex.Text = "HEX";
			this.rbHex.UseVisualStyleBackColor = true;
			this.rbHex.CheckedChanged += new System.EventHandler(this.recvEncode_Changed);
			// 
			// btnClearRecv
			// 
			this.btnClearRecv.Location = new System.Drawing.Point(16, 16);
			this.btnClearRecv.Name = "btnClearRecv";
			this.btnClearRecv.Size = new System.Drawing.Size(75, 23);
			this.btnClearRecv.TabIndex = 1;
			this.btnClearRecv.Text = "清空";
			this.btnClearRecv.UseVisualStyleBackColor = true;
			this.btnClearRecv.Click += new System.EventHandler(this.btnClearRecv_Click);
			// 
			// tbRecv
			// 
			this.tbRecv.Location = new System.Drawing.Point(16, 46);
			this.tbRecv.Multiline = true;
			this.tbRecv.Name = "tbRecv";
			this.tbRecv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbRecv.Size = new System.Drawing.Size(356, 140);
			this.tbRecv.TabIndex = 0;
			// 
			// confList
			// 
			this.confList.FormattingEnabled = true;
			this.confList.ItemHeight = 12;
			this.confList.Location = new System.Drawing.Point(13, 152);
			this.confList.Name = "confList";
			this.confList.Size = new System.Drawing.Size(212, 328);
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
			this.groupBox1.Location = new System.Drawing.Point(12, 193);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(236, 496);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "保存的配置";
			// 
			// btnNew
			// 
			this.btnNew.Location = new System.Drawing.Point(14, 30);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(211, 30);
			this.btnNew.TabIndex = 15;
			this.btnNew.Text = "新建";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(126, 110);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(101, 30);
			this.btnDelete.TabIndex = 14;
			this.btnDelete.Text = "删除";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(14, 110);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(101, 30);
			this.btnEdit.TabIndex = 13;
			this.btnEdit.Text = "重命名";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(125, 70);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(101, 30);
			this.btnLoad.TabIndex = 12;
			this.btnLoad.Text = "加载";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(13, 70);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(101, 30);
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
			this.statusStrip1.Location = new System.Drawing.Point(0, 692);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(744, 22);
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
			this.btnStartSerial.Location = new System.Drawing.Point(566, 20);
			this.btnStartSerial.Name = "btnStartSerial";
			this.btnStartSerial.Size = new System.Drawing.Size(31, 32);
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
			// groupBoxSerial
			// 
			this.groupBoxSerial.Controls.Add(this.测试);
			this.groupBoxSerial.Controls.Add(this.btnStartSerial);
			this.groupBoxSerial.Controls.Add(this.cbCom);
			this.groupBoxSerial.Location = new System.Drawing.Point(12, 12);
			this.groupBoxSerial.Name = "groupBoxSerial";
			this.groupBoxSerial.Size = new System.Drawing.Size(720, 60);
			this.groupBoxSerial.TabIndex = 13;
			this.groupBoxSerial.TabStop = false;
			this.groupBoxSerial.Text = "串口";
			// 
			// 测试
			// 
			this.测试.Location = new System.Drawing.Point(648, 26);
			this.测试.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.测试.Name = "测试";
			this.测试.Size = new System.Drawing.Size(56, 18);
			this.测试.TabIndex = 3;
			this.测试.Text = "btnTest";
			this.测试.UseVisualStyleBackColor = true;
			this.测试.Click += new System.EventHandler(this.测试_Click);
			// 
			// TransferForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(744, 714);
			this.Controls.Add(this.groupBoxSerial);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.configGroup);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "TransferForm";
			this.Text = "串口和网络调试工具 1.0";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TransferForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TransferForm_FormClosed);
			this.Load += new System.EventHandler(this.TransferForm_Load);
			this.configGroup.ResumeLayout(false);
			this.configGroup.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupBoxSerial.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog ofDlg;
		private System.Windows.Forms.SaveFileDialog sfDlg;
		private System.Windows.Forms.GroupBox configGroup;
		private System.Windows.Forms.ComboBox cbBits;
		private System.Windows.Forms.Label label2;
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
		private System.Windows.Forms.GroupBox groupBoxSerial;
		private System.Windows.Forms.Button btnStartSerial;
		private System.Windows.Forms.ImageList pngList;
		private System.Windows.Forms.CheckBox cbEscape;
		private System.Windows.Forms.Button 测试;

    }
}

