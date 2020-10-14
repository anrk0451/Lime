﻿using System;
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
	public partial class Frm_BitInfo : MyDialog
	{
		DataTable dt_bit = new DataTable();
		OracleDataAdapter bitAdapter = new OracleDataAdapter("", SqlHelper.conn);
		public Frm_BitInfo(string regionId,int layerNum, string bitDesc)
		{
			InitializeComponent();
			bitAdapter.SelectCommand.CommandText = "select bi003,bi009,pkg_report.fun_getBitFullName(rg001,bi005,bi003) position,rc003,rc140,rc150,a.status status from bi01 a,v_rc01 b " +
													   "where a.bi001 = b.rc130(+)  and rg001 = :rg001 and bi005 = :bi005 and bi003= :bi003  ";
			OracleParameter op_rg001 = new OracleParameter("rg001", OracleDbType.Varchar2, 10);
			op_rg001.Direction = ParameterDirection.Input;
			op_rg001.Value = regionId;

			OracleParameter op_bi005 = new OracleParameter("bi005", OracleDbType.Int32);
			op_bi005.Direction = ParameterDirection.Input;
			op_bi005.Value = layerNum;

			OracleParameter op_bi003 = new OracleParameter("bi003", OracleDbType.Varchar2, 50);
			op_bi003.Direction = ParameterDirection.Input;
			op_bi003.Value = bitDesc;
			 
			bitAdapter.SelectCommand.Parameters.AddRange(new OracleParameter[] { op_rg001, op_bi005,op_bi003 });
			bitAdapter.Fill(dt_bit);
		}

		private void Frm_BitInfo_Load(object sender, EventArgs e)
		{
			if (dt_bit.Rows.Count > 0)
			{
				textEdit1.EditValue = dt_bit.Rows[0]["POSITION"];  //位置
				textEdit2.EditValue = dt_bit.Rows[0]["BI009"];     //价格
				textEdit3.EditValue = dt_bit.Rows[0]["STATUS"];    //状态
				if (dt_bit.Rows[0]["STATUS"].ToString() == "1")
				{
					textEdit4.EditValue = dt_bit.Rows[0]["RC003"];     //逝者姓名
					dateEdit1.EditValue = dt_bit.Rows[0]["RC140"];     //寄存日期"  
					dateEdit2.EditValue = dt_bit.Rows[0]["RC150"];     //过期日期"  
				}
			}
		}

		private void textEdit3_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
		{
			if (e.Value == null)
				return;
			else if (e.Value.ToString() == "1")
				e.DisplayText = "占用";
			else if (e.Value.ToString() == "9")
				e.DisplayText = "空闲";
			else if (e.Value.ToString() == "0")
				e.DisplayText = "未用";
			else if (e.Value.ToString() == "8")
				e.DisplayText = "待缴费";
		}
	}
}