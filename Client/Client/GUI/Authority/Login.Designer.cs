namespace Client.GUI.Authority
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.lbClose = new DevExpress.XtraEditors.LabelControl();
            this.btnLogin = new System.Windows.Forms.Button();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.vali = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.txtAccount = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.lbRegister = new DevExpress.XtraEditors.LabelControl();
            this.pnHeader = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.vali)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnHeader)).BeginInit();
            this.pnHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbClose
            // 
            this.lbClose.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lbClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.lbClose.Appearance.Options.UseFont = true;
            this.lbClose.Appearance.Options.UseForeColor = true;
            this.lbClose.Appearance.Options.UseTextOptions = true;
            this.lbClose.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbClose.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbClose.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbClose.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lbClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lbClose.ImageOptions.Image")));
            this.lbClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbClose.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.lbClose.Location = new System.Drawing.Point(474, 6);
            this.lbClose.Margin = new System.Windows.Forms.Padding(4);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(35, 38);
            this.lbClose.TabIndex = 0;
            this.lbClose.Click += new System.EventHandler(this.lbClose_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Location = new System.Drawing.Point(122, 528);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(222, 58);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(34, 256);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(132, 28);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Tên Tài Khoản";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(34, 357);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(92, 28);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Mật Khẩu";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(34, 291);
            this.txtAccount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.txtAccount.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAccount.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtAccount.Properties.Appearance.Options.UseBackColor = true;
            this.txtAccount.Properties.Appearance.Options.UseFont = true;
            this.txtAccount.Properties.Appearance.Options.UseForeColor = true;
            this.txtAccount.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAccount.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.txtAccount.Properties.AutoHeight = false;
            this.txtAccount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtAccount.Size = new System.Drawing.Size(420, 49);
            this.txtAccount.TabIndex = 10;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(34, 408);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPassword.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Properties.Appearance.Options.UseBackColor = true;
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.Appearance.Options.UseForeColor = true;
            this.txtPassword.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPassword.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.txtPassword.Properties.AutoHeight = false;
            this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(420, 49);
            this.txtPassword.TabIndex = 12;
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyUp);
            // 
            // lbRegister
            // 
            this.lbRegister.Appearance.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRegister.Appearance.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.lbRegister.Appearance.Options.UseFont = true;
            this.lbRegister.Appearance.Options.UseForeColor = true;
            this.lbRegister.Location = new System.Drawing.Point(44, 486);
            this.lbRegister.Name = "lbRegister";
            this.lbRegister.Size = new System.Drawing.Size(224, 31);
            this.lbRegister.TabIndex = 13;
            this.lbRegister.Text = "Bạn chưa có tài khoản";
            // 
            // pnHeader
            // 
            this.pnHeader.Controls.Add(this.lbClose);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(522, 57);
            this.pnHeader.TabIndex = 14;
            this.pnHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnHeader_MouseDown);
            this.pnHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnHeader_MouseMove);
            this.pnHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnHeader_MouseUp);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(522, 651);
            this.Controls.Add(this.pnHeader);
            this.Controls.Add(this.lbRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Text = "Login";
            this.Shown += new System.EventHandler(this.Login_Shown);
            this.Resize += new System.EventHandler(this.Login_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.vali)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnHeader)).EndInit();
            this.pnHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl lbClose;
        private System.Windows.Forms.Button btnLogin;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtAccount;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider vali;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl lbRegister;
        private DevExpress.XtraEditors.PanelControl pnHeader;
    }
}