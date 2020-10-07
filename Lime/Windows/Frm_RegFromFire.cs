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
using Oracle.ManagedDataAccess.Client;
using Lime.Action;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Lime.Windows
{
	public partial class Frm_RegFromFire : MyDialog
	{
		private DataTable dt_noreg = new DataTable();
		private OracleDataAdapter adapter = new OracleDataAdapter("select * from v_fire_noreg", SqlHelper.conn);
		public Frm_RegFromFire()
		{
			InitializeComponent();
		}

		private void Frm_RegFromFire_Load(object sender, EventArgs e)
		{
			gridControl1.DataSource = dt_noreg;
			adapter.Fill(dt_noreg);
		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			int rowHandle = gridView1.FocusedRowHandle;
			this.DoSelect(rowHandle);
		}
		private void DoSelect(int rowHandle)
		{
			if(rowHandle >= 0)
			{
				this.DialogResult = DialogResult.OK;
				this.swapdata["ac001"] = gridView1.GetRowCellValue(rowHandle, "AC001");
				this.Close();
			}
			else
			{
				XtraMessageBox.Show("请选择一条记录!","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
		}

		private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
			if (e.Column.FieldName == "AC002")
			{
				if (e.Value.ToString() == "0")
					e.DisplayText = "男";
				else if (e.Value.ToString() == "1")
					e.DisplayText = "女";
				else
					e.DisplayText = "未知";
			}
		}

		private void gridView1_MouseDown(object sender, MouseEventArgs e)
		{
			GridHitInfo hInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));
			if (e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				//判断光标是否在行范围内  
				if (hInfo.InRow)
				{
					DoSelect(gridView1.FocusedRowHandle);
				}
			}
		}
	}
}