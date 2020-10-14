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
using Lime.Windows;
using Lime.Action;
using Oracle.ManagedDataAccess.Client;
using System.Xml;
using DevExpress.XtraPrinting;

namespace Lime.BusinessObject
{
	public partial class Report_Cashier : BaseBusiness
	{
		private string s_begin = string.Empty;
		private string s_end = string.Empty;

		private DataTable dt_cf = new DataTable();
		private OracleDataAdapter cfAdapter =
			new OracleDataAdapter("select * from v_cashier_stat", SqlHelper.conn);

		private DataTable dt_cashier_fa01 = new DataTable();
		private OracleDataAdapter fa01Adapter =
			new OracleDataAdapter("select * from v_fa01_cashier where fa100 = :fa100 and (to_char(fa200,'yyyy-mm-dd') between :begin and :end )", SqlHelper.conn);

		private OracleParameter op_begin = null;
		private OracleParameter op_end = null;
		private OracleParameter op_fa100 = null;



		public Report_Cashier()
		{
			InitializeComponent();
			gridView2.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
		}

		private void Report_Cashier_Load(object sender, EventArgs e)
		{
			op_begin = new OracleParameter("begin", OracleDbType.Varchar2, 20);
			op_begin.Direction = ParameterDirection.Input;

			op_end = new OracleParameter("end", OracleDbType.Varchar2, 20);
			op_end.Direction = ParameterDirection.Input;

			op_fa100 = new OracleParameter("fa100", OracleDbType.Varchar2, 10);
			op_fa100.Direction = ParameterDirection.Input;

			fa01Adapter.SelectCommand.Parameters.AddRange(new OracleParameter[] { op_fa100, op_begin, op_end  });

			gridControl1.DataSource = dt_cf;
			gridControl2.DataSource = dt_cashier_fa01;
		}

		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Frm_Duration frm_1 = new Frm_Duration();
			frm_1.swapdata["MODE"] = "1";

			if (frm_1.ShowDialog() == DialogResult.OK)
			{
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
				this.RefreshData();				 
			}
			frm_1.Dispose();
		}

		private void RefreshData()
		{
			this.Cursor = Cursors.WaitCursor;
			int re = MiscAction.CashierStat(s_begin, s_end);
			if (re > 0)
			{
				bandedGridView1.BeginUpdate();
				dt_cf.Rows.Clear();
				cfAdapter.Fill(dt_cf);

				gridColumn5.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
				gridColumn5.SummaryItem.DisplayFormat = "{0:N0}";

				bandedGridView1.EndUpdate();

			}
			this.Cursor = Cursors.Arrow;
		}

		private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{

			if (e.FocusedRowHandle>= 0)
			{
				string s_fa100 = bandedGridView1.GetRowCellValue(e.FocusedRowHandle, "FA100").ToString();
				op_fa100.Value = s_fa100;
				op_begin.Value = s_begin;
				op_end.Value = s_end;

				gridView2.BeginUpdate();
				dt_cashier_fa01.Rows.Clear();
				fa01Adapter.Fill(dt_cashier_fa01);
				gridView2.EndUpdate();
			}
		}
		/// <summary>
		/// 导出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			SaveFileDialog fileDialog = new SaveFileDialog();
			fileDialog.Title = "导出Excel";
			fileDialog.Filter = "Excel文件(*.xlsx)|*.xlsx";

			DialogResult dialogResult = fileDialog.ShowDialog(this);
			if (dialogResult == DialogResult.OK)
			{
				DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions();
				options.TextExportMode = TextExportMode.Text;//设置导出模式为文本
				gridControl1.ExportToXlsx(fileDialog.FileName, options);
				XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
			if (e.Column.FieldName.ToUpper() == "FA002")
			{
				if (e.Value.ToString() == "0")
					e.DisplayText = "火化业务";
				else if (e.Value.ToString() == "1")
					e.DisplayText = "临时销售";
				else if (e.Value.ToString() == "2")
					e.DisplayText = "寄存业务";
			}
			 
		}

		private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.RefreshData();
		}
	}
}
