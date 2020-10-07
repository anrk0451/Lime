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
using Lime.Misc;

namespace Lime.BusinessObject
{
	public partial class DataDict : BaseBusiness
	{

		private int i_sel_index;

		public DataDict()
		{
			InitializeComponent();
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
		}
		private void DataDict_Load(object sender, EventArgs e)
		{
			imageListBoxControl1.SetSelected(0, true);
			gridView1.Columns["SORTID"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
		}

		/// <summary>
		/// 类别选择改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void imageListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			i_sel_index = imageListBoxControl1.SelectedIndex;
			CriteriaOperator filter = CriteriaOperator.Parse("ST002='" + GetDataTypeByIndex(i_sel_index) + "'");
			xpCollection1.Filter = filter;
			 
		}

		private string GetDataTypeByIndex(int index)
		{
			string result = string.Empty;
			switch (index)
			{
				case 0:
					result = "DIEREASON";
					break;
				case 1:
					result = "DISTRICT";
					break;				 
				case 2:
					result = "RELATION";
					break;
				case 3:
					result = "ASHHANDLE";
					break;
				case 4:
					result = "OUTREASON";
					break;
				case 5:
					result = "FREMOVE_REASON";
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
			gridView1.FocusedColumn = gridView1.Columns["ST003"];
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
			string s_st001 = MiscAction.GetEntityPK("ST01");
			gridView1.SetRowCellValue(e.RowHandle, "ST002", GetDataTypeByIndex(i_sel_index));
			gridView1.SetRowCellValue(e.RowHandle, "ST001", s_st001);
			gridView1.SetRowCellValue(e.RowHandle, "STATUS", "1");
			gridView1.SetRowCellValue(e.RowHandle, "SORTID", Convert.ToInt32(s_st001));
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
			if (colName.Equals("ST003"))       //数据项值
			{
				if (String.IsNullOrEmpty(e.Value.ToString()))
				{
					e.Valid = false;
					e.ErrorText = "数据项值不能为空!";
				}
				else
				{
					for (int i = 0; i < gridView1.RowCount - 1; i++)
					{
						if (i == (sender as ColumnView).FocusedRowHandle) continue;
						if (gridView1.GetRowCellValue(i, "ST003") == null) continue;

						//如果名字相同,则校验不通过!                        
						if (String.Equals(gridView1.GetRowCellValue(i, "ST003").ToString(), e.Value.ToString()))
						{
							e.Valid = false;
							e.ErrorText = "值已经存在!";
							break;
						}
					}
				}
			}
		}
		/// <summary>
		/// 行校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
		{
			if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ST003") == null || string.IsNullOrEmpty(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ST003").ToString()))
			{
				e.Valid = false;
				(sender as ColumnView).SetColumnError(gridView1.Columns["ST003"], "数据项不能为空!");
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
			unitOfWork1 = xpCollection1.Session as UnitOfWork;

			gridView1.EndUpdate();
			this.Cursor = Cursors.Arrow;
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
				XtraMessageBox.Show("保存成功!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			catch (Exception ee)
			{
				unitOfWork1.RollbackTransaction();
				LogUtils.Error(ee.Message);
				XtraMessageBox.Show(ee.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
	}
}
