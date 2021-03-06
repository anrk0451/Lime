﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Lime.Xpo.orcl;
using DevExpress.XtraTab;
using DevExpress.XtraEditors;
using Lime.BaseObject;
using DevExpress.Xpo;
using Lime.Misc;
using DevExpress.XtraTab.ViewInfo;
using Lime.Action;
using Lime.Windows;
using System.Runtime.InteropServices;
using System.Diagnostics;
using DevExpress.XtraSplashScreen;

namespace Lime
{
	public partial class Frm_main : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		[DllImport("user32.dll", EntryPoint = "FindWindow")]
		private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

		Process printprocess = null ;                                 //打印服务进程
		public static SocketClient socket = new SocketClient();

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
			//登记系统主窗口
			Envior.mform = this;

			Frm_Login f_login = new Frm_Login();
			f_login.ShowDialog();

			if (f_login.DialogResult == DialogResult.OK)  //登录成功处理..........
			{
				bs_user.Caption = Envior.cur_user.UC003;
				bs_version.Caption = App_Const.APP_VERSION;
				f_login.Dispose();				 
			}

			//启动打印服务进程
			printprocess = new Process();
			printprocess.StartInfo.FileName = "pbnative.exe";
			printprocess.Start();
		}

		/// <summary>
		/// 窗口关闭事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Frm_main_FormClosed(object sender, FormClosedEventArgs e)
		{
			//断开数据库连接
			SqlHelper.DisConnect();
			//关闭关联的打印进程
			
			if (printprocess != null && !printprocess.HasExited) printprocess.Kill();
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
		/// <summary>
		/// 进灵登记
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
		{
			Frm_FireCheckin frm_1 = new Frm_FireCheckin();
			frm_1.ShowDialog();
			frm_1.Dispose();
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
		/// <summary>
		/// 服务商品及定价
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("SalesItemInfo");
		}
		/// <summary>
		/// 寄存结构维护
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("RegisterStru");
		}
		/// <summary>
		/// 业务套餐维护
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("Combo");
		}

		private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("FireCheckinBrow");
		}

		private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("TempSales");
		}

		private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("RegisterBrow");
		}
		/// <summary>
		/// 收费日查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("FinanceDaySearch");
		}

		private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("RegData");
		}
		/// <summary>
		/// 进灵数据查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("Report_Checkin");
		}
		/// <summary>
		/// 出灵数据查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("Report_Checkout");
		}
		/// <summary>
		/// 骨灰寄存量统计
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("Report_Regstat");
		}

		private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("Report_RegDebt");
		}
		/// <summary>
		/// 迁出查询统计
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("Report_OutSearch");
		}

		private void barButtonItem26_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("Report_ClassStat");
		}

		private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("Report_ItemStat");
		}

		private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("Report_FinRoll");
		}
		/// <summary>
		/// 修改密码
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
		{
			Frm_ChgPwd frm_modify_pwd = new Frm_ChgPwd();
			frm_modify_pwd.ShowDialog();
		}

		private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("Report_Hhzm");
		}
		/// <summary>
		/// 收款员统计
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("Report_Cashier");
		}

		private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
		{
			openBusinessObject("Report_Having");
		}
		/// <summary>
		/// 系统备份
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
		{
			saveFileDialog1.Filter = "bin files(*.bin)|*.bin|All files (*.*)|*.*";
			saveFileDialog1.RestoreDirectory = true;
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				SplashScreenManager.ShowDefaultWaitForm("正在备份", "请稍候....");
				string fname;
				fname = saveFileDialog1.FileName;
				BackupSet bset = new BackupSet();
				bset.Backup(fname);
				SplashScreenManager.CloseDefaultWaitForm();
				XtraMessageBox.Show("备份成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}