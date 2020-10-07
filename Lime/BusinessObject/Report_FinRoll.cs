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
using Oracle.ManagedDataAccess.Client;
using Lime.Action;
using Lime.Windows;

namespace Lime.BusinessObject
{
	public partial class Report_FinRoll : BaseBusiness
	{
		private DataTable dt_finance = new DataTable("FINANCE");
		private DataTable dt_invoice = new DataTable();

		private OracleDataAdapter finAdapter =
			new OracleDataAdapter("select * from v_financeRollback where (to_char(zfrq,'yyyy-mm-dd') between :begin and :end) ", SqlHelper.conn);
 
		private DataTable dt_detail = new DataTable("DETAIL");
		private OracleDataAdapter deAdapter =
			new OracleDataAdapter("select * from v_finremovedetail where sa010 = :sa010", SqlHelper.conn);
 
		private OracleParameter op_begin = null;
		private OracleParameter op_end = null;
		private OracleParameter op_sa010 = null;
  
		public Report_FinRoll()
		{
			InitializeComponent();
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
		}

		private void Report_FinRoll_Load(object sender, EventArgs e)
		{
			op_begin = new OracleParameter("begin", OracleDbType.Varchar2, 20);
			op_begin.Direction = ParameterDirection.Input;

			op_end = new OracleParameter("end", OracleDbType.Varchar2, 20);
			op_end.Direction = ParameterDirection.Input;

			op_sa010 = new OracleParameter("sa010", OracleDbType.Varchar2, 10);
			op_sa010.Direction = ParameterDirection.Input;
			 
			finAdapter.SelectCommand.Parameters.AddRange(new OracleParameter[] { op_begin, op_end });
			deAdapter.SelectCommand.Parameters.AddRange(new OracleParameter[] { op_sa010 });
 
			gridControl1.DataSource = dt_finance;
			gridControl2.DataSource = dt_detail;
		}

		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Frm_Duration frm_1 = new Frm_Duration();
			frm_1.swapdata["MODE"] = "2";

			if (frm_1.ShowDialog() == DialogResult.OK)
			{
				string s_begin = string.Empty;
				string s_end = string.Empty;

				if (frm_1.swapdata["begin"] == null)
				{
					s_begin = "1900-01-01";
				}
				else
				{
					s_begin = Convert.ToDateTime(frm_1.swapdata["begin"]).ToString("yyyy-MM-dd");
				}

				if (frm_1.swapdata["end"] == null)
				{
					s_end = "9999-12-31";
				}
				else
				{
					s_end = Convert.ToDateTime(frm_1.swapdata["end"]).ToString("yyyy-MM-dd");
				}


				op_begin.Value = s_begin;
				op_end.Value = s_end;

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
		}

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
		/// 查找
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (!gridView1.IsFindPanelVisible)
				gridView1.ShowFindPanel();
			else
				gridView1.HideFindPanel();
		}

		private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.RefreshData();
		}

		/// <summary>
		/// 刷新数据
		/// </summary>
		private void RefreshData()
		{
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

	}
}
