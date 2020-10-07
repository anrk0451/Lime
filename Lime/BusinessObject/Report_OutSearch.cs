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
using DevExpress.XtraPrinting;
using Lime.Windows;

namespace Lime.BusinessObject
{
	public partial class Report_OutSearch : BaseBusiness
	{
		private DataTable dt_out = new DataTable();
		private OracleDataAdapter outAdapter =
			new OracleDataAdapter("select * from v_outreport where to_char(oc002,'yyyy-mm-dd') between :begin and :end and rc003 like :rc003", SqlHelper.conn);

		private OracleParameter op_begin = null;
		private OracleParameter op_end = null;
		private OracleParameter op_rc003 = null;

		public Report_OutSearch()
		{
			InitializeComponent();
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;	
		}

		private void Report_OutSearch_Load(object sender, EventArgs e)
		{
			op_begin = new OracleParameter("begin", OracleDbType.Varchar2, 20);
			op_begin.Direction = ParameterDirection.Input;

			op_end = new OracleParameter("end", OracleDbType.Varchar2, 20);
			op_end.Direction = ParameterDirection.Input;

			op_rc003 = new OracleParameter("rc003", OracleDbType.Varchar2, 20);
			op_rc003.Direction = ParameterDirection.Input;

			outAdapter.SelectCommand.Parameters.AddRange(new OracleParameter[] { op_begin, op_end, op_rc003 });

			gridControl1.DataSource = dt_out;

			//this.DisplayCondition();
		}

		/// <summary>
		/// 显示条件窗口
		/// </summary>
		private void DisplayCondition()
		{
			Frm_ReportOut frm_co = new Frm_ReportOut();
			frm_co.swapdata["BusinessObject"] = this;

			if (frm_co.ShowDialog() == DialogResult.OK)
			{
				string s_begin = string.Empty;
				string s_end = string.Empty;
				string s_rc003 = string.Empty;

				if (frm_co.swapdata["dbegin"] == null || frm_co.swapdata["dbegin"] is System.DBNull)
				{
					s_begin = "1900/01/01";
				}
				else
				{
					s_begin = Convert.ToDateTime(frm_co.swapdata["dbegin"]).ToString("yyyy/MM/dd");
				}

				if (frm_co.swapdata["dend"] == null || frm_co.swapdata["dend"] is System.DBNull)
				{
					s_end = "9999/12/31";
				}
				else
				{
					s_end = Convert.ToDateTime(frm_co.swapdata["dend"]).ToString("yyyy/MM/dd");
				}

				if (frm_co.swapdata["rc003"] == null || string.IsNullOrEmpty(frm_co.swapdata["rc003"].ToString()))
				{
					s_rc003 = "%";
				}
				else
				{
					s_rc003 = frm_co.swapdata["rc003"].ToString() + "%";
				}

				frm_co.Dispose();

				op_begin.Value = s_begin;
				op_end.Value = s_end;
				op_rc003.Value = s_rc003;

				this.Cursor = Cursors.WaitCursor;
				gridView1.BeginUpdate();
				dt_out.Rows.Clear();
				outAdapter.Fill(dt_out);
				gridView1.EndUpdate();
				this.Cursor = Cursors.Arrow;
			}
		}
		/// <summary>
		/// 查询条件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.DisplayCondition();
		}
		/// <summary>
		/// 刷新	
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			gridView1.BeginUpdate();
			dt_out.Clear();
			outAdapter.Fill(dt_out);
			gridView1.EndUpdate();
			this.Cursor = Cursors.Arrow;
		}
		/// <summary>
		/// 导出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

		private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int rowHandle = gridView1.FocusedRowHandle;
			string s_rc001 = string.Empty;
			if (rowHandle >= 0)
			{
				XtraMessageBox.Show("现在准备打印!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				s_rc001 = gridView1.GetRowCellValue(rowHandle, "RC001").ToString();
				PrintAction.Print_OutCard(s_rc001); 
			}
		}
	}
}
