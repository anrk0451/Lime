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
using Lime.Action;
using DevExpress.Xpo;
using Lime.Xpo.orcl;
using Lime.Misc;

namespace Lime.Windows
{
	public partial class Frm_FireSettle : MyDialog
	{
		private XPCollection xp_sa01 = null;
		private UnitOfWork session = null;
		private AC01 ac01 = null;
		public Frm_FireSettle()
		{
			InitializeComponent();
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
		}
		 
		private void Frm_FireSettle_Load(object sender, EventArgs e)
		{
			ac01 = this.swapdata["ac01"] as AC01;
			List<int> rowList = this.swapdata["rowList"] as List<int>;
			xp_sa01 = this.swapdata["collection"] as XPCollection;
			session = xp_sa01.Session as UnitOfWork;
			xpCollection1.Session = xp_sa01.Session;


			foreach(int i in rowList)
			{
				xpCollection1.Add(xp_sa01[i]);
			}
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			string s_sa001 = string.Empty;
			SA01 sa01 = null;
			FA01 fa01 = null;
			string s_fa099 = string.Empty;
			decimal dec_sum = decimal.Zero;

			//if (string.IsNullOrEmpty(te_fa099.Text))
			//{
			//	te_fa099.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
			//	te_fa099.ErrorText = "请输入收费单据号!";
			//	te_fa099.Focus();
			//	return;
			//}

			try
			{
				string s_fa001 = MiscAction.GetEntityPK("FA01");
				for (int i = 0; i < gridView1.RowCount; i++)
				{
					sa01 = xpCollection1[gridView1.GetDataSourceRowIndex(i)] as SA01;
					if (FireAction.SalesItemIsSettled(sa01.SA001))
						throw new Exception("第" + (i+1).ToString() + "行数据已经结算,请重新选择结算数据!");
					sa01.SA008 = "1";		//结算标志
					sa01.SA010 = s_fa001;   //结算流水号

					dec_sum += sa01.SA007;
				}

				fa01 = new FA01(session);
				fa01.FA001 = s_fa001;       //结算流水号
				fa01.FA002 = "0";           //收费类型 0-火化业务
				fa01.FA003 = ac01.AC003;    //交款人
				fa01.AC001 = ac01.AC001;    //逝者编号
				fa01.FA004 = dec_sum;       //交费金额
				fa01.FA099 = te_fa099.Text; //单据流水号
				fa01.FA100 = Envior.cur_user.UC001;			//经办人
				fa01.FA200 = MiscAction.GetServerTime();    //经办日期
				fa01.WS001 = Envior.workstationId;          //工作站ID
				fa01.STATUS = "1";

				///检查是否有寄存办理
				int i_find = gridView1.LocateByValue("SA002", "08");
				if(i_find >= 0)
				{
					string s_bi001 = gridView1.GetRowCellValue(i_find, "SA004").ToString();
					BI01 bi01 = session.GetObjectByKey<BI01>(s_bi001);
					if (bi01 == null) throw new Exception("找不到寄存号位!");

					bi01.STATUS = "1";

					RC01 rc01 = session.GetObjectByKey<RC01>(gridView1.GetRowCellValue(i_find, "AC001").ToString());
					if (rc01 == null) throw new Exception("找不到寄存登记记录!");

					rc01.STATUS = "1";

					////增加寄存费缴纳记录
					RC04 rc04 = new RC04(session);
					rc04.RC001 = rc01.RC001;
					rc04.RC010 = s_fa001;
					rc04.RC020 = rc01.RC140;   //寄存日期
					rc04.RC022 = rc01.RC150;   //寄存截至日期
					rc04.PRICE = Convert.ToDecimal(gridView1.GetRowCellValue(i_find, "PRICE"));
					rc04.NUMS = Convert.ToInt32(gridView1.GetRowCellValue(i_find, "NUMS"));
					rc04.RC030 = Convert.ToDecimal(gridView1.GetRowCellValue(i_find, "SA007"));
					rc04.RC031 = "1";          //寄存费缴纳类型 1-正常缴费
					rc04.RC100 = Envior.cur_user.UC001;
					rc04.RC200 = MiscAction.GetServerTime();
					rc04.STATUS = "1";					 
				}
 
				session.CommitChanges();
				XtraMessageBox.Show("结算办理成功!现在开始打印单据!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);

				 
				PrintAction.Print_Skpz0(s_fa001);
				if(gridView1.LocateByValue("SA002", "06") >= 0)
				{
					if (XtraMessageBox.Show("现在打印【火化证明】吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						PrintAction.Print_HHZM(ac01.AC001);
					}
				}
				if (gridView1.LocateByValue("SA002", "08") >= 0)
				{
					if (XtraMessageBox.Show("现在打印【寄存证】吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						PrintAction.Print_RegCardBase(ac01.AC001);
					}
					if (XtraMessageBox.Show("现在打印【骨灰安放卡】吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						PrintAction.Print_RegSettle(ac01.AC001);
					}
				}

				this.DialogResult = DialogResult.OK;
				this.Close();

			}
			catch (Exception ee)
			{
				session.RollbackTransaction();
				LogUtils.Error(ee.Message);
				XtraMessageBox.Show(ee.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
	}
}