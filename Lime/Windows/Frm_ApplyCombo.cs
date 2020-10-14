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
using Lime.Misc;
using DevExpress.XtraEditors.Controls;

namespace Lime.Windows
{
	public partial class Frm_ApplyCombo : MyDialog
	{
		private string AC001;
		private DataTable cb01 = new DataTable();
		private OracleDataAdapter cb01Adapter =
			new OracleDataAdapter("select * from cb01 where cb002 = '1' and status = '1'", SqlHelper.conn);


		public Frm_ApplyCombo()
		{
			InitializeComponent();
		}

		private void Frm_ApplyCombo_Load(object sender, EventArgs e)
		{
			AC001 = this.swapdata["ac001"].ToString();
			cb01Adapter.Fill(cb01);
			ck.DataSource = cb01;
			ck.ValueMember = "CB001";
			ck.DisplayMember = "CB003";
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			if (ck.CheckedItemsCount == 0)
			{
				XtraMessageBox.Show("请先选择项目!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			int result; 
			string cb001 = string.Empty;  // ck.SelectedValue.ToString();

			int count = ck.CheckedIndices.Count;
			var chkIndexCollection = ck.CheckedIndices;
			for (int i = 0; i < count; i++)
			{
				var sysusers = ck.DataSource as DataTable;
				var item = sysusers.Rows[chkIndexCollection[i]];//chkIndexCollection[i]获得选中行在chechedListBOX的index 关键代码
				cb001 = item["CB001"].ToString();
				result = FireAction.ApplyUserCombo(AC001,
													   cb001,
													   Envior.cur_user.UC001
				);
				if (result < 0) return;
			}
			 
			DialogResult = DialogResult.OK;
			this.Close(); 
		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}