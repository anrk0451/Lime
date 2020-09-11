namespace Lime.BusinessObject
{
	partial class Operator
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Operator));
			this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
			this.bar1 = new DevExpress.XtraBars.Bar();
			this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.xpCollection1 = new DevExpress.Xpo.XPCollection(this.components);
			this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork(this.components);
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colUC001 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colUC002 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colUC003 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colUC004 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSTATUS = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colROLESLIST = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// barManager1
			// 
			this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
			this.barManager1.DockControls.Add(this.barDockControlTop);
			this.barManager1.DockControls.Add(this.barDockControlBottom);
			this.barManager1.DockControls.Add(this.barDockControlLeft);
			this.barManager1.DockControls.Add(this.barDockControlRight);
			this.barManager1.Form = this;
			this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4});
			this.barManager1.MaxItemId = 7;
			// 
			// bar1
			// 
			this.bar1.BarName = "工具";
			this.bar1.DockCol = 0;
			this.bar1.DockRow = 0;
			this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem3, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem4, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
			this.bar1.OptionsBar.AllowQuickCustomization = false;
			this.bar1.Text = "工具";
			// 
			// barButtonItem1
			// 
			this.barButtonItem1.Caption = "新增";
			this.barButtonItem1.Id = 1;
			this.barButtonItem1.ImageOptions.SvgImage = global::Lime.Properties.Resources.actions_addcircled;
			this.barButtonItem1.Name = "barButtonItem1";
			this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
			// 
			// barButtonItem2
			// 
			this.barButtonItem2.Caption = "删除";
			this.barButtonItem2.Id = 2;
			this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
			this.barButtonItem2.Name = "barButtonItem2";
			this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
			// 
			// barButtonItem3
			// 
			this.barButtonItem3.Caption = "修改";
			this.barButtonItem3.Id = 3;
			this.barButtonItem3.ImageOptions.SvgImage = global::Lime.Properties.Resources.editnames;
			this.barButtonItem3.Name = "barButtonItem3";
			this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
			// 
			// barButtonItem4
			// 
			this.barButtonItem4.Caption = "刷新";
			this.barButtonItem4.Id = 4;
			this.barButtonItem4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem4.ImageOptions.SvgImage")));
			this.barButtonItem4.Name = "barButtonItem4";
			this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.CausesValidation = false;
			this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
			this.barDockControlTop.Manager = this.barManager1;
			this.barDockControlTop.Size = new System.Drawing.Size(1155, 34);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 591);
			this.barDockControlBottom.Manager = this.barManager1;
			this.barDockControlBottom.Size = new System.Drawing.Size(1155, 0);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
			this.barDockControlLeft.Manager = this.barManager1;
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 557);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(1155, 34);
			this.barDockControlRight.Manager = this.barManager1;
			this.barDockControlRight.Size = new System.Drawing.Size(0, 557);
			// 
			// gridControl1
			// 
			this.gridControl1.DataSource = this.xpCollection1;
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControl1.Location = new System.Drawing.Point(0, 34);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.MenuManager = this.barManager1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(1155, 557);
			this.gridControl1.TabIndex = 5;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// xpCollection1
			// 
			this.xpCollection1.ObjectType = typeof(Lime.Xpo.orcl.V_UC01);
			this.xpCollection1.Session = this.unitOfWork1;
			// 
			// unitOfWork1
			// 
			this.unitOfWork1.IsObjectModifiedOnNonPersistentPropertyChange = null;
			this.unitOfWork1.TrackPropertiesModifications = false;
			// 
			// gridView1
			// 
			this.gridView1.ActiveFilterString = "[STATUS] = \'1\'";
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUC001,
            this.colUC002,
            this.colUC003,
            this.colUC004,
            this.colSTATUS,
            this.colROLESLIST});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.IndicatorWidth = 30;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.AllowValidationErrors = false;
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsFilter.AllowFilterEditor = false;
			this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
			this.gridView1.OptionsView.ColumnAutoWidth = false;
			this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
			// 
			// colUC001
			// 
			this.colUC001.FieldName = "UC001";
			this.colUC001.MinWidth = 25;
			this.colUC001.Name = "colUC001";
			this.colUC001.OptionsColumn.AllowShowHide = false;
			this.colUC001.Width = 94;
			// 
			// colUC002
			// 
			this.colUC002.Caption = "用户代码";
			this.colUC002.FieldName = "UC002";
			this.colUC002.MinWidth = 25;
			this.colUC002.Name = "colUC002";
			this.colUC002.Visible = true;
			this.colUC002.VisibleIndex = 0;
			this.colUC002.Width = 172;
			// 
			// colUC003
			// 
			this.colUC003.Caption = "用户名";
			this.colUC003.FieldName = "UC003";
			this.colUC003.MinWidth = 25;
			this.colUC003.Name = "colUC003";
			this.colUC003.Visible = true;
			this.colUC003.VisibleIndex = 1;
			this.colUC003.Width = 208;
			// 
			// colUC004
			// 
			this.colUC004.FieldName = "UC004";
			this.colUC004.MinWidth = 25;
			this.colUC004.Name = "colUC004";
			this.colUC004.OptionsColumn.AllowShowHide = false;
			this.colUC004.Width = 94;
			// 
			// colSTATUS
			// 
			this.colSTATUS.FieldName = "STATUS";
			this.colSTATUS.MinWidth = 25;
			this.colSTATUS.Name = "colSTATUS";
			this.colSTATUS.OptionsColumn.AllowShowHide = false;
			this.colSTATUS.Width = 94;
			// 
			// colROLESLIST
			// 
			this.colROLESLIST.Caption = "角色列表";
			this.colROLESLIST.FieldName = "ROLESLIST";
			this.colROLESLIST.MinWidth = 25;
			this.colROLESLIST.Name = "colROLESLIST";
			this.colROLESLIST.Visible = true;
			this.colROLESLIST.VisibleIndex = 2;
			this.colROLESLIST.Width = 521;
			// 
			// Operator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gridControl1);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Name = "Operator";
			this.Size = new System.Drawing.Size(1155, 591);
			this.Load += new System.EventHandler(this.Operator_Load);
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.BarButtonItem barButtonItem1;
		private DevExpress.XtraBars.BarButtonItem barButtonItem2;
		private DevExpress.XtraBars.BarButtonItem barButtonItem3;
		private DevExpress.XtraBars.BarButtonItem barButtonItem4;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.Xpo.UnitOfWork unitOfWork1;
		private DevExpress.Xpo.XPCollection xpCollection1;
		private DevExpress.XtraGrid.Columns.GridColumn colUC001;
		private DevExpress.XtraGrid.Columns.GridColumn colUC002;
		private DevExpress.XtraGrid.Columns.GridColumn colUC003;
		private DevExpress.XtraGrid.Columns.GridColumn colUC004;
		private DevExpress.XtraGrid.Columns.GridColumn colSTATUS;
		private DevExpress.XtraGrid.Columns.GridColumn colROLESLIST;
	}
}
