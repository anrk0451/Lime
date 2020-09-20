namespace Lime.Windows
{
	partial class Frm_SetFireTime
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
			this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.sb_ok = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// dateEdit1
			// 
			this.dateEdit1.EditValue = null;
			this.dateEdit1.Location = new System.Drawing.Point(132, 38);
			this.dateEdit1.Name = "dateEdit1";
			this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit1.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
			this.dateEdit1.Properties.Mask.EditMask = "g";
			this.dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.dateEdit1.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
			this.dateEdit1.Size = new System.Drawing.Size(188, 24);
			this.dateEdit1.TabIndex = 3;
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Image = null;
			this.labelControl1.AppearanceDisabled.Image = null;
			this.labelControl1.AppearanceHovered.Image = null;
			this.labelControl1.AppearancePressed.Image = null;
			this.labelControl1.Location = new System.Drawing.Point(41, 40);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(86, 19);
			this.labelControl1.TabIndex = 2;
			this.labelControl1.Text = "火化时间:";
			// 
			// sb_ok
			// 
			this.sb_ok.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
			this.sb_ok.Appearance.ForeColor = System.Drawing.Color.White;
			this.sb_ok.Appearance.Options.UseBackColor = true;
			this.sb_ok.Appearance.Options.UseForeColor = true;
			this.sb_ok.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.sb_ok.Location = new System.Drawing.Point(397, 36);
			this.sb_ok.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sb_ok.Name = "sb_ok";
			this.sb_ok.Size = new System.Drawing.Size(108, 30);
			this.sb_ok.TabIndex = 140;
			this.sb_ok.Text = "确定";
			this.sb_ok.Click += new System.EventHandler(this.sb_ok_Click);
			// 
			// Frm_SetFireTime
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 95);
			this.Controls.Add(this.sb_ok);
			this.Controls.Add(this.dateEdit1);
			this.Controls.Add(this.labelControl1);
			this.Name = "Frm_SetFireTime";
			this.Text = "设置";
			this.Load += new System.EventHandler(this.Frm_SetFireTime_Load);
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.DateEdit dateEdit1;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.SimpleButton sb_ok;
	}
}