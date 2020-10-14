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
using DevExpress.XtraPrinting;

namespace Lime.BusinessObject
{
	public partial class Report_Hhzm : BaseBusiness
	{
		private DataTable dt_report = new DataTable("");
  
		private OracleDataAdapter repAdapter =
			new OracleDataAdapter("select * from v_report_hhzm where (fc200 between :begin and :end) ", SqlHelper.conn);
		 
		private OracleParameter op_begin = null;
		private OracleParameter op_end = null;


		public Report_Hhzm()
		{
			InitializeComponent();
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
		}

		private void Report_Hhzm_Load(object sender, EventArgs e)
		{
			op_begin = new OracleParameter("begin", OracleDbType.Varchar2, 20);
			op_begin.Direction = ParameterDirection.Input;

			op_end = new OracleParameter("end", OracleDbType.Varchar2, 20);
			op_end.Direction = ParameterDirection.Input;

			repAdapter.SelectCommand.Parameters.AddRange(new OracleParameter[] { op_begin, op_end });			 
			gridControl1.DataSource = dt_report;
	 
		}
		/// <summary>
		/// 查询条件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
				dt_report.Rows.Clear();

				repAdapter.Fill(dt_report);			 
				gridView1.EndUpdate();
				this.Cursor = Cursors.Arrow;
			}
			frm_1.Dispose();
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
		/// <summary>
		/// 刷新
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.RefreshData();
		}

		private void RefreshData()
		{
			this.Cursor = Cursors.WaitCursor;
 
			gridView1.BeginUpdate();
			dt_report.Rows.Clear();

			repAdapter.Fill(dt_report);			 
			gridView1.EndUpdate();

			this.Cursor = Cursors.Arrow;
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
	}
}
