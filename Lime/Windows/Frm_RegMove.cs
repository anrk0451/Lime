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
using Lime.Misc;

namespace Lime.Windows
{
	public partial class Frm_RegMove : MyDialog
	{
		private string s_rc001 = string.Empty;
		private string s_bitId_old = string.Empty;
		private string s_bitId_new = string.Empty;
		public Frm_RegMove()
		{
			InitializeComponent();
		}

		private void Frm_RegMove_Load(object sender, EventArgs e)
		{
			s_rc001 = this.swapdata["rc001"].ToString();
			RC01 rc01 = unitOfWork1.GetObjectByKey<RC01>(s_rc001);
			if(rc01 != null)
			{
				txtEdit_rc001.Text = s_rc001;
				txtEdit_rc109.EditValue = rc01.RC109;
				txtEdit_rc003.EditValue = rc01.RC003;
				s_bitId_old = rc01.RC130;
				be_position.EditValue = RegAction.GetRegPosition(s_rc001);
			}
			else
			{
				sb_ok.Enabled = false;
				XtraMessageBox.Show("数据未找到!","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			string s_rt003 = string.Empty;

			if (string.IsNullOrEmpty(s_bitId_new))
			{
				be_newposition.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				be_newposition.ErrorText = "请选择变更后位置!";
				return;
			}
			s_rt003 = txtedit_rt003.Text;

			if (string.IsNullOrEmpty(s_rt003))
			{
				txtedit_rt003.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtedit_rt003.ErrorText = "请输入变更原因!";
				return;
			}


			int re = RegAction.RegisterMove(s_rc001, s_bitId_old, s_bitId_new, s_rt003, Envior.cur_user.UC001);
			if (re > 0)
			{
				XtraMessageBox.Show("办理成功!", "提示");
				DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void be_newposition_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			Frm_FreeBit frm_free = new Frm_FreeBit();
			frm_free.swapdata["parent"] = this;

			if (frm_free.ShowDialog() == DialogResult.OK)
			{
				string regionId, bitDesc;
				int i_bi005;
				regionId = this.swapdata["regionId"].ToString();
				bitDesc = this.swapdata["bitDesc"].ToString();
				i_bi005 = Convert.ToInt32(this.swapdata["bi005"]);
				s_bitId_new = RegAction.GetBitId(regionId,i_bi005, bitDesc);
				be_newposition.Text = RegAction.GetBitFullName(regionId,i_bi005, bitDesc);
			}
		}
	}
}