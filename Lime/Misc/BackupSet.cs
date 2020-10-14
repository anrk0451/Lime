using Lime.Action;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Lime.Misc
{
	[Serializable]
	class BackupSet : DataSet
	{
		private DataTable dt_rc01 = new DataTable("RC01");
		private OracleDataAdapter rc01Adapter = new OracleDataAdapter("select * from rc01", SqlHelper.conn);

		private DataTable dt_ac01 = new DataTable("AC01");
		private OracleDataAdapter ac01Adapter = new OracleDataAdapter("select * from ac01", SqlHelper.conn);

		private DataTable dt_sa01 = new DataTable("SA01");
		private OracleDataAdapter sa01Adapter = new OracleDataAdapter("select * from sa01", SqlHelper.conn);

		private DataTable dt_bi01 = new DataTable("BI01");
		private OracleDataAdapter bi01Adapter = new OracleDataAdapter("select * from bi01", SqlHelper.conn);

		private DataTable dt_cb01 = new DataTable("CB01");
		private OracleDataAdapter cb01Adapter = new OracleDataAdapter("select * from cb01", SqlHelper.conn);

		private DataTable dt_cb02 = new DataTable("CB02");
		private OracleDataAdapter cb02Adapter = new OracleDataAdapter("select * from cb02", SqlHelper.conn);

		private DataTable dt_fa01 = new DataTable("FA01");
		private OracleDataAdapter fa01Adapter = new OracleDataAdapter("select * from fa01", SqlHelper.conn);

		private DataTable dt_fa02 = new DataTable("FA02");
		private OracleDataAdapter fa02Adapter = new OracleDataAdapter("select * from fa02", SqlHelper.conn);

		private DataTable dt_fc01 = new DataTable("FC01");
		private OracleDataAdapter fc01Adapter = new OracleDataAdapter("select * from fc01", SqlHelper.conn);

		private DataTable dt_ly01 = new DataTable("LY01");
		private OracleDataAdapter ly01Adapter = new OracleDataAdapter("select * from ly01", SqlHelper.conn);

		private DataTable dt_oc01 = new DataTable("OC01");
		private OracleDataAdapter oc01Adapter = new OracleDataAdapter("select * from oc01", SqlHelper.conn);

		private DataTable dt_rc04 = new DataTable("RC04");
		private OracleDataAdapter rc04Adapter = new OracleDataAdapter("select * from rc04", SqlHelper.conn);

		private DataTable dt_rg01 = new DataTable("RG01");
		private OracleDataAdapter rg01Adapter = new OracleDataAdapter("select * from rg01", SqlHelper.conn);

		private DataTable dt_sa10 = new DataTable("SA10");
		private OracleDataAdapter sa10Adapter = new OracleDataAdapter("select * from sa10", SqlHelper.conn);

		private DataTable dt_si01 = new DataTable("SI01");
		private OracleDataAdapter si01Adapter = new OracleDataAdapter("select * from si01", SqlHelper.conn);

		private DataTable dt_st01 = new DataTable("ST01");
		private OracleDataAdapter st01Adapter = new OracleDataAdapter("select * from st01", SqlHelper.conn);

		public BackupSet()
		{
			this.Tables.Add(dt_rc01);
			rc01Adapter.Fill(dt_rc01);

			this.Tables.Add(dt_ac01);
			rc01Adapter.Fill(dt_ac01);

			this.Tables.Add(dt_sa01);
			sa01Adapter.Fill(dt_sa01);

			this.Tables.Add(dt_bi01);
			bi01Adapter.Fill(dt_bi01);

			this.Tables.Add(dt_cb01);
			cb01Adapter.Fill(dt_cb01);

			this.Tables.Add(dt_cb02);
			cb02Adapter.Fill(dt_cb02);

			this.Tables.Add(dt_fa01);
			fa01Adapter.Fill(dt_fa01);

			this.Tables.Add(dt_fa02);
			fa02Adapter.Fill(dt_fa02);

			this.Tables.Add(dt_fc01);
			fc01Adapter.Fill(dt_fc01);

			this.Tables.Add(dt_ly01);
			ly01Adapter.Fill(dt_ly01);

			this.Tables.Add(dt_oc01);
			oc01Adapter.Fill(dt_oc01);

			this.Tables.Add(dt_rc04);
			rc04Adapter.Fill(dt_rc04);

			this.Tables.Add(dt_rg01);
			rg01Adapter.Fill(dt_rg01);

			this.Tables.Add(dt_sa10);
			sa10Adapter.Fill(dt_sa10);

			this.Tables.Add(dt_si01);
			si01Adapter.Fill(dt_si01);

			this.Tables.Add(dt_st01);
			st01Adapter.Fill(dt_st01);
		}

		public void Backup(string fname)
		{
			this.RemotingFormat = SerializationFormat.Binary;
			FileStream fs = new FileStream(fname, FileMode.Create);
			BinaryFormatter bFormat = new BinaryFormatter();
			bFormat.Serialize(fs, this);
			fs.Close();
			this.Clear();

			this.Dispose();

		}
	}
}
