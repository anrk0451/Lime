using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Lime.BaseObject;
using Lime.Windows;

namespace Lime.BusinessObject
{
	public partial class RegisterBrow : BaseBusiness
	{
		public RegisterBrow()
		{
			InitializeComponent();
		}

		private void barHeaderItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{

		}
		/// <summary>
		/// 外来寄存
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Frm_Register frm_1 = new Frm_Register();
			frm_1.swapdata["source"] = "1";   //来源 1-外来寄存
			if(frm_1.ShowDialog() == DialogResult.OK)
			{

			}
			frm_1.Dispose();
		}
	}
}
