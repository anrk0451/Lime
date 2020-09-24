using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lime.Action
{
	/// <summary>
	/// 寄存业务办理
	/// </summary>
	class RegAction
	{
		/// <summary>
		/// 获取寄存架 层定价
		/// </summary>
		/// <param name="regionId"></param>
		/// <param name="layerNum"></param>
		/// <returns></returns>
		public static decimal GetLayerPrice(string regionId,int layerNum)
		{
			object value = SqlHelper.ExecuteFunc("pkg_report.fun_getLayerPrice", regionId, layerNum);
			if (value == null)
				return 0;
			else
				return Convert.ToDecimal(value);
		}
		/// <summary>
		/// 返回寄存单元是否占用 1-占用 0-未占用
		/// </summary>
		/// <param name="rg001"></param>
		/// <returns></returns>
		public static int RegStruIsUse(string rg001)
		{
			return Convert.ToInt32(SqlHelper.ExecuteFunc("pkg_report.fun_regstruIsUse", rg001));
		}

		/// <summary>
		/// 返回寄存号位状态
		/// </summary>
		/// <param name="regionId"></param>
		/// <param name="bitDesc"></param>
		/// <returns></returns>
		public static string GetBitStatus(string regionId, string bitDesc)
		{
			return SqlHelper.ExecuteFunc("pkg_report.fun_getBitStatus", regionId, bitDesc).ToString();
		}
		/// <summary>
		/// 根据寄存排编号及号位描述 返回寄存号位ID
		/// </summary>
		/// <param name="regionId"></param>
		/// <param name="bitDesc"></param>
		/// <returns></returns>
		public static string GetBitId(string regionId, string bitDesc)
		{
			return SqlHelper.ExecuteFunc("pkg_report.fun_getBitId", regionId, bitDesc).ToString();
		}
		/// <summary>
		/// 返回寄存号位位置
		/// </summary>
		/// <param name="regionId"></param>
		/// <param name="bitDesc"></param>
		/// <returns></returns>
		public static string GetBitFullName(string regionId, string bitDesc)
		{
			return SqlHelper.ExecuteFunc("pkg_report.fun_getBitFullName", regionId, bitDesc).ToString();
		}
		/// <summary>
		/// 返回寄存号位定价
		/// </summary>
		/// <param name="regionId"></param>
		/// <param name="bitDesc"></param>
		/// <returns></returns>
		public static decimal GetBitPrice(string regionId, string bitDesc)
		{
			return Convert.ToDecimal(SqlHelper.ExecuteFunc("pkg_report.fun_getBitPrice2", regionId, bitDesc));
		}
		/// <summary>
		/// 根据寄存号位ID 返回寄存堂编号
		/// </summary>
		/// <param name="bitId"></param>
		/// <returns></returns>
		public static string GetHallIdByBitId(string bitId)
		{
			return SqlHelper.ExecuteFunc("pkg_report.fun_getHallIdByBitId", bitId).ToString();
		}

		/// <summary>
		/// 根据寄存号位ID 返回寄存室编号
		/// </summary>
		/// <param name="bitId"></param>
		/// <returns></returns>
		public static string GetRoomIdByBitId(string bitId)
		{
			return SqlHelper.ExecuteFunc("pkg_report.fun_getRoomIdByBitId", bitId).ToString();
		}
		/// <summary>
		/// 生成寄存证号
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static string GenRegisterNo(string type)
		{
			return SqlHelper.ExecuteFunc("pkg_business.GenRegisterNo", type).ToString();
		}
	}
}
