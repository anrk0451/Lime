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
using Oracle.ManagedDataAccess.Client;
using Lime.Action;

namespace Lime.BusinessObject
{
	public partial class Report_Having : BaseBusiness
	{
		private DataTable dt_ac01 = new DataTable();
		private OracleDataAdapter ac01Adaapter = new OracleDataAdapter("select * from  v_having", SqlHelper.conn);

		public Report_Having()
		{
			InitializeComponent();
			gridView1.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
		}

		private async void Report_Having_Load(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			gridView1.BeginUpdate();
			await RefreshData();
			gridView1.EndUpdate();
			this.Cursor = Cursors.Arrow;

			gridControl1.DataSource = dt_ac01;
		}

		private async Task RefreshData()
		{
			await Task.Run(() =>
			{
				dt_ac01.Rows.Clear();
				ac01Adaapter.Fill(dt_ac01);
			}
				);
		}

		private async void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			gridView1.BeginUpdate();
			gridControl1.DataSource = null;
			await RefreshData();
			gridControl1.DataSource = dt_ac01;
			gridView1.EndUpdate();
			this.Cursor = Cursors.Arrow;
		}
	}
}
