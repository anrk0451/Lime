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
using DevExpress.Data.Filtering;
using Lime.Action;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Xpo;
using DevExpress.XtraPrinting;
using Lime.Misc;

namespace Lime.BusinessObject
{
	public partial class SalesItemInfo : BaseBusiness
	{
		private int i_sel_index;   //类别索引
		public SalesItemInfo()
		{
			InitializeComponent();
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
		}

		private void SalesItemInfo_Load(object sender, EventArgs e)
		{
			imageListBoxControl1.SetSelected(0, true);
			gridView1.Columns["SORTID"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
		}
		/// <summary>
		/// 类别选择事件响应
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void imageListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			i_sel_index = imageListBoxControl1.SelectedIndex;
			CriteriaOperator filter = CriteriaOperator.Parse("SI002='" + GetServiceType(i_sel_index) + "'");
			xpCollection1.Filter = filter;
		}
		/// <summary>
		/// 类别索引对照
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		private string GetServiceType(int index)
		{
			string result = string.Empty;
			switch (index)
			{
				case 0:  //守灵厅
					result = "01";
					break;
				case 1:  //冷藏柜
					result = "02";
					break;
				case 2:  //休息室
					result = "03";
					break;
				case 3:  //告别厅
					result = "04";
					break;
				case 4:  //殡仪服务
					result = "05";
					break;
				case 5:  //火化
					result = "06";
					break;
				case 6:  //灵车
					result = "07";
					break;
				case 7:  //谷类
					result = "10";
					break;
				case 8:  //纸类
					result = "11";
					break;
				case 9:  //祭品
					result = "12";
					break;
				case 10:  //寄存附品
					result = "13";
					break;
			}
			return result;
		}
		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			gridView1.AddNewRow();
			int rowno = gridView1.FocusedRowHandle;
			/////// 设置焦点 开始编辑 !!!
			gridView1.FocusedColumn = gridView1.Columns["SI003"];
			gridView1.ShowEditor();
		}
		/// <summary>
		/// 新行初始化
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
		{
			//// 初始化新行时触发(当在新行中)
			string s_si001 = MiscAction.GetEntityPK("SI01");
			gridView1.SetRowCellValue(e.RowHandle, "SI002", GetServiceType(i_sel_index));
			gridView1.SetRowCellValue(e.RowHandle, "SI001", s_si001);
			gridView1.SetRowCellValue(e.RowHandle, "STATUS", "1");
			gridView1.SetRowCellValue(e.RowHandle, "SORTID", Convert.ToInt32(s_si001));
		}
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (gridView1.FocusedRowHandle >= 0)
			{
				if (XtraMessageBox.Show("确认要删除当前的记录吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
				{
					return;
				}

			}
			gridView1.SetFocusedRowCellValue("STATUS", "0");
			gridView1.UpdateCurrentRow();
		}
		/// <summary>
		/// 编辑校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
		{
			string colName = (sender as ColumnView).FocusedColumn.FieldName.ToUpper();
			if (colName.Equals("SI003"))       //名称
			{
				if (String.IsNullOrEmpty(e.Value.ToString()))
				{
					e.Valid = false;
					e.ErrorText = "名称不能为空!";
				}
				else
				{
					for (int i = 0; i < gridView1.RowCount - 1; i++)
					{
						if (i == (sender as ColumnView).FocusedRowHandle) continue;
						if (gridView1.GetRowCellValue(i, "SI003") == null) continue;

						//如果名字相同,则校验不通过!                        
						if (String.Equals(gridView1.GetRowCellValue(i, "SI003").ToString(), e.Value.ToString()))
						{
							e.Valid = false;
							e.ErrorText = "值已经存在!";
							break;
						}
					}
				}
			}else if (colName.Equals("PRICE"))   //单价
			{
				if (Decimal.Parse(e.Value.ToString()) < 0)
				{
					e.Valid = false;
					e.ErrorText = "单价不能小于0!";
				}
			}
		}
		/// <summary>
		/// 行验证
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
		{
			if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SI003") == null)
			{
				e.Valid = false;
				(sender as ColumnView).SetColumnError(gridView1.Columns["SI003"], "名称不能为空!");
			}
		}
		/// <summary>
		/// 上移
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int row = gridView1.FocusedRowHandle;
			if (row <= 0) return;

			int prior_sortId = int.Parse(gridView1.GetRowCellValue(row - 1, "SORTID").ToString());
			int cur_sortId = int.Parse(gridView1.GetRowCellValue(row, "SORTID").ToString());

			gridView1.SetRowCellValue(row, "SORTID", prior_sortId);
			gridView1.SetRowCellValue(row - 1, "SORTID", cur_sortId);
			gridView1.FocusedRowHandle = row - 1;
		}
		/// <summary>
		/// 下移
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int row = gridView1.FocusedRowHandle;
			if ((row >= gridView1.RowCount - 2) || row < 0) return;

			int next_sortId = int.Parse(gridView1.GetRowCellValue(row + 1, "SORTID").ToString());
			int cur_sortId = int.Parse(gridView1.GetRowCellValue(row, "SORTID").ToString());

			gridView1.SetRowCellValue(row, "SORTID", next_sortId);
			gridView1.SetRowCellValue(row + 1, "SORTID", cur_sortId);
			gridView1.FocusedRowHandle = row + 1;
		}
		/// <summary>
		/// 刷新
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			gridView1.BeginUpdate();
			UnitOfWork unitOfWork = new UnitOfWork();

			xpCollection1.Session = unitOfWork;
			xpCollection1.Reload();

			gridView1.EndUpdate();
			this.Cursor = Cursors.Arrow;
		}
		/// <summary>
		/// 查找对话框
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (gridView1.IsFindPanelVisible)
				gridView1.HideFindPanel();
			else
				gridView1.ShowFindPanel();
		}
		/// <summary>
		/// 导出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
		/// 单元格修改事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			if (e.Column.FieldName == "SI003")
			{
				if (e.Value != System.DBNull.Value)
				{
					gridView1.SetFocusedRowCellValue("SI088", Tool.GetPYString(e.Value.ToString().Trim()));
				}
				else
				{
					gridView1.SetFocusedRowCellValue("SI088", System.DBNull.Value);
				}
			}
		}
		/// <summary>
		/// 保存
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (!gridView1.PostEditor()) return;
			if (!gridView1.UpdateCurrentRow()) return;

			try
			{
				unitOfWork1.CommitChanges();
				XtraMessageBox.Show("保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ee)
			{
				unitOfWork1.RollbackTransaction();
				LogUtils.Error(ee.Message);
				XtraMessageBox.Show(ee.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
