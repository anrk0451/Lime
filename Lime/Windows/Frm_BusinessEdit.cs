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
	public partial class Frm_BusinessEdit : MyDialog
	{
		private SA01 sa01 = null;
		public Frm_BusinessEdit()
		{
			InitializeComponent();
		}

		private void Frm_BusinessEdit_Load(object sender, EventArgs e)
		{
			sa01 = this.swapdata["sa01"] as SA01;
			if(sa01 == null)
			{
				sb_ok.Enabled = false;
				XtraMessageBox.Show("参数传递错误!","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}

			txtedit_sa003.Text = sa01.SA003;
			txtedit_price.EditValue = sa01.PRICE;
			txtedit_nums.EditValue = sa01.NUMS;

			RightSetup();  //权限设置


		}

		/// <summary>
		/// 根据权限设置可修改项
		/// </summary>
		private void RightSetup()
		{
			///设置权限.......
			///
			string sa002 = sa01.SA002;
			if (sa002 == "11" || sa002 == "04" || sa002 == "06" || sa002 == "07" || sa002 == "03")
			{
				txtedit_nums.ReadOnly = true;
			}
		}
		/// <summary>
		/// 单价校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtedit_price_Validating(object sender, CancelEventArgs e)
		{
			if (txtedit_price.EditValue == null || txtedit_price.EditValue is System.DBNull || decimal.Parse(txtedit_price.Text) <= 0)
			{
				txtedit_price.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtedit_price.ErrorText = "请输入单价!";
				e.Cancel = true;
				return;
			}
		}
		/// <summary>
		/// 数量校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtedit_nums_Validating(object sender, CancelEventArgs e)
		{
			if (txtedit_nums.EditValue == null || txtedit_nums.EditValue is System.DBNull || decimal.Parse(txtedit_nums.Text) <= 0)
			{
				txtedit_nums.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtedit_nums.ErrorText = "请输入数量!";
				e.Cancel = true;
				return;
			}

			string sa002 = sa01.SA002;
			if (sa002 == "01" || sa002 == "02")
			{
				if (decimal.Parse(txtedit_nums.Text) - Math.Floor(decimal.Parse(txtedit_nums.Text)) != new decimal(0.5) &&
					 decimal.Parse(txtedit_nums.Text) - Math.Floor(decimal.Parse(txtedit_nums.Text)) != new decimal(0)
					)
				{
					txtedit_nums.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
					txtedit_nums.ErrorText = "存放天数只能为整数或者半日!";
					e.Cancel = true;
					return;
				}
			}
		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			decimal price, nums;
			if (txtedit_price.EditValue == null || txtedit_price.EditValue is System.DBNull)
			{
				txtedit_price.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtedit_price.ErrorText = "请输入单价!";
				return;
			}
			if (txtedit_nums.EditValue == null || txtedit_nums.EditValue is System.DBNull)
			{
				txtedit_nums.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtedit_nums.ErrorText = "请输入数量!";
				return;
			}
			price = decimal.Parse(txtedit_price.Text);
			nums = decimal.Parse(txtedit_nums.Text);

			if (sa01.SA005 == "0")  //火化业务
			{
				int result = FireAction.FireSalesEdit(sa01.SA001,
													  price,
													  nums,
													  Envior.cur_user.UC001
				);
				if (result > 0)
				{
					DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			else if (sa01.SA005 == "1") //临时性销售
			{
				this.DialogResult = DialogResult.OK;
				sa01.PRICE = price;
				sa01.NUMS = nums;
				sa01.SA007 = price * nums;
				this.Close();
			}
		}
	}
}