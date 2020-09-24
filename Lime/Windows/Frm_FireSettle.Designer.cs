namespace Lime.Windows
{
	partial class Frm_FireSettle
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.xpCollection1 = new DevExpress.Xpo.XPCollection(this.components);
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.sb_ok = new DevExpress.XtraEditors.SimpleButton();
			this.sb_cancel = new DevExpress.XtraEditors.SimpleButton();
			this.te_fa099 = new DevExpress.XtraEditors.TextEdit();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_fa099.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gridControl1
			// 
			this.gridControl1.DataSource = this.xpCollection1;
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
			this.gridControl1.Location = new System.Drawing.Point(0, 46);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(648, 412);
			this.gridControl1.TabIndex = 62;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// xpCollection1
			// 
			this.xpCollection1.LoadingEnabled = false;
			this.xpCollection1.ObjectType = typeof(Lime.Xpo.orcl.SA01);
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.IndicatorWidth = 45;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsCustomization.AllowGroup = false;
			this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
			this.gridView1.OptionsView.ColumnAutoWidth = false;
			this.gridView1.OptionsView.ShowFooter = true;
			this.gridView1.OptionsView.ShowGroupExpandCollapseButtons = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "销售编号";
			this.gridColumn1.FieldName = "SA001";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowShowHide = false;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "商品或服务名";
			this.gridColumn2.FieldName = "SA003";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 0;
			this.gridColumn2.Width = 216;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "单价";
			this.gridColumn3.DisplayFormat.FormatString = "N2";
			this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn3.FieldName = "PRICE";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 1;
			this.gridColumn3.Width = 119;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "数量";
			this.gridColumn4.DisplayFormat.FormatString = "N1";
			this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn4.FieldName = "NUMS";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.AllowEdit = false;
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 2;
			this.gridColumn4.Width = 85;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "销售金额";
			this.gridColumn5.DisplayFormat.FormatString = "N2";
			this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn5.FieldName = "SA007";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.OptionsColumn.AllowEdit = false;
			this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SA007", "{0:N2}")});
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 3;
			this.gridColumn5.Width = 125;
			// 
			// sb_ok
			// 
			this.sb_ok.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
			this.sb_ok.Appearance.ForeColor = System.Drawing.Color.White;
			this.sb_ok.Appearance.Options.UseBackColor = true;
			this.sb_ok.Appearance.Options.UseForeColor = true;
			this.sb_ok.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.sb_ok.Location = new System.Drawing.Point(666, 20);
			this.sb_ok.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sb_ok.Name = "sb_ok";
			this.sb_ok.Size = new System.Drawing.Size(129, 30);
			this.sb_ok.TabIndex = 146;
			this.sb_ok.Text = "确定";
			this.sb_ok.Click += new System.EventHandler(this.sb_ok_Click);
			// 
			// sb_cancel
			// 
			this.sb_cancel.Appearance.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.sb_cancel.Appearance.ForeColor = System.Drawing.Color.Black;
			this.sb_cancel.Appearance.Options.UseBackColor = true;
			this.sb_cancel.Appearance.Options.UseForeColor = true;
			this.sb_cancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.sb_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sb_cancel.Location = new System.Drawing.Point(666, 60);
			this.sb_cancel.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sb_cancel.Name = "sb_cancel";
			this.sb_cancel.Size = new System.Drawing.Size(129, 30);
			this.sb_cancel.TabIndex = 145;
			this.sb_cancel.Text = "关闭";
			// 
			// te_fa099
			// 
			this.te_fa099.Location = new System.Drawing.Point(107, 10);
			this.te_fa099.Name = "te_fa099";
			this.te_fa099.Size = new System.Drawing.Size(541, 24);
			this.te_fa099.TabIndex = 147;
			// 
			// panelControl1
			// 
			this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.panelControl1.Appearance.Options.UseBackColor = true;
			this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl1.Controls.Add(this.labelControl1);
			this.panelControl1.Controls.Add(this.te_fa099);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(812, 46);
			this.panelControl1.TabIndex = 148;
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Image = null;
			this.labelControl1.AppearanceDisabled.Image = null;
			this.labelControl1.AppearanceHovered.Image = null;
			this.labelControl1.AppearancePressed.Image = null;
			this.labelControl1.Location = new System.Drawing.Point(8, 14);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(95, 19);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "收费单据号";
			// 
			// Frm_FireSettle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(812, 458);
			this.Controls.Add(this.sb_ok);
			this.Controls.Add(this.sb_cancel);
			this.Controls.Add(this.gridControl1);
			this.Controls.Add(this.panelControl1);
			this.Name = "Frm_FireSettle";
			this.Text = "业务结算";
			this.Load += new System.EventHandler(this.Frm_FireSettle_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_fa099.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			this.panelControl1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraEditors.SimpleButton sb_ok;
		private DevExpress.XtraEditors.SimpleButton sb_cancel;
		private DevExpress.Xpo.XPCollection xpCollection1;
		private DevExpress.XtraEditors.TextEdit te_fa099;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.LabelControl labelControl1;
	}
}