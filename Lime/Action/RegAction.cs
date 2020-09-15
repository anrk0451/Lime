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
	}
}
