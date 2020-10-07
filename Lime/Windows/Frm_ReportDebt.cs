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
	public partial class Frm_ReportDebt : MyDialog
	{
		public Frm_ReportDebt()
		{
			InitializeComponent();
		}

		private void Frm_ReportDebt_Load(object sender, EventArgs e)
		{

		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			this.swapdata["type"] = radioGroup1.EditValue;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}