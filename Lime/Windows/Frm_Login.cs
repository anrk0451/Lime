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
using Lime.Misc;
using System.Configuration;
using Lime.Xpo.orcl;
using DevExpress.Xpo;
using Lime.Action;

namespace Lime.Windows
{
	public partial class Frm_Login : DevExpress.XtraEditors.XtraForm
	{
		public Frm_Login()
		{
			InitializeComponent();
		}

		private void b_exit_Click(object sender, EventArgs e)
		{
			if (Envior.cur_user == null)    //如果是登录
				Application.Exit();
			else                             //如果是重新登陆.... 
				this.Dispose();
		}

		private void Frm_Login_Shown(object sender, EventArgs e)
		{
			this.Focus();
			string lastuser = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath).AppSettings.Settings["lastusername"].Value.ToString();
			if (!string.IsNullOrEmpty(lastuser))
			{
				textEdit_user.Text = lastuser;
				textEdit_pwd.Focus();
			}
			else
			{
				textEdit_user.Focus();
			}
		}

		private void b_ok_Click(object sender, EventArgs e)
		{
			string s_userCode, s_pwd;
			s_userCode = textEdit_user.Text;
			s_pwd = textEdit_pwd.Text;

			if (string.IsNullOrEmpty(s_userCode))
			{
				MessageBox.Show("请输入用户代码!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				textEdit_user.Focus();
				return;
			}
			if (string.IsNullOrEmpty(s_pwd))
			{
				MessageBox.Show("请输入密码!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				textEdit_pwd.Focus();
				return;
			}
			/////////////////////  检索 密码  ///////////////////////////////
			string s_uc001 = SqlHelper.ExecuteScalar("select uc001 from uc01 where status = '1' and rownum < 2 and  uc002 = '" + s_userCode + "'").ToString();
			if (s_uc001 == null || string.IsNullOrEmpty(s_uc001))
			{
				textEdit_user.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				textEdit_user.ErrorText = "用户不存在!";
				return;
			}

			UC01 uc01 = session1.GetObjectByKey<UC01>(s_uc001);
			if (Tool.EncryptWithMD5(s_pwd) != uc01.UC004)
			{
				textEdit_pwd.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				textEdit_pwd.ErrorText = "密码错误!";
				return;
			}
			else
			{
				Envior.cur_user = uc01; 
				Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				config.AppSettings.Settings["lastusername"].Value = s_userCode;
				config.Save(ConfigurationSaveMode.Modified);

				/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}