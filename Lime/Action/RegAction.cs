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
		public static string GetBitStatus(string regionId,int layerNum, string bitDesc)
		{
			return SqlHelper.ExecuteFunc("pkg_report.fun_getBitStatus", regionId, layerNum,bitDesc).ToString();
		}
		/// <summary>
		/// 根据寄存排编号及号位描述 返回寄存号位ID
		/// </summary>
		/// <param name="regionId"></param>
		/// <param name="bitDesc"></param>
		/// <returns></returns>
		public static string GetBitId(string regionId, int layerNum ,string bitDesc)
		{
			return SqlHelper.ExecuteFunc("pkg_report.fun_getBitId", regionId, layerNum,bitDesc).ToString();
		}
		/// <summary>
		/// 返回寄存号位位置
		/// </summary>
		/// <param name="regionId"></param>
		/// <param name="bitDesc"></param>
		/// <returns></returns>
		public static string GetBitFullName(string regionId,int layerNum, string bitDesc)
		{
			return SqlHelper.ExecuteFunc("pkg_report.fun_getBitFullName", regionId, layerNum, bitDesc).ToString();
		}
		/// <summary>
		/// 返回寄存号位定价
		/// </summary>
		/// <param name="regionId"></param>
		/// <param name="bitDesc"></param>
		/// <returns></returns>
		public static decimal GetBitPrice(string regionId,int layerNum, string bitDesc)
		{
			return Convert.ToDecimal(SqlHelper.ExecuteFunc("pkg_report.fun_getBitPrice2", regionId, layerNum,bitDesc));
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
			return SqlHelper.ExecuteFunc("pkg_business.fun_GenRegisterNo", type).ToString();
		}
		/// <summary>
		/// 返回寄存逝者寄存位置
		/// </summary>
		/// <param name="rc001"></param>
		/// <returns></returns>
		public static string GetRegPosition(string rc001)
		{
			return SqlHelper.ExecuteFunc("pkg_report.fun_getRegPosition", rc001).ToString();
		}
		/// <summary>
		/// 返回寄存逝者寄存号位单价
		/// </summary>
		/// <param name="rc001"></param>
		/// <returns></returns>
		public static decimal GetRegPrice(string rc001)
		{
			return Convert.ToDecimal(SqlHelper.ExecuteFunc("pkg_report.fun_getRegPrice", rc001));
		}
		/// <summary>
		/// 续交寄存费
		/// </summary>
		/// <param name="rc001"></param>
		/// <param name="fa001"></param>
		/// <param name="price"></param>
		/// <param name="nums"></param>
		/// <param name="handler"></param>
		/// <returns></returns>
		public static int RegisterPay(string rc001,string fa001,decimal price,int nums,string handler)
		{
			return SqlHelper.ExecuteProc("pkg_business.prc_RegisterPay",rc001,fa001,price,nums, handler);
		} 

		public static int RegisterMove(string rc001,string bi001_old,string bi001_new,string reason,string handler)
		{
			return SqlHelper.ExecuteProc("pkg_business.prc_RegisterMove", rc001,bi001_old,bi001_new,reason,handler);
		}
		/// <summary>
		/// 计算寄存迁出差异天数
		/// </summary>
		/// <param name="rc001"></param>
		/// <returns></returns>
		public static int CalcOutDiffDays(string rc001)
		{
			return Convert.ToInt32(SqlHelper.ExecuteFunc("pkg_business.fun_CalcOutDiffDays", rc001));
		}
		/// <summary>
		/// 寄存迁出办理
		/// </summary>
		/// <param name="rc001"></param>
		/// <param name="oc003"></param>
		/// <param name="oc004"></param>
		/// <param name="oc005"></param>
		/// <param name="oc030"></param>
		/// <param name="fa001"></param>
		/// <param name="price"></param>
		/// <param name="nums"></param>
		/// <param name="handler"></param>
		/// <returns></returns>
		public static int RegisterOut(string rc001,string oc003,string oc004,string oc005,int oc030,string fa001,decimal price,decimal nums,string handler)
		{
			return SqlHelper.ExecuteProc("pkg_business.prc_RegisterOut",rc001,oc003,oc004,oc005,oc030,fa001,price,nums,handler);
		}
		/// <summary>
		/// 获取寄存续费次数
		/// </summary>
		/// <param name="fa001"></param>
		/// <returns></returns>
		public static int GetPayTimes(string fa001)
		{
			return Convert.ToInt32(SqlHelper.ExecuteFunc("pkg_business.fun_GetPayTimes", fa001));
		}
		/// <summary>
		/// 获取寄存缴费交款备注
		/// </summary>
		/// <param name="fa001"></param>
		/// <returns></returns>
		public static string GetRegFinMemo(string fa001)
		{
			return SqlHelper.ExecuteFunc("pkg_business.fun_GetRegFinMemo", fa001).ToString();
		}

		/// <summary>
		/// 返回寄存结构共有号位数
		/// </summary>
		/// <param name="rg001"></param>
		/// <returns></returns>
		public static int GetRgAllBits(string rg001)
		{
			return Convert.ToInt32(SqlHelper.ExecuteFunc("pkg_report.fun_GetRgAllBits", rg001));
		}

		/// <summary>
		/// 返回寄存结构欠费号位数
		/// </summary>
		/// <param name="rg001"></param>
		/// <returns></returns>
		public static int GetRgDebtBits(string rg001)
		{
			return Convert.ToInt32(SqlHelper.ExecuteFunc("pkg_report.fun_GetRgDebtBits", rg001));
		}

		/// <summary>
		/// 返回寄存结构空闲号位数
		/// </summary>
		/// <param name="rg001"></param>
		/// <returns></returns>
		public static int GetRgFreeBits(string rg001)
		{
			return Convert.ToInt32(SqlHelper.ExecuteFunc("pkg_report.fun_GetRgFreeBits", rg001));
		}

		/// <summary>
		/// 返回寄存结构占用号位数
		/// </summary>
		/// <param name="rg001"></param>
		/// <returns></returns>
		public static int GetRgUsedBits(string rg001)
		{
			return Convert.ToInt32(SqlHelper.ExecuteFunc("pkg_report.fun_GetRgUsedBits", rg001));
		}
	}
}
