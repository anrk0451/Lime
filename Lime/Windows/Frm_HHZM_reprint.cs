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
	public partial class Frm_HHZM_reprint : MyDialog
	{
		public Frm_HHZM_reprint()
		{
			InitializeComponent();
		}

		private void Frm_HHZM_reprint_Load(object sender, EventArgs e)
		{

		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			if(dateEdit1.EditValue == null)
			{
				dateEdit1.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				dateEdit1.ErrorText = "请输入出生日期!";
				return;
			}
			else
			{
				this.swapdata["birth"] = dateEdit1.EditValue;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}