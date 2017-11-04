using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketSerialTools {
	public partial class ConfEditor : Form {
		private TransferForm parent;
		public enum EditType{
			New = 1,Rename = 2,Copy = 3
		}
		public EditType Type;
		public ConfEditor(TransferForm parent,EditType type) {
			InitializeComponent();
			nameBox.Focus();
			this.parent = parent;
			this.Type = type;
		}

		private void btnOK_Click(object sender, EventArgs e) {
			string ret = parent.SetConfName(this,nameBox.Text);
			if (ret == "") {
				this.DialogResult = DialogResult.OK;
			} else {
				errorTip.Text = ret;
			}
		}

		private void ConfEditor_Load(object sender, EventArgs e) {
			nameBox.Text = parent.EditConfName;
		}
	}
}
