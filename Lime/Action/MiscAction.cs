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
	}
}
