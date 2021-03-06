﻿using System;
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
using Lime.Xpo.orcl;
using Lime.Action;
using Lime.Windows;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Lime.Misc;

namespace Lime.BusinessObject
{
	public partial class FireBusiness : BaseBusiness
	{
		private string s_ac001 = string.Empty;
		private AC01 ac01 = null;
		public FireBusiness()
		{
			InitializeComponent();
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
		}

		private void FireBusiness_Load(object sender, EventArgs e)
		{
			
		}
		/// <summary>
		/// 业务初始化
		/// </summary>
		public override void Business_Init()
		{
			s_ac001 = this.swapdata["parm"].ToString();
			ac01 = unitOfWork1.GetObjectByKey<AC01>(s_ac001);
			 
			CriteriaOperator criteria = CriteriaOperator.Parse("AC001=? and STATUS = '1'", s_ac001);
			xpCollection1.Criteria = criteria;
			xpCollection1.LoadingEnabled = true;

			this.SetActivePanel();
		}


		private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{

		}
		/// <summary>
		/// 骨灰处理方式改变
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtedit_ac006_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
		{
			if (e.Value == null) return;
			e.DisplayText = MiscAction.Mapper_DD(e.Value.ToString());
		}
		/// <summary>
		/// 基本服务
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			////检查火化是否办理并且结算///////
			if (FireAction.FireIsSettled(s_ac001))
			{
				XtraMessageBox.Show("该逝者已经办理火化并且结算,不能再办理业务!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			Frm_BaseService frm_1 = new Frm_BaseService();
			frm_1.swapdata["ac001"] = s_ac001;
			if(frm_1.ShowDialog() == DialogResult.OK)
			{
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
			UnitOfWork unitOfWork = new UnitOfWork();

			xpCollection1.Session = unitOfWork;
			xpCollection1.Reload();

			ac01.Reload();

			this.SetActivePanel();

			gridView1.EndUpdate();
			this.Cursor = Cursors.Arrow;
		}
		/// <summary>
		/// 刷新
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.RefreshData();
		}
		/// <summary>
		/// 转换代码
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
			if(e.Column.FieldName.ToUpper() == "SA008")
			{
				if (e.Value.ToString() == "1")
					e.DisplayText = "已结算";
				else
					e.DisplayText = "未结算";
			}
		}
		/// <summary>
		/// 设置信息面板显示
		/// </summary>
		private void SetActivePanel()
		{
			txtedit_ac003.EditValue = ac01.AC003;  //逝者姓名
			txtedit_ac004.EditValue = ac01.AC004;  //年龄
			rg_ac002.EditValue = ac01.AC002;       //性别
			txtedit_ac020.EditValue = ac01.AC020;  //到达中心时间
			txtedit_ac050.EditValue = ac01.AC050;  //联系人
			txtedit_ac051.EditValue = ac01.AC051;  //电话
			txtedit_ac052.Text = ac01.AC052;       //与逝者关系
			txtedit_ac006.EditValue = ac01.AC006;  //骨灰处理方式

			this.Parent.Text = "火化业务办理" + "【" + ac01.AC003 + "】" + "(" + ac01.AC001 + ")";

			te_position.Text = FireAction.GetGuyPosition(s_ac001);
			te_gbt.Text = FireAction.GetGBT(s_ac001);
			txtedit_ac018.EditValue =  ac01.AC018;
			txtedit_ac015.EditValue = ac01.AC015;
			te_hhl.Text = FireAction.GetHHL(s_ac001);
			txtedit_xxs.Text = FireAction.GetRestRoomList(s_ac001);

			//判断是否办理寄存业务
			if (gridView1.LocateByValue("SA002", "08") >= 0)
				te_pos.Text = RegAction.GetRegPosition(s_ac001);			 
			else
				te_pos.Text = "";

			decimal dec_yjs = decimal.Zero;
			decimal dec_wjs = decimal.Zero;
			for(int i = 0; i< gridView1.RowCount; i++)
			{
				if (gridView1.GetRowCellValue(i, "SA008").ToString() == "1")
					dec_yjs += Convert.ToDecimal(gridView1.GetRowCellValue(i, "SA007"));
				else
					dec_wjs += Convert.ToDecimal(gridView1.GetRowCellValue(i, "SA007"));
			}

			te_yjs.Text = dec_yjs.ToString("##,##0.00");
			te_wjs.Text = dec_wjs.ToString("##,##0.00");
		}
		/// <summary>
		/// 延申服务及商品
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			////检查火化是否办理并且结算///////
			if (FireAction.FireIsSettled(s_ac001))
			{
				XtraMessageBox.Show("该逝者已经办理火化并且结算,不能再办理业务!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			Frm_MiscItem frm_1 = new Frm_MiscItem();
			frm_1.swapdata["ac001"] = s_ac001;
			if(frm_1.ShowDialog() == DialogResult.OK)
			{
				this.RefreshData();
			}
			frm_1.Dispose();
		}
		/// <summary>
		/// 编辑项目
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.Modify(gridView1.FocusedRowHandle);
		}
		/// <summary>
		/// 编辑项目
		/// </summary>
		/// <param name="rowHandle"></param>
		private void Modify(int rowHandle)
		{
			if(rowHandle >= 0)
			{
				if(gridView1.GetRowCellValue(rowHandle,"SA008").ToString() == "1")
				{
					XtraMessageBox.Show("该项目已经结算,不能修改!","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					return;
				}

				SA01 sa01 = xpCollection1[gridView1.GetDataSourceRowIndex(rowHandle)] as SA01;
				Frm_BusinessEdit frm_1 = new Frm_BusinessEdit();
				frm_1.swapdata["sa01"] = sa01;
				if(frm_1.ShowDialog() == DialogResult.OK)
				{
					sa01.Reload();
					this.SetActivePanel();
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
		/// 删除项目
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (gridView1.SelectedRowsCount == 0)
			{
				XtraMessageBox.Show("请先选择要删除的记录!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string sa001;
			int re;

			if (XtraMessageBox.Show("确认要删除吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

			foreach (int i in gridView1.GetSelectedRows())
			{
				//权限检查
				//if (!AppAction.CheckRight("业务项目删除", gridView1.GetRowCellValue(i, "SA100").ToString())) continue;

				sa001 = gridView1.GetRowCellValue(i, "SA001").ToString();
				re = FireAction.FireSalesItemRemove(sa001);
				if (re < 0) return;
			}

			this.RefreshData();
		}
		/// <summary>
		/// 登记信息修改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			 
			Frm_FireCheckin frm_1 = new Frm_FireCheckin();
			frm_1.swapdata["ac001"] = s_ac001;
			if (frm_1.ShowDialog() == DialogResult.OK)
			{
				ac01.Reload();
				this.SetActivePanel();
			}
			frm_1.Dispose();
			 
		}
		/// <summary>
		/// 设置火化时间
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			////// 检查是否 火化结算完成  //////
			if (FireAction.FireIsSettled(s_ac001) && Envior.cur_user.UC001 != App_Const.ROOT_ID)
			{
				XtraMessageBox.Show("火化业务已经办理并且结算,不能修改!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			int i_find = gridView1.LocateByValue("SA002", "06");
			if (i_find < 0)
			{
				XtraMessageBox.Show("没有办理【火化】业务!","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}


		    Frm_SetFireTime frm_1 = new Frm_SetFireTime();
			frm_1.swapdata["ac01"] = ac01;
			if(frm_1.ShowDialog() == DialogResult.OK)
			{
				txtedit_ac015.EditValue = ac01.AC015;	
			}
			frm_1.Dispose();
		}
		/// <summary>
		/// 结算
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.SettleHandle();
		}
		/// <summary>
		/// 结算过程
		/// </summary>
		private void SettleHandle()
		{
			if (gridView1.GetSelectedRows().Length <= 0)
			{
				XtraMessageBox.Show("请选择要结算的记录!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			List<int> rowList = new List<int>();
			//检查是否有未输入单价项目
			for (int i = 0; i < gridView1.RowCount; i++)
			{
				if (!gridView1.IsRowSelected(i) || gridView1.GetRowCellValue(i, "SA008").ToString() == "1") continue;
				if (Convert.ToDecimal(gridView1.GetRowCellValue(i, "PRICE")) == 0)
				{
					XtraMessageBox.Show("第" + (i + 1).ToString() + "行项目未输入价格!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}				 
				rowList.Add(gridView1.GetDataSourceRowIndex(i));
			}

			int i_find = gridView1.LocateByValue("SA002", "06");
			if (i_find >= 0 && gridView1.IsRowSelected(i_find))
			{
				if (SqlHelper.ExecuteScalar("select ac015 from ac01 where ac001= '" + s_ac001 + "'") is DBNull)
				{
					XtraMessageBox.Show("火化时间尚未设置！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					return;
				}
			}

			Frm_FireSettle frm_settle = new Frm_FireSettle();
			frm_settle.swapdata["collection"] = xpCollection1;
			frm_settle.swapdata["rowList"] = rowList;
			frm_settle.swapdata["ac01"] = ac01;
			frm_settle.swapdata["session"] = unitOfWork1;

			if (frm_settle.ShowDialog() == DialogResult.OK)
			{
				this.RefreshData();
			}
			frm_settle.Dispose();

			CancelSelect();

		}

		/// <summary>
		/// 取消所有选择的行
		/// </summary>
		private void CancelSelect()
		{
			for (int i = 0; i < gridView1.RowCount; i++)
			{
				gridView1.UnselectRow(i);
			}
		}
		/// <summary>
		/// 全部结算
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			for (int i = 0; i < gridView1.RowCount; i++)
			{
				if (gridView1.GetRowCellValue(i, "SA008").ToString() == "0")
				{
					gridView1.SelectRow(i);
				}
			}
			this.SettleHandle();
		}

		private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
		{
			if (e.Action == CollectionChangeAction.Add)
			{
				//int row = gridView1.FocusedRowHandle;
				int row = e.ControllerRow;
				if (gridView1.GetRowCellValue(row, "SA008").ToString() == "1")
				{
					XtraMessageBox.Show("已结算数据不能修改!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					gridView1.UnselectRow(row);
				}
			}
			else if (e.Action == CollectionChangeAction.Refresh && gridView1.SelectedRowsCount > 0)
			{
				gridView1.BeginUpdate();
				for (int i = 0; i < gridView1.RowCount; i++)
				{
					if (gridView1.GetRowCellValue(i, "SA008").ToString() == "1")
					{
						gridView1.UnselectRow(i);
					}
				}
				gridView1.EndUpdate();
			}
		}
		/// <summary>
		/// 骨灰寄存
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			////检查火化是否办理并且结算///////
			if (FireAction.FireIsSettled(s_ac001))
			{
				XtraMessageBox.Show("该逝者已经办理火化并且结算,不能再办理业务!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			///要先检测该逝者是否已经办理过寄存业务 
			if (Convert.ToInt32(SqlHelper.ExecuteScalar("select count(*) from v_sa01 where sa002 = '08' and ac001 = '" + s_ac001 + "'")) > 0)
			{
				XtraMessageBox.Show("该逝者已经办理了骨灰寄存业务!","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			 
			Frm_Register frm_1 = new Frm_Register();
			frm_1.swapdata["source"] = "8";   //来源 8-待缴费
			frm_1.swapdata["rc001"] = s_ac001;
			if(frm_1.ShowDialog() == DialogResult.OK)
			{
				this.RefreshData();
			}
			frm_1.Dispose();
		}

		private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (FireAction.FireIsSettled(s_ac001))
			{
				XtraMessageBox.Show("已经办理火化且结算完成,不能继续办理业务!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			Frm_ApplyCombo frm_combo = new Frm_ApplyCombo();
			frm_combo.swapdata["ac001"] = s_ac001;

			if (frm_combo.ShowDialog() == DialogResult.OK)
			{
				this.RefreshData();
			}
			frm_combo.Dispose();
		}
	}
}
