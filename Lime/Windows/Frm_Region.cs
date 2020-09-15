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
using Lime.BusinessObject;
using DevExpress.XtraTreeList.Nodes;
using Lime.Xpo.orcl;
using DevExpress.Xpo;
using Lime.Action;

namespace Lime.Windows
{
	public partial class Frm_Region : MyDialog
	{
		private RegisterStru rs = null;
		private TreeListNode parentNode = null;
		private UnitOfWork unitOfWork = null;

		public Frm_Region()
		{
			InitializeComponent();
		}
				
		private void Frm_Region_Load(object sender, EventArgs e)
		{
			rs = this.swapdata["bobject"] as RegisterStru;
			parentNode = this.swapdata["parentNode"] as TreeListNode;
			unitOfWork = this.swapdata["session"] as UnitOfWork;
			
			combo_rg030.SelectedIndex = 0;
			combo_rg033.SelectedIndex = 0;
			txt_rg003.Text = rs.GetSuggestName(parentNode, "3");

			if (!parentNode.HasChildren)
			{
				txt_rg010.Text = "1";
			}
			else
			{
				if (string.IsNullOrWhiteSpace(parentNode.LastNode.GetValue("RG011").ToString()))
					txt_rg010.Text = "1";
				else
					txt_rg010.Text = (int.Parse(parentNode.LastNode.GetValue("RG011").ToString()) + 1).ToString();
			}
			 
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			string rg003 = string.Empty;
			int rg010 = 0;                 //起始号位
										   //int rg011 ;				   //终止号位
			int rg020;    //层数
			int rg021;    //每层号位数

			///输入校验
			if (String.IsNullOrEmpty(txt_rg003.Text))
			{
				txt_rg003.Focus();
				txt_rg003.ErrorText = "请输入寄存排名字!";
				return;
			}
			else
			{
				rg003 = txt_rg003.Text;
			}

			if (string.IsNullOrEmpty(txt_rg020.Text))
			{
				txt_rg020.Focus();
				txt_rg020.ErrorText = "请输入层数!";
				return;
			}
			else
			{
				rg020 = int.Parse(txt_rg020.Text);
			}

			if (string.IsNullOrEmpty(txt_rg021.Text))
			{
				txt_rg021.Focus();
				txt_rg021.ErrorText = "请输入每层号位数!";
				return;
			}
			else
			{
				rg021 = int.Parse(txt_rg021.Text);
			}
 
			if (string.IsNullOrEmpty(txt_rg010.Text))
			{
				txt_rg010.Focus();
				txt_rg010.ErrorText = "请输入起始号位!";
				return;
			}
			else
			{
				rg010 = int.Parse(txt_rg010.Text);
			}

			//////////////////  校验结束  ///////////////////////////
			RG01 rg01 = new RG01(unitOfWork);
			rg01.RG001 = MiscAction.GetEntityPK("RG01");
			rg01.RG002 = "3";
			rg01.RG003 = rg003;
			rg01.RG010 = rg010;
			rg01.RG020 = rg020;
			rg01.RG021 = rg021;
			rg01.RG030 = combo_rg030.SelectedIndex.ToString();
			rg01.RG033 = combo_rg033.SelectedIndex.ToString();
			rg01.RG009 = parentNode.GetValue("RG001").ToString();
			rg01.STATUS = "1";

			this.swapdata["newdata"] = rg01;
			 
			DialogResult = DialogResult.OK;
			this.Close();
		}
		/// <summary>
		/// 起始号位校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txt_rg010_Validating(object sender, CancelEventArgs e)
		{
			if (String.IsNullOrEmpty(txt_rg010.Text))
			{
				txt_rg010.ErrorText = "请输入起始号位!";
				e.Cancel = true;
				return;
			}
			if (int.Parse(txt_rg010.EditValue.ToString()) <= 0)
			{
				txt_rg010.ErrorText = "请输入大于0的数字!";
				e.Cancel = true;
			}
		}
		/// <summary>
		/// 终止号位校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txt_rg011_Validating(object sender, CancelEventArgs e)
		{
			if (!string.IsNullOrEmpty(txt_rg011.Text) && int.Parse(txt_rg011.Text) <= 0)
			{
				txt_rg011.ErrorText = "请输入大于0的数字!";
				e.Cancel = true;
				return;
			}
		}
		/// <summary>
		/// 层数校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txt_rg020_Validating(object sender, CancelEventArgs e)
		{
			if (String.IsNullOrEmpty(txt_rg020.Text))
			{
				txt_rg020.ErrorText = "请输入层数!";
				e.Cancel = true;
				return;
			}
			if (int.Parse(txt_rg020.Text) <= 0)
			{
				txt_rg020.ErrorText = "请输入大于0的数字!";
				e.Cancel = true;
			}
		}
		/// <summary>
		/// 每层号位数校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txt_rg021_Validating(object sender, CancelEventArgs e)
		{
			if (String.IsNullOrEmpty(txt_rg021.Text))
			{
				txt_rg021.ErrorText = "请输入每层号位数!";
				e.Cancel = true;
				return;
			}
			if (int.Parse(txt_rg021.Text) <= 0)
			{
				txt_rg021.ErrorText = "请输入大于0的数字!";
				e.Cancel = true;
			}
		}

		private void sb_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Frm_Region_FormClosing(object sender, FormClosingEventArgs e)
		{
			txt_rg021.CausesValidation = false;
			txt_rg010.CausesValidation = false;
			txt_rg011.CausesValidation = false;
			txt_rg020.CausesValidation = false;
		}
	}
}