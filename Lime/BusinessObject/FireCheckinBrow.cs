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
using DevExpress.Data.Filtering;
using Lime.Misc;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Emf;
using Lime.Windows;
using Lime.Xpo.orcl;
using DevExpress.Xpo;
using DevExpress.XtraPrinting;

namespace Lime.BusinessObject
{
	/// <summary>
	/// 进灵登记浏览
	/// </summary>
	public partial class FireCheckinBrow : BaseBusiness
	{
		private DataTable dt_uc01 = new DataTable("UC01");
		private OracleDataAdapter uc01_adapter = new OracleDataAdapter("select * from uc01 where status <> '0' ", SqlHelper.conn);
		private DataTable dt_st01 = new DataTable("ST01");
		private OracleDataAdapter st01_adapter = new OracleDataAdapter("select * from st01 where st002 in ('ASHHANDLE')", SqlHelper.conn);

		public FireCheckinBrow()
		{
			InitializeComponent();
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
		}

		private void FireCheckinBrow_Load(object sender, EventArgs e)
		{
			//操作员
			uc01_adapter.Fill(dt_uc01);
			lookup_ac100.DataSource = dt_uc01;
			lookup_ac100.DisplayMember = "UC003";
			lookup_ac100.ValueMember = "UC001";

			st01_adapter.Fill(dt_st01);
			lookup_ac006.DataSource = dt_st01;
			lookup_ac006.DisplayMember = "ST003";
			lookup_ac006.ValueMember = "ST001";

			this.DoSearch(barEditItem1.EditValue.ToString());

		}
		/// <summary>
		/// 执行查询
		/// </summary>
		/// <param name="action"></param>
		private void DoSearch(string action)
		{
			CriteriaOperator criteria = null;
			switch (action)
			{
				case "今日登记":
					criteria = CriteriaOperator.Parse("AC200 >=?" , MiscAction.GetServerTime().Date);					 
					break;
				case "近三日登记":
					criteria = CriteriaOperator.Parse("AC200 >=? ", MiscAction.GetServerTime().Date.AddDays(-2));
					break;
				case "一个月内登记":
					criteria = CriteriaOperator.Parse("AC200 >=? ", MiscAction.GetServerTime().Date.AddDays(-29));
					break;
			}
			xpCollection_ac01.Criteria = criteria;
			xpCollection_ac01.LoadingEnabled = true;
		}
		/// <summary>
		/// 按时间范围检索
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barEditItem1_EditValueChanged(object sender, EventArgs e)
		{
			if (barEditItem1.EditValue != null && !string.IsNullOrWhiteSpace(barEditItem1.EditValue.ToString()))
			{
				DoSearch(barEditItem1.EditValue.ToString());
			}
		}
		/// <summary>
		/// 代码文本转换
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
			if (e.Column.FieldName == "AC002")
			{
				if (e.Value.ToString() == "0")
					e.DisplayText = "男";
				else if (e.Value.ToString() == "1")
					e.DisplayText = "女";
				else
					e.DisplayText = "未知";
			}
		}
		/// <summary>
		/// 双击编辑
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_MouseDown(object sender, MouseEventArgs e)
		{
			GridHitInfo hInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));
			if (e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				//判断光标是否在行范围内  
				if (hInfo.InRow)
				{
					Modify(gridView1.FocusedRowHandle);
				}
			}
		}
		/// <summary>
		/// 更新
		/// </summary>
		/// <param name="rowHandle"></param>
		private void Modify(int rowHandle)
		{
			if(rowHandle >= 0)
			{
				Frm_FireCheckin frm_1 = new Frm_FireCheckin();
				AC01 ac01 = xpCollection_ac01[gridView1.GetDataSourceRowIndex(rowHandle)] as AC01;
				frm_1.swapdata["ac001"] = gridView1.GetRowCellValue(rowHandle, "AC001").ToString();
				if(frm_1.ShowDialog() == DialogResult.OK)
				{
					ac01.Reload();
				}
				frm_1.Dispose();
			}
			
		}
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int rowHandle = gridView1.FocusedRowHandle; ;
			if (rowHandle < 0) return;
			 
			string s_ac001 = gridView1.GetRowCellValue(rowHandle, "AC001").ToString();
			if (MessageBox.Show("确认要删除登记信息吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel) return;

			if (FireAction.RemoveFireCheckin(s_ac001, Envior.cur_user.UC001) > 0)
			{
				XtraMessageBox.Show("删除成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				AC01 ac01 = xpCollection_ac01[gridView1.GetDataSourceRowIndex(rowHandle)] as AC01;
				ac01.Reload();
			}
		}
		/// <summary>
		/// 刷新数据
		/// </summary>
		private void RefreshData()
		{
			this.Cursor = Cursors.WaitCursor;
			gridView1.BeginUpdate();
			UnitOfWork unitOfWork = new UnitOfWork();

			xpCollection_ac01.Session = unitOfWork;
			xpCollection_ac01.Reload();

			gridView1.EndUpdate();
			this.Cursor = Cursors.Arrow;
		}
		/// <summary>
		/// 导出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Frm_FireCheckin frm_1 = new Frm_FireCheckin();
			if(frm_1.ShowDialog() == DialogResult.OK)
			{
				AC01 ac01 = frm_1.swapdata["ac01"] as AC01;
				AC01 ac01_2 = unitOfWork1.GetObjectByKey<AC01>(ac01.AC001);
				xpCollection_ac01.Add(ac01_2);
			}
			frm_1.Dispose();
		}
		/// <summary>
		/// 业务办理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int rowHandle = gridView1.FocusedRowHandle;
			if (rowHandle < 0) return;

			string s_ac001 = gridView1.GetRowCellValue(rowHandle, "AC001").ToString();
			(Envior.mform as Frm_main).openBusinessObject("FireBusiness", s_ac001);
		}
		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.Modify(gridView1.FocusedRowHandle);
		}
	}
}
