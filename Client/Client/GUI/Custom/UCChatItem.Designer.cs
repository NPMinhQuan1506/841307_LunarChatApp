namespace Client.GUI.Custom
{
    partial class UCChatItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnChat = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtChat = new DevExpress.XtraEditors.TextEdit();
            this.pnMsg = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lbName = new DevExpress.XtraEditors.LabelControl();
            this.peAvatar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnChat)).BeginInit();
            this.pnChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtChat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnMsg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnChat
            // 
            this.pnChat.Appearance.BackColor = System.Drawing.Color.White;
            this.pnChat.Appearance.Options.UseBackColor = true;
            this.pnChat.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnChat.Controls.Add(this.simpleButton1);
            this.pnChat.Controls.Add(this.txtChat);
            this.pnChat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnChat.Location = new System.Drawing.Point(0, 628);
            this.pnChat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnChat.Name = "pnChat";
            this.pnChat.Size = new System.Drawing.Size(909, 130);
            this.pnChat.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(718, 17);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(83, 93);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Gửi";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtChat
            // 
            this.txtChat.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtChat.Location = new System.Drawing.Point(2, 2);
            this.txtChat.Name = "txtChat";
            this.txtChat.Properties.AutoHeight = false;
            this.txtChat.Size = new System.Drawing.Size(685, 126);
            this.txtChat.TabIndex = 0;
            this.txtChat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChat_KeyPress);
            // 
            // pnMsg
            // 
            this.pnMsg.AllowTouchScroll = true;
            this.pnMsg.Appearance.BackColor = System.Drawing.Color.Gray;
            this.pnMsg.Appearance.Options.UseBackColor = true;
            this.pnMsg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMsg.InvertTouchScroll = true;
            this.pnMsg.Location = new System.Drawing.Point(0, 112);
            this.pnMsg.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnMsg.Name = "pnMsg";
            this.pnMsg.Size = new System.Drawing.Size(909, 516);
            this.pnMsg.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.lbName);
            this.panelControl1.Controls.Add(this.peAvatar);
            this.panelControl1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.SkinMaskColor = System.Drawing.Color.FloralWhite;
            this.panelControl1.LookAndFeel.SkinName = "The Bezier";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(909, 112);
            this.panelControl1.TabIndex = 0;
            // 
            // lbName
            // 
            this.lbName.Location = new System.Drawing.Point(204, 22);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(143, 32);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "labelControl1";
            // 
            // peAvatar
            // 
            this.peAvatar.Location = new System.Drawing.Point(71, 22);
            this.peAvatar.Name = "peAvatar";
            this.peAvatar.Size = new System.Drawing.Size(100, 84);
            this.peAvatar.TabIndex = 0;
            this.peAvatar.TabStop = false;
            // 
            // UCChatItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnMsg);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.pnChat);
            this.Name = "UCChatItem";
            this.Size = new System.Drawing.Size(909, 758);
            ((System.ComponentModel.ISupportInitialize)(this.pnChat)).EndInit();
            this.pnChat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtChat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnMsg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnChat;
        private DevExpress.XtraEditors.PanelControl pnMsg;
        private DevExpress.XtraEditors.TextEdit txtChat;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lbName;
        private System.Windows.Forms.PictureBox peAvatar;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}
