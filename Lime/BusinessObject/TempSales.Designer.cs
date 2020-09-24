namespace Lime.BusinessObject
{
	partial class TempSales
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TempSales));
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
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.te_billno = new DevExpress.XtraEditors.TextEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.be_cuname = new DevExpress.XtraEditors.ButtonEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.xpCollection1 = new DevExpress.Xpo.XPCollection(this.components);
			this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork(this.components);
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lookup_sa001 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.te_billno.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.be_cuname.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lookup_sa001)).BeginInit();
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
			this.barButtonItem4.Caption = "结算";
			this.barButtonItem4.Id = 4;
			this.barButtonItem4.ImageOptions.Image = global::Lime.Properties.Resources.boposition2_16x161;
			this.barButtonItem4.ImageOptions.LargeImage = global::Lime.Properties.Resources.boposition2_32x321;
			this.barButtonItem4.Name = "barButtonItem4";
			this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.CausesValidation = false;
			this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
			this.barDockControlTop.Manager = this.barManager1;
			this.barDockControlTop.Size = new System.Drawing.Size(1159, 36);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 650);
			this.barDockControlBottom.Manager = this.barManager1;
			this.barDockControlBottom.Size = new System.Drawing.Size(1159, 0);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 36);
			this.barDockControlLeft.Manager = this.barManager1;
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 614);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(1159, 36);
			this.barDockControlRight.Manager = this.barManager1;
			this.barDockControlRight.Size = new System.Drawing.Size(0, 614);
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.te_billno);
			this.panelControl1.Controls.Add(this.labelControl2);
			this.panelControl1.Controls.Add(this.be_cuname);
			this.panelControl1.Controls.Add(this.labelControl1);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 36);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(1159, 48);
			this.panelControl1.TabIndex = 4;
			// 
			// te_billno
			// 
			this.te_billno.Location = new System.Drawing.Point(704, 11);
			this.te_billno.MenuManager = this.barManager1;
			this.te_billno.Name = "te_billno";
			this.te_billno.Size = new System.Drawing.Size(299, 24);
			this.te_billno.TabIndex = 11;
			// 
			// labelControl2
			// 
			this.labelControl2.Appearance.Image = null;
			this.labelControl2.AppearanceDisabled.Image = null;
			this.labelControl2.AppearanceHovered.Image = null;
			this.labelControl2.AppearancePressed.Image = null;
			this.labelControl2.Location = new System.Drawing.Point(626, 14);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(57, 19);
			this.labelControl2.TabIndex = 10;
			this.labelControl2.Text = "单据号";
			// 
			// be_cuname
			// 
			this.be_cuname.Location = new System.Drawing.Point(152, 11);
			this.be_cuname.MenuManager = this.barManager1;
			this.be_cuname.Name = "be_cuname";
			this.be_cuname.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
			this.be_cuname.Size = new System.Drawing.Size(432, 24);
			this.be_cuname.TabIndex = 9;
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Image = null;
			this.labelControl1.AppearanceDisabled.Image = null;
			this.labelControl1.AppearanceHovered.Image = null;
			this.labelControl1.AppearancePressed.Image = null;
			this.labelControl1.Location = new System.Drawing.Point(16, 14);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(114, 19);
			this.labelControl1.TabIndex = 8;
			this.labelControl1.Text = "交款人或单位";
			// 
			// gridControl1
			// 
			this.gridControl1.DataSource = this.xpCollection1;
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControl1.Location = new System.Drawing.Point(0, 84);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.MenuManager = this.barManager1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lookup_sa001});
			this.gridControl1.Size = new System.Drawing.Size(1159, 566);
			this.gridControl1.TabIndex = 32;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// xpCollection1
			// 
			this.xpCollection1.LoadingEnabled = false;
			this.xpCollection1.ObjectType = typeof(Lime.Xpo.orcl.SA01);
			this.xpCollection1.Session = this.unitOfWork1;
			// 
			// unitOfWork1
			// 
			this.unitOfWork1.IsObjectModifiedOnNonPersistentPropertyChange = null;
			this.unitOfWork1.TrackPropertiesModifications = false;
			// 
			// gridView1
			// 
			this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
			this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
			this.gridView1.Appearance.Row.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gridView1.Appearance.Row.Options.UseFont = true;
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn6,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn7});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.IndicatorWidth = 45;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsBehavior.ReadOnly = true;
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsMenu.ShowFooterItem = true;
			this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
			this.gridView1.OptionsView.ColumnAutoWidth = false;
			this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.gridView1.OptionsView.ShowFooter = true;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "项目编号";
			this.gridColumn1.FieldName = "SA004";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.OptionsColumn.AllowShowHide = false;
			this.gridColumn1.Width = 221;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "服务或商品名";
			this.gridColumn6.FieldName = "SA003";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.OptionsColumn.AllowEdit = false;
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 0;
			this.gridColumn6.Width = 218;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "单价";
			this.gridColumn2.DisplayFormat.FormatString = "N2";
			this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn2.FieldName = "PRICE";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 113;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "数量";
			this.gridColumn3.DisplayFormat.FormatString = "N1";
			this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn3.FieldName = "NUMS";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			this.gridColumn3.Width = 106;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "金额";
			this.gridColumn4.DisplayFormat.FormatString = "N2";
			this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn4.FieldName = "SA007";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.AllowEdit = false;
			this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SA007", "合计={0:N2}")});
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			this.gridColumn4.Width = 173;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "类别";
			this.gridColumn5.FieldName = "SA002";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.OptionsColumn.AllowEdit = false;
			this.gridColumn5.OptionsColumn.AllowShowHide = false;
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "gridColumn7";
			this.gridColumn7.FieldName = "SA005";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.OptionsColumn.AllowShowHide = false;
			// 
			// lookup_sa001
			// 
			this.lookup_sa001.AutoHeight = false;
			this.lookup_sa001.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lookup_sa001.Name = "lookup_sa001";
			// 
			// TempSales
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gridControl1);
			this.Controls.Add(this.panelControl1);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Name = "TempSales";
			this.Size = new System.Drawing.Size(1159, 650);
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			this.panelControl1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.te_billno.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.be_cuname.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lookup_sa001)).EndInit();
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
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup_sa001;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.TextEdit te_billno;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.ButtonEdit be_cuname;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.Xpo.XPCollection xpCollection1;
		private DevExpress.Xpo.UnitOfWork unitOfWork1;
	}
}
