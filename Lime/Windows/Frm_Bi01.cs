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
using DevExpress.Xpo;
using DevExpress.Data.Filtering;

namespace Lime.Windows
{
	public partial class Frm_Bi01 : MyDialog
	{
		private BI01 bi01 = null;
		private XPCollection xpcollection_bi01 = null;
		private UnitOfWork session = null;
		public Frm_Bi01()
		{
			InitializeComponent();
		}

		private void Frm_Bi01_Load(object sender, EventArgs e)
		{
			string s_regionId = string.Empty;
			string s_bi003 = string.Empty;
			if (this.swapdata.ContainsKey("collection"))
			{
				xpcollection_bi01 = this.swapdata["collection"] as XPCollection;
				session = this.swapdata["session"] as UnitOfWork;
				s_regionId = this.swapdata["regionId"].ToString();
				s_bi003 = this.swapdata["bi003"].ToString();

				CriteriaOperator criteria = CriteriaOperator.Parse("RG001 ='" + s_regionId + "' and BI003='" + s_bi003 + "'" );
				XPCollection<BI01> xp_temp = new XPCollection<BI01>(session, xpcollection_bi01, criteria);
				if (xp_temp.Count > 0)
					bi01 = xp_temp[0];
					
				te_bi003.EditValue = bi01.BI003;
				te_price.EditValue = bi01.BI009;

				if (bi01.STATUS == "1")
					radioButton3.Enabled = false;
				else if (bi01.STATUS == "0")
				{
					radioButton3.Checked = true;
					te_price.Enabled = false;
					radioButton3.Text = "使有效";
				}
				te_price.Focus();
			}
			else
			{
				XtraMessageBox.Show("数据查询错误!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error) ;
				sb_ok.Enabled = false;
			} 
		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
			{
				te_price.Enabled = true;
				te_bi003.Enabled = false;
			}
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton2.Checked)
			{
				te_price.Enabled = false;
				te_bi003.Enabled = true;
			}
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton3.Checked)
			{
				te_price.Enabled = false;
				te_bi003.Enabled = false;
			}
		}
		/// <summary>
		/// 编辑验证
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void te_price_Validating(object sender, CancelEventArgs e)
		{
			if (decimal.Parse(te_price.Text) < 0)
			{
				te_price.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				te_price.ErrorText = "价格不能小于0";
				e.Cancel = true;
			}
		}

		private void te_bi003_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(te_bi003.Text))
			{
				te_bi003.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				te_bi003.ErrorText = "号位描述不能为空!";
				e.Cancel = true;
			}
			else
			{
				CriteriaOperator criteria = CriteriaOperator.Parse("BI003 ='" + te_bi003.Text + "' and BI001 !='" + bi01.BI001 + "'");
				XPCollection<BI01> xp_temp = new XPCollection<BI01>(session, xpcollection_bi01, criteria);
				 
				if (xp_temp.Count > 0)
				{
					te_bi003.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
					te_bi003.ErrorText = "号位描述重复!";
					e.Cancel = true;
				}
			}
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			if (radioButton1.Checked)           //修改价格
			{
				decimal price = decimal.Parse(te_price.Text);
				bi01.BI009 = price;
				bi01.BI007 = "1";
			}
			else if (radioButton2.Checked)      //修改号位描述
			{
				string bi003 = te_bi003.Text;
				bi01.BI003 = bi003;
			}
			else if (radioButton3.Checked)      //修改号位状态
			{
				if (radioButton3.Text == "使有效")
				{
					bi01.BI003 = bi01.BI003.Substring(1);
					bi01.STATUS = "9";
				}
				else
				{
					bi01.BI003 = "#" + bi01.BI002.ToString().PadLeft(4, '0');
					bi01.STATUS = "0";
				}
			}

			DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}