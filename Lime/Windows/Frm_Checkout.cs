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
using Lime.Action;
using Oracle.ManagedDataAccess.Client;

namespace Lime.Windows
{
	public partial class Frm_Checkout : MyDialog
	{
		private DataTable dt_ac007_source = new DataTable();   //所属区县
		private OracleDataAdapter ac007Adapter =
			new OracleDataAdapter("select st001,st003 from st01 where st002 = 'DISTRICT' and status = '1' order by sortId", SqlHelper.conn);

		public Frm_Checkout()
		{
			InitializeComponent();
		}

		private void Frm_Checkout_Load(object sender, EventArgs e)
		{
			dateEdit2.EditValue = MiscAction.GetServerTime();
			dateEdit1.EditValue = MiscAction.GetServerTime().AddMonths(-1);

			ac007Adapter.Fill(dt_ac007_source);
			DataRow newrow = dt_ac007_source.NewRow();
			newrow["ST001"] = "%";
			newrow["ST003"] = "全部";
			dt_ac007_source.Rows.Add(newrow);

			lookUp_ac007.Properties.DataSource = dt_ac007_source;
			lookUp_ac007.Properties.DisplayMember = "ST003";
			lookUp_ac007.Properties.ValueMember = "ST001";
			lookUp_ac007.EditValue = "%";
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			this.swapdata["dbegin"] = dateEdit1.EditValue.ToString();
			this.swapdata["dend"] = dateEdit2.EditValue.ToString();
			this.swapdata["ac003"] = textEdit1.Text;
			this.swapdata["ac007"] = lookUp_ac007.EditValue;

			DialogResult = DialogResult.OK;
			this.Close();
		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}