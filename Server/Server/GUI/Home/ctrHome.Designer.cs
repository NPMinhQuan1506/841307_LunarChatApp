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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrHome));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnHeader = new DevExpress.XtraEditors.PanelControl();
            this.txtStatus = new DevExpress.XtraEditors.LabelControl();
            this.txtPort = new DevExpress.XtraEditors.TextEdit();
            this.btnOpen = new DevExpress.XtraEditors.ButtonEdit();
            this.txtIp = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tbRevenue = new System.Windows.Forms.TabControl();
            this.tpOverview = new System.Windows.Forms.TabPage();
            this.tpDetail = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.pnHeader)).BeginInit();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.tbRevenue.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(214)))), ((int)(((byte)(216)))));
            this.pnHeader.Appearance.Options.UseBackColor = true;
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
            this.pnHeader.Size = new System.Drawing.Size(402, 765);
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
            this.txtPort.Location = new System.Drawing.Point(275, 259);
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
            this.txtPort.EditValueChanged += new System.EventHandler(this.txtPort_EditValueChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.EditValue = "Mở Server";
            this.btnOpen.Location = new System.Drawing.Point(131, 52);
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
            editorButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions1.SvgImage")));
            this.btnOpen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, true, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
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
            this.txtIp.Size = new System.Drawing.Size(219, 47);
            this.txtIp.TabIndex = 0;
            this.txtIp.EditValueChanged += new System.EventHandler(this.txtIp_EditValueChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(214)))), ((int)(((byte)(216)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.tbRevenue);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(402, 0);
            this.panelControl1.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(214)))), ((int)(((byte)(216)))));
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(911, 765);
            this.panelControl1.TabIndex = 53;
            // 
            // tbRevenue
            // 
            this.tbRevenue.Controls.Add(this.tpOverview);
            this.tbRevenue.Controls.Add(this.tpDetail);
            this.tbRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRevenue.Location = new System.Drawing.Point(2, 2);
            this.tbRevenue.Margin = new System.Windows.Forms.Padding(4);
            this.tbRevenue.Name = "tbRevenue";
            this.tbRevenue.SelectedIndex = 0;
            this.tbRevenue.Size = new System.Drawing.Size(907, 761);
            this.tbRevenue.TabIndex = 1;
            this.tbRevenue.SelectedIndexChanged += new System.EventHandler(this.tbRevenue_SelectedIndexChanged);
            // 
            // tpOverview
            // 
            this.tpOverview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(220)))), ((int)(((byte)(223)))));
            this.tpOverview.Location = new System.Drawing.Point(4, 41);
            this.tpOverview.Margin = new System.Windows.Forms.Padding(4);
            this.tpOverview.Name = "tpOverview";
            this.tpOverview.Padding = new System.Windows.Forms.Padding(4);
            this.tpOverview.Size = new System.Drawing.Size(899, 716);
            this.tpOverview.TabIndex = 0;
            this.tpOverview.Text = "Lịch sử";
            // 
            // tpDetail
            // 
            this.tpDetail.Location = new System.Drawing.Point(4, 41);
            this.tpDetail.Margin = new System.Windows.Forms.Padding(4);
            this.tpDetail.Name = "tpDetail";
            this.tpDetail.Padding = new System.Windows.Forms.Padding(4);
            this.tpDetail.Size = new System.Drawing.Size(899, 716);
            this.tpDetail.TabIndex = 1;
            this.tpDetail.Text = "Trạng thái";
            this.tpDetail.UseVisualStyleBackColor = true;
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
            this.panelControl1.ResumeLayout(false);
            this.tbRevenue.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnHeader;
        private DevExpress.XtraEditors.TextEdit txtIp;
        private DevExpress.XtraEditors.TextEdit txtPort;
        private DevExpress.XtraEditors.ButtonEdit btnOpen;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl txtStatus;
        private System.Windows.Forms.TabControl tbRevenue;
        private System.Windows.Forms.TabPage tpOverview;
        private System.Windows.Forms.TabPage tpDetail;
    }
}
