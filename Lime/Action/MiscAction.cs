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

	}
}
