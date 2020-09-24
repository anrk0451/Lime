namespace Lime.Windows
{
	partial class Frm_LayerPrice
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
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colLY001 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRG001 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colLY002 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPRICE = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.sb_ok = new DevExpress.XtraEditors.SimpleButton();
			this.sb_cancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
			this.SuspendLayout();
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.gridControl1.Location = new System.Drawing.Point(0, 0);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
			this.gridControl1.Size = new System.Drawing.Size(499, 344);
			this.gridControl1.TabIndex = 9;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLY001,
            this.colRG001,
            this.colLY002,
            this.colPRICE});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
			this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
			this.gridView1.OptionsCustomization.AllowFilter = false;
			this.gridView1.OptionsCustomization.AllowSort = false;
			this.gridView1.OptionsFilter.AllowColumnMRUFilterList = false;
			this.gridView1.OptionsFilter.AllowFilterEditor = false;
			this.gridView1.OptionsFilter.AllowFilterIncrementalSearch = false;
			this.gridView1.OptionsFilter.AllowMRUFilterList = false;
			this.gridView1.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
			this.gridView1.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = false;
			this.gridView1.OptionsMenu.EnableColumnMenu = false;
			this.gridView1.OptionsView.ColumnAutoWidth = false;
			this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.gridView1.OptionsView.ShowGroupExpandCollapseButtons = false;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLY002, DevExpress.Data.ColumnSortOrder.Descending)});
			this.gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView1_ValidatingEditor);
			// 
			// colLY001
			// 
			this.colLY001.FieldName = "LY001";
			this.colLY001.MinWidth = 25;
			this.colLY001.Name = "colLY001";
			this.colLY001.OptionsColumn.AllowShowHide = false;
			this.colLY001.Width = 94;
			// 
			// colRG001
			// 
			this.colRG001.FieldName = "RG001";
			this.colRG001.MinWidth = 25;
			this.colRG001.Name = "colRG001";
			this.colRG001.OptionsColumn.AllowShowHide = false;
			this.colRG001.Width = 94;
			// 
			// colLY002
			// 
			this.colLY002.AppearanceCell.Options.UseTextOptions = true;
			this.colLY002.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colLY002.Caption = "层号";
			this.colLY002.FieldName = "LY002";
			this.colLY002.MinWidth = 25;
			this.colLY002.Name = "colLY002";
			this.colLY002.OptionsColumn.ReadOnly = true;
			this.colLY002.Visible = true;
			this.colLY002.VisibleIndex = 0;
			this.colLY002.Width = 146;
			// 
			// colPRICE
			// 
			this.colPRICE.AppearanceCell.Options.UseTextOptions = true;
			this.colPRICE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.colPRICE.Caption = "定价";
			this.colPRICE.ColumnEdit = this.repositoryItemTextEdit2;
			this.colPRICE.FieldName = "PRICE";
			this.colPRICE.MinWidth = 25;
			this.colPRICE.Name = "colPRICE";
			this.colPRICE.Visible = true;
			this.colPRICE.VisibleIndex = 1;
			this.colPRICE.Width = 212;
			// 
			// repositoryItemTextEdit2
			// 
			this.repositoryItemTextEdit2.AutoHeight = false;
			this.repositoryItemTextEdit2.Mask.EditMask = "N2";
			this.repositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.repositoryItemTextEdit2.Mask.UseMaskAsDisplayFormat = true;
			this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
			// 
			// repositoryItemTextEdit1
			// 
			this.repositoryItemTextEdit1.AutoHeight = false;
			this.repositoryItemTextEdit1.Mask.EditMask = "N2";
			this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.repositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = true;
			this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
			// 
			// sb_ok
			// 
			this.sb_ok.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
			this.sb_ok.Appearance.ForeColor = System.Drawing.Color.White;
			this.sb_ok.Appearance.Options.UseBackColor = true;
			this.sb_ok.Appearance.Options.UseForeColor = true;
			this.sb_ok.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.sb_ok.Location = new System.Drawing.Point(243, 366);
			this.sb_ok.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sb_ok.Name = "sb_ok";
			this.sb_ok.Size = new System.Drawing.Size(118, 30);
			this.sb_ok.TabIndex = 63;
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
			this.sb_cancel.Location = new System.Drawing.Point(367, 366);
			this.sb_cancel.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sb_cancel.Name = "sb_cancel";
			this.sb_cancel.Size = new System.Drawing.Size(118, 30);
			this.sb_cancel.TabIndex = 64;
			this.sb_cancel.Text = "取消";
			this.sb_cancel.Click += new System.EventHandler(this.sb_cancel_Click);
			// 
			// simpleButton1
			// 
			this.simpleButton1.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
			this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.White;
			this.simpleButton1.Appearance.Options.UseBackColor = true;
			this.simpleButton1.Appearance.Options.UseForeColor = true;
			this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.simpleButton1.Location = new System.Drawing.Point(8, 366);
			this.simpleButton1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(118, 30);
			this.simpleButton1.TabIndex = 65;
			this.simpleButton1.Text = "复制当前值";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// Frm_LayerPrice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.sb_cancel;
			this.ClientSize = new System.Drawing.Size(499, 411);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.sb_cancel);
			this.Controls.Add(this.sb_ok);
			this.Controls.Add(this.gridControl1);
			this.Name = "Frm_LayerPrice";
			this.Text = "层定价";
			this.Load += new System.EventHandler(this.Frm_LayerPrice_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
		private DevExpress.XtraEditors.SimpleButton sb_ok;
		private DevExpress.XtraEditors.SimpleButton sb_cancel;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraGrid.Columns.GridColumn colLY001;
		private DevExpress.XtraGrid.Columns.GridColumn colRG001;
		private DevExpress.XtraGrid.Columns.GridColumn colLY002;
		private DevExpress.XtraGrid.Columns.GridColumn colPRICE;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
	}
}