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
using DevExpress.Xpo.DB;
using Lime.Action;
using Lime.Misc;

namespace Lime.Windows
{
	public partial class Frm_Operator : MyDialog
	{
		private UC01 uc01 = null;
		private string action = "";

		public Frm_Operator()
		{
			InitializeComponent();
		}

		private void Frm_Operator_Load(object sender, EventArgs e)
		{
			if(this.swapdata.ContainsKey("uc001") )
			{

				this.Text = "编辑用户";
				action = "edit";
				uc01 = unitOfWork1.GetObjectByKey<UC01>(this.swapdata["uc001"].ToString());
				txtedit_uc002.EditValue = uc01.UC002;  //用户代码
				txtedit_uc003.EditValue = uc01.UC003;  //用户姓名
				///密码不能修改
				txtedit_pwd.ReadOnly = true;
				txtedit_pwd2.ReadOnly = true;

				//设置角色
				foreach(SelectStatementResultRow row in SqlHelper.ExecuteQuery("select ro001 from ur_mapper where uc001 = :uc001",new string[] {"uc001"},new string[] { uc01.UC001 }).ResultSet[0].Rows)
				{
					string s_ro001 = row.Values[0].ToString();
					RO01 ro01 = unitOfWork1.GetObjectByKey<RO01>(s_ro001);
					int i_index = clbx_roles.FindItem(ro01);
					if(i_index >=0) clbx_roles.SetItemChecked(i_index,true);
				}

			}
			else
			{
				this.Text = "新建用户";
				action = "add";
			}


		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			//数据校验
			string s_uc002 = txtedit_uc002.Text;
			string s_uc003 = txtedit_uc003.Text;
			string s_uc004 = txtedit_pwd.Text;
			string s_uc004_2 = txtedit_pwd2.Text;

			if (String.IsNullOrEmpty(s_uc002))
			{
				txtedit_uc002.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtedit_uc002.ErrorText = "用户登录代码必须输入!";
				txtedit_uc002.Focus();
				return;
			}

			if (String.IsNullOrEmpty(s_uc003))
			{
				txtedit_uc003.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtedit_uc003.ErrorText = "用户姓名必须输入!";
				txtedit_uc003.Focus();
				return;
			}

			if (action == "add")
			{
				if (String.IsNullOrEmpty(s_uc004))
				{
					txtedit_pwd.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
					txtedit_pwd.ErrorText = "密码必须输入!";
					txtedit_pwd.Focus();
					return;
				}
				else if (!String.Equals(s_uc004, s_uc004_2))
				{
					txtedit_pwd2.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
					txtedit_pwd2.ErrorText = "密码不一致!";
					txtedit_pwd2.Focus();
					return;
				}
			}
			 
			/////////// 保存过程  ////////
			if(action == "add")
			{
				uc01 = new UC01(unitOfWork1);
				uc01.UC001 = MiscAction.GetEntityPK("UC01");
				uc01.STATUS = '1';
				uc01.UC004 = SecurityTool.EncryptWithMD5(s_uc004);
			}
			uc01.UC002 = s_uc002;
			uc01.UC003 = s_uc003;
		 
			try
			{
				///unitOfWork1.BeginTransaction();
				uc01.Save();

				SqlHelper.ExecuteNonQuery("delete from ur_mapper where uc001 = :uc001", new string[] { "uc001" }, new string[] { uc01.UC001 });

				foreach (RO01 r in clbx_roles.CheckedItems)
				{
					UR_MAPPER mapper = new UR_MAPPER(unitOfWork1);
					mapper.UM001 = MiscAction.GetEntityPK("MAPPER");
					mapper.UC001 = uc01.UC001;
					mapper.RO001 = r.RO001;
					mapper.Save();
				}

				unitOfWork1.CommitChanges();
				XtraMessageBox.Show("保存成功!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ee)
			{
				unitOfWork1.RollbackTransaction();
				LogUtils.Error(ee.Message);
				XtraMessageBox.Show(ee.ToString(),"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			 
		}
	}
}