namespace Server.GUI.Home
{
    partial class ctrHome
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrHome));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnHeader = new DevExpress.XtraEditors.PanelControl();
            this.txtStatus = new DevExpress.XtraEditors.LabelControl();
            this.txtPort = new DevExpress.XtraEditors.TextEdit();
            this.btnOpen = new DevExpress.XtraEditors.ButtonEdit();
            this.txtIp = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnHeader)).BeginInit();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(214)))), ((int)(((byte)(216)))));
            this.pnHeader.Appearance.Options.UseBackColor = true;
            this.pnHeader.Controls.Add(this.richTextBox1);
            this.pnHeader.Controls.Add(this.txtStatus);
            this.pnHeader.Controls.Add(this.txtPort);
            this.pnHeader.Controls.Add(this.btnOpen);
            this.pnHeader.Controls.Add(this.txtIp);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(214)))), ((int)(((byte)(216)))));
            this.pnHeader.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnHeader.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(532, 765);
            this.pnHeader.TabIndex = 1;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(152, 190);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(106, 32);
            this.txtStatus.TabIndex = 53;
            this.txtStatus.Text = "Trạng thái";
            // 
            // txtPort
            // 
            this.txtPort.EditValue = "Port";
            this.txtPort.Location = new System.Drawing.Point(396, 260);
            this.txtPort.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(202)))), ((int)(((byte)(203)))));
            this.txtPort.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.txtPort.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPort.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(142)))), ((int)(((byte)(144)))));
            this.txtPort.Properties.Appearance.Options.UseBackColor = true;
            this.txtPort.Properties.Appearance.Options.UseBorderColor = true;
            this.txtPort.Properties.Appearance.Options.UseFont = true;
            this.txtPort.Properties.Appearance.Options.UseForeColor = true;
            this.txtPort.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPort.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.txtPort.Properties.AutoHeight = false;
            this.txtPort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtPort.Properties.NullText = "Nhập Thông Tin Tìm Kiếm";
            this.txtPort.Properties.Padding = new System.Windows.Forms.Padding(0, 0, 41, 0);
            this.txtPort.Size = new System.Drawing.Size(110, 47);
            this.txtPort.TabIndex = 52;
            // 
            // btnOpen
            // 
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.EditValue = "Mở Server";
            this.btnOpen.Location = new System.Drawing.Point(152, 110);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(202)))), ((int)(((byte)(203)))));
            this.btnOpen.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.btnOpen.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnOpen.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.btnOpen.Properties.Appearance.Options.UseBackColor = true;
            this.btnOpen.Properties.Appearance.Options.UseBorderColor = true;
            this.btnOpen.Properties.Appearance.Options.UseFont = true;
            this.btnOpen.Properties.Appearance.Options.UseForeColor = true;
            this.btnOpen.Properties.AutoHeight = false;
            this.btnOpen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            editorButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions2.SvgImage")));
            this.btnOpen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, true, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnOpen.Properties.ReadOnly = true;
            this.btnOpen.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnOpen.Properties.UseReadOnlyAppearance = false;
            this.btnOpen.Size = new System.Drawing.Size(168, 45);
            this.btnOpen.TabIndex = 51;
            this.btnOpen.ToolTipAnchor = DevExpress.Utils.ToolTipAnchor.Cursor;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtIp
            // 
            this.txtIp.EditValue = "Ip Address";
            this.txtIp.Location = new System.Drawing.Point(39, 260);
            this.txtIp.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtIp.Name = "txtIp";
            this.txtIp.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(202)))), ((int)(((byte)(203)))));
            this.txtIp.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.txtIp.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIp.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(142)))), ((int)(((byte)(144)))));
            this.txtIp.Properties.Appearance.Options.UseBackColor = true;
            this.txtIp.Properties.Appearance.Options.UseBorderColor = true;
            this.txtIp.Properties.Appearance.Options.UseFont = true;
            this.txtIp.Properties.Appearance.Options.UseForeColor = true;
            this.txtIp.Properties.Appearance.Options.UseTextOptions = true;
            this.txtIp.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.txtIp.Properties.AutoHeight = false;
            this.txtIp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtIp.Properties.NullText = "Nhập Thông Tin Tìm Kiếm";
            this.txtIp.Properties.Padding = new System.Windows.Forms.Padding(0, 0, 41, 0);
            this.txtIp.Size = new System.Drawing.Size(341, 47);
            this.txtIp.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(214)))), ((int)(((byte)(216)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(532, 0);
            this.panelControl1.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(214)))), ((int)(((byte)(216)))));
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(781, 765);
            this.panelControl1.TabIndex = 53;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(104, 376);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 96);
            this.richTextBox1.TabIndex = 54;
            this.richTextBox1.Text = "";
            // 
            // ctrHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.pnHeader);
            this.Name = "ctrHome";
            this.Size = new System.Drawing.Size(1313, 765);
            ((System.ComponentModel.ISupportInitialize)(this.pnHeader)).EndInit();
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnHeader;
        private DevExpress.XtraEditors.TextEdit txtIp;
        private DevExpress.XtraEditors.TextEdit txtPort;
        private DevExpress.XtraEditors.ButtonEdit btnOpen;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl txtStatus;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
