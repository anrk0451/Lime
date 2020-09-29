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
using DevExpress.XtraGrid.Views.Grid;
using Lime.Action;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Data.Filtering;
using Lime.Xpo.orcl;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;
using Lime.Misc;

namespace Lime.BusinessObject
{
	public partial class Roles : BaseBusiness
	{
		public Roles()
		{
			InitializeComponent();
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
		}
		 
		 
		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
  
			RO01 ro01 = new RO01(unitOfWork1);
			ro01.RO001 = MiscAction.GetEntityPK("RO01");
			ro01.STATUS = "1";
			int rowHandle = gridView1.GetRowHandle(xpCollection1.Add(ro01));

			gridView1.FocusedRowHandle = rowHandle;
			gridView1.FocusedColumn = gridView1.Columns["RO003"];
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
			GridView view = sender as GridView;
			string ro001 = MiscAction.GetEntityPK("RO01");
			int currow = view.FocusedRowHandle;
			view.SetRowCellValue(e.RowHandle, view.Columns["RO001"], ro001);
			view.SetRowCellValue(e.RowHandle, view.Columns["STATUS"], "1");
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
				if(gridView1.GetFocusedRowCellValue("RO001").ToString() == App_Const.ADMIN_GROUP_ID)
				{
					XtraMessageBox.Show("内置角色,不能删除!","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					return;
				}
				if (XtraMessageBox.Show("确认要删除当前的记录吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
				{
					return;
				}

			}
			gridView1.SetFocusedRowCellValue("STATUS", "0");
			gridView1.UpdateCurrentRow();
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
			if (!this.CheckValidBeforeSave()) return;

			try
			{
				unitOfWork1.CommitChanges();
				XtraMessageBox.Show("保存成功!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			catch (Exception ee)
			{
				LogUtils.Error(ee.ToString());
				XtraMessageBox.Show(ee.ToString(),"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

		}
		/// <summary>
		/// 刷新
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			gridView1.BeginUpdate();


			unitOfWork1.Dispose();
			UnitOfWork unitOfWork = new UnitOfWork();

			xpCollection1.Session = unitOfWork;
			xpCollection1.Reload();
			unitOfWork1 = xpCollection1.Session as UnitOfWork;

			gridView1.EndUpdate();
			this.Cursor = Cursors.Arrow;
		}

		/// <summary>
		/// 编辑校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
		{
			string colName = (sender as ColumnView).FocusedColumn.FieldName.ToUpper();
			if (colName.Equals("RO003"))
			{
				if (String.IsNullOrEmpty(e.Value.ToString()))
				{
					e.Valid = false;
					e.ErrorText = "角色名称不能为空!";
				}
				else
				{
					for (int i = 0; i < gridView1.RowCount - 1; i++)
					{
						if (i == (sender as ColumnView).FocusedRowHandle) continue;
						if (gridView1.GetRowCellValue(i, "RO003") == null) continue;

						//如果角色名字相同,则校验不通过!                        
						if (String.Equals(gridView1.GetRowCellValue(i, "RO003").ToString(), e.Value.ToString()))
						{
							e.Valid = false;
							e.ErrorText = "角色名称已经存在!";
							break;
						}
					}
				}
			}
		}
		 
		 
		/// <summary>
		/// 保存前检查
		/// </summary>
		/// <returns></returns>
		private bool CheckValidBeforeSave()
		{
			foreach(RO01 r in xpCollection1)
			{
				if(r.RO003 == null || string.IsNullOrEmpty(r.RO003))
				{
					int rowHandle = gridView1.GetRowHandle(xpCollection1.IndexOf(r));
					gridView1.FocusedRowHandle = rowHandle;
					gridView1.FocusedColumn = gridView1.Columns["RO003"];
					XtraMessageBox.Show("【角色名】必须输入!","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					gridView1.ShowEditor();
					return false;
				}
			}
			return true;
		}

		private void xpCollection1_CollectionChanged(object sender, XPCollectionChangedEventArgs e)
		{
			
		}
		/// <summary>
		/// 内置角色 禁止编辑
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
		{
			if (gridView1.GetFocusedRowCellValue("RO001") != null && gridView1.GetFocusedRowCellValue("RO001").ToString() == App_Const.ADMIN_GROUP_ID)
			{
				e.Cancel = true;
			}
		}
	}
}
