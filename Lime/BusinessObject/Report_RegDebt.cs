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
	public partial class Report_RegDebt : BaseBusiness
	{
		private DataTable dt_source = new DataTable();
		private OracleDataAdapter dtAdapter = new OracleDataAdapter("select * from v_reg_debt where diff between :begin and :end", SqlHelper.conn);
		private OracleParameter op_begin = null;
		private OracleParameter op_end = null;
		public Report_RegDebt()
		{
			InitializeComponent();
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
		}

		private void Report_RegDebt_Load(object sender, EventArgs e)
		{
			op_begin = new OracleParameter("begin", OracleDbType.Int32);
			op_begin.Direction = ParameterDirection.Input;

			op_end = new OracleParameter("end", OracleDbType.Int32);
			op_end.Direction = ParameterDirection.Input;
			dtAdapter.SelectCommand.Parameters.AddRange(new OracleParameter[] { op_begin, op_end });

			gridControl1.DataSource = dt_source;
		}

		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Frm_ReportDebt frm_1 = new Frm_ReportDebt();
			if (frm_1.ShowDialog() == DialogResult.OK)
			{
				switch (frm_1.swapdata["type"].ToString())
				{
					case "全部":
						op_begin.Value = 0;
						op_end.Value = 9999;
						break;
					case "一年之内":
						op_begin.Value = 0;
						op_end.Value = 12;
						break;
					case "三年之内":
						op_begin.Value = 0;
						op_end.Value = 36;
						break;
					case "三年以上":
						op_begin.Value = 36;
						op_end.Value = 9999;
						break;
				}

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
			dt_source.Rows.Clear();
			dtAdapter.Fill(dt_source);
			gridView1.EndUpdate();
			this.Cursor = Cursors.Arrow;
		}

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
	}
}
