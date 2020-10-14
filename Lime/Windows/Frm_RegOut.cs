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
	public partial class Frm_RegOut : MyDialog
	{
		private string s_rc001 = string.Empty;
		private decimal price = decimal.Zero;  //寄存单价
		private bool isrefund = false;         //是否需要退费

		public Frm_RegOut()
		{
			InitializeComponent();
		}

		private void Frm_RegOut_Load(object sender, EventArgs e)
		{
			s_rc001 = this.swapdata["rc001"].ToString();
			RC01 rc01 = unitOfWork1.GetObjectByKey<RC01>(s_rc001);
			if(rc01 != null)
			{
				txtEdit_rc001.Text = rc01.RC001;
				txtEdit_rc109.Text = rc01.RC109;    //寄存证号
				be_position.Text = RegAction.GetRegPosition(s_rc001);   //寄存位置
				txtEdit_rc003.Text = rc01.RC003;
				txtEdit_rc303.EditValue = rc01.RC303;
				rg_rc002.EditValue = rc01.RC002;
				rg_rc202.EditValue = rc01.RC202;
				txtEdit_rc004.EditValue = rc01.RC004;
				txtEdit_rc404.EditValue = rc01.RC404;
				//寄存号位单价
				price = RegAction.GetRegPrice(s_rc001);
				txtEdit_price.EditValue = price;
				txtEdit_rc150.EditValue = rc01.RC150;      //寄存到期时间

				int diff = RegAction.CalcOutDiffDays(s_rc001);
				int compare = string.Compare(rc01.RC150.ToString("yyyyMMdd"), MiscAction.GetServerTime().ToString("yyyyMMdd"));
				if (compare == 0)
				{
					checkEdit1.Enabled = false;
					txtEdit_nums.Enabled = false;
				}
				else if (compare > 0)  //退费
				{
					lc_1.Text = "剩余天数";
					lc_2.Text = "应退费月数";
					lc_3.Text = "退费金额";
					isrefund = true;

					//txtEdit_nums.EditValue = Math.Round((diff * 1.0f) / 30, 0);
					//txtEdit_fee.EditValue = Convert.ToDecimal(Math.Round((diff * 1.0f) / 30, 0)) * price;
					txtEdit_nums.EditValue = 0;
					txtEdit_fee.EditValue = 0;
					 
				}
				else
				{
					lc_1.Text = "过期天数";
					lc_2.Text = "应补费月数";
					lc_3.Text = "补费金额";

					txtEdit_nums.EditValue = Math.Round((diff * 1.0f) / 30, 0);
					txtEdit_fee.EditValue = Convert.ToDecimal(Math.Round((diff * 1.0f) / 30, 0)) * price;
				}				 
				txtEdit_diff.EditValue = diff;
				 
			}
			else
			{
				sb_ok.Enabled = false;
				XtraMessageBox.Show("数据未找到!","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		/// <summary>
		/// 补退费开关
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkEdit1_CheckedChanged(object sender, EventArgs e)
		{
			txtEdit_nums.Enabled = checkEdit1.Checked;
			if (!checkEdit1.Checked)
			{
				txtEdit_nums.Text = "0.00";
			}
		}

		private void txtEdit_nums_Validating(object sender, CancelEventArgs e)
		{
			if (!string.IsNullOrEmpty(txtEdit_nums.Text))
			{
				if (Convert.ToDecimal(txtEdit_nums.Text) < 0)
				{
					txtEdit_nums.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
					txtEdit_nums.ErrorText = "应为正值!";
					e.Cancel = true;
				}
			}
		}
		/// <summary>
		/// 补退费 数量变更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtEdit_nums_EditValueChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtEdit_nums.Text))
			{
				decimal nums = Convert.ToDecimal(txtEdit_nums.Text);
				txtEdit_fee.EditValue = Math.Round(price * nums);
			}
		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			if (txtEdit_oc003.EditValue == null || txtEdit_oc003.EditValue is System.DBNull)
			{
				txtEdit_oc003.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtEdit_oc003.ErrorText = "请输入迁出办理人!";
				return;
			}
			if (mem_oc005.EditValue == null)
			{
				mem_oc005.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				mem_oc005.ErrorText = "请输入迁出原因!";
				return;
			}
			string s_oc003 = txtEdit_oc003.Text;   //迁出人
			string s_oc005 = mem_oc005.Text;       //迁出原因
			string s_oc004 = txtEdit_oc004.Text;   //迁出人身份证号

			int diff = int.Parse(txtEdit_diff.EditValue.ToString());
			decimal nums = decimal.Zero;
			string fa001 = MiscAction.GetEntityPK("FA01");
			 
			//补退情况
			if (checkEdit1.Checked && (!string.IsNullOrEmpty(txtEdit_nums.Text)))
			{
				nums = decimal.Parse(txtEdit_nums.Text);
			}
			else
			{
				nums = 0;
			}

			if (XtraMessageBox.Show("确认要继续办理迁出吗？本业务将不能回退!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
			int re = RegAction.RegisterOut(s_rc001,
											s_oc003,
											s_oc004,
											s_oc005,
											diff,
											fa001,
											price,
											isrefund ? 0 - nums : nums,
											Envior.cur_user.UC001
			);

			if (re > 0)
			{
				XtraMessageBox.Show("迁出办理成功,现在打印【迁出通知单】", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
				PrintAction.Print_OutCard(s_rc001);
				if(Math.Abs(nums) > 0)
				{
					string s_billno = string.Empty;
					XtraMessageBox.Show("本次迁出发生补费,现在准备打印【收据】!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);


					///todo 6.打印补退费票据
					//Frm_InputBill frm_bill = new Frm_InputBill();
					//if (frm_bill.ShowDialog() == DialogResult.OK)
					//{
					//	s_billno = frm_bill.swapdata["billno"].ToString();
					//}
					//frm_bill.Dispose();
					//if (!string.IsNullOrEmpty(s_billno))
					//{
					PrintAction.Print_Skpz1(fa001);
					//	MiscAction.SetFinanceBill(fa001, s_billno);
					//}

				}
				this.DialogResult = DialogResult.OK;
				this.Close();
			}

		}
	}
}