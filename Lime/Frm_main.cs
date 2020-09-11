using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Lime.Xpo.orcl;
using DevExpress.XtraTab;
using DevExpress.XtraSplashScreen;
using System.Threading;
using DevExpress.XtraEditors;
using Lime.BaseObject;
using DevExpress.Xpo;
using Lime.Misc;
using DevExpress.XtraTab.ViewInfo;

namespace Lime
{
	public partial class Frm_main : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		public Dictionary<string, Object> swapdata { get; set; }      //交换数据对象
		XPQuery<BO01> BO01_list = null; 
		
		//追踪已经打开的Tab页
		private Dictionary<string, XtraTabPage> openedTabPage = new Dictionary<string, XtraTabPage>();

		public Frm_main()
		{
			InitializeComponent();
			swapdata = new Dictionary<string, object>();
			BO01_list = new XPQuery<BO01>(session1);
		}

		private void Frm_main_Load(object sender, EventArgs e)
		{
			LogUtils.Info("start successfully!");
		}

		/// <summary>
		/// 窗口关闭事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Frm_main_FormClosed(object sender, FormClosedEventArgs e)
		{
			 
		}

		/// <summary>
		/// 打开业务对象(如果没有则创建)
		/// </summary>
		public void openBusinessObject(string bo001)
		{
			openBusinessObject(bo001, null);
		}

		/// <summary>
		/// 打开业务对象(如果没有则创建)
		/// </summary>
		public void openBusinessObject(string bo001, object parm)
		{
			if (openedTabPage.ContainsKey(bo001))
			{
				xtraTabControl1.SelectedTabPage = openedTabPage[bo001];
				if (parm != null)
				{
					foreach (Control control in openedTabPage[bo001].Controls)
					{
						if (control is BaseBusiness)
						{
							((BaseBusiness)control).swapdata["parm"] = parm;
							((BaseBusiness)control).Business_Init();
							return;
						}
					}
				}
			}
			else //如果尚未打开，则new
			{
				XtraTabPage newPage = new XtraTabPage();
				var searchList = from c in BO01_list
								where (c.BO001 == bo001) orderby c.BO001
								select c;


				if (searchList.Count() <= 0)
				{
					XtraMessageBox.Show("功能参数错误!","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
				BO01 target_bo = searchList.ElementAt<BO01>(0);
				newPage.Text = target_bo.BO003;
				newPage.Tag = bo001;
				newPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;

				BaseBusiness bo = (BaseBusiness)Activator.CreateInstance(Type.GetType("Lime.BusinessObject." + bo001));

				Envior.mform = this;

				bo.Dock = DockStyle.Fill;
				bo.Parent = newPage;
				bo.swapdata.Add("parm", parm);

				newPage.Controls.Add(bo);

				xtraTabControl1.TabPages.Add(newPage);
				xtraTabControl1.SelectedTabPage = newPage;
				bo.Business_Init();

				////////登记已打开 Tabpage ////////
				openedTabPage.Add(bo001, newPage);

			}
		}




		/// <summary>
		/// 角色管理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("Roles");
		}

		private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (session1.IsConnected)
				MessageBox.Show("数据库已经连接", "默认连接");
			else
				MessageBox.Show("数据库未连接", "默认连接");

			MessageBox.Show(session1.Connection.ConnectionString, "记录数");
		}
		/// <summary>
		/// 关闭标签页
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
		{
			ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
			XtraTabPage curPage = (XtraTabPage)arg.Page;
			///////// 清除页面追踪 ////////
			openedTabPage.Remove(curPage.Tag.ToString());
			curPage.Dispose();
		}
		/// <summary>
		/// 用户管理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("Operator");
		}

		/// <summary>
		/// 数据项维护
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("DataDict");
		}
	}
}