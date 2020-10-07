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

namespace Lime.Windows
{
	public partial class Frm_PrtPayRecord : MyDialog
	{
		private string rc001 = string.Empty;
		private DataTable dt_rc04 = new DataTable("RC04");
		private OracleDataAdapter rc04Adapter = new OracleDataAdapter("select * from v_rc04 where rc001 = :rc001", SqlHelper.conn);
		private OracleParameter op_rc001 = null;
		private string s_rc001 = string.Empty;

		public Frm_PrtPayRecord()
		{
			InitializeComponent();
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
			op_rc001 = new OracleParameter("rc001", OracleDbType.Varchar2, 10);
			op_rc001.Direction = ParameterDirection.Input;
		}

		private void Frm_PrtPayRecord_Load(object sender, EventArgs e)
		{
			s_rc001 = this.swapdata["rc001"].ToString();
			op_rc001.Value = s_rc001;
			rc04Adapter.SelectCommand.Parameters.Add(op_rc001);
			rc04Adapter.Fill(dt_rc04);
			gridControl1.DataSource = dt_rc04;
		}

		private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
			if (e.Column.FieldName == "RC031")
			{
				if (e.Value.ToString() == "0")
					e.DisplayText = "原始登记";
				else if (e.Value.ToString() == "1")
					e.DisplayText = "正常";
			}
			else if (e.Column.FieldName == "RC100")
			{
				e.DisplayText = MiscAction.Mapper_Operator(e.Value.ToString());
			}
		}

		private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
		{
			if (e.Action == CollectionChangeAction.Add)
			{
				int row = gridView1.FocusedRowHandle;
				for (int i = 0; i < gridView1.RowCount; i++)
				{
					if (i == row) continue;
					gridView1.UnselectRow(i);
				}
			}
			else if (e.Action == CollectionChangeAction.Refresh && gridView1.SelectedRowsCount > 0)
			{
				 
			}
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			if (gridView1.SelectedRowsCount == 0)
			{
				XtraMessageBox.Show("请先选择要打印的缴费记录!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			int row = gridView1.GetSelectedRows()[0];
			string fa001 = string.Empty;

			if(row == 0)
			{
				XtraMessageBox.Show("请选择续费记录打印!","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			else if (row > 0)
			{
				XtraMessageBox.Show("现在打印第" + row.ToString() + "条续费记录!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				fa001 = gridView1.GetRowCellValue(row, "RC010").ToString();
				PrintAction.Print_PayRecord(fa001);
				//this.Close();
			}
		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}