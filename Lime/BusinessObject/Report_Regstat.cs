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
using DevExpress.XtraPrinting;

namespace Lime.BusinessObject
{
	public partial class Report_Regstat : BaseBusiness
	{
		DataTable dt_regstat = new DataTable();
		OracleDataAdapter regAdapter = new OracleDataAdapter("select * from v_register where to_char(rc140,'yyyy-mm-dd') between :begin and :end", SqlHelper.conn);

		OracleParameter op_begin = new OracleParameter("begin", OracleDbType.Varchar2, 20);
		OracleParameter op_end = new OracleParameter("end", OracleDbType.Varchar2, 20);


		public Report_Regstat()
		{
			InitializeComponent();
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;

			op_end.Direction = ParameterDirection.Input;
			op_begin.Direction = ParameterDirection.Input;
			regAdapter.SelectCommand.Parameters.AddRange(new OracleParameter[] { op_begin, op_end });
			gridControl1.DataSource = dt_regstat;
		}

		/// <summary>
		/// 执行查询
		/// </summary>
		private void DoSearch()
		{
			Frm_Duration frm_1 = new Frm_Duration();
			frm_1.swapdata["MODE"] = "0";
			string s_begin = string.Empty;
			string s_end = string.Empty;
			if (frm_1.ShowDialog() == DialogResult.OK)
			{

				if (frm_1.swapdata["begin"] == null || frm_1.swapdata["begin"] is System.DBNull)
				{
					s_begin = "1900-01-01";
				}
				else
				{
					s_begin = Convert.ToDateTime(frm_1.swapdata["begin"]).ToString("yyyy-MM-dd");
				}

				if (frm_1.swapdata["end"] == null || frm_1.swapdata["end"] is System.DBNull)
				{
					s_end = "9999-12-31";
				}
				else
				{
					s_end = Convert.ToDateTime(frm_1.swapdata["end"]).ToString("yyyy-MM-dd");
				}

				op_begin.Value = s_begin;
				op_end.Value = s_end;

				this.RefreshData();
			}
			frm_1.Dispose();
		}


		/// <summary>
		/// 刷新数据
		/// </summary>
		private void RefreshData()
		{
			this.Cursor = Cursors.WaitCursor;
			gridView1.BeginUpdate();
			dt_regstat.Rows.Clear();
			regAdapter.Fill(dt_regstat);
			gridView1.EndUpdate();
			this.Cursor = Cursors.Arrow;
		}
		/// <summary>
		/// 查询条件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			DoSearch();
		}
		/// <summary>
		/// 刷新数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.RefreshData();
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

		private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
			if(e.Column.FieldName.ToUpper() == "RC002")
			{
				if (e.Value.ToString() == "0")
					e.DisplayText = "男";
				else if (e.Value.ToString() == "1")
					e.DisplayText = "女";
			}
		}

		private void Report_Regstat_Load(object sender, EventArgs e)
		{
			this.DoSearch();
		}
	}
}
