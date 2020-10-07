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
using Oracle.ManagedDataAccess.Client;
using Lime.Action;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Lime.Misc;
using DevExpress.XtraPrinting;

namespace Lime.BusinessObject
{
	public partial class RegisterBrow : BaseBusiness
	{
		private DataTable dt_rc01 = new DataTable("RC01");
		private OracleDataAdapter rc01Adapter = new OracleDataAdapter("",SqlHelper.conn);

		public RegisterBrow()
		{
			InitializeComponent();
			gridControl1.DataSource = dt_rc01;
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
		}
		/// <summary>
		/// 装入事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RegisterBrow_Load(object sender, EventArgs e)
		{
			this.DoSearch(barEditItem1.EditValue.ToString());
		}

		private void barHeaderItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{

		}
		/// <summary>
		/// 外来寄存
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Frm_Register frm_1 = new Frm_Register();
			frm_1.swapdata["source"] = "1";   //来源 1-外来寄存
			if(frm_1.ShowDialog() == DialogResult.OK)
			{
				this.RefreshData();
			}
			frm_1.Dispose();
		}
		/// <summary>
		/// 执行查询
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
		/// 执行查询
		/// </summary>
		/// <param name="action"></param>
		private void DoSearch(string action)
		{
			switch (action)
			{
				case "今日登记":
					rc01Adapter.SelectCommand.CommandText = "select * from v_rc01_list where trunc(rc200) = trunc(sysdate)  ";
					break;
				case "近三日登记":
					rc01Adapter.SelectCommand.CommandText = "select * from v_rc01_list where (trunc(sysdate) - trunc(rc200)) <=2  ";
					break;
				case "一个月内登记":
					rc01Adapter.SelectCommand.CommandText = "select * from v_rc01_list where (trunc(sysdate) - trunc(rc200)) <=30  ";
					break;
				case "条件查询":
					break; 
			}

			this.Cursor = Cursors.WaitCursor;
			gridView1.BeginUpdate();
			dt_rc01.Rows.Clear();
			rc01Adapter.Fill(dt_rc01);
			gridView1.EndUpdate();
			this.Cursor = Cursors.Arrow;
		}
		/// <summary>
		/// 刷新
		/// </summary>
		private void RefreshData()
		{
			DoSearch(barEditItem1.EditValue.ToString());
		}
		/// <summary>
		/// 本馆火化寄存
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Frm_RegFromFire frm_1 = new Frm_RegFromFire();
			if(frm_1.ShowDialog() == DialogResult.OK)
			{
				string s_ac001 = frm_1.swapdata["ac001"].ToString();
				Frm_Register frm_reg = new Frm_Register();
				frm_reg.swapdata["source"] = "0";      //来源为 本馆火化
				frm_reg.swapdata["rc001"] = s_ac001;  //逝者编号
				if(frm_reg.ShowDialog() == DialogResult.OK)
				{
					this.RefreshData();
				}
				frm_reg.Dispose();
			}
			frm_1.Dispose();
		}
		/// <summary>
		/// 修改寄存记录
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int rowHandle = gridView1.FocusedRowHandle;
			if (rowHandle >= 0)
			{
				this.Modify(rowHandle);
			}
		}
		
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
		/// 修改寄存记录
		/// </summary>
		/// <param name="rowHandle"></param>
		private void Modify(int rowHandle)
		{
			string s_rc001 = gridView1.GetRowCellValue(rowHandle, "RC001").ToString();

			Frm_RegisterEdit frm_edit = new Frm_RegisterEdit(); 
			frm_edit.swapdata["rc001"] = s_rc001;
			if (frm_edit.ShowDialog() == DialogResult.OK)
			{
				this.RefreshData();
			}
		}
		/// <summary>
		/// 缴费
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int rowHandle = gridView1.FocusedRowHandle;
			if (rowHandle >= 0)
			{
				Frm_RegisterPay frm_pay = new Frm_RegisterPay();
				frm_pay.swapdata["rc001"] = gridView1.GetRowCellValue(rowHandle, "RC001");
				if (frm_pay.ShowDialog() == DialogResult.OK)
				{
					this.RefreshData();
				}
				frm_pay.Dispose();
			}
		}
		/// <summary>
		/// 刷新
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.RefreshData();
		}
		/// <summary>
		/// 快速查找
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barEditItem2_EditValueChanged(object sender, EventArgs e)
		{
			string s_sql = string.Empty;
			string s_text = te_quicksearch.EditValue.ToString();

			if (s_text.Length == 4 || (s_text.Length == 5 && s_text.Contains("-")))   //号位查询
			{
				s_sql = "select * from v_rc01_list r where exists(select 1 from bi01 b where r.rc130 = b.bi001 and bi003 ='" + s_text + "')";
			}
			else if (Tool.IsHZ(s_text))
			{
				s_sql = "select * from v_rc01_list r where rc003 like '" + s_text + "%'";
			}
			else if (s_text.Length > 4)
			{
				s_sql = "select * from v_rc01_list r where rc109 like '" + s_text + "%'";
			}

			if (!string.IsNullOrEmpty(s_sql))
			{
				rc01Adapter.SelectCommand.CommandText = s_sql;
				this.Cursor = Cursors.WaitCursor;
				gridView1.BeginUpdate();
				dt_rc01.Rows.Clear();
				rc01Adapter.Fill(dt_rc01);
				gridView1.EndUpdate();
				this.Cursor = Cursors.Arrow;
			}
		}
		/// <summary>
		/// 位置变更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int rowHandle = gridView1.FocusedRowHandle;
			if (rowHandle >= 0)
			{
				Frm_RegMove frm_move = new Frm_RegMove();
				frm_move.swapdata["rc001"] = gridView1.GetRowCellValue(rowHandle, "RC001");
				if (frm_move.ShowDialog() == DialogResult.OK)
				{
					this.RefreshData();
				}
				frm_move.Dispose();
			}
		}
		/// <summary>
		/// 导出excel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
		/// 寄存迁出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int rowHandle = gridView1.FocusedRowHandle;
			if (rowHandle >= 0)
			{
				string s_rc001 = gridView1.GetRowCellValue(rowHandle, "RC001").ToString();
				Frm_RegOut frm_out = new Frm_RegOut();
				frm_out.swapdata["rc001"] = s_rc001;

				if (frm_out.ShowDialog() == DialogResult.OK)
				{
					this.RefreshData();
				}
				frm_out.Dispose();
			}
		}
		/// <summary>
		/// 补打寄存证
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int rowHandle = gridView1.FocusedRowHandle;
			string s_rc001 = string.Empty;
			if(rowHandle >= 0)
			{
				s_rc001 = gridView1.GetRowCellValue(rowHandle, "RC001").ToString();
				XtraMessageBox.Show("现在准备打印!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				PrintAction.Print_RegCardBase(s_rc001);
			}
		}
		/// <summary>
		/// 补打安放卡
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int rowHandle = gridView1.FocusedRowHandle;
			string s_rc001 = string.Empty;
			if (rowHandle >= 0)
			{
				s_rc001 = gridView1.GetRowCellValue(rowHandle, "RC001").ToString();
				XtraMessageBox.Show("现在准备打印!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				PrintAction.Print_RegSettle(s_rc001);
			}
		}
		/// <summary>
		/// 打印续费记录
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int rowHandle = gridView1.FocusedRowHandle;
			if (rowHandle >= 0)
			{
				string s_rc001 = gridView1.GetRowCellValue(rowHandle, "RC001").ToString();
				Frm_PrtPayRecord frm_payrec = new Frm_PrtPayRecord();
				frm_payrec.swapdata["rc001"] = s_rc001;

				frm_payrec.ShowDialog();
				frm_payrec.Dispose();
			}
		}
	}
}
