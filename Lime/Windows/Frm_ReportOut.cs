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
	public partial class Frm_ReportOut : MyDialog
	{
		public Frm_ReportOut()
		{
			InitializeComponent();
		}

		private void Frm_ReportOut_Load(object sender, EventArgs e)
		{
			dateEdit2.EditValue = MiscAction.GetServerTime();
			dateEdit1.EditValue = MiscAction.GetServerTime().AddMonths(-1);
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			this.swapdata["dbegin"] = dateEdit1.EditValue;
			this.swapdata["dend"] = dateEdit2.EditValue;
			this.swapdata["rc003"] = textEdit1.EditValue;

			DialogResult = DialogResult.OK;
			this.Close();
		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}