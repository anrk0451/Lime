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
	public partial class Frm_FinRemoveReason : MyDialog
	{
		public Frm_FinRemoveReason()
		{
			InitializeComponent();
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			string s_reason = memoEdit1.Text;
			this.swapdata["reason"] = s_reason;
			DialogResult = DialogResult.OK;
			this.Close();
		}

		private void Frm_FinRemoveReason_Load(object sender, EventArgs e)
		{
			memoEdit1.Focus();
		}
	}
}