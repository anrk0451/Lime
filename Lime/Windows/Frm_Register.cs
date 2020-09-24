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
using Lime.Xpo.orcl;
using Oracle.ManagedDataAccess.Client;
using Lime.Action;
using Lime.Misc;
using DevExpress.XtraGrid.Views.Base;

namespace Lime.Windows
{
	public partial class Frm_Register : MyDialog
	{
		private string regionId = string.Empty;
		private string bitDesc = string.Empty;
		private string bitId = string.Empty;

		private decimal bitPrice = decimal.Zero;   //号位定价
		private decimal fpfee = decimal.Zero;      //附品费用 	
		private decimal regfee = decimal.Zero;     //寄存费用

		private string s_source = string.Empty;    //寄存来源
		private string s_rc001 = string.Empty;
		private RC01 rc01 = null;

		private DataTable dt_st01 = new DataTable("ST01");
		private OracleDataAdapter st01Adapter = new OracleDataAdapter("select * from st01 where status = '1' ",SqlHelper.conn);
		private DataView dv_relation = null;

		private DataTable dt_allItem = new DataTable();
		private OracleDataAdapter itemAdapter = new OracleDataAdapter("select * from v_allValidItem where item_type = '13' ", SqlHelper.conn);

		private DataTable dt_reg_combo = new DataTable();
		private OracleDataAdapter comboAdapter = new OracleDataAdapter("select * from cb02 where cb001 in (select cb001 from cb01 where cb002 = '0' and cb005 = '08' and status = '1' ) order by cb001 ", SqlHelper.conn);

		public Frm_Register()
		{
			InitializeComponent();
		}

		private void Frm_Register_Load(object sender, EventArgs e)
		{
			///初始化
			st01Adapter.Fill(dt_st01);
			dv_relation = new DataView(dt_st01);
			dv_relation.RowFilter = "ST002='RELATION'";
			lookUp_rc052.Properties.DataSource = dv_relation;
			lookUp_rc052.Properties.ValueMember = "ST003";
			lookUp_rc052.Properties.DisplayMember = "ST003";

			itemAdapter.Fill(dt_allItem);
			rep_lookup_sa004.DataSource = dt_allItem;
			rep_lookup_sa004.DisplayMember = "ITEM_TEXT";
			rep_lookup_sa004.ValueMember = "ITEM_ID";

			comboAdapter.Fill(dt_reg_combo);

			//寄存所属套餐
			foreach (DataRow r in dt_reg_combo.Rows)
			{
				SA01 sa01 = new SA01(unitOfWork1);
				sa01.SA004 = r["CB021"].ToString();                           //商品或服务编号
				sa01.PRICE = FireAction.GetItemPrice(r["CB021"].ToString());
				sa01.NUMS = Convert.ToInt32(r["CB030"]);
				sa01.SA006 = sa01.PRICE;
				sa01.SA007 = sa01.PRICE * sa01.NUMS;
				fpfee += sa01.SA007;
				xpCollection_sa01.Add(sa01);
			}
			this.CalcHJ();

			s_source = this.swapdata["source"].ToString();
			if(s_source == "0" /* 本馆火化 */  || s_source == "8"  /*待缴费*/)
			{
				s_rc001 = this.swapdata["rc001"].ToString();
				AC01 ac01 = unitOfWork1.GetObjectByKey<AC01>(s_rc001);
				if(ac01 != null)
				{
					txtEdit_rc003.EditValue = ac01.AC003;    //逝者姓名
					rg_rc002.EditValue = ac01.AC002;		 //性别
					txtEdit_rc004.EditValue = ac01.AC004;    //年龄
					txtedit_rc014.EditValue = ac01.AC014;    //身份证号
					txtEdit_rc050.EditValue = ac01.AC050;    //联系人
					lookUp_rc052.EditValue = ac01.AC052;     //与逝者关系
					txtEdit_rc051.EditValue = ac01.AC051;    //联系电话
					txtEdit_ac055.EditValue = ac01.AC055;    //联系地址
					txtEdit_rc001.Text = ac01.AC001;		 //逝者编号
					sb_clear.Enabled = false;
				}
				else
				{
					XtraMessageBox.Show("数据参数错误!","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					sb_ok.Enabled = false;
					return;
				}
			}			 
		}
 
		/// <summary>
		/// 选择寄存位置
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void be_position_Click(object sender, EventArgs e)
		{
			Frm_FreeBit frm_free = new Frm_FreeBit();
			frm_free.swapdata["parent"] = this;

			if (frm_free.ShowDialog() == DialogResult.OK)
			{
				regionId = this.swapdata["regionId"].ToString();
				bitDesc = this.swapdata["bitDesc"].ToString();
				bitId = RegAction.GetBitId(regionId, bitDesc);

				be_position.Text = RegAction.GetBitFullName(regionId, bitDesc);
				bitPrice = RegAction.GetBitPrice(regionId, bitDesc);
				txtedit_price.EditValue = bitPrice;

				this.CalcHJ();
			}
		}

		/// <summary>
		/// 计算合计金额
		/// </summary>
		private void CalcHJ()
		{
			decimal nums = decimal.Zero;

			if (decimal.TryParse(comboBox1.Text, out nums))
			{
				if (bitPrice > 0)
					regfee = nums * bitPrice;
				else
					regfee = 0;
			}
			else
			{
				regfee = 0;
			}

			txtedit_regfee.EditValue = regfee;


			lc_hj.Text = string.Format("{0:C2}", regfee + fpfee);
		}

		
		/// <summary>
		/// 缴费期限校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBox1_Validating(object sender, CancelEventArgs e)
		{
			decimal nums;
			if (!decimal.TryParse(comboBox1.Text, out nums))
			{
				e.Cancel = true;
				XtraMessageBox.Show("请输入正确的缴费期限!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (nums - Math.Truncate(nums) > 0  )
			{
				e.Cancel = true;
				XtraMessageBox.Show("缴费期限只能为整数!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CalcHJ();
		}
		/// <summary>
		/// 性别变更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rg_rc002_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (rg_rc002.EditValue.ToString() == "0")
			{
				rg_rc202.EditValue = "1";
			}
			else if (rg_rc002.EditValue.ToString() == "1")
			{
				rg_rc202.EditValue = "0";
			}
		}
		 
		/// <summary>
		/// 身份证号校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtedit_rc014_Validating(object sender, CancelEventArgs e)
		{
			string s_idcard = txtedit_rc014.Text.Trim();
			if (string.IsNullOrWhiteSpace(s_idcard)) return;

			if (s_idcard.Length != 15 && s_idcard.Length != 18)
			{
				txtedit_rc014.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtedit_rc014.ErrorText = "身份证号位数错误!";
				e.Cancel = true;
			}
			else if (s_idcard.Length == 15)
			{
				if (!Tool.CheckIDCard15(s_idcard))
				{
					txtedit_rc014.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
					txtedit_rc014.ErrorText = "身份证号错误!";
					e.Cancel = true;
				}
			}
			else if (s_idcard.Length == 18)
			{
				if (!Tool.CheckIDCard18(s_idcard))
				{
					txtedit_rc014.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
					txtedit_rc014.ErrorText = "身份证号错误!";
					e.Cancel = true;
				}
			}
		}
		/// <summary>
		/// 附品删除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
		{
			fpfee = 0;
			for (int i = 0; i < gridView1.RowCount; i++)
			{
				if (gridView1.GetRowCellValue(i, "SA007") != null && gridView1.GetRowCellValue(i, "SA007") != System.DBNull.Value)
				{
					fpfee += Convert.ToDecimal(gridView1.GetRowCellValue(i, "SA007"));
				}
			}
			this.CalcHJ();
		}

		
		/// <summary>
		/// 清除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void sb_clear_Click(object sender, EventArgs e)
		{
			txtedit_price.Text = "";
			txtEdit_rc001.Text = "";
			txtEdit_rc109.Text = "";
			be_position.Text = "";
			comboBox1.Text = "12";
			txtedit_regfee.Text = "";
			txtEdit_rc003.Text = "";
			txtEdit_rc303.Text = "";
			txtEdit_rc004.Text = "";
			txtEdit_rc404.Text = "";
			rg_rc002.EditValue = "0";
			rg_rc202.EditValue = "1";
			txtedit_rc014.Text = "";
			txtEdit_rc050.Text = "";
			lookUp_rc052.EditValue = "";
			txtEdit_rc051.Text = "";
			txtEdit_ac055.Text = "";
			mem_rc099.Text = "";
			 
			for(int i = gridView1.RowCount; i >= 0; i--)
			{
				gridView1.DeleteRow(i);
			}
			lc_hj.Text = "";
		}


		/// <summary>
		/// 计算附品金额
		/// </summary>
		/// <param name="rowHandle"></param>
		private void calcFee(int rowHandle)
		{
			decimal price;
			if (!(gridView1.GetRowCellValue(rowHandle, "PRICE") is System.DBNull))
				price = Convert.ToDecimal(gridView1.GetRowCellValue(rowHandle, "PRICE"));
			else
				price = 0;

			int nums;
			if (!(gridView1.GetRowCellValue(rowHandle, "NUMS") is System.DBNull))
				nums = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "NUMS"));
			else
				nums = 0;

			gridView1.SetRowCellValue(rowHandle, "SA007", price * nums);
		}

		/// <summary>
		/// 单价数量变更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			int rowHandle = gridView1.FocusedRowHandle;
			if (e.Column.FieldName == "SA004" && e.Value != null && e.Value != System.DBNull.Value)
			{
				gridView1.SetRowCellValue(rowHandle, "PRICE", FireAction.GetItemPrice(gridView1.GetRowCellValue(rowHandle, "SA004").ToString()));
				gridView1.SetRowCellValue(rowHandle, "NUMS", 1);
				calcFee(rowHandle);
			}
			else if (e.Column.FieldName == "PRICE" || e.Column.FieldName == "NUMS")
			{
				calcFee(rowHandle);
			}
			else if (e.Column.FieldName == "SA007")
			{
				fpfee = 0;
				for (int i = 0; i < gridView1.RowCount; i++)
				{
					if (i == rowHandle)
					{
						fpfee += Convert.ToDecimal(e.Value);
					}
					else
					{
						if (gridView1.GetRowCellValue(i, "SA007") != null && gridView1.GetRowCellValue(i, "SA007") != System.DBNull.Value)
							fpfee += Convert.ToDecimal(gridView1.GetRowCellValue(i, "SA007"));
					}

				}
				///// 如果是新行
				if (rowHandle < 0)
				{
					fpfee += Convert.ToDecimal(e.Value);
				}

				this.CalcHJ();
			}
		}
		
		private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
		{
			string colName = (sender as ColumnView).FocusedColumn.FieldName.ToUpper();
			if (colName.Equals("SA004"))
			{
				for (int i = 0; i < gridView1.RowCount - 1; i++)
				{
					if (i == (sender as ColumnView).FocusedRowHandle) continue;
					if (gridView1.GetRowCellValue(i, "SA004") == null) continue;

					//如果项目相同,则校验不通过!                        
					if (String.Equals(gridView1.GetRowCellValue(i, "SA004").ToString(), e.Value.ToString()))
					{
						e.Valid = false;
						e.ErrorText = "项目已经存在!";
						break;
					}
				}
			}
			else if (colName.Equals("PRICE"))
			{
				if(e.Value == null || Convert.ToDecimal(e.Value) <= 0)
				{
					e.Valid = false;
					e.ErrorText = "请输入正确的价格!";
					return;
				}
			}
			else if (colName.Equals("NUMS"))
			{
				if (e.Value == null || Convert.ToDecimal(e.Value) <= 0)
				{
					e.Valid = false;
					e.ErrorText = "请输入正确的数量!";
					return;
				}
			}

		}

		/// <summary>
		/// 保存前检查
		/// </summary>
		/// <returns></returns>
		private bool SaveCheck()
		{
			//逝者姓名
			if (string.IsNullOrWhiteSpace(txtEdit_rc003.Text.Trim()))
			{
				txtEdit_rc003.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtEdit_rc003.ErrorText = "逝者姓名必须输入!";
				txtEdit_rc003.Focus();
				return false;
			}
			//年龄
			if (string.IsNullOrWhiteSpace(txtEdit_rc004.Text.Trim()))
			{
				txtEdit_rc004.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtEdit_rc004.ErrorText = "年龄必须输入!";
				txtEdit_rc004.Focus();
				return false;
			}

			if (!string.IsNullOrWhiteSpace(txtEdit_rc303.Text.Trim()) && string.IsNullOrWhiteSpace(txtEdit_rc404.Text.Trim()))
			{
				txtEdit_rc404.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtEdit_rc404.ErrorText = "年龄必须输入!";
				txtEdit_rc404.Focus();
				return false;
			}


			//联系人
			if (string.IsNullOrWhiteSpace(txtEdit_rc050.Text))
			{
				txtEdit_rc050.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtEdit_rc050.ErrorText = "联系人必须输入!";
				txtEdit_rc050.Focus();
				return false;
			}
			//与逝者关系
			if (lookUp_rc052.EditValue == null)
			{
				lookUp_rc052.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				lookUp_rc052.ErrorText = "与逝者关系必须输入!";
				lookUp_rc052.Focus();
				return false;
			}
			//联系电话
			if (string.IsNullOrWhiteSpace(txtEdit_rc051.Text))
			{
				txtEdit_rc051.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtEdit_rc051.ErrorText = "联系人必须输入!";
				txtEdit_rc051.Focus();
				return false;
			}

			//寄存位置
			if (string.IsNullOrEmpty(be_position.Text) || string.IsNullOrEmpty(bitId))
			{
				be_position.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				be_position.ErrorText = "请选择寄存位置!";
				return false;
			}
			if (bitPrice <= 0)
			{
				txtedit_price.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				txtedit_price.ErrorText = "此号位未定价!";
				return false;
			}
			if (string.IsNullOrEmpty(comboBox1.Text))
			{
				XtraMessageBox.Show("请输入缴费期限!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				comboBox1.Focus();
				return false;
			}

			return true;
		}



		private void sb_ok_Click(object sender, EventArgs e)
		{
			if (!gridView1.PostEditor()) return;
			if (!gridView1.UpdateCurrentRow()) return;
			if (!SaveCheck()) return;  //数据合法性校验!!!

			string s_billno = string.Empty;

			if (s_source == "0" || s_source == "1")
			{
				Frm_InputBill frm_bill = new Frm_InputBill();
				if(frm_bill.ShowDialog() == DialogResult.OK)
				{
					s_billno = frm_bill.swapdata["billno"].ToString();
				}
				frm_bill.Dispose();
				if (string.IsNullOrEmpty(s_billno)) return;
			}

		    //0.再次判断寄存号位 是否占用
			if (RegAction.GetBitStatus(regionId,bitDesc) != "9")
			{
				XtraMessageBox.Show("当前号位无效或已被占用!","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			//1.生成寄存记录
			int i_months = Convert.ToInt32(comboBox1.Text);
			rc01 = new RC01(unitOfWork1);
			if (s_source == "1" /*外来寄存*/)
				rc01.RC001 = MiscAction.GetEntityPK("RC01");
			else if (s_source == "0" || s_source == "8")
				rc01.RC001 = txtEdit_rc001.Text;

			rc01.RC002 = rg_rc002.EditValue.ToString();  //逝者性别
			rc01.RC202 = rg_rc202.EditValue.ToString();  //逝者性别2
			rc01.RC003 = txtEdit_rc003.Text;             //逝者姓名
			rc01.RC303 = txtEdit_rc303.Text;             //逝者姓名2
			rc01.RC004 = Convert.ToInt32(txtEdit_rc004.EditValue);  //逝者年龄
			rc01.RC404 = txtEdit_rc404.EditValue == null ? 0 : Convert.ToInt32(txtEdit_rc404.EditValue);
			rc01.RC014 = txtedit_rc014.Text;             //身份证号
			rc01.RC050 = txtEdit_rc050.Text;             //联系人
			rc01.RC051 = txtEdit_rc051.Text;             //联系电话
			rc01.RC052 = lookUp_rc052.EditValue.ToString(); //与逝者关系
			rc01.RC055 = txtEdit_ac055.Text;             //联系地址
			rc01.RC099 = mem_rc099.Text;                 //备注
			rc01.RC109 = RegAction.GenRegisterNo(s_source == "2" ? "1" : "0");

			if (s_source == "0" || s_source == "8")
				rc01.SOURCE = "0";                       //本馆火化   
			else if (s_source == "1")
				rc01.SOURCE = "1";

			//状态
			if (s_source == "8")
				rc01.STATUS = "8";
			else
				rc01.STATUS = "1";

			rc01.RC110 = RegAction.GetRoomIdByBitId(bitId);   //寄存室编号
			rc01.RC120 = regionId;                            //寄存架号
			rc01.RC130 = bitId;                               //寄存号位
			rc01.RC140 = MiscAction.GetServerTime();          //寄存日期
			rc01.RC150 = rc01.RC140.AddMonths(i_months);      //寄存到期日期
			rc01.RC100 = Envior.cur_user.UC001;               //经办人
			rc01.RC200 = MiscAction.GetServerTime();


			///2.寄存费缴费记录表
			string s_fa001 = MiscAction.GetEntityPK("FA01");
			if(s_source == "0" || s_source == "1" )  //本馆火化 或外来寄存 
			{
				RC04 rc04 = new RC04(unitOfWork1);
				rc04.RC001 = rc01.RC001;
				rc04.RC010 = s_fa001;						//结算流水号
				rc04.RC020 = MiscAction.GetServerTime();    //缴费开始时间
				rc04.RC022 = rc01.RC150;                    //缴费截至时间
				rc04.PRICE = bitPrice;                      //单价
				rc04.NUMS = Convert.ToInt32(comboBox1.Text);//缴费期限
				rc04.RC030 = rc04.PRICE * rc04.NUMS;        //寄存费金额
				rc04.RC031 = "1";                           //0-原始登记 1-正常交费
				rc04.RC100 = Envior.cur_user.UC001;         //经办人
				rc04.RC200 = MiscAction.GetServerTime();
				rc04.STATUS = "1";
			}

			///3.插入销售表
			SA01 sa01 = new SA01(unitOfWork1);
			sa01.SA001 = MiscAction.GetEntityPK("SA01");
			sa01.SA002 = "08";         //项目类别 08-寄存费
			sa01.AC001 = rc01.RC001;   //逝者编号
			sa01.SA003 = "寄存费";
			sa01.SA004 = bitId;
			sa01.SA005 = "2";          //销售业务类型 2-骨灰寄存
			sa01.PRICE = bitPrice;
			sa01.NUMS = Convert.ToInt32(comboBox1.Text);
			sa01.SA007 = sa01.PRICE * sa01.NUMS;
			sa01.SA006 = bitPrice;
			sa01.SA008 = s_source == "8" ? "0" : "1";
			sa01.SA010 = s_source == "8" ? "" : s_fa001;
			sa01.SA100 = Envior.cur_user.UC001;         //经办人
			sa01.SA200 = MiscAction.GetServerTime();
			sa01.STATUS = "1";

			///4.处理附件销售.			
			foreach(SA01 s in xpCollection_sa01)
			{
				s.SA001 = MiscAction.GetEntityPK("SA01");
				s.SA002 = "13";
				s.AC001 = rc01.RC001;
				s.SA003 = FireAction.Mapper_Item(s.SA004);
				s.SA005 = "2";                               // 销售类别 0 - 火化业务 1 - 临时性销售 2骨灰寄存
				s.SA008 = s_source == "8" ? "0" : "1";
				s.SA010 = s_source == "8" ? "" : s_fa001;
				s.SA100 = Envior.cur_user.UC001;         //经办人
				s.SA200 = MiscAction.GetServerTime();
				s.STATUS = "1";
			}

			////5. 处理财务结算表  
			if(s_source == "0" || s_source == "1")
			{
				FA01 fa01 = new FA01(unitOfWork1);
				fa01.FA001 = s_fa001;
				fa01.FA002 = "2";             //收费业务类型 2-寄存
				fa01.FA003 = rc01.RC003;
				fa01.FA004 = regfee + fpfee;
				fa01.FA100 = Envior.cur_user.UC001;
				fa01.FA200 = MiscAction.GetServerTime();
				fa01.FA099 = s_billno;
				fa01.WS001 = Envior.workstationId;
				fa01.STATUS = "1";
			}
			////6. 处理号位表
			BI01 bi01 = unitOfWork1.GetObjectByKey<BI01>(bitId);
			bi01.BI010 = rc01.RC001;
			if(s_source == "0" || s_source == "1")
			{
				bi01.STATUS = "1";
			}
			else if (s_source == "8")
			{
				bi01.STATUS = "8";
			}

			try
			{
				unitOfWork1.CommitChanges();
				string s_tip = string.Empty;
				if (s_source == "0" || s_source == "1")
					s_tip = "办理成功,现在打印【寄存证】";
				else
					s_tip = "办理成功!";

				XtraMessageBox.Show(s_tip,"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);

				////todo 2.打印寄存证
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ee)
			{
				unitOfWork1.RollbackTransaction();
				LogUtils.Error(ee.Message);
				XtraMessageBox.Show(ee.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			 
		}





	}
}