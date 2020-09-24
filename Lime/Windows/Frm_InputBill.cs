using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Lime.BaseObject;

namespace Lime.Windows
{
	public partial class Frm_InputBill : MyDialog
	{
		public Frm_InputBill()
		{
			InitializeComponent();
		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Frm_InputBill_Load(object sender, EventArgs e)
		{
			textEdit1.Focus();
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			string s_billno = textEdit1.Text;
			if (string.IsNullOrEmpty(s_billno))
			{
				textEdit1.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				textEdit1.ErrorText = "请输入单据号";
				textEdit1.Focus();
				return;
			}
			else
			{
				this.swapdata["billno"] = s_billno;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}