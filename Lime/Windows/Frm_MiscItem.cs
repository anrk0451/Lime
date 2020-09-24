using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Lime.BaseObject;
using Oracle.ManagedDataAccess.Client;
using Lime.Action;
using DevExpress.XtraGrid.Views.Base;
using Lime.Xpo.orcl;
using Lime.Misc;

namespace Lime.Windows
{
	public partial class Frm_MiscItem : MyDialog
	{
		private string s_ac001 = string.Empty;
		private DataTable dt_allItems = new DataTable();
		private OracleDataAdapter itemAdapter = new OracleDataAdapter("select a.*,1 nums from v_allValidItem a where item_type in ('05','10','11','12','13')",SqlHelper.conn);
		private DataView dv_service = null;
		private DataView dv_gl = null;
		private DataView dv_zl = null;
		private DataView dv_jp = null;
		public Frm_MiscItem()
		{
			InitializeComponent();

			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
			gridView2.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
			gridView3.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
			gridView4.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
		}

		private void Frm_MiscItem_Load(object sender, EventArgs e)
		{
			s_ac001 = this.swapdata["ac001"].ToString();
			 
			itemAdapter.Fill(dt_allItems);
			//殡仪服务
			dv_service = new DataView(dt_allItems);
			dv_service.RowFilter = "ITEM_TYPE = '05'";
			gridControl1.DataSource = dv_service;

			//谷类
			dv_gl = new DataView(dt_allItems);
			dv_gl.RowFilter = "ITEM_TYPE = '10'";
			gridControl2.DataSource = dv_gl;

			//纸类
			dv_zl = new DataView(dt_allItems);
			dv_zl.RowFilter = "ITEM_TYPE = '11'";
			gridControl3.DataSource = dv_zl;

			//祭品
			dv_jp = new DataView(dt_allItems);
			dv_jp.RowFilter = "ITEM_TYPE = '12' or ITEM_TYPE = '13'";
			gridControl4.DataSource = dv_jp;

		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		/// <summary>
		/// 设置数量
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
		{
			if (e.Column.FieldName.ToUpper() == "NUMS" && e.IsGetData)
			{
				e.Value = 1;
			}
		}

		
		/// <summary>
		/// 编辑校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
		{
			string colName = (sender as ColumnView).FocusedColumn.FieldName.ToUpper();
			if (colName == "NUMS")
			{
				if (e.Value == null || e.Value is System.DBNull)
				{
					e.Valid = false;
					e.ErrorText = "请输入数量!";
					return;
				}
				else if (int.Parse(e.Value.ToString()) <= 0)
				{
					e.Valid = false;
					e.ErrorText = "数量必须大于0！";
					return;
				}
			}
			else if (colName == "PRICE")
			{
				if (decimal.Parse(e.Value.ToString()) <= 0)
				{
					e.Valid = false;
					e.ErrorText = "价格必须大于0！";
					return;
				}
			}
		}

		private void gridView2_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
		{

		}

		private void gridView4_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
		{
			string colName = (sender as ColumnView).FocusedColumn.FieldName.ToUpper();
			if (colName == "NUMS")
			{
				if (e.Value == null || e.Value is System.DBNull)
				{
					e.Valid = false;
					e.ErrorText = "请输入数量!";
					return;
				}
				else if (int.Parse(e.Value.ToString()) <= 0)
				{
					e.Valid = false;
					e.ErrorText = "数量必须大于0！";
					return;
				}
			}
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			if (!gridView1.PostEditor()) return;
			if (!gridView1.UpdateCurrentRow()) return;
			if (!gridView4.PostEditor()) return;
			if (!gridView4.UpdateCurrentRow()) return;

			int[] service_sel = gridView1.GetSelectedRows();
			int[] gl_sel = gridView2.GetSelectedRows();
			int[] zl_sel = gridView3.GetSelectedRows();
			int[] jp_sel = gridView4.GetSelectedRows();
			if(service_sel.Length + gl_sel.Length + zl_sel.Length + jp_sel.Length <= 0)
			{
				XtraMessageBox.Show("请先选择项目!","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			//延申服务处理
			foreach(int i in service_sel)
			{
				if (FireAction.ItemIsExisted(s_ac001, "05", gridView1.GetRowCellValue(i, "ITEM_ID").ToString()))
				{
					if (XtraMessageBox.Show("【" + gridView1.GetRowCellValue(i,"ITEM_TEXT").ToString() + "】已经存在,是否继续?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No) return;
				}
				SA01 sa01 = new SA01(unitOfWork1);
				sa01.SA001 = MiscAction.GetEntityPK("SA01");
				sa01.AC001 = s_ac001;
				sa01.SA002 = "05";  //殡仪服务			 
				sa01.SA003 = gridView1.GetRowCellValue(i, "ITEM_TEXT").ToString();
				sa01.SA004 = gridView1.GetRowCellValue(i, "ITEM_ID").ToString();
				sa01.SA005 = "0";
				sa01.PRICE = Convert.ToDecimal(gridView1.GetRowCellValue(i, "PRICE"));
				sa01.NUMS = Convert.ToInt32(gridView1.GetRowCellValue(i, "NUMS"));
				sa01.SA007 = sa01.PRICE * sa01.NUMS;
				sa01.SA006 = sa01.PRICE;
				sa01.SA008 = "0";
				sa01.SA100 = Envior.cur_user.UC001;
				sa01.SA200 = MiscAction.GetServerTime();
				sa01.STATUS = "1";
			}

			//谷类处理
			foreach (int i in gl_sel)
			{
				if (FireAction.ItemIsExisted(s_ac001, "10", gridView2.GetRowCellValue(i, "ITEM_ID").ToString()))
				{
					if (XtraMessageBox.Show("【" + gridView2.GetRowCellValue(i, "ITEM_TEXT").ToString() + "】已经存在,是否继续?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
				}
				SA01 sa01 = new SA01(unitOfWork1);
				sa01.SA001 = MiscAction.GetEntityPK("SA01");
				sa01.AC001 = s_ac001;
				sa01.SA002 = "10";  //谷类			 
				sa01.SA003 = gridView2.GetRowCellValue(i, "ITEM_TEXT").ToString();
				sa01.SA004 = gridView2.GetRowCellValue(i, "ITEM_ID").ToString();
				sa01.SA005 = "0";
				sa01.PRICE = Convert.ToDecimal(gridView2.GetRowCellValue(i, "PRICE"));
				sa01.NUMS = Convert.ToInt32(gridView2.GetRowCellValue(i, "NUMS"));
				sa01.SA007 = sa01.PRICE * sa01.NUMS;
				sa01.SA006 = sa01.PRICE;
				sa01.SA008 = "0";
				sa01.SA100 = Envior.cur_user.UC001;
				sa01.SA200 = MiscAction.GetServerTime();
				sa01.STATUS = "1";
			}

			//纸类处理
			foreach (int i in zl_sel)
			{
				if (FireAction.ItemIsExisted(s_ac001, "10", gridView3.GetRowCellValue(i, "ITEM_ID").ToString()))
				{
					if (XtraMessageBox.Show("【" + gridView3.GetRowCellValue(i, "ITEM_TEXT").ToString() + "】已经存在,是否继续?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
				}
				SA01 sa01 = new SA01(unitOfWork1);
				sa01.SA001 = MiscAction.GetEntityPK("SA01");
				sa01.AC001 = s_ac001;
				sa01.SA002 = "11";  //纸类			 
				sa01.SA003 = gridView3.GetRowCellValue(i, "ITEM_TEXT").ToString();
				sa01.SA004 = gridView3.GetRowCellValue(i, "ITEM_ID").ToString();
				sa01.SA005 = "0";
				sa01.PRICE = Convert.ToDecimal(gridView3.GetRowCellValue(i, "PRICE"));
				sa01.NUMS = Convert.ToInt32(gridView3.GetRowCellValue(i, "NUMS"));
				sa01.SA007 = sa01.PRICE * sa01.NUMS;
				sa01.SA006 = sa01.PRICE;
				sa01.SA008 = "0";
				sa01.SA100 = Envior.cur_user.UC001;
				sa01.SA200 = MiscAction.GetServerTime();
				sa01.STATUS = "1";
			}

			//祭品处理
			foreach (int i in jp_sel)
			{
				if (FireAction.ItemIsExisted(s_ac001, "12", gridView4.GetRowCellValue(i, "ITEM_ID").ToString()))
				{
					if (XtraMessageBox.Show("【" + gridView4.GetRowCellValue(i, "ITEM_TEXT").ToString() + "】已经存在,是否继续?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
				}
				SA01 sa01 = new SA01(unitOfWork1);
				sa01.SA001 = MiscAction.GetEntityPK("SA01");
				sa01.AC001 = s_ac001;
				sa01.SA002 = "12";  //祭品			 
				sa01.SA003 = gridView4.GetRowCellValue(i, "ITEM_TEXT").ToString();
				sa01.SA004 = gridView4.GetRowCellValue(i, "ITEM_ID").ToString();
				sa01.SA005 = "0";
				sa01.PRICE = Convert.ToDecimal(gridView4.GetRowCellValue(i, "PRICE"));
				sa01.NUMS = Convert.ToInt32(gridView4.GetRowCellValue(i, "NUMS"));
				sa01.SA007 = sa01.PRICE * sa01.NUMS;
				sa01.SA006 = sa01.PRICE;
				sa01.SA008 = "0";
				sa01.SA100 = Envior.cur_user.UC001;
				sa01.SA200 = MiscAction.GetServerTime();
				sa01.STATUS = "1";
			}

			try
			{
				unitOfWork1.CommitChanges();
				XtraMessageBox.Show("保存成功!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.DialogResult = DialogResult.OK;
				this.Close();
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