using DevExpress.Xpo;
using Lime.Xpo.orcl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lime.Misc
{
	/// <summary>
	/// 程序环境类
	/// </summary>
	static class Envior
	{
		public static Frm_main mform { get; set; }  //系统主窗口
		public static UC01 cur_user { get; set; }   //当前操作员
		public static string workstationId { get; set; }  //工作站ID
		public static int PRINT_PORT { get; set; }        //打印端口 

		/// <summary>
		/// 测试专用
		/// </summary>
		static Envior()
		{
			//cur_user = new UC01(XpoDefault.Session);
			//cur_user.UC001 = "0000000000";
			//cur_user.UC003 = "根用户";
			//cur_user.UC002 = "root";
		}
	}
}
