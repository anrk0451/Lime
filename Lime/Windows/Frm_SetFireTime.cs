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
using Lime.Xpo.orcl;
using Lime.Action;

namespace Lime.Windows
{
	public partial class Frm_SetFireTime : MyDialog
	{
		private AC01 ac01 = null;
		public Frm_SetFireTime()
		{
			InitializeComponent();
		}

		private void Frm_SetFireTime_Load(object sender, EventArgs e)
		{
			ac01 = this.swapdata["ac01"] as AC01;
			dateEdit1.EditValue = ac01.AC015;
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			if(dateEdit1.EditValue == null || string.IsNullOrEmpty(dateEdit1.EditValue.ToString()))
			{
				XtraMessageBox.Show("请输入正确的日期时间格式!","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			if(FireAction.SetFireTime(ac01.AC001,Convert.ToDateTime(dateEdit1.EditValue)) > 0)
			{
				this.DialogResult = DialogResult.OK;
				ac01.AC015 = Convert.ToDateTime(dateEdit1.EditValue);
				XtraMessageBox.Show("设置成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
		}
	}
}