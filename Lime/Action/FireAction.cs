using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lime.Action
{
	/// <summary>
	/// 火化业务办理类
	/// </summary>
	class FireAction
	{
		/// <summary>
		/// 删除火化登记信息
		/// </summary>
		/// <param name="ac001"></param>
		/// <param name="handler"></param>
		/// <returns></returns>
		public static int RemoveFireCheckin(string ac001,string handler)
		{
			return SqlHelper.ExecuteProc("pkg_business.prc_removeFireCheckin", ac001,handler);
		}
		/// <summary>
		/// 判断是否火化结算 1-yes 0-no
		/// </summary>
		/// <param name="ac001"></param>
		/// <returns></returns>
		public static bool FireIsSettled(string ac001)
		{
			int i_result = Convert.ToInt32(SqlHelper.ExecuteFunc("pkg_business.fun_FireIsSettled", ac001));
			if (i_result == 1)
				return true;
			else
				return false;
		}
		/// <summary>
		/// 判断指定项目是否办理
		/// </summary>
		/// <param name="ac001"></param>
		/// <param name="itemType"></param>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public static bool ItemIsExisted(string ac001,string itemType,string itemId)
		{
			int i_result = Convert.ToInt32(SqlHelper.ExecuteFunc("pkg_business.fun_ItemIsExisted", ac001,itemType,itemId));
			if (i_result > 0)
				return true;
			else
				return false;
		}
		/// <summary>
		/// 获取项目名称
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public static string GetItemName(string itemId)
		{
			return SqlHelper.ExecuteFunc("pkg_report.fun_GetItemName", itemId).ToString();
		}

		/// <summary>
		/// 获取项目定价
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public static decimal GetItemPrice(string itemId)
		{
			return Convert.ToDecimal(SqlHelper.ExecuteFunc("pkg_report.fun_GetFixprice", itemId));
		}
		/// <summary>
		/// 获取逝者存放位置
		/// </summary>
		/// <param name="ac001"></param>
		/// <returns></returns>
		public static string GetGuyPosition(string ac001)
		{
			object result = SqlHelper.ExecuteFunc("pkg_report.fun_GetGuyPosition", ac001);
			return result == null ? "" : result.ToString();
		}
		/// <summary>
		/// 返回逝者 告别厅
		/// </summary>
		/// <param name="ac001"></param>
		/// <returns></returns>
		public static string GetGBT(string ac001)
		{
			object result = SqlHelper.ExecuteFunc("pkg_report.fun_GetGBT", ac001);
			return result == null ? "" : result.ToString();
		}
		/// <summary>
		/// 返回逝者 火化标准
		/// </summary>
		/// <param name="ac001"></param>
		/// <returns></returns>
		public static string GetHHL(string ac001)
		{
			object result = SqlHelper.ExecuteFunc("pkg_report.fun_GetHHL", ac001);
			return result == null ? "" : result.ToString();
		}
		/// <summary>
		/// 返回逝者 休息室
		/// </summary>
		/// <param name="ac001"></param>
		/// <returns></returns>
		public static string GetRestRoomList(string ac001)
		{
			object result = SqlHelper.ExecuteFunc("pkg_report.fun_getRestRoomList", ac001);
			return result == null ? "" : result.ToString();
		}
		/// <summary>
		/// 销售项目修改
		/// </summary>
		/// <param name="sa001"></param>
		/// <param name="new_price"></param>
		/// <param name="new_nums"></param>
		/// <param name="handler"></param>
		/// <returns></returns>
		public static int FireSalesEdit(string sa001,decimal new_price,decimal new_nums,string handler)
		{
			return SqlHelper.ExecuteProc("pkg_business.prc_FireSalesEdit", sa001,new_price,new_nums,handler);
		}
		/// <summary>
		/// 销售项目删除
		/// </summary>
		/// <param name="sa001"></param>
		/// <returns></returns>
		public static int FireSalesItemRemove(string sa001)
		{
			return SqlHelper.ExecuteProc("pkg_business.prc_FireSalesItemRemove", sa001 );
		}
		/// <summary>
		/// 设置火化时间
		/// </summary>
		/// <param name="ac001"></param>
		/// <returns></returns>
		public static int SetFireTime(string ac001,DateTime ac015)
		{
			return SqlHelper.ExecuteProc("pkg_business.prc_SetFireTime", ac001,ac015);
		}
		/// <summary>
		/// 判断销售项目是否已经结算
		/// </summary>
		/// <param name="sa001"></param>
		/// <returns></returns>
		public static bool SalesItemIsSettled(string sa001)
		{
			object result = SqlHelper.ExecuteFunc("pkg_business.fun_SalesItemIsSettled", sa001);
			if (result.ToString() == "1")
				return true;
			else
				return false;
		}
		/// <summary>
		/// 映射项目名
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public static string Mapper_Item(string itemId)
		{
			return SqlHelper.ExecuteFunc("pkg_report.fun_Mapper_Item", itemId).ToString();
		}
	}
}
