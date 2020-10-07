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
using Lime.Misc;

namespace Lime.Windows
{
	public partial class Frm_RegisterEdit : MyDialog
	{
		private RC01 rc01 = null;
		private string s_rc001 = string.Empty;

		public Frm_RegisterEdit()
		{
			InitializeComponent();
		}

		private void Frm_RegisterEdit_Load(object sender, EventArgs e)
		{
			s_rc001 = this.swapdata["rc001"].ToString();
			rc01 = unitOfWork1.GetObjectByKey<RC01>(s_rc001);
			if (rc01 != null)
			{
				txtEdit_rc001.EditValue = rc01.RC001;
				rg_rc002.EditValue = rc01.RC002;
				txtEdit_rc003.EditValue = rc01.RC003;
				txtEdit_rc004.EditValue = rc01.RC004;
				txtEdit_rc109.EditValue = rc01.RC109;   //寄存证号
				txtEdit_rc303.EditValue = rc01.RC303;
				rg_rc202.EditValue = rc01.RC202;
				txtEdit_rc404.EditValue = rc01.RC404;
				txtedit_rc014.EditValue = rc01.RC014;   //身份证号
				txtEdit_rc050.EditValue = rc01.RC050;   //联系人
				txtEdit_rc051.EditValue = rc01.RC051;   //联系电话
				lookUp_rc052.EditValue = rc01.RC052;    //与逝者关系
				txtEdit_ac055.EditValue = rc01.RC055;   //联系地址
				mem_rc099.EditValue = rc01.RC099;		//备注
			}
			else 
			{
				sb_ok.Enabled = false;
				XtraMessageBox.Show("未找到数据!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			 
		}
		/// <summary>
		/// 性别变更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rg_rc002_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (rg_rc002.EditValue.ToString() == "0")
			{
				rg_rc202.EditValue = "1";
			}
			else if (rg_rc002.EditValue.ToString() == "1")
			{
				rg_rc202.EditValue = "0";
			}
		}
		/// <summary>
		/// 身份证号校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtedit_rc014_Validating(object sender, CancelEventArgs e)
		{
			string s_idcard = txtedit_rc014.Text.Trim();
			if (string.IsNullOrWhiteSpace(s_idcard)) return;

			if (s_idcard.Length != 15 && s_idcard.Length != 18)
			{
				txtedit_rc014.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtedit_rc014.ErrorText = "身份证号位数错误!";
				e.Cancel = true;
			}
			else if (s_idcard.Length == 15)
			{
				if (!Tool.CheckIDCard15(s_idcard))
				{
					txtedit_rc014.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
					txtedit_rc014.ErrorText = "身份证号错误!";
					e.Cancel = true;
				}
			}
			else if (s_idcard.Length == 18)
			{
				if (!Tool.CheckIDCard18(s_idcard))
				{
					txtedit_rc014.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
					txtedit_rc014.ErrorText = "身份证号错误!";
					e.Cancel = true;
				}
			}
		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			if (!CheckBeforeSave()) return;

			try
			{
				rc01.RC002 = rg_rc002.EditValue.ToString();  //性别

				if (rg_rc202.EditValue != null)
					rc01.RC202 = rg_rc202.EditValue.ToString();
				else
					rc01.RC202 = "";

				rc01.RC003 = txtEdit_rc003.Text;                    //逝者姓名
				rc01.RC303 = txtEdit_rc303.Text;
				rc01.RC004 = Convert.ToInt32(txtEdit_rc004.Text);  //年龄

				if (txtEdit_rc404.EditValue != null)
					rc01.RC404 = Convert.ToInt32(txtEdit_rc404.Text);
				else
					rc01.RC404 = null;

				rc01.RC014 = txtedit_rc014.Text;                     //身份证号
				rc01.RC050 = txtEdit_rc050.Text;                     //联系人
				rc01.RC052 = lookUp_rc052.EditValue.ToString();     //与逝者关系
				rc01.RC051 = txtEdit_rc051.Text;                     //联系电话
				rc01.RC055 = txtEdit_ac055.Text;                     //联系地址
				rc01.RC099 = mem_rc099.Text;                         //备注

				AC01 ac01 = unitOfWork1.GetObjectByKey<AC01>(s_rc001);
				if(ac01 != null)
				{
					ac01.AC002 = rc01.RC002;
					ac01.AC003 = rc01.RC003;
					ac01.AC004 = rc01.RC004;
					ac01.AC014 = rc01.RC014;
				}
				unitOfWork1.CommitChanges();
				this.DialogResult = DialogResult.OK;
				XtraMessageBox.Show("保存成功!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.Close();
			}
			catch (Exception ee)
			{
				unitOfWork1.RollbackTransaction();
				LogUtils.Error(ee.Message);
				XtraMessageBox.Show(ee.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

		}
		/// <summary>
		/// 保存前检查
		/// </summary>
		/// <returns></returns>
		private bool CheckBeforeSave()
		{
			//逝者姓名
			if (string.IsNullOrWhiteSpace(txtEdit_rc003.Text.Trim()))
			{
				txtEdit_rc003.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtEdit_rc003.ErrorText = "逝者姓名必须输入!";
				txtEdit_rc003.Focus();
				return false;
			}
			//年龄
			if (string.IsNullOrWhiteSpace(txtEdit_rc004.Text.Trim()))
			{
				txtEdit_rc004.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtEdit_rc004.ErrorText = "年龄必须输入!";
				txtEdit_rc004.Focus();
				return false;
			}

			if (!string.IsNullOrWhiteSpace(txtEdit_rc303.Text.Trim()) && string.IsNullOrWhiteSpace(txtEdit_rc404.Text.Trim()))
			{
				txtEdit_rc404.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtEdit_rc404.ErrorText = "年龄必须输入!";
				txtEdit_rc404.Focus();
				return false;
			}


			//联系人
			if (string.IsNullOrWhiteSpace(txtEdit_rc050.Text))
			{
				txtEdit_rc050.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtEdit_rc050.ErrorText = "联系人必须输入!";
				txtEdit_rc050.Focus();
				return false;
			}
			//与逝者关系
			if (lookUp_rc052.EditValue == null)
			{
				lookUp_rc052.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				lookUp_rc052.ErrorText = "与逝者关系必须输入!";
				lookUp_rc052.Focus();
				return false;
			}
			//联系电话
			if (string.IsNullOrWhiteSpace(txtEdit_rc051.Text))
			{
				txtEdit_rc051.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtEdit_rc051.ErrorText = "联系电话必须输入!";
				txtEdit_rc051.Focus();
				return false;
			}
			return true;
		}
	}
}