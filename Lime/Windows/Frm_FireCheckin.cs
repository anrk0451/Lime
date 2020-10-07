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
using Lime.Action;
using DevExpress.Utils.DirectXPaint;
using Lime.Xpo.orcl;
using Lime.Misc;

namespace Lime.Windows
{
	public partial class Frm_FireCheckin : MyDialog
	{
		private DataTable dt_st01 = new DataTable("ST01");   //系统数据字典
		private OracleDataAdapter st01_adapter = new OracleDataAdapter("select * from st01 where status <> '0' ", SqlHelper.conn);
		private DataView dv_reason = null;
		private DataView dv_ash_handle = null;
		private DataView dv_district = null;
		private DataView dv_relation = null;
 
		private AC01 ac01 = null;
		private string s_ac001 = string.Empty;
		private bool b_new = true;
		
		public Frm_FireCheckin()
		{
			InitializeComponent();
		}

		private void Frm_FireCheckin_Load(object sender, EventArgs e)
		{
			//检索数据字典
			st01_adapter.Fill(dt_st01);
			//创建数据视图
			dv_reason = new DataView(dt_st01);
			dv_reason.RowFilter = "ST002 = 'DIEREASON'";

			///死因
			lookUp_ac005.Properties.DataSource = dv_reason;
			lookUp_ac005.Properties.ValueMember = "ST003";
			lookUp_ac005.Properties.DisplayMember = "ST003";
			dv_reason.Sort = "SORTID ASC";

			dv_ash_handle = new DataView(dt_st01);
			dv_ash_handle.RowFilter = "ST002 = 'ASHHANDLE' ";

			//骨灰处理方式
			lookUp_ac006.Properties.DataSource = dv_ash_handle;
			lookUp_ac006.Properties.ValueMember = "ST001";
			lookUp_ac006.Properties.DisplayMember = "ST003";

			//乡镇区县
			dv_district = new DataView(dt_st01);
			dv_district.RowFilter = "ST002='DISTRICT' ";

			lookUp_ac007.Properties.DataSource = dv_district;
			lookUp_ac007.Properties.ValueMember = "ST001";
			lookUp_ac007.Properties.DisplayMember = "ST003";

			//与逝者关系
			dv_relation = new DataView(dt_st01);
			dv_relation.RowFilter = "ST002='RELATION' ";

			lookUp_ac052.Properties.DataSource = dv_relation;
			lookUp_ac052.Properties.ValueMember = "ST003";
			lookUp_ac052.Properties.DisplayMember = "ST003";

			/////////////////// 检索 是否有对象传入 ///////////////////////
			if (this.swapdata.ContainsKey("ac001"))   //编辑模式
			{
				s_ac001 = this.swapdata["ac001"].ToString();
				ac01 = unitOfWork1.GetObjectByKey<AC01>(s_ac001);
				txtEdit_ac003.EditValue = ac01.AC003;
				rg_ac002.EditValue = ac01.AC002;
				txtEdit_ac004.EditValue = ac01.AC004;
				txtedit_ac014.EditValue = ac01.AC014;
				txtEdit_ac009.EditValue = ac01.AC009;           //接灵地点
				dateEdit_ac010.EditValue = ac01.AC010;          //死亡时间
				lookUp_ac005.EditValue = ac01.AC005;            //死因
				lookUp_ac006.EditValue = ac01.AC006;            //骨灰处理方式
				lookUp_ac007.EditValue = ac01.AC007;            //乡镇区县
				lookUp_ac052.EditValue = ac01.AC052;            //与逝者关系
				txtEdit_ac050.EditValue = ac01.AC050;			//联系人
				txtEdit_ac051.EditValue = ac01.AC051;           //联系电话
				txtEdit_ac055.EditValue = ac01.AC055;           //联系地址
				dateEdit_ac020.EditValue = ac01.AC020;          //到达时间
				mem_ac099.EditValue = ac01.AC099;				//备注
 
				sb_clear.Enabled = false;
				b_new = false;
			}
			else                                     //新建模式    
			{
				ac01 = new AC01(unitOfWork1);
				s_ac001 = ac01.AC001 = MiscAction.GetEntityPK("AC01");
				ac01.STATUS = "1";
				rg_ac002.EditValue = "0";                         //性别 默认 男
				ac01.AC020 = MiscAction.GetServerTime();          //到达时间
				ac01.AC200 = ac01.AC020;                          //经办日期
				ac01.AC100 = Envior.cur_user.UC001;               //经办人
				ac01.AC110 = ac01.AC100;                          //最后经办人
				ac01.AC220 = ac01.AC200;
				ac01.AC020 = MiscAction.GetServerTime();          //到达时间
				dateEdit_ac020.EditValue = ac01.AC020;
			}

		}
		/// <summary>
		/// 清除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void sb_clear_Click(object sender, EventArgs e)
		{
			txtEdit_ac003.Text = "";
			rg_ac002.EditValue = "0";
			txtEdit_ac004.EditValue = "";
			txtedit_ac014.Text = "";
			txtEdit_ac009.Text = "";
			dateEdit_ac010.EditValue = null;
			lookUp_ac005.EditValue = "";
			lookUp_ac006.EditValue = "";
			lookUp_ac007.EditValue = "";
			txtEdit_ac008.Text = "";
			txtEdit_ac050.Text = "";
			lookUp_ac052.EditValue = "";
			txtEdit_ac051.Text = "";
			txtEdit_ac055.Text = "";
			mem_ac099.Text = "";
			txtEdit_ac003.Focus();
		}
		/// <summary>
		/// 身份证号校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtedit_ac014_Validating(object sender, CancelEventArgs e)
		{
			string s_idcard = txtedit_ac014.Text.Trim();
			if (string.IsNullOrWhiteSpace(s_idcard)) return;

			if (s_idcard.Length != 15 && s_idcard.Length != 18)
			{
				txtedit_ac014.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtedit_ac014.ErrorText = "身份证号位数错误!";
				e.Cancel = true;
			}
			else if (s_idcard.Length == 15)
			{
				if (!Tool.CheckIDCard15(s_idcard))
				{
					txtedit_ac014.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
					txtedit_ac014.ErrorText = "身份证号错误!";
					e.Cancel = true;
				}
			}
			else if (s_idcard.Length == 18)
			{
				if (!Tool.CheckIDCard18(s_idcard))
				{
					txtedit_ac014.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
					txtedit_ac014.ErrorText = "身份证号错误!";
					e.Cancel = true;
				}
			}
		}
		/// <summary>
		/// 死亡时间校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dateEdit_ac010_Validating(object sender, CancelEventArgs e)
		{
			if (dateEdit_ac010.EditValue == null) return;
			if (DateTime.Compare((DateTime)dateEdit_ac010.EditValue, MiscAction.GetServerTime()) > 0)
			{
				dateEdit_ac010.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				dateEdit_ac010.ErrorText = "死亡时间不能大于系统当前时间!";
				e.Cancel = true;
			}
		}
		/// <summary>
		/// 年龄校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtEdit_ac004_Validating(object sender, CancelEventArgs e)
		{
			string s_ac004 = txtEdit_ac004.Text.Trim();
			if (string.IsNullOrWhiteSpace(s_ac004)) return;

			int i;
			if (int.TryParse(s_ac004, out i))
			{
				if (i < 0)
				{
					txtEdit_ac004.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
					txtEdit_ac004.ErrorText = "年龄不能小于0!";
					e.Cancel = true;
				}
			}
		}
		/// <summary>
		/// 保存前检查
		/// </summary>
		/// <returns></returns>
		private bool CheckBeforeSave()
		{
			//逝者姓名
			if (string.IsNullOrWhiteSpace(txtEdit_ac003.Text.Trim()))
			{
				txtEdit_ac003.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtEdit_ac003.ErrorText = "逝者姓名必须输入!";
				txtEdit_ac003.Focus();
				return false;
			}
			//年龄
			if (string.IsNullOrWhiteSpace(txtEdit_ac004.Text.Trim()))
			{
				txtEdit_ac004.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtEdit_ac004.ErrorText = "年龄必须输入!";
				txtEdit_ac004.Focus();
				return false;
			}

			//身份证号
			//if (string.IsNullOrWhiteSpace(txtedit_ac014.Text.Trim()))
			//{
			//	txtedit_ac014.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
			//	txtedit_ac014.ErrorText = "身份证号必须输入!";
			//	txtedit_ac014.Focus();
			//	return false;
			//}

			//死亡原因
			if (lookUp_ac005.EditValue == null)
			{
				lookUp_ac005.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				lookUp_ac005.ErrorText = "死亡原因必须输入!";
				lookUp_ac005.Focus();
				return false;
			}
			//逝者户籍
			if (lookUp_ac007.EditValue == null)
			{
				lookUp_ac007.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				lookUp_ac007.ErrorText = "逝者户籍必须输入!";
				lookUp_ac007.Focus();
				return false;
			}
			//联系人
			if (string.IsNullOrWhiteSpace(txtEdit_ac050.Text))
			{
				txtEdit_ac050.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtEdit_ac050.ErrorText = "联系人必须输入!";
				txtEdit_ac050.Focus();
				return false;
			}
			//与逝者关系
			if ( lookUp_ac052.EditValue == null)
			{
				lookUp_ac052.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				lookUp_ac052.ErrorText = "与逝者关系必须输入!";
				lookUp_ac052.Focus();
				return false;
			}
			//联系电话
			if (string.IsNullOrWhiteSpace(txtEdit_ac051.Text))
			{
				txtEdit_ac051.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtEdit_ac051.ErrorText = "联系人必须输入!";
				txtEdit_ac051.Focus();
				return false;
			}
			//到达日期
			if(dateEdit_ac020.EditValue == null)
			{
				dateEdit_ac020.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				dateEdit_ac020.ErrorText = "到达时间必须输入!";
				dateEdit_ac020.Focus();
				return false;
			}

			return true;
		}
		
		/// <summary>
		/// 到达日期编辑校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dateEdit_ac020_Validating(object sender, CancelEventArgs e)
		{
			if (dateEdit_ac020.EditValue == null) return;
			if (DateTime.Compare((DateTime)dateEdit_ac020.EditValue, MiscAction.GetServerTime()) > 0)
			{
				dateEdit_ac020.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				dateEdit_ac020.ErrorText = "到达时间不能大于系统当前时间!";
				e.Cancel = true;
			}
		}

		/// <summary>
		/// 保存过程
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void sb_ok_Click(object sender, EventArgs e)
		{
			if (!CheckBeforeSave()) return;
			ac01.AC003 = txtEdit_ac003.Text;					  //逝者姓名
			ac01.AC002 = rg_ac002.EditValue.ToString();			  //性别
			ac01.AC004 = Convert.ToInt32(txtEdit_ac004.EditValue);//年龄
			ac01.AC014 = txtedit_ac014.Text;                      //身份证号
			ac01.AC020 = Convert.ToDateTime(dateEdit_ac020.EditValue);  //到达时间
			ac01.AC009 = txtEdit_ac009.Text;                      //接令地点
			ac01.AC010 = Convert.ToDateTime(dateEdit_ac010.EditValue);  //死亡时间
			ac01.AC005 = lookUp_ac005.EditValue.ToString();       //死亡原因

			ac01.AC006 = lookUp_ac006.EditValue == null ? null : lookUp_ac006.EditValue.ToString();       //骨灰处理

			ac01.AC007 = lookUp_ac007.EditValue.ToString();       //县镇区县
			ac01.AC008 = txtEdit_ac008.Text;                      //详细地址
			ac01.AC050 = txtEdit_ac050.Text;                      //联系人
			ac01.AC052 = lookUp_ac052.EditValue.ToString();       //与逝者关系
			ac01.AC051 = txtEdit_ac051.Text;                      //联系电话
			ac01.AC055 = txtEdit_ac055.Text;                      //联系地址
			ac01.AC099 = mem_ac099.Text;                          //备注

			try
			{
				unitOfWork1.CommitChanges();
				DialogResult = DialogResult.OK;
				if (b_new)
				{
					this.swapdata["ac001"] = ac01.AC001;
					if(XtraMessageBox.Show("登记成功,现在要进行业务办理吗?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
					{
						this.Close();
						(Envior.mform as Frm_main).openBusinessObject("FireBusiness", s_ac001);
					}
					else
					{
						this.Close();
					}
				}
				else
				{
					XtraMessageBox.Show("保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
				}
				
			}
			catch (Exception ee)
			{
				unitOfWork1.RollbackTransaction();
				LogUtils.Error(ee.Message);
				XtraMessageBox.Show(ee.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

  		}
	}
}