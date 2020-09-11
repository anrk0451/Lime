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
using Lime.Windows;
using DevExpress.Xpo;
using Lime.Misc;
using Lime.Xpo.orcl;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Lime.BusinessObject
{
	public partial class Operator : BaseBusiness
	{
		public Operator()
		{
			InitializeComponent();
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
		}

		 
		private void Operator_Load(object sender, EventArgs e)
		{

		}
		/// <summary>
		/// 新建用户
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Frm_Operator frm_1 = new Frm_Operator();
			if(frm_1.ShowDialog() == DialogResult.OK)
			{
				this.RefreshData();
			}
			frm_1.Dispose();
		}
		/// <summary>
		/// 刷新
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			RefreshData();
		}
		/// <summary>
		/// 刷新过程
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
		/// 删除操作员
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int rowHandle = gridView1.FocusedRowHandle;
			if (rowHandle >= 0)
			{
				if(gridView1.GetRowCellValue(rowHandle,"UC001").ToString() == App_Const.ROOT_ID)
				{
					XtraMessageBox.Show("系统内置用户,不能删除!","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					return;
				}
				if(XtraMessageBox.Show("确认要删除当前用户吗?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
				{
					string s_uc001 = gridView1.GetRowCellValue(rowHandle, "UC001").ToString();
					UC01 uc01 = unitOfWork1.GetObjectByKey<UC01>(s_uc001);
					try
					{						
						uc01.STATUS = '0';
						uc01.Save();
						unitOfWork1.CommitChanges();
						
						XtraMessageBox.Show("删除成功!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
						this.RefreshData();
					}
					catch (Exception ee )
					{
						unitOfWork1.RollbackTransaction();
						LogUtils.Error(ee.Message);
						XtraMessageBox.Show(ee.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
					}
				}
			}
		}
		/// <summary>
		/// 修改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int rowHandle = gridView1.FocusedRowHandle;
			this.Edit(rowHandle);
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

		private void Edit(int rowHandle)
		{
			if (rowHandle >= 0)
			{
				if (gridView1.GetRowCellValue(rowHandle, "UC001").ToString() == App_Const.ROOT_ID)
				{
					XtraMessageBox.Show("系统内置用户,不能修改!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				string s_uc001 = gridView1.GetRowCellValue(rowHandle, "UC001").ToString();

				Frm_Operator frm_1 = new Frm_Operator();
				frm_1.swapdata["uc001"] = s_uc001;
				if (frm_1.ShowDialog() == DialogResult.OK)
				{
					this.RefreshData();
				}
				frm_1.Dispose();
			}
		}
	}
}
