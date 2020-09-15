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
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Lime.Action;
using Lime.Xpo.orcl;
using Lime.Windows;
using Lime.Misc;
using DevExpress.Xpo;
using DevExpress.Data.Helpers;
using DevExpress.Data.Filtering;
using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.Data.WcfLinq.Helpers;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Lime.BusinessObject
{
	/// <summary>
	/// 寄存结构维护
	/// </summary>
	public partial class RegisterStru : BaseBusiness
	{
		private DataTable gridTable = new DataTable("grid");
		private string curRegionId = string.Empty;
		private bool b_update = false;

		public RegisterStru()
		{
			InitializeComponent();
		}

		private void RegisterStru_Load(object sender, EventArgs e)
		{
			SplashScreenManager.ShowDefaultWaitForm("请等待", "处理中....");

			xpCollection_bi01.LoadingEnabled = true;
			xpCollection_ly01.LoadingEnabled = true;
			xpCollection_rg01.LoadingEnabled = true;

			treeList1.ExpandToLevel(2);
			try
			{
				SplashScreenManager.CloseDefaultWaitForm();
			}
			finally { }
		}
		/// <summary>
		/// 编辑前检查是否可以编辑节点
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void treeList1_ShowingEditor(object sender, CancelEventArgs e)
		{
			TreeList currentTreeList = sender as TreeList;
			if (currentTreeList != null)
			{
				TreeListNode node = currentTreeList.FocusedNode;			 
				if (node.Level == 0)
				{
					e.Cancel = true;
				}
				else
				{
					e.Cancel = false;
				}
			}
		}
		/// <summary>
		/// 树节点改变事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
		{
			if (e.Node == null) return;
			if (e.Node.Level < 3)
			{
				pictureBox1.Visible = true;
				gridControl1.Visible = false;
				return;
			}
			else
			{
				pictureBox1.Visible = false;
				gridControl1.Visible = true;
				curRegionId = e.Node.GetValue("RG001").ToString();
			}
			SplashScreenManager.ShowDefaultWaitForm("请等待", "处理中....");
			DrawGrid(e.Node);
			SplashScreenManager.CloseDefaultWaitForm();
		}
		/// <summary>
		/// 绘制表格
		/// </summary>
		/// <param name="regionNode"></param>
		private void DrawGrid(TreeListNode regionNode)
		{
			int rows = int.Parse(regionNode.GetValue("RG020").ToString());  //层数
			int cols = int.Parse(regionNode.GetValue("RG021").ToString());

			gridView1.BeginUpdate();

			/////////清除所有数据
			gridTable.Clear();
			gridTable.Columns.Clear();

			gridView1.RowHeight = App_Const.GRID_HEIGHT;

			////生成列
			DataColumn col = null;
			DataRow row = null;
			for (int i = 1; i <= cols; i++)
			{
				col = new DataColumn("col" + i.ToString(), typeof(string));
				col.ReadOnly = true;
				gridTable.Columns.Add(col);
			}

			CriteriaOperator criteria = CriteriaOperator.Parse("RG001 ='" + regionNode.GetValue("RG001").ToString() + "'" );
			XPCollection<BI01> bits_arry = new XPCollection<BI01>(unitOfWork1, xpCollection_bi01, criteria);

			SortingCollection sorting = new SortingCollection();
			sorting.Add(new SortProperty("BI005", DevExpress.Xpo.DB.SortingDirection.Descending));
			sorting.Add(new SortProperty("BI008", DevExpress.Xpo.DB.SortingDirection.Ascending));
			bits_arry.Sorting = sorting;

			 
			int bitIndex = 0;
			for (int i = 1; i <= rows; i++)
			{
				row = gridTable.NewRow();
				for (int j = 1; j <= cols; j++)
				{
					//bits_arry[i - 1].BI003
					row.SetField(j - 1, bits_arry[bitIndex].BI003);
					bitIndex++;
				}
				gridTable.Rows.Add(row);
			}

			gridControl1.DataSource = gridTable;
			gridView1.PopulateColumns();

			//设置列宽 
			for (int i = 1; i <= cols; i++)
			{
				gridView1.Columns[i - 1].Width = App_Const.GRID_WIDTH;
			}
			//grid标题
			TreeListNode hall_node = regionNode.ParentNode.ParentNode;
			TreeListNode room_node = regionNode.ParentNode;
			gridView1.ViewCaption = hall_node.GetDisplayText("RG003") + "-" + room_node.GetDisplayText("RG003") + "-" + regionNode.GetDisplayText("RG003");

			gridView1.EndUpdate();

		}
		/// <summary>
		/// 新建 同级节点
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			TreeListNode node = treeList1.FocusedNode;
			string nodeType = node.Level.ToString();
			int i_image_Index = 0;

			if (nodeType == "0")        //顶级节点,退出
			{
				XtraMessageBox.Show("不能在顶级节点创建!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (nodeType != "3")        //非寄存排
			{
				RG01 rg01 = new RG01(unitOfWork1);
				rg01.RG001 = MiscAction.GetEntityPK("RG01");
				rg01.RG002 = nodeType;												//节点类型
				rg01.RG003 = this.GetSuggestName(node.ParentNode, nodeType);
				rg01.RG009 = node.ParentNode.GetValue("RG001").ToString();          //父节点编号 
				rg01.STATUS = "1";
				xpCollection_rg01.Add(rg01);

				if (nodeType == "1")
					i_image_Index = 1;
				else if (nodeType == "2")
					i_image_Index = 2;
 
				TreeListNode newNode = treeList1.FindNodeByKeyID(rg01.RG001);
				newNode.SelectImageIndex = i_image_Index;
				newNode.ImageIndex = i_image_Index;

				treeList1.SetFocusedNode(newNode);
				treeList1.ShowEditor();
				b_update = true; 
			}
			else                        //寄存排
			{
				CreateRegion(node.ParentNode);
			}
		}

		/// <summary>
		/// 获取建议名称
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public string GetSuggestName(TreeListNode parent, string level)
		{
			if (level == "1")         //寄存堂
			{
				return "新寄存堂" + (parent.Nodes.Count + 1).ToString();
			}
			else if (level == "2")    //寄存室
			{
				return "新寄存室" + (parent.Nodes.Count + 1).ToString();
			}
			else if (level == "3")    //寄存排
			{
				return (parent.Nodes.Count + 1).ToString() + "排";
			}
			else
				return "";
		}
		/// <summary>
		/// 创建寄存排
		/// </summary>
		/// <param name="parentNode"></param>
		public void CreateRegion(TreeListNode parentNode)
		{
			Frm_Region frm_1 = new Frm_Region();
			RG01 rg01 = unitOfWork1.GetObjectByKey<RG01>(parentNode.GetValue("RG001").ToString());
			frm_1.swapdata["parent"] = rg01;
			frm_1.swapdata["bobject"] = this;
			frm_1.swapdata["parentNode"] = parentNode;
			frm_1.swapdata["session"] = unitOfWork1;
			if(frm_1.ShowDialog() == DialogResult.OK)
			{
				RG01 newRegion = frm_1.swapdata["newdata"] as RG01;
				xpCollection_rg01.Add(newRegion);

				TreeListNode newNode = treeList1.FindNodeByKeyID(newRegion.RG001);
				newNode.SelectImageIndex = 3;
				newNode.ImageIndex = 3;

				CreateRegion_mode0(newRegion, newNode);
				treeList1.SetFocusedNode(newNode);				 
				DrawGrid(newNode);
				b_update = true;
			}
			frm_1.Dispose();
		}
		/// <summary>
		/// 创建子节点
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			TreeListNode node = treeList1.FocusedNode;
			string nodeType = node.Level.ToString();
			int i_image_Index = 0;

			if (nodeType == "3")        //最末级节点,退出
			{
				XtraMessageBox.Show("不能在末级节点创建!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (nodeType != "2")   //非寄存排
			{
				RG01 rg01 = new RG01(unitOfWork1);
				rg01.RG001 = MiscAction.GetEntityPK("RG01");

				if (nodeType == "0")
				{
					rg01.RG002 = "1";           //寄存堂		
					i_image_Index = 1;
				}								
				else if (nodeType == "1")
				{
					rg01.RG002 = "2";           //寄存室
					i_image_Index = 2;
				}
					

				rg01.RG003 = this.GetSuggestName(node, rg01.RG002);
				rg01.RG009 = node.GetValue("RG001").ToString();
				rg01.STATUS = "1";
				xpCollection_rg01.Add(rg01);


				TreeListNode newNode = treeList1.FindNodeByKeyID(rg01.RG001);
				newNode.SelectImageIndex = i_image_Index;
				newNode.ImageIndex = i_image_Index;

				treeList1.SetFocusedNode(newNode);
				treeList1.ShowEditor();
				b_update = true;
			}
			if (nodeType == "2")   //创建寄存排
			{
				this.CreateRegion(node);
			}
		}


		/// <summary>
		/// 制造新排-传统方式
		/// </summary>
		/// <param name="newrow"></param>
		/// <param name="newNode"></param>
		private void CreateRegion_mode0(RG01 newRegion, TreeListNode newNode)
		{
			///创建层
			LY01 ly01 = null;
			BI01 bi01 = null;
			int startbit = int.Parse(newRegion.RG010.ToString());
			int layerIndex;
			int colIndex;
			string rg030 = newRegion.RG030.ToString();                       //起始位置
			bool flag = true;

			if (rg030 == "0" || rg030 == "2")  //左上或右上
				layerIndex = int.Parse(newRegion.RG020.ToString());
			else
				layerIndex = 1;

			for (int i = 1; i <= int.Parse(newRegion.RG020.ToString()); i++) //rg020层数
			{
				ly01 = new LY01(unitOfWork1);
				ly01.LY001 = MiscAction.GetEntityPK("LY01");
				ly01.RG001 = newRegion.RG001;
				ly01.LY002 = i;
				xpCollection_ly01.Add(ly01);
				 
				if ((rg030 == "0" || rg030 == "1") && flag) //左上或左下
				{
					colIndex = 1;
				}
				else if ((rg030 == "2" || rg030 == "3") && !flag)
				{
					colIndex = 1;
				}
				else
				{
					colIndex = int.Parse(newRegion.RG021.ToString());
				}

				///创建号位
				for (int j = 1; j <= int.Parse(newRegion.RG021.ToString()); j++)  //rg021每层号位数
				{
					bi01 = new BI01(unitOfWork1);
					bi01.BI001 = MiscAction.GetEntityPK("BI01");
					bi01.RG001 = newRegion.RG001;
					bi01.BI020 = newNode.ParentNode.GetValue("RG001").ToString();		      //寄存室编号
					bi01.BI030 = newNode.ParentNode.ParentNode.GetValue("RG001").ToString();  //寄存楼编号
					bi01.BI002 = startbit + j - 1;											  //号位数字编号
					bi01.BI003 = (startbit + j - 1).ToString().PadLeft(4, '0');               //号位文字描述
					bi01.BI005 = layerIndex;												  //层号
					bi01.BI008 = colIndex;                                                    //列数.
					bi01.BI009 = 0;                                                           //价格
					bi01.BI007 = "0";                                                         //价格锁
					bi01.STATUS = "9";                                                        //状态-空闲
					xpCollection_bi01.Add(bi01);
					 
					//RG033 排列顺序 0-顺序 1-蛇形
					if (newRegion.RG033 == "0")
					{
						if (rg030 == "0" || rg030 == "1") //左上或左下
						{
							if (colIndex >= newRegion.RG021)
								colIndex = 1;
							else
								colIndex++;
						}
						else
						{
							if (colIndex <= 1)
								colIndex = 1;
							else
								colIndex--;
						}
					}
					else
					{
						if ((rg030 == "0" || rg030 == "1") && flag) //左上或左下
						{
							if (colIndex >= newRegion.RG021)
							{
								colIndex = newRegion.RG021;
							}
							else
								colIndex++;
						}
						else if ((rg030 == "0" || rg030 == "1") && !flag)
						{
							if (colIndex <= 1)
							{
								colIndex = 1;
							}
							else
							{
								colIndex--;
							}
						}
						else if ((rg030 == "2" || rg030 == "3") && flag)
						{
							if (colIndex <= 1)
							{
								colIndex = 1;
							}
							else
							{
								colIndex--;
							}
						}
						else if ((rg030 == "2" || rg030 == "3") && !flag)
						{
							if (colIndex >= newRegion.RG021)
							{
								colIndex = newRegion.RG021;
							}
							else
							{
								colIndex++;
							}
						}

					}
				}
				startbit += newRegion.RG021;

				if (newRegion.RG033 == "1")
				{
					flag = !flag;
				}

				if (rg030 == "0" || rg030 == "2")  //左上或右上
					layerIndex--;
				else
					layerIndex++;
			}			 
		}
		/// <summary>
		/// 绘制行号
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
		{
			e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			if (e.Info.IsRowIndicator)
			{
				if (e.RowHandle >= 0)
				{
					int layerNum = gridView1.RowCount - e.RowHandle;
					e.Info.DisplayText = (gridView1.RowCount - e.RowHandle).ToString() + "【" + this.GetLayerPrice(curRegionId, layerNum).ToString() + "】";
				}
				else if (e.RowHandle < 0 && e.RowHandle > -1000)
				{
					e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
					e.Info.DisplayText = "G" + e.RowHandle.ToString();
				}
			}
		}
		/// <summary>
		/// 获取层单价
		/// </summary>
		/// <param name="regionId"></param>
		/// <param name="layerNum"></param>
		/// <returns></returns>
		private decimal GetLayerPrice(string regionId,int layerNum)
		{
			CriteriaOperator criteria = CriteriaOperator.Parse("RG001 ='" + regionId + "' and LY002=" + layerNum.ToString() );
			XPCollection<LY01> xp_temp = new XPCollection<LY01>(unitOfWork1, xpCollection_ly01, criteria);
			if(xp_temp.Count > 0)
			{
				return xp_temp[0].PRICE;
			}
			else
			{
				return 0;
			}
		}


		/// <summary>
		/// 根据号位状态绘制颜色
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
		{
			string s_bitStatus = string.Empty;  // RegisterAction.GetBitStatus(curRegionId, e.CellValue.ToString());

			CriteriaOperator criteria = CriteriaOperator.Parse("RG001 ='" + curRegionId + "' and BI003='" + e.CellValue.ToString() + "'");
			XPCollection<BI01> xp_temp = new XPCollection<BI01>(unitOfWork1, xpCollection_bi01, criteria);
			if(xp_temp.Count > 0)
			{
				s_bitStatus = xp_temp[0].STATUS;
				if (s_bitStatus == "9" || s_bitStatus == "n")
				{
					e.Appearance.BackColor = Color.Green;
					e.Appearance.ForeColor = Color.White;
				}
				else if (s_bitStatus == "0")
				{
					e.Appearance.BackColor = Color.White;
					e.Appearance.ForeColor = Color.White;
				}
				else
				{
					e.Appearance.BackColor = Color.Yellow;
					e.Appearance.ForeColor = Color.Black;
				}
			}
			xp_temp.Dispose();
		}
		/// <summary>
		/// 刷新
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.RefreshData();
		}
		private void RefreshData()
		{
			if (b_update)
			{
				DialogResult dr = XtraMessageBox.Show("刷新会丢失未保存的更新,是否继续?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
				if (dr == DialogResult.Cancel) return;
			}
			SplashScreenManager.ShowDefaultWaitForm("请等待", "刷新数据....");
			treeList1.BeginUpdate();
			treeList1.ClearNodes();

			xpCollection_rg01.Load();
			xpCollection_ly01.Load();
			xpCollection_bi01.Load();
			 
			treeList1.ExpandToLevel(2);
			treeList1.EndUpdate();

			try
			{
				SplashScreenManager.CloseDefaultWaitForm();
			}
			catch { }

			b_update = false;
		}
		/// <summary>
		/// 保存
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			treeList1.SetFocusedNode(treeList1.GetNodeByVisibleIndex(0));
			treeList1.PostEditor();
			treeList1.CloseEditor();

			foreach (RG01 rg01 in xpCollection_rg01)
			{
				if (rg01.RG003 == null ||  String.IsNullOrEmpty(rg01.RG003))
				{
					XtraMessageBox.Show("节点名称必须输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					TreeListNode myNode = treeList1.FindNode((node) => {
						return node["RG001"].ToString() == rg01.RG001;
					  }
					);
					if(myNode != null)
					{
						treeList1.SetFocusedNode(myNode);
					}
					return;
				}
			}

			try
			{
				unitOfWork1.CommitChanges();
				XtraMessageBox.Show("保存成功!", "提示");
			}
			catch (Exception ee)
			{
				unitOfWork1.RollbackTransaction();
				LogUtils.Error(ee.Message);
				XtraMessageBox.Show("保存数据错误!\n" + ee.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			//this.RefreshData();
		}
		/// <summary>
		/// 设置图标索引
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void treeList1_AfterExpand(object sender, NodeEventArgs e)
		{
			if(e.Node.Level == 0)
			{
				e.Node.ImageIndex = 0;
				e.Node.SelectImageIndex = 0;
			}
			else if(e.Node.Level == 1)
			{
				e.Node.ImageIndex = 1;
				e.Node.SelectImageIndex = 1;
			}
			else if (e.Node.Level == 2)
			{
				e.Node.ImageIndex = 2;
				e.Node.SelectImageIndex = 2;
				foreach(TreeListNode node in e.Node.Nodes)
				{
					node.ImageIndex = 3;
					node.SelectImageIndex = 3;
				}
			}
			 
		}
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			TreeListNode curNode = treeList1.FocusedNode;
			if (curNode.Level == 0) return;

			DialogResult result = XtraMessageBox.Show("确认要删除当前节点及其所有子节点?", "删除确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (result == DialogResult.Cancel) return;

			////判断是否有被占用的节点
			int i_count = RegAction.RegStruIsUse(curNode.GetValue("RG001").ToString()); 
			if (i_count > 0)
			{
				XtraMessageBox.Show("存在被占用的号位,不能删除!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			else
			{
				if(curNode.Level == 1)        //寄存堂
				{
					foreach(TreeListNode room in curNode.Nodes)
					{
						foreach(TreeListNode region in room.Nodes)
						{
							region.SetValue("STATUS", "0");
						}
						room.SetValue("STATUS", "0");
					}
				}
				else if(curNode.Level == 2)   //寄存室
				{
					foreach (TreeListNode region in curNode.Nodes)
					{
						region.SetValue("STATUS", "0");
					}
				}

				curNode.SetValue("STATUS", "0");
				treeList1.SetFocusedNode(curNode.ParentNode);
			}
		}
		/// <summary>
		/// 层定价
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			TreeListNode curNode = treeList1.FocusedNode;
			if (curNode.Level != 3) return;
			Frm_LayerPrice frm_1 = new Frm_LayerPrice();
			frm_1.swapdata["regionId"] = curRegionId;
			frm_1.swapdata["xpcollection_ly01"] = xpCollection_ly01;
			frm_1.swapdata["xpcollection_bi01"] = xpCollection_bi01;

			if(frm_1.ShowDialog() == DialogResult.OK)
			{
				DrawGrid(curNode);
			}
			frm_1.Dispose();
			xpCollection_ly01.Filter = null;
		}

		private void gridView1_DoubleClick(object sender, EventArgs e)
		{
			GridHitInfo _info;
			Point _pt = gridView1.GridControl.PointToClient(Control.MousePosition);
			_info = gridView1.CalcHitInfo(_pt);
			if (_info.HitTest != GridHitTest.RowCell)
				return;

			TreeListNode curNode = treeList1.FocusedNode;
			string bi003 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.FocusedColumn).ToString();

			Frm_Bi01 frm_bi01 = new Frm_Bi01();
			frm_bi01.swapdata["collection"] = xpCollection_bi01;
			frm_bi01.swapdata["session"] = unitOfWork1;
			frm_bi01.swapdata["regionId"] = curNode.GetValue("RG001");
			frm_bi01.swapdata["bi003"] = bi003;
			 
			DialogResult dr = frm_bi01.ShowDialog();
			if (dr == DialogResult.OK)
			{
				this.DrawGrid(curNode);
			}
		}
	}
}
