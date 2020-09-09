using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
