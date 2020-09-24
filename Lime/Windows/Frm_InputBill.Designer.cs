namespace Lime.Windows
{
	partial class Frm_InputBill
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
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
			this.sb_cancel = new DevExpress.XtraEditors.SimpleButton();
			this.sb_ok = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Image = null;
			this.labelControl1.AppearanceDisabled.Image = null;
			this.labelControl1.AppearanceHovered.Image = null;
			this.labelControl1.AppearancePressed.Image = null;
			this.labelControl1.Location = new System.Drawing.Point(33, 41);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(57, 19);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "单据号";
			// 
			// textEdit1
			// 
			this.textEdit1.Location = new System.Drawing.Point(112, 39);
			this.textEdit1.Name = "textEdit1";
			this.textEdit1.Size = new System.Drawing.Size(234, 24);
			this.textEdit1.TabIndex = 1;
			// 
			// sb_cancel
			// 
			this.sb_cancel.Appearance.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.sb_cancel.Appearance.ForeColor = System.Drawing.Color.Black;
			this.sb_cancel.Appearance.Options.UseBackColor = true;
			this.sb_cancel.Appearance.Options.UseForeColor = true;
			this.sb_cancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.sb_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sb_cancel.Location = new System.Drawing.Point(381, 55);
			this.sb_cancel.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sb_cancel.Name = "sb_cancel";
			this.sb_cancel.Size = new System.Drawing.Size(129, 30);
			this.sb_cancel.TabIndex = 213;
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
			this.sb_ok.Location = new System.Drawing.Point(381, 19);
			this.sb_ok.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sb_ok.Name = "sb_ok";
			this.sb_ok.Size = new System.Drawing.Size(129, 30);
			this.sb_ok.TabIndex = 212;
			this.sb_ok.Text = "确定";
			this.sb_ok.Click += new System.EventHandler(this.sb_ok_Click);
			// 
			// Frm_InputBill
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(554, 100);
			this.Controls.Add(this.sb_cancel);
			this.Controls.Add(this.sb_ok);
			this.Controls.Add(this.textEdit1);
			this.Controls.Add(this.labelControl1);
			this.Name = "Frm_InputBill";
			this.Text = "输入";
			this.Load += new System.EventHandler(this.Frm_InputBill_Load);
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.TextEdit textEdit1;
		private DevExpress.XtraEditors.SimpleButton sb_cancel;
		private DevExpress.XtraEditors.SimpleButton sb_ok;
	}
}