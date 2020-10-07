namespace Lime.Windows
{
	partial class Frm_RegMove
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
			this.txtedit_rt003 = new DevExpress.XtraEditors.TextEdit();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.be_newposition = new DevExpress.XtraEditors.ButtonEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.txtEdit_rc003 = new DevExpress.XtraEditors.TextEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.txtEdit_rc109 = new DevExpress.XtraEditors.TextEdit();
			this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
			this.txtEdit_rc001 = new DevExpress.XtraEditors.TextEdit();
			this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
			this.be_position = new DevExpress.XtraEditors.ButtonEdit();
			this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
			this.sb_cancel = new DevExpress.XtraEditors.SimpleButton();
			this.sb_ok = new DevExpress.XtraEditors.SimpleButton();
			this.unitOfWork1 = new DevExpress.Xpo.UnitOfWork(this.components);
			((System.ComponentModel.ISupportInitialize)(this.txtedit_rt003.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.be_newposition.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdit_rc003.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdit_rc109.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdit_rc001.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.be_position.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).BeginInit();
			this.SuspendLayout();
			// 
			// txtedit_rt003
			// 
			this.txtedit_rt003.Location = new System.Drawing.Point(161, 206);
			this.txtedit_rt003.Name = "txtedit_rt003";
			this.txtedit_rt003.Size = new System.Drawing.Size(338, 24);
			this.txtedit_rt003.TabIndex = 175;
			// 
			// labelControl3
			// 
			this.labelControl3.Location = new System.Drawing.Point(49, 206);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(76, 19);
			this.labelControl3.TabIndex = 174;
			this.labelControl3.Text = "变更原因";
			// 
			// be_newposition
			// 
			this.be_newposition.Location = new System.Drawing.Point(161, 156);
			this.be_newposition.Name = "be_newposition";
			this.be_newposition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.be_newposition.Properties.ReadOnly = true;
			this.be_newposition.Size = new System.Drawing.Size(338, 24);
			this.be_newposition.TabIndex = 173;
			this.be_newposition.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.be_newposition_ButtonClick);
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(49, 159);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(95, 19);
			this.labelControl2.TabIndex = 172;
			this.labelControl2.Text = "变更后位置";
			// 
			// txtEdit_rc003
			// 
			this.txtEdit_rc003.Enabled = false;
			this.txtEdit_rc003.Location = new System.Drawing.Point(161, 66);
			this.txtEdit_rc003.Name = "txtEdit_rc003";
			this.txtEdit_rc003.Size = new System.Drawing.Size(122, 24);
			this.txtEdit_rc003.TabIndex = 171;
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(49, 68);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(76, 19);
			this.labelControl1.TabIndex = 170;
			this.labelControl1.Text = "逝者姓名";
			// 
			// txtEdit_rc109
			// 
			this.txtEdit_rc109.Enabled = false;
			this.txtEdit_rc109.Location = new System.Drawing.Point(377, 25);
			this.txtEdit_rc109.Name = "txtEdit_rc109";
			this.txtEdit_rc109.Size = new System.Drawing.Size(122, 24);
			this.txtEdit_rc109.TabIndex = 169;
			// 
			// labelControl13
			// 
			this.labelControl13.Location = new System.Drawing.Point(295, 28);
			this.labelControl13.Name = "labelControl13";
			this.labelControl13.Size = new System.Drawing.Size(76, 19);
			this.labelControl13.TabIndex = 168;
			this.labelControl13.Text = "寄存证号";
			// 
			// txtEdit_rc001
			// 
			this.txtEdit_rc001.Enabled = false;
			this.txtEdit_rc001.Location = new System.Drawing.Point(161, 25);
			this.txtEdit_rc001.Name = "txtEdit_rc001";
			this.txtEdit_rc001.Size = new System.Drawing.Size(122, 24);
			this.txtEdit_rc001.TabIndex = 167;
			// 
			// labelControl8
			// 
			this.labelControl8.Location = new System.Drawing.Point(49, 28);
			this.labelControl8.Name = "labelControl8";
			this.labelControl8.Size = new System.Drawing.Size(76, 19);
			this.labelControl8.TabIndex = 166;
			this.labelControl8.Text = "逝者编号";
			// 
			// be_position
			// 
			this.be_position.Enabled = false;
			this.be_position.Location = new System.Drawing.Point(161, 109);
			this.be_position.Name = "be_position";
			this.be_position.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.be_position.Properties.ReadOnly = true;
			this.be_position.Size = new System.Drawing.Size(338, 24);
			this.be_position.TabIndex = 165;
			// 
			// labelControl16
			// 
			this.labelControl16.Location = new System.Drawing.Point(49, 111);
			this.labelControl16.Name = "labelControl16";
			this.labelControl16.Size = new System.Drawing.Size(95, 19);
			this.labelControl16.TabIndex = 164;
			this.labelControl16.Text = "现寄存位置";
			// 
			// sb_cancel
			// 
			this.sb_cancel.Appearance.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.sb_cancel.Appearance.ForeColor = System.Drawing.Color.Black;
			this.sb_cancel.Appearance.Options.UseBackColor = true;
			this.sb_cancel.Appearance.Options.UseForeColor = true;
			this.sb_cancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.sb_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.sb_cancel.Location = new System.Drawing.Point(521, 66);
			this.sb_cancel.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sb_cancel.Name = "sb_cancel";
			this.sb_cancel.Size = new System.Drawing.Size(118, 30);
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
			this.sb_ok.Location = new System.Drawing.Point(521, 26);
			this.sb_ok.LookAndFeel.UseDefaultLookAndFeel = false;
			this.sb_ok.Name = "sb_ok";
			this.sb_ok.Size = new System.Drawing.Size(118, 30);
			this.sb_ok.TabIndex = 212;
			this.sb_ok.Text = "确定";
			this.sb_ok.Click += new System.EventHandler(this.sb_ok_Click);
			// 
			// Frm_RegMove
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(672, 251);
			this.Controls.Add(this.sb_cancel);
			this.Controls.Add(this.sb_ok);
			this.Controls.Add(this.txtedit_rt003);
			this.Controls.Add(this.labelControl3);
			this.Controls.Add(this.be_newposition);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.txtEdit_rc003);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.txtEdit_rc109);
			this.Controls.Add(this.labelControl13);
			this.Controls.Add(this.txtEdit_rc001);
			this.Controls.Add(this.labelControl8);
			this.Controls.Add(this.be_position);
			this.Controls.Add(this.labelControl16);
			this.Name = "Frm_RegMove";
			this.Text = "寄存位置变更";
			this.Load += new System.EventHandler(this.Frm_RegMove_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtedit_rt003.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.be_newposition.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdit_rc003.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdit_rc109.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdit_rc001.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.be_position.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.unitOfWork1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.TextEdit txtedit_rt003;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.ButtonEdit be_newposition;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.TextEdit txtEdit_rc003;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.TextEdit txtEdit_rc109;
		private DevExpress.XtraEditors.LabelControl labelControl13;
		private DevExpress.XtraEditors.TextEdit txtEdit_rc001;
		private DevExpress.XtraEditors.LabelControl labelControl8;
		private DevExpress.XtraEditors.ButtonEdit be_position;
		private DevExpress.XtraEditors.LabelControl labelControl16;
		private DevExpress.XtraEditors.SimpleButton sb_cancel;
		private DevExpress.XtraEditors.SimpleButton sb_ok;
		private DevExpress.Xpo.UnitOfWork unitOfWork1;
	}
}