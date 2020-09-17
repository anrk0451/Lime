using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraEditors;
using Lime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lime.Action
{
	/// <summary>
	/// 数据库sql 帮助类
	/// </summary>
	class SqlHelper
	{
		/// <summary>
		/// 执行非查询类sql (数据操控语句直接提交)
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public static int ExecuteNonQuery(string sql)
		{
			return XpoDefault.Session.ExecuteNonQuery(sql);
		}

		/// <summary>
		/// 执行带参数的非查询类 sql 
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="parameterValues"></param>
		/// <returns></returns>
		public static int ExecuteNonQuery(string sql,string[] paraname,Object[] parameterValues)
		{
			return XpoDefault.Session.ExecuteNonQuery(sql, paraname,parameterValues);
		}

		/// <summary>
		/// 执行SQL语句 返回第一行第一列
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public static object ExecuteScalar(string sql)
		{
			return XpoDefault.Session.ExecuteScalar(sql);
		}
		/// <summary>
		/// 执行sql(带参数) 返回第一行第一列
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="parameterValues"></param>
		/// <returns></returns>
		public static object ExecuteScalar(string sql, string[] paraname,object[] parameterValues)
		{
			return XpoDefault.Session.ExecuteScalar(sql,paraname, parameterValues);
		}

		/// <summary>
		/// 执行SQL查询 返回结果集
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public static SelectedData ExecuteQuery(string sql)
		{
			return XpoDefault.Session.ExecuteQuery(sql);
		}

		/// <summary>
		/// 执行带参数SQL查询 返回结果集
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="paraname"></param>
		/// <param name="parameterValues"></param>
		/// <returns></returns>
		public static SelectedData ExecuteQuery(string sql, string[] paraname, object[] parameterValues)
		{
			return XpoDefault.Session.ExecuteQuery(sql, paraname, parameterValues);
		}

		/// <summary>
		/// 执行数据库函数()
		/// </summary>
		/// <param name="procName"></param>
		/// <param name=""></param>
		/// <returns></returns>
		public static object ExecuteFunc(string funcName, params OperandValue[] parameters)
		{
			SelectedData result = null;
			try
			{
				result = XpoDefault.Session.ExecuteSproc(funcName.ToUpper(), parameters);
				return result.ResultSet[1].Rows[0].Values[0];
			}
			catch (Exception ee)
			{
				LogUtils.Error(ee.ToString());
				XtraMessageBox.Show(ee.ToString(),"执行错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return null;
			}			 
		}


		public static int ExecuteProc(string procName, params OperandValue[] parameters)
		{
			SelectedData result = null;
			string s_error = string.Empty;
			int i_ret_code = 0;
			try
			{
				result = XpoDefault.Session.ExecuteSproc(procName.ToUpper(), parameters);

				i_ret_code = Convert.ToInt32(result.ResultSet[1].Rows[0].Values[1]);
				if(result.ResultSet[1].Rows[1].Values[1] != null)
					s_error = result.ResultSet[1].Rows[1].Values[1].ToString();

				if (i_ret_code > 0)
					return i_ret_code;
				else
				{
					///LogUtils.Error(s_error);
					XtraMessageBox.Show(s_error,"提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return -1;
				}
			}
			catch (Exception ee)
			{
				LogUtils.Error(ee.ToString());
				XtraMessageBox.Show(ee.ToString(), "执行错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return -1;
			}
		}
	}
}
