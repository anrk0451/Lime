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
using DevExpress.Xpo;
using Lime.Xpo.orcl;
using Lime.Action;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using Lime.Misc;

namespace Lime.Windows
{
	public partial class Frm_Combo : MyDialog
	{
		private XPCollection xp_cb01 = null;
		private CB01 cb01 = null;
		private bool b_isnew = false;
		public Frm_Combo()
		{
			InitializeComponent();
			gridView2.CustomDrawRowIndicator += MiscAction.DrawGridLineNo;
			this.SetGridLookUpEditMoreColumnFilter(repository_cb021);
		}

		private void Frm_Combo_Load(object sender, EventArgs e)
		{
			//设置下拉窗口
			
			GridColumn col_itemid = repository_cb021.View.Columns.AddField("ITEM_ID");
			col_itemid.Visible = false;

			GridColumn col_itemtype = repository_cb021.View.Columns.AddField("ITEM_TYPE_TEXT");
			col_itemtype.Caption = "类别";
			col_itemtype.VisibleIndex = 0;
			col_itemtype.Width = 80;
			col_itemtype.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

			GridColumn col_itemtext = repository_cb021.View.Columns.AddField("ITEM_TEXT");
			col_itemtext.Caption = "名称";
			col_itemtext.VisibleIndex = 1;
			col_itemtext.Width = 125;

			GridColumn col_price = repository_cb021.View.Columns.AddField("PRICE");
			col_price.Caption = "单价";
			col_price.VisibleIndex = 2;
			col_price.Width = 70;
			col_price.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			col_price.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			col_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			col_price.DisplayFormat.FormatString = "N2";

			GridColumn col_zjf = repository_cb021.View.Columns.AddField("ZJF");
			col_zjf.Caption = "助记符";
			col_zjf.VisibleIndex = 3;
			col_zjf.Width = 60;


			if (this.swapdata.ContainsKey("collection"))
			{
				xp_cb01 = this.swapdata["collection"] as XPCollection;
				xpCollection_cb02.Session = xp_cb01.Session;

				///编辑套餐
				if (this.swapdata.ContainsKey("cb01"))
				{
					cb01 = this.swapdata["cb01"] as CB01;
					te_cb003.EditValue = cb01.CB003;
					rg_cb002.EditValue = cb01.CB002;
					glue_cb005.EditValue = cb01.CB005;
					mem_cb006.EditValue = cb01.CB006;

				}
				///新增套餐
				else  
				{
					rg_cb002.EditValue = "1";
					cb01 = new CB01(xp_cb01.Session);
					cb01.CB001 = MiscAction.GetEntityPK("CB01");
					cb01.STATUS = "1";
					b_isnew = true;
				}
				CriteriaOperator criteria = CriteriaOperator.Parse("CB001 ='" + cb01.CB001 + "'");
				xpCollection_cb02.Criteria = criteria;
				xpCollection_cb02.LoadingEnabled = true;
			}
			else
			{
				XtraMessageBox.Show("参数传递错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				sb_ok.Enabled = false; ;
			}
		}
		/// <summary>
		/// 套餐类别变更事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rg_cb002_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(rg_cb002.SelectedIndex == 1)
			{
				glue_cb005.EditValue = null;
				glue_cb005.Enabled = false;
			}
			else
			{
				glue_cb005.Enabled = true;
			}
		}
		/// <summary>
		/// 套餐名称校验
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void te_cb003_Validating(object sender, CancelEventArgs e)
		{
			CriteriaOperator criteria = CriteriaOperator.Parse("CB003 ='" + te_cb003.Text + "' and CB001 !='" + cb01.CB001 + "' and STATUS = '1'" );
			XPCollection<CB01> xp_temp = new XPCollection<CB01>(xp_cb01.Session, xp_cb01, criteria);
			if (xp_temp.Count > 0)
			{
				te_cb003.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				te_cb003.ErrorText = "套餐名称重复!";
				e.Cancel = true;
				return;
			}
			xp_temp.Dispose();
		}
		/// <summary>
		/// 套餐明细  新行初始化
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView2_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
		{ 
			gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "CB001", cb01.CB001);	 
			gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "CB201", MiscAction.GetEntityPK("CB02"));
			gridView2.SetRowCellValue(gridView2.FocusedRowHandle, "CB030", 1);
		}

		private void repository_cb021_Popup(object sender, EventArgs e)
		{
			//FilterLookup(sender);
		}

		/// <summary>
		/// 过滤 项目
		/// </summary>
		/// <param name="sender"></param>
		//private void FilterLookup(object sender)
		//{
		//	Text += " ! ";
		//	GridLookUpEdit edit = sender as GridLookUpEdit;
		//	GridView gridView = edit.Properties.View;
		//	FieldInfo fi = gridView.GetType().GetField("extraFilter", BindingFlags.NonPublic | BindingFlags.Instance);
		//	Text = edit.AutoSearchText;
		//	BinaryOperator op1 = new BinaryOperator("ITEM_TEXT", edit.AutoSearchText + "%", BinaryOperatorType.Like);
		//	BinaryOperator op2 = new BinaryOperator("ZJF", edit.AutoSearchText + "%", BinaryOperatorType.Like);
		//	string filterCondition = new GroupOperator(GroupOperatorType.Or, new CriteriaOperator[] { op1, op2 }).ToString();
		//	fi.SetValue(gridView, filterCondition);

		//	MethodInfo mi = gridView.GetType().GetMethod("ApplyColumnsFilterEx", BindingFlags.NonPublic | BindingFlags.Instance);
		//	mi.Invoke(gridView, null);
		//}



		/// <summary>
		/// 删除明细
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void simpleButton1_Click(object sender, EventArgs e)
		{
			DialogResult result = XtraMessageBox.Show("确认删除?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (result == DialogResult.Yes)
			{
				gridView2.DeleteRow(gridView2.FocusedRowHandle);
			}
		}

		private void gridView2_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
		{
			ColumnView view = sender as ColumnView;
			int rowHandle = view.FocusedRowHandle;
			string colname = view.FocusedColumn.FieldName;

			if (colname == "CB030")
			{
				if (e.Value == null || string.IsNullOrEmpty(e.Value.ToString()))
				{
					e.ErrorText = "数量必须输入!";
					e.Valid = false;
				}
			}
			else if (colname == "CB021")  //项目名
			{
				if (e.Value == null || string.IsNullOrWhiteSpace(e.Value.ToString())) return;
				for (int i = 0; i < view.RowCount - 1; i++)
				{
					if (i == rowHandle) continue;
					if (gridView2.GetRowCellValue(i, "CB021") == null || gridView2.GetRowCellValue(i, "CB021") is System.DBNull || gridView2.GetRowCellValue(i, "CB021") == null) continue;

					//如果相同,则校验不通过!                        
					if (String.Equals(gridView2.GetRowCellValue(i, "CB021").ToString(), e.Value.ToString()))
					{
						e.Valid = false;
						e.ErrorText = "项目已经存在!";
						return;
					}
				}
			}
		}

		private void gridView2_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
		{
			DataRowView rowdata = e.Row as DataRowView;
			if (rowdata == null) return;

			if (rowdata["CB021"] is System.DBNull)
			{
				e.ErrorText = "请选择项目!";
				e.Valid = false;
				return;
			}
			else if (rowdata["CB030"] is System.DBNull)
			{
				e.ErrorText = "请输入数量!";
				e.Valid = false;
				return;

			}
			else if (decimal.Parse(rowdata["CB030"].ToString()) <= 0)
			{
				e.ErrorText = "数量必须大于0!";
				e.Valid = false;
				return;
			}
		}

		private void sb_ok_Click(object sender, EventArgs e)
		{
			if (!CheckBeforeSave()) return;
			UnitOfWork unitOfWork = xp_cb01.Session as UnitOfWork;
			try 
			{
				cb01.CB002 = rg_cb002.EditValue.ToString();
				cb01.CB003 = te_cb003.Text;
				cb01.CB005 = glue_cb005.EditValue == null ? "": glue_cb005.EditValue.ToString();
				cb01.CB006 = mem_cb006.Text;

				if (b_isnew)
				{
					xp_cb01.Add(cb01);
				}
				unitOfWork.CommitChanges();
				XtraMessageBox.Show("保存成功!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			 
				DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ee)
			{
				unitOfWork.RollbackTransaction();
				LogUtils.Error(ee.Message);
				XtraMessageBox.Show(ee.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		/// <summary>
		/// 保存前检查
		/// </summary>
		/// <returns></returns>
		private bool CheckBeforeSave()
		{
			if (string.IsNullOrEmpty(te_cb003.Text))
			{
				te_cb003.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
				te_cb003.ErrorText = "套餐名必须输入!";
				te_cb003.Focus();
				return false;
			}
			if(rg_cb002.EditValue.ToString() == "0" /*服务绑定套餐*/)
			{
				if(glue_cb005.EditValue == null || glue_cb005.EditValue is System.DBNull)
				{
					glue_cb005.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
					glue_cb005.ErrorText = "请先选择一个要绑定的服务!";
					return false;
				}
			}
			if ( !gridView2.PostEditor()) return false;
			if ( !gridView2.UpdateCurrentRow()) return false;

			return true;
		}

		/// <summary>
		/// 设置GridLookUpEdit多列过滤
		/// </summary>
		/// <param name="repGLUEdit">GridLookUpEdit的知识库，eg:gridlookUpEdit.Properties</param>
		private void SetGridLookUpEditMoreColumnFilter(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repGLUEdit)
		{
			repGLUEdit.EditValueChanging += (sender, e) =>
			{
				this.BeginInvoke(new System.Windows.Forms.MethodInvoker(() => {
					GridLookUpEdit edit = sender as GridLookUpEdit;
					DevExpress.XtraGrid.Views.Grid.GridView view = edit.Properties.View as DevExpress.XtraGrid.Views.Grid.GridView;
					//获取GriView私有变量
					System.Reflection.FieldInfo extraFilter = view.GetType().GetField("extraFilter", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
					List<DevExpress.Data.Filtering.CriteriaOperator> columnsOperators = new List<DevExpress.Data.Filtering.CriteriaOperator>();
					foreach (GridColumn col in view.VisibleColumns)
					{
						if (col.Visible && col.ColumnType == typeof(string))
							columnsOperators.Add(new DevExpress.Data.Filtering.FunctionOperator(DevExpress.Data.Filtering.FunctionOperatorType.Contains,
								new DevExpress.Data.Filtering.OperandProperty(col.FieldName),
								new DevExpress.Data.Filtering.OperandValue(edit.Text)));
					}

					string filterCondition = new DevExpress.Data.Filtering.GroupOperator(DevExpress.Data.Filtering.GroupOperatorType.Or, columnsOperators).ToString();
					extraFilter.SetValue(view, filterCondition);
					//获取GriView中处理列过滤的私有方法
					System.Reflection.MethodInfo ApplyColumnsFilterEx = view.GetType().GetMethod("ApplyColumnsFilterEx", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

					ApplyColumnsFilterEx.Invoke(view, null);

				}));

			};

		}
	}
}