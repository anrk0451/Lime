using DevExpress.XtraEditors;
using Lime.Misc;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lime.Action
{
	/// <summary>
	/// 其他 业务类
	/// </summary>
	class MiscAction
	{
		/// <summary>
		/// 生成主键 
		/// </summary>
		/// <param name="stype"></param>
		/// <returns></returns>
		public static string GetEntityPK(string stype)
		{
			return SqlHelper.ExecuteFunc("pkg_business.fun_EntityPk", stype).ToString();
		}

		/// <summary>
		/// 绘制数据表格 行号
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public static void DrawGridLineNo(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
		{
			e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			if (e.Info.IsRowIndicator)
			{
				if (e.RowHandle >= 0)
				{
					e.Info.DisplayText = (e.RowHandle + 1).ToString();
				}
				else if (e.RowHandle < 0 && e.RowHandle > -1000)
				{
					e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
					e.Info.DisplayText = "G" + e.RowHandle.ToString();
				}
			}
		}

		/// <summary>
		/// 删除业务套餐
		/// </summary>
		/// <param name="cb001"></param>
		/// <returns></returns>
		public static int DeleteCombo(string cb001)
		{
			return SqlHelper.ExecuteProc("pkg_business.prc_DeleteCombo", cb001);
		}
		/// <summary>
		/// 返回服务器时间
		/// </summary>
		/// <returns></returns>
		public static DateTime GetServerTime()
		{
			return Convert.ToDateTime(SqlHelper.ExecuteScalar("select sysdate from dual"));
		}
		/// <summary>
		/// 返回数据字典映射
		/// </summary>
		/// <param name="st001"></param>
		/// <returns></returns>
		public static string Mapper_DD(string st001)
		{
			return SqlHelper.ExecuteFunc("pkg_report.fun_Mapper_DD", st001).ToString();
		}
		/// <summary>
		/// 映射操作员
		/// </summary>
		/// <param name="uc001"></param>
		/// <returns></returns>
		public static string Mapper_Operator(string uc001)
		{
			return SqlHelper.ExecuteFunc("pkg_report.fun_operatorMapper", uc001).ToString();
		}
		/// <summary>
		/// 财务收费作废
		/// </summary>
		/// <param name="fa001"></param>
		/// <param name="fa003"></param>
		/// <param name="handler"></param>
		/// <returns></returns>
		public static int FinanceRemove(string fa001,string fa003,string handler)
		{
			return SqlHelper.ExecuteProc("pkg_business.prc_FinanceRemove",fa001,fa003, handler);
		}
		/// <summary>
		/// 设置财务单据号
		/// </summary>
		/// <param name="fa001"></param>
		/// <param name="billno"></param>
		/// <returns></returns>
		public static int SetFinanceBill(string fa001,string billno)
		{
			return SqlHelper.ExecuteProc("pkg_business.prc_SetFinanceBill", fa001,billno);
		}

		/// <summary>
		/// 财务类别统计
		/// </summary>
		/// <param name="dbegin"></param>
		/// <param name="dend"></param>
		/// <param name="class_arry"></param>
		/// <returns></returns>
		public static int ClassStat(string dbegin, string dend, string[] class_arry)
		{
			OracleCommand cmd = new OracleCommand("pkg_report.prc_ClassStat", SqlHelper.conn);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			OracleTransaction trans = null;

			//统计日期1
			OracleParameter op_begin = new OracleParameter("ic_begin", OracleDbType.Varchar2, 16);
			op_begin.Direction = ParameterDirection.Input;
			op_begin.Value = dbegin;
			//统计日期2
			OracleParameter op_end = new OracleParameter("ic_end", OracleDbType.Varchar2, 16);
			op_end.Direction = ParameterDirection.Input;
			op_end.Value = dend;

			//销售记录编号数组
			OracleParameter op_class_arry = new OracleParameter("ic_class", OracleDbType.Varchar2);
			op_class_arry.Direction = ParameterDirection.Input;
			op_class_arry.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
			op_class_arry.Value = class_arry;

			OracleParameter appcode = new OracleParameter("on_appcode", OracleDbType.Int16);
			appcode.Direction = ParameterDirection.Output;
			OracleParameter apperror = new OracleParameter("oc_error", OracleDbType.Varchar2, 100);
			apperror.Direction = ParameterDirection.Output;

			try
			{
				trans = SqlHelper.conn.BeginTransaction();
				cmd.Parameters.AddRange(new OracleParameter[] { op_begin, op_end, op_class_arry, appcode, apperror });
				cmd.ExecuteNonQuery();

				if (int.Parse(appcode.Value.ToString()) < 0)
				{
					trans.Rollback();
					XtraMessageBox.Show(apperror.Value.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return -1;
				}

				trans.Commit();
				return 1;
			}
			catch (InvalidOperationException e)
			{
				trans.Rollback();
				XtraMessageBox.Show("执行过程错误!\n" + e.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return -1;
			}
			finally
			{
				cmd.Dispose();
			}
		}

		/// <summary>
		/// 返回 分类统计笔数
		/// </summary>
		/// <returns></returns>
		public static int GetClassStat_BS()
		{
			return Convert.ToInt32(SqlHelper.ExecuteFunc("pkg_report.fun_GetClassStat_BS"));
		}

		public static int Modify_Pwd(string newPwd)
		{
			return SqlHelper.ExecuteProc("pkg_business.prc_Modify_Pwd", Envior.cur_user.UC001, newPwd);
		}

	}
}
