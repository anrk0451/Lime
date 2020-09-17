using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Lime.Action;
using Lime.BaseObject;
using Lime.Windows;
using Lime.Xpo.orcl;
using System.Drawing;
using System.Windows.Forms;

namespace Lime.BusinessObject
{
	public partial class Combo2 : BaseBusiness
	{
		public Combo2()
		{
			InitializeComponent();
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
		}
		/// <summary>
		/// 新增套餐
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Frm_Combo frm_1 = new Frm_Combo();
			frm_1.swapdata["collection"] = xpCollection1;
			if (frm_1.ShowDialog() == DialogResult.OK)
			{

			}
			frm_1.Dispose();
		}
		/// <summary>
		/// 套餐类别转换
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
			if (e.Column.FieldName.ToUpper() == "CB002")
			{
				if (e.Value.ToString() == "0")
					e.DisplayText = "服务绑定";
				else if (e.Value.ToString() == "1")
					e.DisplayText = "用户定义";
			}
		}
		/// <summary>
		/// 删除套餐
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int rowHandle = gridView1.FocusedRowHandle;
			string s_cb001 = string.Empty;
			/////  删除记录 
			if (rowHandle >= 0)
			{
				if (XtraMessageBox.Show("确认要删除当前的记录吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
				{
					return;
				}
				s_cb001 = gridView1.GetRowCellValue(rowHandle, "CB001").ToString();
				if (MiscAction.DeleteCombo(s_cb001) > 0)
				{
					XtraMessageBox.Show("删除成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.RefreshData();
				}
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

			xpCollection1.Session = unitOfWork;
			xpCollection1.Reload();

			gridView1.EndUpdate();
			this.Cursor = Cursors.Arrow;
		}
		/// <summary>
		/// 刷新
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.RefreshData();
		}
		/// <summary>
		/// 编辑
		/// </summary>
		private void Edit(int rowHandle)
		{
			CB01 cb01 = null;
			if(rowHandle >=0)
			{
				cb01 = xpCollection1[gridView1.GetDataSourceRowIndex(rowHandle)] as CB01;
				Frm_Combo frm_1 = new Frm_Combo();
				frm_1.swapdata["collection"] = xpCollection1;
				frm_1.swapdata["cb01"] = cb01;
				if(frm_1.ShowDialog() == DialogResult.OK)
				{
					this.RefreshData();
				}
				frm_1.Dispose();
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
					Edit(gridView1.FocusedRowHandle);
				}
			}
		}
		/// <summary>
		/// 编辑
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.Edit(gridView1.FocusedRowHandle);
		}
	}
}
