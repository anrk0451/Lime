﻿namespace Lime.Windows
{
	partial class Frm_BusinessEdit
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
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.txtedit_price = new DevExpress.XtraEditors.TextEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.txtedit_sa003 = new DevExpress.XtraEditors.TextEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.txtedit_nums = new DevExpress.XtraEditors.SpinEdit();
			this.sb_cancel = new DevExpress.XtraEditors.SimpleButton();
			this.sb_ok = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.txtedit_price.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtedit_sa003.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtedit_nums.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// labelControl3
			// 
			this.labelControl3.Appearance.Image = null;
			this.labelControl3.AppearanceDisabled.Image = null;
			this.labelControl3.AppearanceHovered.Image = null;
			this.labelControl3.AppearancePressed.Image = null;
			this.labelControl3.Location = new System.Drawing.Point(40, 132);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(38, 19);
			this.labelControl3.TabIndex = 33;
			this.labelControl3.Text = "数量";
			// 
			// txtedit_price
			// 
			this.txtedit_price.Location = new System.Drawing.Point(127, 80);
			this.txtedit_price.Name = "txtedit_price";
			this.txtedit_price.Properties.Appearance.Options.UseTextOptions = true;
			this.txtedit_price.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.txtedit_price.Properties.Mask.EditMask = "N2";
			this.txtedit_price.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.txtedit_price.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.txtedit_price.Size = new System.Drawing.Size(212, 24);
			this.txtedit_price.TabIndex = 32;
			this.txtedit_price.Validating += new System.ComponentModel.CancelEventHandler(this.txtedit_price_Validating);
			// 
			// labelControl2
			// 
			this.labelControl2.Appearance.Image = null;
			this.labelControl2.AppearanceDisabled.Image = null;
			this.labelControl2.AppearanceHovered.Image = null;
			this.labelControl2.AppearancePressed.Image = null;
			this.labelControl2.Location = new System.Drawing.Point(40, 82);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(38, 19);
			this.labelControl2.TabIndex = 31;
			this.labelControl2.Text = "单价";
			// 
			// txtedit_sa003
			// 
			this.txtedit_sa003.Location = new System.Drawing.Point(127, 33);
			this.txtedit_sa003.Name = "txtedit_sa003";
			this.txtedit_sa003.Properties.ReadOnly = true;
			this.txtedit_sa003.Size = new System.Drawing.Size(212, 24);
			this.txtedit_sa003.TabIndex = 30;
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Image = null;
			this.labelControl1.AppearanceDisabled.Image = null;
			this.labelControl1.AppearanceHovered.Image = null;
			this.labelControl1.AppearancePressed.Image = null;
			this.labelControl1.Location = new System.Drawing.Point(40, 36);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(76, 19);
			this.labelControl1.TabIndex = 29;
			this.labelControl1.Text = "项目名称";
			// 
			// txtedit_nums
			// 
			this.txtedit_nums.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.txtedit_nums.Location = new System.Drawing.Point(127, 128);
			this.txtedit_nums.Name = "txtedit_nums";
			this.txtedit_nums.Properties.Appearance.Options.UseTextOptions = true;
			this.txtedit_nums.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.txtedit_nums.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.txtedit_nums.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
			this.txtedit_nums.Properties.Mask.EditMask = "N1";
			this.txtedit_nums.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.txtedit_nums.Size = new System.Drawing.Size(82, 24);
			this.txtedit_nums.TabIndex = 34;
			this.txtedit_nums.Validating += new System.ComponentModel.CancelEventHandler(this.txtedit_nums_Validating);
			// 
			// sb_cancel
			// 
			this.sb_cancel.Appearance.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.sb_cancel.Appearance.ForeColor = System.Drawing.Color.Black;
			this.sb_cancel.Appearance.Options.UseBackColor = true;
			this.sb_cancel.Appearance.Options.UseForeColor = true;
			this.sb_cancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.sb_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sb_cancel.Location = new System.Drawing.Point(358, 76);
			this.sb_cancel.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sb_cancel.Name = "sb_cancel";
			this.sb_cancel.Size = new System.Drawing.Size(129, 30);
			this.sb_cancel.TabIndex = 144;
			this.sb_cancel.Text = "取消";
			this.sb_cancel.Click += new System.EventHandler(this.sb_cancel_Click);
			// 
			// sb_ok
			// 
			this.sb_ok.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
			this.sb_ok.Appearance.ForeColor = System.Drawing.Color.White;
			this.sb_ok.Appearance.Options.UseBackColor = true;
			this.sb_ok.Appearance.Options.UseForeColor = true;
			this.sb_ok.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.sb_ok.Location = new System.Drawing.Point(358, 35);
			this.sb_ok.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sb_ok.Name = "sb_ok";
			this.sb_ok.Size = new System.Drawing.Size(129, 30);
			this.sb_ok.TabIndex = 143;
			this.sb_ok.Text = "确定";
			this.sb_ok.Click += new System.EventHandler(this.sb_ok_Click);
			// 
			// Frm_BusinessEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(508, 185);
			this.Controls.Add(this.sb_cancel);
			this.Controls.Add(this.sb_ok);
			this.Controls.Add(this.labelControl3);
			this.Controls.Add(this.txtedit_price);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.txtedit_sa003);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.txtedit_nums);
			this.Name = "Frm_BusinessEdit";
			this.Text = "项目编辑";
			this.Load += new System.EventHandler(this.Frm_BusinessEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtedit_price.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtedit_sa003.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtedit_nums.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.TextEdit txtedit_price;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.TextEdit txtedit_sa003;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.SpinEdit txtedit_nums;
		private DevExpress.XtraEditors.SimpleButton sb_cancel;
		private DevExpress.XtraEditors.SimpleButton sb_ok;
	}
}