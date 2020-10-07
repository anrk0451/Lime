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
using Lime.Action;

namespace Lime.Windows
{
	public partial class Frm_Duration : MyDialog
	{
		string s_mode = string.Empty;

		public Frm_Duration()
		{
			InitializeComponent();
		}

		private void Frm_Duration_Load(object sender, EventArgs e)
		{
			s_mode = this.swapdata["MODE"].ToString();
			if (string.IsNullOrEmpty(s_mode) || s_mode == "1")
			{
				dateEdit2.EditValue = MiscAction.GetServerTime();
				dateEdit1.EditValue = dateEdit2.EditValue;
			}
			else
			{
				dateEdit2.EditValue = MiscAction.GetServerTime();
				dateEdit1.EditValue = MiscAction.GetServerTime().AddMonths(-1);
			}
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			this.swapdata["begin"] = dateEdit1.EditValue;
			this.swapdata["end"] = dateEdit2.EditValue;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}