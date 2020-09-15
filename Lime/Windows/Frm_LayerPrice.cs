using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Lime.BaseObject;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Columns;
using Lime.Xpo.orcl;

namespace Lime.Windows
{
	public partial class Frm_LayerPrice : MyDialog
	{
		private string s_regionId = string.Empty;
		private XPCollection xpCollection_ly01 = null;
		private XPCollection xpCollection_bi01 = null;
		public Frm_LayerPrice()
		{
			InitializeComponent();
		}

		private void Frm_LayerPrice_Load(object sender, EventArgs e)
		{
			if (this.swapdata.ContainsKey("xpcollection_ly01"))
			{
				xpCollection_ly01 = this.swapdata["xpcollection_ly01"] as XPCollection;
				xpCollection_bi01 = this.swapdata["xpcollection_bi01"] as XPCollection;

				s_regionId = this.swapdata["regionId"].ToString();
				CriteriaOperator criteria = CriteriaOperator.Parse("RG001 ='" + s_regionId + "'");
				xpCollection_ly01.Filter = criteria;
				gridControl1.DataSource = xpCollection_ly01;
			}
		}
		/// <summary>
		/// 复制价格
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void simpleButton1_Click(object sender, EventArgs e)
		{
			int row = gridView1.FocusedRowHandle;
			if (string.IsNullOrEmpty(gridView1.GetRowCellValue(row, "PRICE").ToString())) return;

			decimal price = decimal.Parse(gridView1.GetRowCellValue(row, "PRICE").ToString());
			for (int i = 1; i <= gridView1.RowCount; i++)
			{
				gridView1.SetRowCellValue(i - 1, "PRICE", price);
			}
		}
		/// <summary>
		/// 编辑校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
		{
			GridColumn col = gridView1.FocusedColumn;
			int row = gridView1.FocusedRowHandle;
			if (col.FieldName == "PRICE" && e.Value != null)
			{
				if (decimal.Parse(e.Value.ToString()) < 0)
				{
					e.Valid = false;
					e.ErrorText = "价格不能小于0!";
				}
			}
		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		/// <summary>
		/// 确定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void sb_ok_Click(object sender, EventArgs e)
		{
			if (!gridView1.PostEditor()) return;
			if (!gridView1.UpdateCurrentRow()) return;

			string s_rg001 = string.Empty;
			int i_ly002 = 0;
			decimal dec_price = decimal.Zero;
			//更新寄存号位价格
			for(int i = 0; i< gridView1.RowCount; i++)
			{
				s_rg001 = gridView1.GetRowCellValue(i, "RG001").ToString();
				i_ly002 = Convert.ToInt32(gridView1.GetRowCellValue(i, "LY002"));
				dec_price = Convert.ToDecimal(gridView1.GetRowCellValue(i, "PRICE"));
				CriteriaOperator criteria = CriteriaOperator.Parse("RG001 ='" + s_rg001 + "' and BI005=" + i_ly002 + " and STATUS = '9' and BI007 = '0' ");
				XPCollection<BI01> xp_temp = new XPCollection<BI01>(xpCollection_bi01.Session, xpCollection_bi01, criteria);
				foreach(BI01 bi01 in xp_temp)
				{
					bi01.BI009 = dec_price;
				}
				xp_temp.Dispose();
			}


			DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}