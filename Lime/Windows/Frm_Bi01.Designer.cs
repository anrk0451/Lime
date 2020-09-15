namespace Lime.Windows
{
	partial class Frm_Bi01
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
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.te_bi003 = new DevExpress.XtraEditors.TextEdit();
			this.te_price = new DevExpress.XtraEditors.TextEdit();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.sb_cancel = new DevExpress.XtraEditors.SimpleButton();
			this.sb_ok = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.te_bi003.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.te_price.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(58, 129);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(87, 23);
			this.radioButton3.TabIndex = 23;
			this.radioButton3.Text = "使无效";
			this.radioButton3.UseVisualStyleBackColor = true;
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// te_bi003
			// 
			this.te_bi003.Enabled = false;
			this.te_bi003.Location = new System.Drawing.Point(203, 77);
			this.te_bi003.Name = "te_bi003";
			this.te_bi003.Size = new System.Drawing.Size(191, 24);
			this.te_bi003.TabIndex = 22;
			this.te_bi003.Validating += new System.ComponentModel.CancelEventHandler(this.te_bi003_Validating);
			// 
			// te_price
			// 
			this.te_price.Location = new System.Drawing.Point(203, 33);
			this.te_price.Name = "te_price";
			this.te_price.Properties.Appearance.Options.UseTextOptions = true;
			this.te_price.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.te_price.Properties.Mask.EditMask = "N2";
			this.te_price.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.te_price.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.te_price.Size = new System.Drawing.Size(191, 24);
			this.te_price.TabIndex = 21;
			this.te_price.Validating += new System.ComponentModel.CancelEventHandler(this.te_price_Validating);
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(58, 80);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(106, 23);
			this.radioButton2.TabIndex = 20;
			this.radioButton2.Text = "修改号位";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(58, 34);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(106, 23);
			this.radioButton1.TabIndex = 19;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "修改价格";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// sb_cancel
			// 
			this.sb_cancel.Appearance.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.sb_cancel.Appearance.ForeColor = System.Drawing.Color.Black;
			this.sb_cancel.Appearance.Options.UseBackColor = true;
			this.sb_cancel.Appearance.Options.UseForeColor = true;
			this.sb_cancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.sb_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sb_cancel.Location = new System.Drawing.Point(277, 178);
			this.sb_cancel.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sb_cancel.Name = "sb_cancel";
			this.sb_cancel.Size = new System.Drawing.Size(118, 30);
			this.sb_cancel.TabIndex = 66;
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
			this.sb_ok.Location = new System.Drawing.Point(153, 178);
			this.sb_ok.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sb_ok.Name = "sb_ok";
			this.sb_ok.Size = new System.Drawing.Size(118, 30);
			this.sb_ok.TabIndex = 65;
			this.sb_ok.Text = "确定";
			this.sb_ok.Click += new System.EventHandler(this.sb_ok_Click);
			// 
			// Frm_Bi01
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(453, 237);
			this.Controls.Add(this.sb_cancel);
			this.Controls.Add(this.sb_ok);
			this.Controls.Add(this.radioButton3);
			this.Controls.Add(this.te_bi003);
			this.Controls.Add(this.te_price);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Name = "Frm_Bi01";
			this.Text = "寄存号位编辑";
			this.Load += new System.EventHandler(this.Frm_Bi01_Load);
			((System.ComponentModel.ISupportInitialize)(this.te_bi003.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.te_price.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton radioButton3;
		private DevExpress.XtraEditors.TextEdit te_bi003;
		private DevExpress.XtraEditors.TextEdit te_price;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private DevExpress.XtraEditors.SimpleButton sb_cancel;
		private DevExpress.XtraEditors.SimpleButton sb_ok;
	}
}