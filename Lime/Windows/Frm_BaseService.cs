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
using Lime.Xpo.orcl;
using DevExpress.XtraGrid.Views.Grid;
using Lime.Misc;

namespace Lime.Windows
{
	public partial class Frm_BaseService : MyDialog
	{
		private DataTable dt_si01 = new DataTable("SI01");
		private OracleDataAdapter st01_adapter = new OracleDataAdapter("select * from si01 where status <> '0' ", SqlHelper.conn);
		private DataView dv_slt = null;
		private DataView dv_lcg = null;
		private DataView dv_xxs = null;
		private DataView dv_gbt = null;
		private DataView dv_lc = null;
		private DataView dv_hh = null;

		private AC01 ac01 = null;
		private string s_ac001 = string.Empty;

		public Frm_BaseService()
		{
			InitializeComponent();			
		}

		private void Frm_BaseService_Load(object sender, EventArgs e)
		{
			//接收逝者 
			s_ac001 = this.swapdata["ac001"].ToString();
			ac01 = unitOfWork1.GetObjectByKey<AC01>(s_ac001);

			//填充
			st01_adapter.Fill(dt_si01);
			
			//01守灵厅
			dv_slt = new DataView(dt_si01);
			dv_slt.RowFilter = "SI002 = '01' ";

			glookup_slt.Properties.DataSource = dv_slt;
			glookup_slt.Properties.DisplayMember = "SI003";
			glookup_slt.Properties.ValueMember = "SI001";

			//02冷藏柜
			dv_lcg = new DataView(dt_si01);
			dv_lcg.RowFilter = "SI002 = '02' ";

			glookup_lcg.Properties.DataSource = dv_lcg;
			glookup_lcg.Properties.DisplayMember = "SI003";
			glookup_lcg.Properties.ValueMember = "SI001";

			//03休息室
			dv_xxs = new DataView(dt_si01);
			dv_xxs.RowFilter = "SI002 = '03' ";

			gridControl1.DataSource = dv_xxs;

			//04告别厅
			dv_gbt = new DataView(dt_si01);
			dv_gbt.RowFilter = "SI002 = '04' ";

			glookup_gbt.Properties.DataSource = dv_gbt;
			glookup_gbt.Properties.DisplayMember = "SI003";
			glookup_gbt.Properties.ValueMember = "SI001";

			//07 灵车
			dv_lc = new DataView(dt_si01);
			dv_lc.RowFilter = "SI002 = '07' ";

			glookup_lc.Properties.DataSource = dv_lc;
			glookup_lc.Properties.DisplayMember = "SI003";
			glookup_lc.Properties.ValueMember = "SI001";

			//06 火化
			dv_hh = new DataView(dt_si01);
			dv_hh.RowFilter = "SI002 = '06' ";

			glookup_hh.Properties.DataSource = dv_hh;
			glookup_hh.Properties.DisplayMember = "SI003";
			glookup_hh.Properties.ValueMember = "SI001";
		}
		/// <summary>
		/// 选择告别厅
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void glookup_gbt_EditValueChanged(object sender, EventArgs e)
		{
			if(glookup_gbt.EditValue != null)
			{
				de_gbsj.EditValue = MiscAction.GetServerTime();
			}
			else
			{
				de_gbsj.EditValue = null;
			}
		}
		/// <summary>
		/// 选择火化
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void glookup_hh_EditValueChanged(object sender, EventArgs e)
		{
			if (glookup_hh.EditValue != null)
			{
				de_hhsj.EditValue = MiscAction.GetServerTime();
			}
			else
			{
				de_hhsj.EditValue = null;
			}
		}
		/// <summary>
		/// 守灵厅选择
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void glookup_slt_EditValueChanged(object sender, EventArgs e)
		{
			if (glookup_slt.EditValue != null)
			{
				te_slt_nums.EditValue = 1;
			}
			else
			{
				te_slt_nums.EditValue = 0;
			}
		}
		/// <summary>
		/// 冷藏柜选择
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void glookup_lcg_EditValueChanged(object sender, EventArgs e)
		{
			if (glookup_lcg.EditValue != null)
			{
				sp_lcg_nums.EditValue = 1;
			}
			else
			{
				sp_lcg_nums.EditValue = 0;
			}
		}
		/// <summary>
		/// 清除选择
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void simpleButton1_Click(object sender, EventArgs e)
		{
			glookup_slt.EditValue = null;
			te_slt_nums.EditValue = 0;
			glookup_lcg.EditValue = null;
			sp_lcg_nums.EditValue = 0;
 
			gridView2.ClearSelection();
			
			glookup_gbt.EditValue = null;
			de_gbsj.EditValue = null;

			glookup_lc.EditValue = null;
			glookup_hh.EditValue = null;
			de_hhsj.EditValue = null;
		}
		/// <summary>
		/// 守灵天数校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void te_slt_nums_Validating(object sender, CancelEventArgs e)
		{
			decimal nums = decimal.Parse(te_slt_nums.Text);
			if ((nums - Math.Floor(nums)) > 0 && (nums - Math.Floor(nums)) != new decimal(0.5))
			{
				te_slt_nums.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				te_slt_nums.ErrorText = "存放天数只能为整数或者半日!";
				e.Cancel = true;
				return;
			}
		}
		/// <summary>
		/// 冷藏天数校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void sp_lcg_nums_Validating(object sender, CancelEventArgs e)
		{
			decimal nums = decimal.Parse(sp_lcg_nums.Text);
			if ((nums - Math.Floor(nums)) > 0 && (nums - Math.Floor(nums)) != new decimal(0.5))
			{
				sp_lcg_nums.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				sp_lcg_nums.ErrorText = "存放天数只能为整数或者半日!";
				e.Cancel = true;
				return;
			}
		}
		/// <summary>
		/// 保存
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void sb_ok_Click(object sender, EventArgs e)
		{
			bool b_done = false;

			if (FireAction.FireIsSettled(ac01.AC001))
			{
				XtraMessageBox.Show("该逝者已经办理火化并且结算,不能再办理业务!", "提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}

			///判断 守灵 冷藏 是否同时选择
			if(!string.IsNullOrEmpty(glookup_slt.EditValue.ToString()) && Convert.ToDecimal(te_slt_nums.Text) > 0 && !string.IsNullOrEmpty(glookup_lcg.EditValue.ToString()) && Convert.ToDecimal(sp_lcg_nums.Text) >0)
			{
				if (XtraMessageBox.Show("确认要同时选择【守灵】和【冷藏】业务吗?","确认",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No) return;
			}

			if(!string.IsNullOrEmpty(glookup_slt.EditValue.ToString()) && Convert.ToDecimal(te_slt_nums.Text) > 0)
			{
				if (FireAction.ItemIsExisted(ac01.AC001, "01", ""))
				{
					if (XtraMessageBox.Show("【守灵】已经办理,是否继续?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
				}
			}
			if (!string.IsNullOrEmpty(glookup_lcg.EditValue.ToString()) && Convert.ToDecimal(sp_lcg_nums.Text) > 0)
			{
				if (FireAction.ItemIsExisted(ac01.AC001, "02", ""))
				{
					if (XtraMessageBox.Show("【冷藏】已经办理,是否继续?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
				}
			}

			if ( !string.IsNullOrEmpty(glookup_gbt.EditValue.ToString()) && de_gbsj.EditValue != null )
			{
				if (FireAction.ItemIsExisted(ac01.AC001, "04", ""))
				{
					XtraMessageBox.Show("【告别】已经办理!", "确认", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}

			if (!string.IsNullOrEmpty(glookup_lc.EditValue.ToString()))
			{
				if (FireAction.ItemIsExisted(ac01.AC001, "07", ""))
				{
					XtraMessageBox.Show("【灵车】已经办理!", "确认", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}
			////////////////////////  业务办理 ///////////////////////
			/// 01 如果守灵厅   
			if ( !string.IsNullOrEmpty(glookup_slt.EditValue.ToString()) && Convert.ToDecimal(te_slt_nums.Text) > 0)
			{
				SA01 sa01 = new SA01(unitOfWork1);
				sa01.SA001 = MiscAction.GetEntityPK("SA01");
				sa01.AC001 = ac01.AC001;
				sa01.SA002 = "01";  //守灵厅				
				GridView view = glookup_slt.Properties.View;
				sa01.SA003 = "守灵厅" + "【" + view.GetRowCellValue(view.FocusedRowHandle, "SI003") + "】";
				sa01.SA004 = glookup_slt.EditValue.ToString();
				sa01.SA005 = "0";
				sa01.PRICE = Convert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "PRICE"));
				sa01.NUMS = Convert.ToDecimal(te_slt_nums.Text);
				sa01.SA007 = sa01.PRICE * sa01.NUMS;
				sa01.SA006 = sa01.PRICE;
				sa01.SA008 = "0";
				sa01.SA100 = Envior.cur_user.UC001;
				sa01.SA200 = MiscAction.GetServerTime();
				sa01.STATUS = "1";
				ApplyCombo("01");
				b_done = true;
				//sa01.Save();
			}
			/// 02 如果冷藏柜  
			if ( !string.IsNullOrEmpty(glookup_lcg.EditValue.ToString()) &&  Convert.ToDecimal(sp_lcg_nums.Text) > 0)
			{
				SA01 sa01 = new SA01(unitOfWork1);
				sa01.SA001 = MiscAction.GetEntityPK("SA01");
				sa01.AC001 = ac01.AC001;
				sa01.SA002 = "02";  //冷藏柜			
				GridView view = glookup_lcg.Properties.View;
				sa01.SA003 = "冷藏" + "【" + view.GetRowCellValue(view.FocusedRowHandle, "SI003") + "】";
				sa01.SA004 = glookup_lcg.EditValue.ToString();
				sa01.SA005 = "0";
				sa01.PRICE = Convert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "PRICE"));
				sa01.NUMS = Convert.ToDecimal(te_slt_nums.Text);
				sa01.SA007 = sa01.PRICE * sa01.NUMS;
				sa01.SA006 = sa01.PRICE;
				sa01.SA008 = "0";
				sa01.SA100 = Envior.cur_user.UC001;
				sa01.SA200 = MiscAction.GetServerTime();
				sa01.STATUS = "1";
				ApplyCombo("02");
				b_done = true;
				//sa01.Save();
			}
			///03 休息室
			foreach(int i in gridView2.GetSelectedRows())
			{
				if (FireAction.ItemIsExisted(ac01.AC001, "03", gridView2.GetRowCellValue(i, "SI001").ToString()))
				{
					throw new Exception("【" + gridView2.GetRowCellValue(i,"SI003").ToString() + "】" +  "已经存在!");
				}
				SA01 sa01 = new SA01(unitOfWork1);
				sa01.AC001 = ac01.AC001;
				sa01.SA001 = MiscAction.GetEntityPK("SA01");
				sa01.SA002 = "03";  //休息室		
				sa01.SA003 = "休息室" + "【" + gridView2.GetRowCellValue(i, "SI003") + "】";
				sa01.SA004 = gridView2.GetRowCellValue(i, "SI001").ToString();
				sa01.SA005 = "0";
				sa01.PRICE = Convert.ToDecimal(gridView2.GetRowCellValue(i, "PRICE"));
				sa01.NUMS = 1;
				sa01.SA007 = sa01.PRICE;
				sa01.SA006 = sa01.PRICE;
				sa01.SA008 = "0";
				sa01.SA100 = Envior.cur_user.UC001;
				sa01.SA200 = MiscAction.GetServerTime();
				sa01.STATUS = "1";
				ApplyCombo("03");
				b_done = true;
				//sa01.Save();
			}

			///04 告别厅
			if ( !string.IsNullOrEmpty(glookup_gbt.EditValue.ToString()) && de_gbsj.EditValue != null)
			{
				SA01 sa01 = new SA01(unitOfWork1);
				sa01.SA001 = MiscAction.GetEntityPK("SA01");
				sa01.AC001 = ac01.AC001;
				sa01.SA002 = "04";  //告别厅			
				GridView view = glookup_gbt.Properties.View;
				sa01.SA003 = "告别厅" + "【" + view.GetRowCellValue(view.FocusedRowHandle, "SI003") + "】";
				sa01.SA004 = glookup_gbt.EditValue.ToString();
				sa01.SA005 = "0";
				sa01.PRICE = Convert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "PRICE"));
				sa01.NUMS = 1;
				sa01.SA007 = sa01.PRICE ;
				sa01.SA006 = sa01.PRICE;
				sa01.SA008 = "0";
				sa01.SA100 = Envior.cur_user.UC001;
				sa01.SA200 = MiscAction.GetServerTime();
				sa01.STATUS = "1";
				ApplyCombo("04");
				ac01.AC018 = Convert.ToDateTime(de_gbsj.EditValue);  //告别时间
				b_done = true;
			}

			///07 灵车
			if (!string.IsNullOrEmpty(glookup_lc.EditValue.ToString()))
			{
				SA01 sa01 = new SA01(unitOfWork1);
				sa01.SA001 = MiscAction.GetEntityPK("SA01");
				sa01.AC001 = ac01.AC001;
				sa01.SA002 = "07";  //灵车			
				GridView view = glookup_lc.Properties.View;
				sa01.SA003 = "灵车" + "【" + view.GetRowCellDisplayText(view.FocusedRowHandle, "SI003") + "】";
				sa01.SA004 = glookup_lc.EditValue.ToString();
				sa01.SA005 = "0";
				sa01.PRICE = Convert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "PRICE"));
				sa01.NUMS = 1;
				sa01.SA007 = sa01.PRICE;
				sa01.SA006 = sa01.PRICE;
				sa01.SA008 = "0";
				sa01.SA100 = Envior.cur_user.UC001;
				sa01.SA200 = MiscAction.GetServerTime();
				sa01.STATUS = "1";
				ApplyCombo("07");
				b_done = true;
				//sa01.Save();
			}

			///06 火化
			if (!string.IsNullOrEmpty(glookup_hh.EditValue.ToString()) && de_hhsj.EditValue != null)
			{
				SA01 sa01 = new SA01(unitOfWork1);
				sa01.SA001 = MiscAction.GetEntityPK("SA01");
				sa01.AC001 = ac01.AC001;
				sa01.SA002 = "06";  //火化			
				GridView view = glookup_hh.Properties.View;
				sa01.SA003 = "火化" + "【" + view.GetRowCellValue(view.FocusedRowHandle, "SI003") + "】";
				sa01.SA004 = glookup_hh.EditValue.ToString();
				sa01.SA005 = "0";
				sa01.PRICE = Convert.ToDecimal(view.GetRowCellValue(view.FocusedRowHandle, "PRICE"));
				sa01.NUMS = 1;
				sa01.SA007 = sa01.PRICE;
				sa01.SA006 = sa01.PRICE;
				sa01.SA008 = "0";
				sa01.SA100 = Envior.cur_user.UC001;
				sa01.SA200 = MiscAction.GetServerTime();
				sa01.STATUS = "1";
				ApplyCombo("06");

				ac01.AC015 = Convert.ToDateTime(de_hhsj.EditValue);   //火化时间
				b_done = true;
			}

			if (!b_done)
			{
				XtraMessageBox.Show("还未选择项目!","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}


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
			 
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		/// <summary>
		/// 应用套餐
		/// </summary>
		/// <param name="serviceType"></param>
		private void ApplyCombo(string serviceType)
		{
			DataTable dt_cb02 = new DataTable();
			OracleDataAdapter cb02Adapter = new OracleDataAdapter("select * from cb02 where cb001=(select cb001 from cb01 where cb002 = '0' and cb005 = :service)", SqlHelper.conn);

			OracleParameter op_service = new OracleParameter("service", OracleDbType.Varchar2, 3);
			op_service.Direction = ParameterDirection.Input;
			cb02Adapter.SelectCommand.Parameters.Add(op_service);
			op_service.Value = serviceType;
			cb02Adapter.Fill(dt_cb02);

			/////循环处理套餐明细 
			foreach(DataRow dr in dt_cb02.Rows)
			{   ///如果套餐明细项目不存在!
				if (!FireAction.ItemIsExisted(ac01.AC001, dr["CB022"].ToString(), dr["CB021"].ToString()))
				{
					SA01 sa01 = new SA01(unitOfWork1);
					sa01.SA001 = MiscAction.GetEntityPK("SA01");
					sa01.AC001 = ac01.AC001;
					sa01.SA002 = dr["CB022"].ToString();   //类型
					sa01.SA003 = FireAction.GetItemName(dr["CB021"].ToString());
					sa01.SA004 = dr["CB021"].ToString();
					sa01.SA005 = "0";
					sa01.PRICE = FireAction.GetItemPrice(dr["CB021"].ToString());
					sa01.NUMS = Convert.ToInt32(dr["CB030"]);
					sa01.SA007 = sa01.PRICE * sa01.NUMS;
					sa01.SA006 = sa01.PRICE;
					sa01.SA008 = "0";
					sa01.SA100 = Envior.cur_user.UC001;
					sa01.SA200 = MiscAction.GetServerTime();
					sa01.STATUS = "1";
				}
			}

		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}