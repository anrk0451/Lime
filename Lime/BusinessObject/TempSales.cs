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
using Lime.Xpo.orcl;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Lime.Misc;
using DevExpress.Data.Filtering;

namespace Lime.BusinessObject
{
	public partial class TempSales : BaseBusiness
	{
		public TempSales()
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
			Frm_MiscItem2 frm_1 = new Frm_MiscItem2();
			frm_1.swapdata["collection"] = xpCollection1;
			if(frm_1.ShowDialog() == DialogResult.OK)
			{

			}
			frm_1.Close();
		}
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			int rowHandle = gridView1.FocusedRowHandle;

			if (rowHandle < 0)
			{
				XtraMessageBox.Show("请先选择要删除的记录!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			gridView1.DeleteRow(rowHandle);
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
		/// <summary>
		/// 修改项目
		/// </summary>
		/// <param name="rowHandle"></param>
		private void Modify(int rowHandle)
		{
			if (rowHandle >= 0)
			{
				SA01 sa01 = xpCollection1[gridView1.GetDataSourceRowIndex(rowHandle)] as SA01;
				Frm_BusinessEdit frm_1 = new Frm_BusinessEdit();
				frm_1.swapdata["sa01"] = sa01;
				if (frm_1.ShowDialog() == DialogResult.OK)
				{					
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
					Modify(gridView1.FocusedRowHandle);
				}
			}
		}
		/// <summary>
		/// 结算
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if(gridView1.RowCount <= 0)
			{
				XtraMessageBox.Show("请先选择项目!","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			if (string.IsNullOrEmpty(be_cuname.Text))
			{
				be_cuname.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				be_cuname.ErrorText = "交款人或单位必须输入!";
				return;
			}
			if (string.IsNullOrEmpty(te_billno.Text))
			{
				if (XtraMessageBox.Show("尚未输入单据号,是否继续?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No) return;
			}


			//1.检查是否有单价为0的项目 
			for(int i = 0; i< gridView1.RowCount; i++)
			{
				if(gridView1.GetRowCellValue(i,"PRICE") != null && Convert.ToDecimal(gridView1.GetRowCellValue(i, "PRICE")) <= 0)
				{
					gridView1.FocusedRowHandle = i;
					XtraMessageBox.Show("项目单价尚未设置!","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					return;
				}
			}
			SA01 sa01 = null;
			string s_fa001 = MiscAction.GetEntityPK("FA01");
			string s_cuname = be_cuname.Text;
			string s_billno = te_billno.Text;
			decimal dec_sum = decimal.Zero;

			for(int i = 0; i < gridView1.RowCount; i++)
			{
				sa01 = xpCollection1[gridView1.GetDataSourceRowIndex(i)] as SA01;
				sa01.SA010 = s_fa001;
				sa01.SA008 = "1";
				dec_sum += sa01.SA007;
			}

			FA01 fa01 = new FA01(unitOfWork1);
			fa01.FA001 = s_fa001;
			fa01.FA002 = "1";       //交费类型 1-临时性销售
			fa01.FA003 = s_cuname;  //交款人
			fa01.FA004 = dec_sum;
			fa01.FA100 = Envior.cur_user.UC001;
			fa01.FA200 = MiscAction.GetServerTime();
			fa01.WS001 = Envior.workstationId;
			fa01.STATUS = "1";
			try
			{
				unitOfWork1.CommitChanges();
				XtraMessageBox.Show("办理成功!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);

				be_cuname.Text = "";
				te_billno.Text = "";

				CriteriaOperator criteria = CriteriaOperator.Parse("1<0");
				xpCollection1.Criteria = criteria;
				xpCollection1.Criteria = null;

				be_cuname.Focus();

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
