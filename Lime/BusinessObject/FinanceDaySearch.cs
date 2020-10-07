using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Lime.BaseObject;
using Lime.Action;
using Oracle.ManagedDataAccess.Client;
using Lime.Windows;
using Lime.Misc;

namespace Lime.BusinessObject
{
	public partial class FinanceDaySearch : BaseBusiness
	{
		private DataTable dt_finance = new DataTable("FINANCE");
		private OracleDataAdapter finAdapter =
			new OracleDataAdapter("select * from v_financeDay where (to_char(fa200,'yyyy-mm-dd') between :begin and :end) and fa003 like :fa003 and fa100 like :fa100 ", SqlHelper.conn);

		private DataTable dt_detail = new DataTable("DETAIL");
		private OracleDataAdapter deAdapter =
			new OracleDataAdapter("select * from v_findetail where sa010 = :sa010", SqlHelper.conn);

		private OracleParameter op_begin = null;
		private OracleParameter op_end = null;
		private OracleParameter op_fa003 = null;
		private OracleParameter op_fa100 = null;

		private OracleParameter op_sa010 = null;

		public FinanceDaySearch()
		{
			InitializeComponent();
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;

			op_begin = new OracleParameter("begin", OracleDbType.Varchar2, 20);
			op_begin.Direction = ParameterDirection.Input;

			op_end = new OracleParameter("end", OracleDbType.Varchar2, 20);
			op_end.Direction = ParameterDirection.Input;

			op_fa003 = new OracleParameter("fa003", OracleDbType.Varchar2, 80);
			op_fa003.Direction = ParameterDirection.Input;


			op_fa100 = new OracleParameter("fa100", OracleDbType.Varchar2, 10);
			op_fa100.Direction = ParameterDirection.Input;

			op_sa010 = new OracleParameter("sa010", OracleDbType.Varchar2, 10);
			op_sa010.Direction = ParameterDirection.Input;

			finAdapter.SelectCommand.Parameters.AddRange(new OracleParameter[] { op_begin, op_end, op_fa003, op_fa100 });
			deAdapter.SelectCommand.Parameters.AddRange(new OracleParameter[] { op_sa010 });

			gridControl1.DataSource = dt_finance;
			gridControl2.DataSource = dt_detail;
		}
		/// <summary>
		/// 查询条件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Frm_FinSearch frm_1 = new Frm_FinSearch();
			if (frm_1.ShowDialog() == DialogResult.OK)
			{
				string s_begin = string.Empty;
				string s_end = string.Empty;
				string s_fa003 = string.Empty;
				string s_fa100 = string.Empty;

				if (frm_1.swapdata["dbegin"] == null)
				{
					s_begin = "1900/01/01";
				}
				else
				{
					s_begin = Convert.ToDateTime(frm_1.swapdata["dbegin"]).ToString("yyyy/MM/dd");
				}

				if (frm_1.swapdata["dend"] == null)
				{
					s_end = "9999/12/31";
				}
				else
				{
					s_end = Convert.ToDateTime(frm_1.swapdata["dend"]).ToString("yyyy/MM/dd");
				}

				if (frm_1.swapdata["fa003"] == null || string.IsNullOrEmpty(frm_1.swapdata["fa003"].ToString()))
				{
					s_fa003 = "%";
				}
				else
				{
					s_fa003 = frm_1.swapdata["fa003"].ToString() + "%";
				}

				if (frm_1.swapdata["fa100"] == null)
				{
					s_fa100 = "%";
				}
				else
				{
					s_fa100 = frm_1.swapdata["fa100"].ToString();
				}


				op_begin.Value = s_begin;
				op_end.Value = s_end;
				op_fa003.Value = s_fa003;
				op_fa100.Value = s_fa100;
 

				this.Cursor = Cursors.WaitCursor;


				//////1.按收费笔数检索
				gridView1.BeginUpdate();
				dt_finance.Rows.Clear();

				finAdapter.Fill(dt_finance);

				gridCol_Fa004.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
				gridCol_Fa004.SummaryItem.DisplayFormat = "合计 = {0:N2}";

				gridColumn5.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
				gridColumn5.SummaryItem.DisplayFormat = "共计 = {0:N0}笔";

				gridView1.EndUpdate();
				this.Cursor = Cursors.Arrow;
			}
			frm_1.Dispose();
			this.OnlyMe_Filter();
		}

		private void OnlyMe_Filter()
		{
			if (Convert.ToBoolean(toggle_onlyme.EditValue))
			{
				gridView1.ActiveFilterString = "FA100 = '" + Envior.cur_user.UC001 + "'";
			}
			else
			{
				gridView1.ActiveFilter.Clear();
			}
		}
		/// <summary>
		/// 过滤“只看自己”
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toggle_onlyme_EditValueChanged(object sender, EventArgs e)
		{
			this.OnlyMe_Filter();
		}
		/// <summary>
		/// 检索明细
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			if (e.FocusedRowHandle >= 0)
			{
				this.RetrieveDetail(e.FocusedRowHandle);
			}
		}

		/// <summary>
		/// 检索明细
		/// </summary>
		/// <param name="rowHandle"></param>
		private void RetrieveDetail(int rowHandle)
		{
			if (rowHandle >= 0)
			{
				string s_fa001 = gridView1.GetRowCellValue(rowHandle, "FA001").ToString();
				op_sa010.Value = s_fa001;
				gridView2.BeginUpdate();
				dt_detail.Rows.Clear();
				deAdapter.Fill(dt_detail);
				gridView2.EndUpdate();
			}
		}
		/// <summary>
		/// 补打收据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int rowHandle = gridView1.FocusedRowHandle;
			if(rowHandle >= 0)
			{
				string s_fa002 = gridView1.GetRowCellValue(rowHandle, "FA002").ToString();
				string s_fa001 = gridView1.GetRowCellValue(rowHandle, "FA001").ToString();

				XtraMessageBox.Show("现在准备开始打印!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				if (s_fa002 == "0" || s_fa002 == "1")
					PrintAction.Print_Skpz0(s_fa001);
				else
					PrintAction.Print_Skpz1(s_fa001);
			}
		}
		/// <summary>
		/// 作废收费记录
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int rowHandle = gridView1.FocusedRowHandle;
			if(rowHandle >= 0)
			{
				if (XtraMessageBox.Show("确认要作废吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

				string s_reason = string.Empty;
				string s_rc001 = gridView1.GetRowCellValue(rowHandle, "AC001").ToString();
				string s_fa001 = gridView1.GetRowCellValue(rowHandle, "FA001").ToString();

				Frm_FinRemoveReason frm_reason = new Frm_FinRemoveReason();
				if (frm_reason.ShowDialog() == DialogResult.OK)
				{
					s_reason = frm_reason.swapdata["reason"].ToString();
				}
				frm_reason.Dispose();

				if (gridView1.GetRowCellValue(rowHandle, "FA002").ToString() == "2")  //寄存业务
				{

					decimal count = (decimal)SqlHelper.ExecuteScalar("select count(*) from v_rc04 where rc001='" + s_rc001 + "'");
					if (count <= 1)
					{
						if (XtraMessageBox.Show("此记录是唯一一次交费记录,作废此记录将删除寄存登记信息,是否继续?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
					}
				}

				if(MiscAction.FinanceRemove(s_fa001, s_reason, Envior.cur_user.UC001) >0)
				{
					XtraMessageBox.Show("作废成功!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
					gridView1.DeleteRow(rowHandle);
				}
				


			}
		}
	}
}	
