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
using DevExpress.XtraPrinting;

namespace Lime.BusinessObject
{
	public partial class Report_ClassStat : BaseBusiness
	{
		private DataTable dt_cs = new DataTable();
		private OracleDataAdapter csAdapter =
			new OracleDataAdapter("select * from v_classStat order by cs01", SqlHelper.conn);

		private string s_begin = string.Empty;
		private string s_end = string.Empty;
		private string[] classArry;

		public Report_ClassStat()
		{
			InitializeComponent();
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
		}

		private void Report_ClassStat_Load(object sender, EventArgs e)
		{
			gridControl1.DataSource = dt_cs;
		}

		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Frm_Report_ClassStat frm_stat = new Frm_Report_ClassStat();

			if (frm_stat.ShowDialog() == DialogResult.OK)
			{
				classArry = frm_stat.swapdata["class"] as string[];

				if (frm_stat.swapdata["dbegin"] == null || frm_stat.swapdata["dbegin"] is System.DBNull)
				{
					s_begin = "1900-01-01";
				}
				else
				{
					s_begin = Convert.ToDateTime(frm_stat.swapdata["dbegin"]).ToString("yyyy-MM-dd");
				}

				if (frm_stat.swapdata["dend"] == null || frm_stat.swapdata["dend"] is System.DBNull)
				{
					s_end = "9999-12-31";
				}
				else
				{
					s_end = Convert.ToDateTime(frm_stat.swapdata["dend"]).ToString("yyyy-MM-dd");
				}

				this.RefreshData();
			}
			frm_stat.Dispose();
		}

		/// <summary>
		/// 刷新数据
		/// </summary>
		private void RefreshData()
		{
			this.Cursor = Cursors.WaitCursor;
			int re = MiscAction.ClassStat(s_begin, s_end, classArry);
			if (re > 0)
			{
				gridView1.BeginUpdate();
				dt_cs.Rows.Clear();
				csAdapter.Fill(dt_cs);

				gridColumn3.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
				gridColumn3.SummaryItem.DisplayFormat = "合计 = {0:N2}";

				bs_bs.Caption = "           共有收费笔数:" + MiscAction.GetClassStat_BS().ToString() + "笔";

				gridView1.EndUpdate();

			}
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
