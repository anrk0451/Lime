using DevExpress.XtraEditors;
using Lime.Misc;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lime.Action
{
	/// <summary>
	/// 打印服务类
	/// </summary>
	class PrintAction
	{
		private static string PADSTR = "!@#";
		private static string PADSTR2 = "$$$";

		class Send_PrintData
		{
			public string command { get; set; }
			public string data { get; set; }
			public string extra1 { get; set; }   //附加信息1
			public string extra2 { get; set; }   //附加信息2
			public string extra3 { get; set; }   //附加信息3
			public string extra4 { get; set; }   //附加信息4
			public string extra5 { get; set; }   //附加信息5

		}
		/// <summary>
		/// 打印火化证明
		/// </summary>
		/// <param name="ac001"></param>
		public static void Print_HHZM(string ac001)
		{
			StringBuilder sb_1 = new StringBuilder(200);
			OracleCommand oc_command = new OracleCommand("select * from V_PRINT_HHZM where ac001 = :ac001", SqlHelper.conn);
			OracleParameter op_ac001 = new OracleParameter("ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;
			oc_command.Parameters.Add(op_ac001);

			OracleDataReader reader = oc_command.ExecuteReader();
			if (reader.HasRows && reader.Read())
			{
				if (reader["MM"] == null || reader["MM"] is DBNull)
					sb_1.Append("" + PADSTR);                               //密码
				else
					sb_1.Append(reader["MM"].ToString() + PADSTR);


				if (reader["AC003"] == null || reader["AC003"] is DBNull)
					sb_1.Append("" + PADSTR);                               //逝者姓名
				else
					sb_1.Append(reader["AC003"].ToString() + PADSTR);

				if (reader["AC002"] == null || reader["AC002"] is DBNull)
					sb_1.Append("" + PADSTR);                               //逝者性别
				else
					sb_1.Append(reader["AC002"].ToString() + PADSTR);

				if (reader["AC004"] == null || reader["AC004"] is DBNull)
					sb_1.Append("" + PADSTR);                               //逝者年龄
				else
					sb_1.Append(reader["AC004"].ToString() + PADSTR);

				if (reader["AC008"] == null || reader["AC008"] is DBNull)
					sb_1.Append("" + PADSTR);                               //住址
				else
					sb_1.Append(reader["AC008"].ToString() + PADSTR);

				if (reader["AC005"] == null || reader["AC005"] is DBNull)
					sb_1.Append("" + PADSTR);                               //死因
				else
					sb_1.Append(reader["AC005"].ToString() + PADSTR);

				if (reader["FIRETIME"] == null || reader["FIRETIME"] is DBNull)
					sb_1.Append("" + PADSTR);                               //火化时间
				else
					sb_1.Append(reader["FIRETIME"].ToString() + PADSTR);

				sb_1.Append(Envior.cur_user.UC003 + PADSTR);               //经办人

				if (reader["FIRETIME"] == null || reader["FIRETIME"] is DBNull)
					sb_1.Append("" + PADSTR);                              //经办时间
				else
					sb_1.Append(reader["FIRETIME"].ToString() + PADSTR);

				sb_1.Append(reader["UNITNAME"].ToString() + PADSTR);       //单位

				Send_PrintData printData = new Send_PrintData();
				printData.command = "hhzm";
				printData.data = sb_1.ToString();
				Frm_main.socket.sendMsg(Tool.ConvertObjectToJson(printData));
			}
			else
			{
				XtraMessageBox.Show("未找到数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			reader.Dispose();
			oc_command.Dispose();
		}
		/// <summary>
		/// 补打火化证明(带身份证)
		/// </summary>
		/// <param name="ac001"></param>
		public static void Print_HHZM_BD1(string ac001)
		{
			StringBuilder sb_1 = new StringBuilder(200);
			OracleCommand oc_command = new OracleCommand("select * from V_PRINT_HHZM where ac001 = :ac001", SqlHelper.conn);
			OracleParameter op_ac001 = new OracleParameter("ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;
			oc_command.Parameters.Add(op_ac001);

			OracleDataReader reader = oc_command.ExecuteReader();
			if (reader.HasRows && reader.Read())
			{
				sb_1.Append(reader["AC003"].ToString() + PADSTR);  //逝者姓名
				sb_1.Append(reader["AC002"].ToString() + PADSTR);  //逝者性别

				//所属区县
				if (reader["AC007"] == null || reader["AC007"] is DBNull)
					sb_1.Append("" + PADSTR);                                
				else
					sb_1.Append(MiscAction.Mapper_DD(reader["AC007"].ToString()) + PADSTR);

				sb_1.Append(reader["AC014"].ToString() + PADSTR);     //身份证号
				sb_1.Append(reader["FIRETIME"].ToString() + PADSTR);  //火化日期

				//死亡原因
				if (reader["AC005"] == null || reader["AC005"] is DBNull)
					sb_1.Append("" + PADSTR);
				else
					sb_1.Append(reader["AC005"].ToString()  + PADSTR);

				//经办日期
				sb_1.Append(string.Format("{0:yyyy年MM月dd日}", MiscAction.GetServerTime()) + PADSTR);
				sb_1.Append("" + PADSTR);

				Send_PrintData printData = new Send_PrintData();
				printData.command = "hhzm_bd1";
				printData.data = sb_1.ToString();
				Frm_main.socket.sendMsg(Tool.ConvertObjectToJson(printData));
			}
			else
			{
				XtraMessageBox.Show("未找到数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			reader.Dispose();
			oc_command.Dispose();
		}


		/// <summary>
		/// 补打火化证明(带身份证)
		/// </summary>
		/// <param name="ac001"></param>
		public static void Print_HHZM_BD2(string ac001,DateTime birth)
		{
			StringBuilder sb_1 = new StringBuilder(200);
			OracleCommand oc_command = new OracleCommand("select * from V_PRINT_HHZM where ac001 = :ac001", SqlHelper.conn);
			OracleParameter op_ac001 = new OracleParameter("ac001", OracleDbType.Varchar2, 10);
			op_ac001.Direction = ParameterDirection.Input;
			op_ac001.Value = ac001;
			oc_command.Parameters.Add(op_ac001);

			OracleDataReader reader = oc_command.ExecuteReader();
			if (reader.HasRows && reader.Read())
			{
				sb_1.Append(reader["AC003"].ToString() + PADSTR);  //逝者姓名
				sb_1.Append(reader["AC002"].ToString() + PADSTR);  //逝者性别

				//所属区县
				if (reader["AC007"] == null || reader["AC007"] is DBNull)
					sb_1.Append("" + PADSTR);
				else
					sb_1.Append(MiscAction.Mapper_DD(reader["AC007"].ToString()) + PADSTR);

				sb_1.Append(reader["AC014"].ToString() + PADSTR);     //身份证号
				sb_1.Append(reader["FIRETIME"].ToString() + PADSTR);  //火化日期

				//死亡原因
				if (reader["AC005"] == null || reader["AC005"] is DBNull)
					sb_1.Append("" + PADSTR);
				else
					sb_1.Append(reader["AC005"].ToString() + PADSTR);

				//经办日期
				sb_1.Append(string.Format("{0:yyyy年MM月dd日}", MiscAction.GetServerTime()) + PADSTR);
				sb_1.Append(string.Format("{0:yyyy年MM月dd日}", birth) + PADSTR);

				Send_PrintData printData = new Send_PrintData();
				printData.command = "hhzm_bd2";
				printData.data = sb_1.ToString();
				Frm_main.socket.sendMsg(Tool.ConvertObjectToJson(printData));
			}
			else
			{
				XtraMessageBox.Show("未找到数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			reader.Dispose();
			oc_command.Dispose();
		}



		/// <summary>
		/// 打印收款凭证（火化收费、临时性收费）
		/// </summary>
		/// <param name="fa001"></param>
		public static void Print_Skpz0(string fa001)
		{
			//结算数据
			OracleCommand oc_jsd = new OracleCommand("select * from v_fa01 where fa001= :fa001", SqlHelper.conn);
			OracleParameter op_fa001 = new OracleParameter("fa001", OracleDbType.Varchar2, 10);
			op_fa001.Direction = ParameterDirection.Input;
			op_fa001.Value = fa001;

			OracleParameter op_sa010 = new OracleParameter("sa010", OracleDbType.Varchar2, 10);
			op_sa010.Direction = ParameterDirection.Input;
			op_sa010.Value = fa001;

			oc_jsd.Parameters.Add(op_fa001);
			//结算明细数据
			OracleCommand oc_detail = new OracleCommand("select * from v_sa01 where sa010= :sa010", SqlHelper.conn);
			oc_detail.Parameters.Add(op_sa010);

			OracleDataReader reader = oc_jsd.ExecuteReader();
			OracleDataReader reader2 = oc_detail.ExecuteReader();

			string s_skr = string.Empty;
			string s_skrq = string.Empty;
			string s_cuname = string.Empty;
			int i_count = 0;
			int i_pages = 0;


			if (reader.HasRows && reader.Read())
			{
				StringBuilder sb_1 = new StringBuilder(100);
				while (reader2.Read())
				{
					sb_1.Append(reader2["SA002"].ToString() + PADSTR);                             // 服务商品类别
					sb_1.Append(reader2["SA003"].ToString() + PADSTR);                             // 服务或商品名
					sb_1.Append(reader2["PRICE"].ToString() + PADSTR);                             // 单价
					sb_1.Append(reader2["NUMS"].ToString() + PADSTR);                              // 数量
					sb_1.Append(reader2["SA007"].ToString() + PADSTR);                             // 销售金额
					sb_1.Append(PADSTR2);
					i_count++;
				}

				s_skr = MiscAction.Mapper_Operator(reader["FA100"].ToString());
				s_skrq = string.Format("{0:yyyyMMdd}", reader["FA200"]);
				s_cuname = reader["FA003"].ToString();

				Send_PrintData printData = new Send_PrintData();
				printData.command = "print_skpz0";
				printData.data = sb_1.ToString();
				
				printData.extra1 = s_cuname;
				printData.extra2 = s_skr;
				printData.extra3 = s_skrq; 

				i_pages = (int)Math.Ceiling(i_count / (App_Const.BILL_COUNT * 1.0));
				XtraMessageBox.Show("现在开始打印【收据】，共需要" + i_pages.ToString() + "张!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Frm_main.socket.sendMsg(Tool.ConvertObjectToJson(printData));
			}
			else
			{
				MessageBox.Show("未找到结算数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			reader.Dispose();
			reader2.Dispose();
			oc_jsd.Dispose();

		}

		/// <summary>
		/// 打印收款凭证（寄存收费）
		/// </summary>
		/// <param name="fa001"></param>
		public static void Print_Skpz1(string fa001)
		{
			//结算数据
			OracleCommand oc_jsd = new OracleCommand("select * from v_fa01 where fa001= :fa001", SqlHelper.conn);
			OracleParameter op_fa001 = new OracleParameter("fa001", OracleDbType.Varchar2, 10);
			op_fa001.Direction = ParameterDirection.Input;
			op_fa001.Value = fa001;

			OracleParameter op_sa010 = new OracleParameter("sa010", OracleDbType.Varchar2, 10);
			op_sa010.Direction = ParameterDirection.Input;
			op_sa010.Value = fa001;

			oc_jsd.Parameters.Add(op_fa001);
			//结算明细数据
			OracleCommand oc_detail = new OracleCommand("select * from v_sa01 where sa010= :sa010", SqlHelper.conn);
			oc_detail.Parameters.Add(op_sa010);

			OracleDataReader reader = oc_jsd.ExecuteReader();
			OracleDataReader reader2 = oc_detail.ExecuteReader();

			string s_skr = string.Empty;
			string s_skrq = string.Empty;
			string s_cuname = string.Empty;
			string s_memo = string.Empty;
			int i_count = 0;
  
			if (reader.HasRows && reader.Read())
			{
				StringBuilder sb_1 = new StringBuilder(100);
				while (reader2.Read())
				{
					sb_1.Append(reader2["SA002"].ToString() + PADSTR);                             // 服务商品类别
					sb_1.Append(reader2["SA003"].ToString() + PADSTR);                             // 服务或商品名
					sb_1.Append(reader2["PRICE"].ToString() + PADSTR);                             // 单价
					sb_1.Append(reader2["NUMS"].ToString() + PADSTR);                              // 数量
					sb_1.Append(reader2["SA007"].ToString() + PADSTR);                             // 销售金额
					sb_1.Append(PADSTR2);
					i_count++;
				}

				s_skr = MiscAction.Mapper_Operator(reader["FA100"].ToString());
				s_skrq = string.Format("{0:yyyyMMdd}", reader["FA200"]);
				s_cuname = reader["FA003"].ToString();

				Send_PrintData printData = new Send_PrintData();
				printData.command = "print_skpz1";
				printData.data = sb_1.ToString();

				printData.extra1 = s_cuname;
				printData.extra2 = s_skr;
				printData.extra3 = s_skrq;
				printData.extra4 = RegAction.GetRegFinMemo(fa001);

				//i_pages = (int)Math.Ceiling(i_count / (App_Const.BILL_COUNT * 1.0));
				//XtraMessageBox.Show("现在开始打印【结算单】，共需要" + i_pages.ToString() + "张!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Frm_main.socket.sendMsg(Tool.ConvertObjectToJson(printData));
			}
			else
			{
				MessageBox.Show("未找到结算数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			reader.Dispose();
			reader2.Dispose();
			oc_jsd.Dispose();

		}
		/// <summary>
		/// 打印寄存证(基础)
		/// </summary>
		/// <param name="rc001"></param>
		public static void Print_RegCardBase(string rc001)
		{
			StringBuilder sb_1 = new StringBuilder(200);
			OracleCommand oc_command = new OracleCommand("select * from rc01 where rc001 = :rc001", SqlHelper.conn);
			OracleParameter op_rc001 = new OracleParameter("rc001", OracleDbType.Varchar2, 10);
			op_rc001.Direction = ParameterDirection.Input;
			op_rc001.Value = rc001;
			oc_command.Parameters.Add(op_rc001);			 
			OracleDataReader reader = oc_command.ExecuteReader();

			if (reader.HasRows && reader.Read())
			{
				sb_1.Append(reader["RC003"].ToString() + PADSTR);  //逝者姓名
				sb_1.Append(reader["RC109"].ToString() + PADSTR);  //寄存证号

				if (reader["RC002"] == null || reader["RC002"] is DBNull)
					sb_1.Append("" + PADSTR);                      //性别
				else
					sb_1.Append(reader["RC002"].ToString() + PADSTR);

				if (reader["RC004"] == null || reader["RC004"] is DBNull)
					sb_1.Append("" + PADSTR);                      //年龄
				else
					sb_1.Append(reader["RC004"].ToString() + PADSTR);
				                                                   //寄存位置
				string s_position = RegAction.GetRegPosition(reader["RC001"].ToString());
				if (string.IsNullOrEmpty(s_position))
					sb_1.Append("" + PADSTR);
				else
					sb_1.Append(s_position + PADSTR);

				if (reader["RC050"] == null || reader["RC050"] is DBNull)
					sb_1.Append("" + PADSTR);                      //联系人
				else
					sb_1.Append(reader["RC050"].ToString() + PADSTR);

				if (reader["RC051"] == null || reader["RC051"] is DBNull)
					sb_1.Append("" + PADSTR);                      //联系电话
				else
					sb_1.Append(reader["RC051"].ToString() + PADSTR);

				if (reader["RC200"] == null || reader["RC200"] is DBNull)
					sb_1.Append("" + PADSTR);                      //经办日期
				else 
					sb_1.Append(string.Format("{0:yyyy年MM月dd日}", reader["RC200"]) + PADSTR);

				if (reader["RC055"] == null || reader["RC055"] is DBNull)
					sb_1.Append("" + PADSTR);                      //联系地址
				else
					sb_1.Append(reader["RC055"].ToString() + PADSTR);

				if (reader["RC140"] == null || reader["RC140"] is DBNull)
					sb_1.Append("" + PADSTR);                      //寄存日期
				else
					sb_1.Append(string.Format("{0:yyyy-MM-dd}", reader["RC140"]) + PADSTR);


				DateTime d_end = Convert.ToDateTime(SqlHelper.ExecuteScalar("select min(rc022) from rc04 where status = '1' and rc001 = '" + rc001 + "'"));
				if(d_end == null)
					sb_1.Append("" + PADSTR);                      //截至日期
				else
					sb_1.Append(string.Format("{0:yyyy-MM-dd}", d_end) + PADSTR);

				decimal price = RegAction.GetRegPrice(rc001);
				sb_1.Append(price.ToString() + PADSTR);

				Send_PrintData printData = new Send_PrintData();
				printData.command = "RegCardBase";
				printData.data = sb_1.ToString();
				Frm_main.socket.sendMsg(Tool.ConvertObjectToJson(printData));
				  
			}
			reader.Dispose();
			oc_command.Dispose();

		}
		/// <summary>
		/// 打印骨灰安放卡
		/// </summary>
		/// <param name="rc001"></param>
		public static void Print_RegSettle(string rc001)
		{
			StringBuilder sb_1 = new StringBuilder(200);
			OracleCommand oc_command = new OracleCommand("select * from rc01 where rc001 = :rc001", SqlHelper.conn);
			OracleParameter op_rc001 = new OracleParameter("rc001", OracleDbType.Varchar2, 10);
			op_rc001.Direction = ParameterDirection.Input;
			op_rc001.Value = rc001;
			oc_command.Parameters.Add(op_rc001);
			OracleDataReader reader = oc_command.ExecuteReader();

			if (reader.HasRows && reader.Read())
			{
				sb_1.Append(reader["RC003"].ToString() + PADSTR);  //逝者姓名
				sb_1.Append(reader["RC109"].ToString() + PADSTR);  //寄存证号

				if (reader["RC002"] == null || reader["RC002"] is DBNull)
					sb_1.Append("" + PADSTR);                      //性别
				else
					sb_1.Append(reader["RC002"].ToString() + PADSTR);

				if (reader["RC004"] == null || reader["RC004"] is DBNull)
					sb_1.Append("" + PADSTR);                      //年龄
				else
					sb_1.Append(reader["RC004"].ToString() + PADSTR);

				//寄存位置
				string s_position = RegAction.GetRegPosition(reader["RC001"].ToString());
				if (string.IsNullOrEmpty(s_position))
					sb_1.Append("" + PADSTR);
				else
					sb_1.Append(s_position + PADSTR);

				if (reader["RC050"] == null || reader["RC050"] is DBNull)
					sb_1.Append("" + PADSTR);                      //联系人
				else
					sb_1.Append(reader["RC050"].ToString() + PADSTR);

				 
				if (reader["RC051"] == null || reader["RC051"] is DBNull)
					sb_1.Append("" + PADSTR);                      //联系电话
				else
					sb_1.Append(reader["RC051"].ToString() + PADSTR);


				if (reader["RC052"] == null || reader["RC052"] is DBNull)
					sb_1.Append("" + PADSTR);                      //与逝者关系
				else
					sb_1.Append(reader["RC052"].ToString() + PADSTR);
				 
				if (reader["RC200"] == null || reader["RC200"] is DBNull)
					sb_1.Append("" + PADSTR);                      //经办日期
				else
					sb_1.Append(string.Format("{0:yyyy年MM月dd日}", reader["RC200"]) + PADSTR);

				if (reader["RC055"] == null || reader["RC055"] is DBNull)
					sb_1.Append("" + PADSTR);                      //联系地址
				else
					sb_1.Append(reader["RC055"].ToString() + PADSTR);

				 
				Send_PrintData printData = new Send_PrintData();
				printData.command = "RegSettleCard";
				printData.data = sb_1.ToString();
				Frm_main.socket.sendMsg(Tool.ConvertObjectToJson(printData));

			}
			reader.Dispose();
			oc_command.Dispose();

		}
		/// <summary>
		/// 打印 迁出通知单
		/// </summary>
		/// <param name="rc001"></param>
		public static void Print_OutCard(string rc001)
		{
			StringBuilder sb_1 = new StringBuilder(200);
			OracleCommand oc_command = new OracleCommand("select * from v_outcard where rc001 = :rc001", SqlHelper.conn);
			OracleParameter op_rc001 = new OracleParameter("rc001", OracleDbType.Varchar2, 10);
			op_rc001.Direction = ParameterDirection.Input;
			op_rc001.Value = rc001;
			oc_command.Parameters.Add(op_rc001);
			OracleDataReader reader = oc_command.ExecuteReader();
			if (reader.HasRows && reader.Read())
			{
				sb_1.Append(reader["RC003"].ToString().Trim() + PADSTR);     //逝者姓名
				sb_1.Append(reader["RC109"].ToString().Trim() + PADSTR);     //寄存证号
				sb_1.Append(reader["POSITION"].ToString() + PADSTR);  //寄存位置

				if (reader["RC050"] == null || reader["RC050"] is DBNull)
					sb_1.Append("" + PADSTR);                          //家属姓名
				else
					sb_1.Append(reader["RC050"].ToString().Trim() + PADSTR);

				if (reader["RC051"] == null || reader["RC051"] is DBNull)
					sb_1.Append("" + PADSTR);                          //联系电话
				else
					sb_1.Append(reader["RC051"].ToString().Trim() + PADSTR);

				if (reader["OC002"] == null || reader["OC002"] is DBNull)
					sb_1.Append("" + PADSTR);                          //迁出日期
				else
					sb_1.Append(string.Format("{0:yyyy-MM-dd}", reader["OC002"]) + PADSTR);

				if (reader["RC055"] == null || reader["RC055"] is DBNull)
					sb_1.Append("" + PADSTR);                          //联系地址
				else
					sb_1.Append(reader["RC055"].ToString().Trim() + PADSTR);

				if (reader["OC005"] == null || reader["OC005"] is DBNull)
					sb_1.Append("" + PADSTR);                          //迁出原因
				else
					sb_1.Append(reader["OC005"].ToString().Trim() + PADSTR);

				Send_PrintData printData = new Send_PrintData();
				printData.command = "OutCard";
				printData.data = sb_1.ToString();
				Frm_main.socket.sendMsg(Tool.ConvertObjectToJson(printData));


			}
			reader.Dispose();
			oc_command.Dispose();
		}

		public static void Print_PayRecord(string fa001)
		{
			int i_order = RegAction.GetPayTimes(fa001);
			 
			StringBuilder sb_1 = new StringBuilder(200);
			OracleCommand oc_command = new OracleCommand("select * from rc04 where rc010 = :fa001", SqlHelper.conn);
			OracleParameter op_fa001 = new OracleParameter("fa001", OracleDbType.Varchar2, 10);
			op_fa001.Direction = ParameterDirection.Input;
			op_fa001.Value = fa001;
			oc_command.Parameters.Add(op_fa001);
			OracleDataReader reader = oc_command.ExecuteReader();
 
			if (reader.HasRows && reader.Read())
			{
				int i_times = i_order % App_Const.PAYPAGECOUNT;

				if (i_times == 1 && i_order > 1)
				{
					XtraMessageBox.Show("需要更换新证!请先将新证放入打印机打印基础信息!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Print_RegCardBase(reader["RC001"].ToString());
				}

				if (i_times == 0) i_times = App_Const.PAYPAGECOUNT;

				sb_1.Append(string.Format("{0:yyyyMMdd}", reader["RC200"]) + PADSTR);    //经办日期
				sb_1.Append(string.Format("{0:yyyy-MM-dd}", reader["RC020"]) + PADSTR);  //缴费开始
				sb_1.Append(string.Format("{0:yyyy-MM-dd}", reader["RC022"]) + PADSTR);  //缴费终止

				string s_handler = reader["RC100"].ToString();  //经办人
				string s_handler_code = SqlHelper.ExecuteScalar("select uc002 from uc01 where uc001='" + s_handler + "'").ToString();

				sb_1.Append(s_handler_code + PADSTR);            //经办人代码
				sb_1.Append("第" + i_order.ToString() + "次" + PADSTR);

				Send_PrintData printData = new Send_PrintData();
				printData.command = "payrecord";
				printData.data = sb_1.ToString();
				printData.extra1 = i_times.ToString();

				Frm_main.socket.sendMsg(Tool.ConvertObjectToJson(printData));
			}
			reader.Dispose();
			oc_command.Dispose();			 
		}
	}
}
