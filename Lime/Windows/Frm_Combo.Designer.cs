namespace Lime.Windows
{
	partial class Frm_Combo
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
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.mem_cb006 = new DevExpress.XtraEditors.MemoEdit();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.glue_cb005 = new DevExpress.XtraEditors.GridLookUpEdit();
			this.xpCollection_service = new DevExpress.Xpo.XPCollection(this.components);
			this.session1 = new DevExpress.Xpo.Session(this.components);
			this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colSERVICEID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSERVICENAME = new DevExpress.XtraGrid.Columns.GridColumn();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.rg_cb002 = new DevExpress.XtraEditors.RadioGroup();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.te_cb003 = new DevExpress.XtraEditors.TextEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.gridControl2 = new DevExpress.XtraGrid.GridControl();
			this.xpCollection_cb02 = new DevExpress.Xpo.XPCollection(this.components);
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repository_cb021 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
			this.xpCollection_item = new DevExpress.Xpo.XPCollection(this.components);
			this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.sb_cancel = new DevExpress.XtraEditors.SimpleButton();
			this.sb_ok = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mem_cb006.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.glue_cb005.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xpCollection_service)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.session1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rg_cb002.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_cb003.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xpCollection_cb02)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repository_cb021)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xpCollection_item)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl1
			// 
			this.groupControl1.Appearance.Options.UseFont = true;
			this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.groupControl1.Controls.Add(this.mem_cb006);
			this.groupControl1.Controls.Add(this.labelControl4);
			this.groupControl1.Controls.Add(this.glue_cb005);
			this.groupControl1.Controls.Add(this.labelControl3);
			this.groupControl1.Controls.Add(this.rg_cb002);
			this.groupControl1.Controls.Add(this.labelControl2);
			this.groupControl1.Controls.Add(this.te_cb003);
			this.groupControl1.Controls.Add(this.labelControl1);
			this.groupControl1.Location = new System.Drawing.Point(18, 20);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(559, 324);
			this.groupControl1.TabIndex = 0;
			this.groupControl1.Text = "基本信息";
			// 
			// mem_cb006
			// 
			this.mem_cb006.Location = new System.Drawing.Point(81, 223);
			this.mem_cb006.Name = "mem_cb006";
			this.mem_cb006.Size = new System.Drawing.Size(393, 83);
			this.mem_cb006.TabIndex = 7;
			// 
			// labelControl4
			// 
			this.labelControl4.Location = new System.Drawing.Point(81, 189);
			this.labelControl4.Name = "labelControl4";
			this.labelControl4.Size = new System.Drawing.Size(60, 18);
			this.labelControl4.TabIndex = 6;
			this.labelControl4.Text = "套餐描述";
			// 
			// glue_cb005
			// 
			this.glue_cb005.EditValue = "";
			this.glue_cb005.Location = new System.Drawing.Point(173, 136);
			this.glue_cb005.Name = "glue_cb005";
			this.glue_cb005.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.glue_cb005.Properties.DataSource = this.xpCollection_service;
			this.glue_cb005.Properties.DisplayMember = "SERVICENAME";
			this.glue_cb005.Properties.NullText = "[选择关联服务]";
			this.glue_cb005.Properties.PopupView = this.gridLookUpEdit1View;
			this.glue_cb005.Properties.ValueMember = "SERVICEID";
			this.glue_cb005.Size = new System.Drawing.Size(300, 24);
			this.glue_cb005.TabIndex = 5;
			// 
			// xpCollection_service
			// 
			this.xpCollection_service.ObjectType = typeof(Lime.Xpo.orcl.V_BINDINGSERVICE);
			this.xpCollection_service.Session = this.session1;
			// 
			// gridLookUpEdit1View
			// 
			this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSERVICEID,
            this.colSERVICENAME});
			this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
			this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridLookUpEdit1View.OptionsView.ShowColumnHeaders = false;
			this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
			// 
			// colSERVICEID
			// 
			this.colSERVICEID.FieldName = "SERVICEID";
			this.colSERVICEID.MinWidth = 18;
			this.colSERVICEID.Name = "colSERVICEID";
			this.colSERVICEID.Visible = true;
			this.colSERVICEID.VisibleIndex = 0;
			this.colSERVICEID.Width = 67;
			// 
			// colSERVICENAME
			// 
			this.colSERVICENAME.FieldName = "SERVICENAME";
			this.colSERVICENAME.MinWidth = 18;
			this.colSERVICENAME.Name = "colSERVICENAME";
			this.colSERVICENAME.Visible = true;
			this.colSERVICENAME.VisibleIndex = 1;
			this.colSERVICENAME.Width = 67;
			// 
			// labelControl3
			// 
			this.labelControl3.Location = new System.Drawing.Point(81, 139);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(60, 18);
			this.labelControl3.TabIndex = 4;
			this.labelControl3.Text = "关联服务";
			// 
			// rg_cb002
			// 
			this.rg_cb002.Location = new System.Drawing.Point(172, 82);
			this.rg_cb002.Name = "rg_cb002";
			this.rg_cb002.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.rg_cb002.Properties.Appearance.Options.UseBackColor = true;
			this.rg_cb002.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.rg_cb002.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "服务绑定"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "用户定义")});
			this.rg_cb002.Size = new System.Drawing.Size(268, 32);
			this.rg_cb002.TabIndex = 3;
			this.rg_cb002.SelectedIndexChanged += new System.EventHandler(this.rg_cb002_SelectedIndexChanged);
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(81, 89);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(30, 18);
			this.labelControl2.TabIndex = 2;
			this.labelControl2.Text = "类型";
			// 
			// te_cb003
			// 
			this.te_cb003.Location = new System.Drawing.Point(173, 42);
			this.te_cb003.Name = "te_cb003";
			this.te_cb003.Size = new System.Drawing.Size(300, 24);
			this.te_cb003.TabIndex = 1;
			this.te_cb003.Validating += new System.ComponentModel.CancelEventHandler(this.te_cb003_Validating);
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(81, 44);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(45, 18);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "套餐名";
			// 
			// gridControl2
			// 
			this.gridControl2.DataSource = this.xpCollection_cb02;
			this.gridControl2.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
			this.gridControl2.EmbeddedNavigator.Buttons.Edit.Visible = false;
			this.gridControl2.EmbeddedNavigator.Buttons.First.Visible = false;
			this.gridControl2.EmbeddedNavigator.Buttons.Last.Visible = false;
			this.gridControl2.EmbeddedNavigator.Buttons.Next.Visible = false;
			this.gridControl2.EmbeddedNavigator.Buttons.NextPage.Visible = false;
			this.gridControl2.EmbeddedNavigator.Buttons.Prev.Visible = false;
			this.gridControl2.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
			this.gridControl2.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.gridControl2.Location = new System.Drawing.Point(18, 350);
			this.gridControl2.MainView = this.gridView2;
			this.gridControl2.Name = "gridControl2";
			this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repository_cb021,
            this.repositoryItemSpinEdit1});
			this.gridControl2.Size = new System.Drawing.Size(559, 258);
			this.gridControl2.TabIndex = 29;
			this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
			// 
			// xpCollection_cb02
			// 
			this.xpCollection_cb02.LoadingEnabled = false;
			this.xpCollection_cb02.ObjectType = typeof(Lime.Xpo.orcl.CB02);
			this.xpCollection_cb02.Sorting.AddRange(new DevExpress.Xpo.SortProperty[] {
            new DevExpress.Xpo.SortProperty("[CB022]", DevExpress.Xpo.DB.SortingDirection.Ascending),
            new DevExpress.Xpo.SortProperty("[CB201]", DevExpress.Xpo.DB.SortingDirection.Ascending)});
			// 
			// gridView2
			// 
			this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
			this.gridView2.Appearance.Row.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gridView2.Appearance.Row.Options.UseFont = true;
			this.gridView2.Appearance.ViewCaption.Options.UseTextOptions = true;
			this.gridView2.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
			this.gridView2.GridControl = this.gridControl2;
			this.gridView2.IndicatorWidth = 31;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
			this.gridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
			this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
			this.gridView2.OptionsNavigation.EnterMoveNextColumn = true;
			this.gridView2.OptionsView.ColumnAutoWidth = false;
			this.gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
			this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			this.gridView2.OptionsView.ShowViewCaption = true;
			this.gridView2.ViewCaption = "套餐明细";
			this.gridView2.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView2_InitNewRow);
			this.gridView2.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView2_ValidateRow);
			this.gridView2.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView2_ValidatingEditor);
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "明细编号";
			this.gridColumn1.FieldName = "CB201";
			this.gridColumn1.MinWidth = 22;
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowShowHide = false;
			this.gridColumn1.Width = 84;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "套餐编号";
			this.gridColumn2.FieldName = "CB001";
			this.gridColumn2.MinWidth = 22;
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowShowHide = false;
			this.gridColumn2.Width = 84;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "服务或商品";
			this.gridColumn3.ColumnEdit = this.repository_cb021;
			this.gridColumn3.FieldName = "CB021";
			this.gridColumn3.MinWidth = 22;
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 0;
			this.gridColumn3.Width = 204;
			// 
			// repository_cb021
			// 
			this.repository_cb021.AutoHeight = false;
			this.repository_cb021.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repository_cb021.DataSource = this.xpCollection_item;
			this.repository_cb021.DisplayMember = "ITEM_TEXT";
			this.repository_cb021.ImmediatePopup = true;
			this.repository_cb021.Name = "repository_cb021";
			this.repository_cb021.NullText = "请选择项目";
			this.repository_cb021.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
			this.repository_cb021.PopupView = this.repositoryItemGridLookUpEdit1View;
			this.repository_cb021.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
			this.repository_cb021.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
			this.repository_cb021.ValueMember = "ITEM_ID";
			this.repository_cb021.Popup += new System.EventHandler(this.repository_cb021_Popup);
			// 
			// xpCollection_item
			// 
			this.xpCollection_item.ObjectType = typeof(Lime.Xpo.orcl.V_COMBO_ITEMS);
			this.xpCollection_item.Sorting.AddRange(new DevExpress.Xpo.SortProperty[] {
            new DevExpress.Xpo.SortProperty("[INVTYPE]", DevExpress.Xpo.DB.SortingDirection.Ascending),
            new DevExpress.Xpo.SortProperty("[ITEM_ID]", DevExpress.Xpo.DB.SortingDirection.Ascending)});
			// 
			// repositoryItemGridLookUpEdit1View
			// 
			this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
			this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.repositoryItemGridLookUpEdit1View.OptionsView.AllowCellMerge = true;
			this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn4
			// 
			this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.gridColumn4.Caption = "数量";
			this.gridColumn4.ColumnEdit = this.repositoryItemSpinEdit1;
			this.gridColumn4.DisplayFormat.FormatString = "N0";
			this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn4.FieldName = "CB030";
			this.gridColumn4.MinWidth = 22;
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 1;
			this.gridColumn4.Width = 132;
			// 
			// repositoryItemSpinEdit1
			// 
			this.repositoryItemSpinEdit1.Appearance.Options.UseTextOptions = true;
			this.repositoryItemSpinEdit1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.repositoryItemSpinEdit1.AutoHeight = false;
			this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemSpinEdit1.DisplayFormat.FormatString = "N0";
			this.repositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.repositoryItemSpinEdit1.Mask.EditMask = "N0";
			this.repositoryItemSpinEdit1.MaxValue = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.repositoryItemSpinEdit1.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "项目类别";
			this.gridColumn5.FieldName = "CB022";
			this.gridColumn5.MinWidth = 22;
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.OptionsColumn.AllowShowHide = false;
			this.gridColumn5.Width = 84;
			// 
			// sb_cancel
			// 
			this.sb_cancel.Appearance.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.sb_cancel.Appearance.ForeColor = System.Drawing.Color.Black;
			this.sb_cancel.Appearance.Options.UseBackColor = true;
			this.sb_cancel.Appearance.Options.UseForeColor = true;
			this.sb_cancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.sb_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sb_cancel.Location = new System.Drawing.Point(600, 65);
			this.sb_cancel.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sb_cancel.Name = "sb_cancel";
			this.sb_cancel.Size = new System.Drawing.Size(115, 30);
			this.sb_cancel.TabIndex = 68;
			this.sb_cancel.Text = "取消";
			// 
			// sb_ok
			// 
			this.sb_ok.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
			this.sb_ok.Appearance.ForeColor = System.Drawing.Color.White;
			this.sb_ok.Appearance.Options.UseBackColor = true;
			this.sb_ok.Appearance.Options.UseForeColor = true;
			this.sb_ok.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.sb_ok.Location = new System.Drawing.Point(600, 20);
			this.sb_ok.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sb_ok.Name = "sb_ok";
			this.sb_ok.Size = new System.Drawing.Size(115, 30);
			this.sb_ok.TabIndex = 67;
			this.sb_ok.Text = "确定";
			this.sb_ok.Click += new System.EventHandler(this.sb_ok_Click);
			// 
			// simpleButton1
			// 
			this.simpleButton1.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
			this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.White;
			this.simpleButton1.Appearance.Options.UseBackColor = true;
			this.simpleButton1.Appearance.Options.UseForeColor = true;
			this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.simpleButton1.Location = new System.Drawing.Point(600, 361);
			this.simpleButton1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(115, 30);
			this.simpleButton1.TabIndex = 69;
			this.simpleButton1.Text = "删除明细";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// Frm_Combo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(736, 620);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.sb_cancel);
			this.Controls.Add(this.sb_ok);
			this.Controls.Add(this.gridControl2);
			this.Controls.Add(this.groupControl1);
			this.Name = "Frm_Combo";
			this.Text = "业务套餐";
			this.Load += new System.EventHandler(this.Frm_Combo_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			this.groupControl1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.mem_cb006.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.glue_cb005.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xpCollection_service)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.session1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rg_cb002.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_cb003.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xpCollection_cb02)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repository_cb021)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xpCollection_item)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.MemoEdit mem_cb006;
		private DevExpress.XtraEditors.LabelControl labelControl4;
		private DevExpress.XtraEditors.GridLookUpEdit glue_cb005;
		private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.RadioGroup rg_cb002;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.TextEdit te_cb003;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraGrid.GridControl gridControl2;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repository_cb021;
		private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraEditors.SimpleButton sb_cancel;
		private DevExpress.XtraEditors.SimpleButton sb_ok;
		private DevExpress.Xpo.XPCollection xpCollection_service;
		private DevExpress.Xpo.Session session1;
		private DevExpress.XtraGrid.Columns.GridColumn colSERVICEID;
		private DevExpress.XtraGrid.Columns.GridColumn colSERVICENAME;
		private DevExpress.Xpo.XPCollection xpCollection_item;
		private DevExpress.Xpo.XPCollection xpCollection_cb02;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
	}
}