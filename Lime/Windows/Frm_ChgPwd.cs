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
using Oracle.ManagedDataAccess.Client;
using Lime.Misc;
using Lime.Action;

namespace Lime.Windows
{
	public partial class Frm_ChgPwd : MyDialog
	{
		public Frm_ChgPwd()
		{
			InitializeComponent();
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textEdit1.Text))
			{
				textEdit1.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				textEdit1.ErrorText = "请输入原密码!";
				return;
			}
			if (string.IsNullOrEmpty(textEdit2.Text))
			{
				textEdit2.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				textEdit2.ErrorText = "请输入新密码!";
				return;
			}
			if (string.IsNullOrEmpty(textEdit3.Text) || textEdit2.Text != textEdit3.Text)
			{
				textEdit3.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				textEdit3.ErrorText = "密码不一致!";
				return;
			}

			string s_orig_pwd = string.Empty;

			s_orig_pwd = SqlHelper.ExecuteScalar("select uc004 from uc01 where uc001 = '" + Envior.cur_user.UC001 + "'").ToString();
			if (Tool.EncryptWithMD5(textEdit1.Text) != s_orig_pwd)
			{
				textEdit1.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				textEdit1.ErrorText = "原密码不正确!";
				return;
			}

			string s_new_pwd = Tool.EncryptWithMD5(textEdit2.Text);
			if (MiscAction.Modify_Pwd( s_new_pwd) == 1)
			{
				MessageBox.Show("修改密码成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Dispose();
			}
		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}