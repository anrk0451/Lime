﻿namespace Lime.Windows
{
	partial class Frm_FinRemoveReason
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
			this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
			this.sb_ok = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// memoEdit1
			// 
			this.memoEdit1.Location = new System.Drawing.Point(0, 3);
			this.memoEdit1.Name = "memoEdit1";
			this.memoEdit1.Size = new System.Drawing.Size(446, 149);
			this.memoEdit1.TabIndex = 74;
			// 
			// sb_ok
			// 
			this.sb_ok.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
			this.sb_ok.Appearance.ForeColor = System.Drawing.Color.White;
			this.sb_ok.Appearance.Options.UseBackColor = true;
			this.sb_ok.Appearance.Options.UseForeColor = true;
			this.sb_ok.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.sb_ok.Location = new System.Drawing.Point(4, 161);
			this.sb_ok.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sb_ok.Name = "sb_ok";
			this.sb_ok.Size = new System.Drawing.Size(440, 30);
			this.sb_ok.TabIndex = 147;
			this.sb_ok.Text = "确定";
			this.sb_ok.Click += new System.EventHandler(this.sb_ok_Click);
			// 
			// Frm_FinRemoveReason
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(452, 203);
			this.Controls.Add(this.sb_ok);
			this.Controls.Add(this.memoEdit1);
			this.Name = "Frm_FinRemoveReason";
			this.Text = "收款作废原因";
			this.Load += new System.EventHandler(this.Frm_FinRemoveReason_Load);
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.MemoEdit memoEdit1;
		private DevExpress.XtraEditors.SimpleButton sb_ok;
	}
}