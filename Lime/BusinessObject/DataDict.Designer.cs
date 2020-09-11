namespace Lime.BusinessObject
{
	partial class DataDict
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
			DevExpress.XtraEditors.Controls.ImageListBoxItemImageOptions imageListBoxItemImageOptions1 = new DevExpress.XtraEditors.Controls.ImageListBoxItemImageOptions();
			DevExpress.XtraEditors.Controls.ImageListBoxItemImageOptions imageListBoxItemImageOptions2 = new DevExpress.XtraEditors.Controls.ImageListBoxItemImageOptions();
			DevExpress.XtraEditors.Controls.ImageListBoxItemImageOptions imageListBoxItemImageOptions3 = new DevExpress.XtraEditors.Controls.ImageListBoxItemImageOptions();
			DevExpress.XtraEditors.Controls.ImageListBoxItemImageOptions imageListBoxItemImageOptions4 = new DevExpress.XtraEditors.Controls.ImageListBoxItemImageOptions();
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.imageListBoxControl1 = new DevExpress.XtraEditors.ImageListBoxControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
			this.bar1 = new DevExpress.XtraBars.Bar();
			this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colRO001 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRO003 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRO004 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSTATUS = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imageListBoxControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.imageListBoxControl1);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
			this.splitContainerControl1.Panel2.Controls.Add(this.barDockControlLeft);
			this.splitContainerControl1.Panel2.Controls.Add(this.barDockControlRight);
			this.splitContainerControl1.Panel2.Controls.Add(this.barDockControlBottom);
			this.splitContainerControl1.Panel2.Controls.Add(this.barDockControlTop);
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(1002, 603);
			this.splitContainerControl1.SplitterPosition = 231;
			this.splitContainerControl1.TabIndex = 0;
			// 
			// imageListBoxControl1
			// 
			this.imageListBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			imageListBoxItemImageOptions1.SvgImage = global::Lime.Properties.Resources.bo_contract;
			imageListBoxItemImageOptions2.SvgImage = global::Lime.Properties.Resources.bo_contract1;
			imageListBoxItemImageOptions3.SvgImage = global::Lime.Properties.Resources.bo_contract2;
			imageListBoxItemImageOptions4.SvgImage = global::Lime.Properties.Resources.bo_contract3;
			this.imageListBoxControl1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageListBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("死亡原因", "", imageListBoxItemImageOptions1, null),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("所属区县", "", imageListBoxItemImageOptions2, null),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("与逝者关系", "", imageListBoxItemImageOptions3, null),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("骨灰处理", "", imageListBoxItemImageOptions4, null)});
			this.imageListBoxControl1.Location = new System.Drawing.Point(0, 0);
			this.imageListBoxControl1.Name = "imageListBoxControl1";
			this.imageListBoxControl1.Size = new System.Drawing.Size(231, 603);
			this.imageListBoxControl1.TabIndex = 0;
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 32);
			this.barDockControlLeft.Manager = this.barManager1;
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 571);
			// 
			// barManager1
			// 
			this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
			this.barManager1.DockControls.Add(this.barDockControlTop);
			this.barManager1.DockControls.Add(this.barDockControlBottom);
			this.barManager1.DockControls.Add(this.barDockControlLeft);
			this.barManager1.DockControls.Add(this.barDockControlRight);
			this.barManager1.Form = this.splitContainerControl1.Panel2;
			this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6});
			this.barManager1.MaxItemId = 6;
			// 
			// bar1
			// 
			this.bar1.BarAppearance.Normal.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.bar1.BarName = "工具";
			this.bar1.DockCol = 0;
			this.bar1.DockRow = 0;
			this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem3, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem6, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
			this.bar1.Text = "工具";
			// 
			// barButtonItem1
			// 
			this.barButtonItem1.Caption = "新增";
			this.barButtonItem1.Id = 0;
			this.barButtonItem1.ImageOptions.SvgImage = global::Lime.Properties.Resources.actions_addcircled1;
			this.barButtonItem1.Name = "barButtonItem1";
			// 
			// barButtonItem2
			// 
			this.barButtonItem2.Caption = "删除";
			this.barButtonItem2.Id = 1;
			this.barButtonItem2.ImageOptions.SvgImage = global::Lime.Properties.Resources.delete;
			this.barButtonItem2.Name = "barButtonItem2";
			// 
			// barButtonItem3
			// 
			this.barButtonItem3.Caption = "保存";
			this.barButtonItem3.Id = 2;
			this.barButtonItem3.ImageOptions.SvgImage = global::Lime.Properties.Resources.save;
			this.barButtonItem3.Name = "barButtonItem3";
			// 
			// barButtonItem6
			// 
			this.barButtonItem6.Caption = "刷新";
			this.barButtonItem6.Id = 5;
			this.barButtonItem6.ImageOptions.SvgImage = global::Lime.Properties.Resources.changeview;
			this.barButtonItem6.Name = "barButtonItem6";
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.CausesValidation = false;
			this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
			this.barDockControlTop.Manager = this.barManager1;
			this.barDockControlTop.Size = new System.Drawing.Size(764, 32);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 603);
			this.barDockControlBottom.Manager = this.barManager1;
			this.barDockControlBottom.Size = new System.Drawing.Size(764, 0);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(764, 32);
			this.barDockControlRight.Manager = this.barManager1;
			this.barDockControlRight.Size = new System.Drawing.Size(0, 571);
			// 
			// barButtonItem4
			// 
			this.barButtonItem4.Caption = "barButtonItem4";
			this.barButtonItem4.Id = 3;
			this.barButtonItem4.Name = "barButtonItem4";
			toolTipItem1.Text = "上移";
			superToolTip1.Items.Add(toolTipItem1);
			this.barButtonItem4.SuperTip = superToolTip1;
			// 
			// barButtonItem5
			// 
			this.barButtonItem5.Caption = "barButtonItem5";
			this.barButtonItem5.Id = 4;
			this.barButtonItem5.Name = "barButtonItem5";
			toolTipItem2.Text = "下移";
			superToolTip2.Items.Add(toolTipItem2);
			this.barButtonItem5.SuperTip = superToolTip2;
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControl1.Location = new System.Drawing.Point(0, 32);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.MenuManager = this.barManager1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(764, 571);
			this.gridControl1.TabIndex = 5;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.ActiveFilterString = "[STATUS] <> \'0\'";
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRO001,
            this.colRO003,
            this.colRO004,
            this.colSTATUS});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.IndicatorWidth = 30;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.AllowValidationErrors = false;
			this.gridView1.OptionsFilter.AllowFilterEditor = false;
			this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
			this.gridView1.OptionsView.ColumnAutoWidth = false;
			this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
			this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// colRO001
			// 
			this.colRO001.FieldName = "RO001";
			this.colRO001.MinWidth = 25;
			this.colRO001.Name = "colRO001";
			this.colRO001.OptionsColumn.AllowShowHide = false;
			this.colRO001.Width = 94;
			// 
			// colRO003
			// 
			this.colRO003.Caption = "角色名";
			this.colRO003.FieldName = "RO003";
			this.colRO003.MinWidth = 25;
			this.colRO003.Name = "colRO003";
			this.colRO003.Visible = true;
			this.colRO003.VisibleIndex = 0;
			this.colRO003.Width = 222;
			// 
			// colRO004
			// 
			this.colRO004.Caption = "描述";
			this.colRO004.FieldName = "RO004";
			this.colRO004.MinWidth = 25;
			this.colRO004.Name = "colRO004";
			this.colRO004.Visible = true;
			this.colRO004.VisibleIndex = 1;
			this.colRO004.Width = 843;
			// 
			// colSTATUS
			// 
			this.colSTATUS.FieldName = "STATUS";
			this.colSTATUS.MinWidth = 25;
			this.colSTATUS.Name = "colSTATUS";
			this.colSTATUS.OptionsColumn.AllowShowHide = false;
			this.colSTATUS.Width = 94;
			// 
			// DataDict
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainerControl1);
			this.Name = "DataDict";
			this.Size = new System.Drawing.Size(1002, 603);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.imageListBoxControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private DevExpress.XtraEditors.ImageListBoxControl imageListBoxControl1;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.BarButtonItem barButtonItem1;
		private DevExpress.XtraBars.BarButtonItem barButtonItem2;
		private DevExpress.XtraBars.BarButtonItem barButtonItem3;
		private DevExpress.XtraBars.BarButtonItem barButtonItem4;
		private DevExpress.XtraBars.BarButtonItem barButtonItem5;
		private DevExpress.XtraBars.BarButtonItem barButtonItem6;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn colRO001;
		private DevExpress.XtraGrid.Columns.GridColumn colRO003;
		private DevExpress.XtraGrid.Columns.GridColumn colRO004;
		private DevExpress.XtraGrid.Columns.GridColumn colSTATUS;
	}
}
