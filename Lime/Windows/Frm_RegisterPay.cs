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
using Lime.Action;
using Oracle.ManagedDataAccess.Client;
using Lime.Xpo.orcl;
using Lime.Misc;

namespace Lime.Windows
{
	public partial class Frm_RegisterPay : MyDialog
	{
		private string s_rc001 = string.Empty;
		private DataTable dt_rc04 = new DataTable("RC04");
		private OracleDataAdapter rc04Adapter = new OracleDataAdapter("select * from v_rc04 where rc001 = :rc001", SqlHelper.conn);
		private OracleParameter op_rc001 = new OracleParameter("rc001", OracleDbType.Varchar2, 10);
		private decimal bitprice = decimal.Zero;

		public Frm_RegisterPay()
		{
			InitializeComponent();
			rc04Adapter.SelectCommand.Parameters.Add(op_rc001);
		}

		private void Frm_RegisterPay_Load(object sender, EventArgs e)
		{
			s_rc001 = this.swapdata["rc001"].ToString();
			RC01 rc01 = unitOfWork1.GetObjectByKey<RC01>(s_rc001);
			if(rc01 != null)
			{
				txtEdit_rc001.EditValue = rc01.RC001;
				txtEdit_rc109.EditValue = rc01.RC109;						//寄存证号
				be_position.Text = RegAction.GetRegPosition(s_rc001);      //寄存位置

				bitprice = RegAction.GetRegPrice(s_rc001);                 //寄存单价
				txtedit_price.EditValue = bitprice;
				txtEdit_rc003.EditValue = rc01.RC003;
				rg_rc002.EditValue = rc01.RC002;
				txtEdit_rc004.EditValue = rc01.RC004;
				txtEdit_rc303.EditValue = rc01.RC303;
				rg_rc202.EditValue = rc01.RC202;
				txtEdit_rc404.EditValue = rc01.RC404;

				op_rc001.Value = s_rc001;
				rc04Adapter.Fill(dt_rc04);
				gridControl1.DataSource = dt_rc04;

				comboBox1.Text = "";

			}
			else
			{
				sb_ok.Enabled = false;
				XtraMessageBox.Show("数据未找到!","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		/// <summary>
		/// 修改寄存期限
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBox1_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(comboBox1.Text)) return;
			decimal nums = int.Parse(comboBox1.Text);
			if (nums > 0 && bitprice > 0)
			{
				txtedit_regfee.EditValue = nums * bitprice;
			}
		}

		private void comboBox1_Validating(object sender, CancelEventArgs e)
		{
			int nums;
			if (!int.TryParse(comboBox1.Text, out nums))
			{
				e.Cancel = true;
				XtraMessageBox.Show("请输入正确的缴费期限!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}			 
		}

		private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
			if (e.Column.FieldName == "RC031")  //缴费类型
			{
				if (e.Value.ToString() == "1")
					e.DisplayText = "正常";
				else if (e.Value.ToString() == "0")
				{
					e.DisplayText = "原始登记";
				}
			}
		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			int nums;
			if (!int.TryParse(comboBox1.Text, out nums))
			{
				comboBox1.Focus();
				XtraMessageBox.Show("请输入正确的缴费期限!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (!(bitprice > 0))
			{
				XtraMessageBox.Show("参数传递错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string cuname = txtEdit_rc003.Text;
			string s_fa001 = MiscAction.GetEntityPK("FA01");
			string s_billno = string.Empty;

			int re = RegAction.RegisterPay(s_rc001, s_fa001, bitprice, nums, Envior.cur_user.UC001);
			if (re > 0)
			{
				dt_rc04.Rows.Clear();
				rc04Adapter.Fill(dt_rc04);

				if (XtraMessageBox.Show("缴费成功!现在打印【收据】吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
				{
					//Frm_InputBill frm_bill = new Frm_InputBill();
					//if (frm_bill.ShowDialog() == DialogResult.OK)
					//{
					//	s_billno = frm_bill.swapdata["billno"].ToString();
					//}
					//frm_bill.Dispose();
					//if (!string.IsNullOrEmpty(s_billno))
					//{
					PrintAction.Print_Skpz1(s_fa001);
					//	MiscAction.SetFinanceBill(s_fa001, s_billno);
					//}
				}

				///todo 4 打印缴费记录
				if(XtraMessageBox.Show("现在打印缴费记录吗?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
					PrintAction.Print_PayRecord(s_fa001);

				DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}