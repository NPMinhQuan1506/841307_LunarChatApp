namespace Client.GUI.Custom
{
    partial class UCConservation
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
            this.lbName = new System.Windows.Forms.Label();
            this.lbContent = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pnGrid = new DevExpress.XtraEditors.PanelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnGrid)).BeginInit();
            this.pnGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.LightGray;
            this.lbName.Location = new System.Drawing.Point(65, 5);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(53, 20);
            this.lbName.TabIndex = 5;
            this.lbName.Text = "label2";
            // 
            // lbContent
            // 
            this.lbContent.AutoSize = true;
            this.lbContent.BackColor = System.Drawing.Color.Transparent;
            this.lbContent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbContent.Location = new System.Drawing.Point(65, 30);
            this.lbContent.Name = "lbContent";
            this.lbContent.Size = new System.Drawing.Size(68, 28);
            this.lbContent.TabIndex = 4;
            this.lbContent.Text = "Name";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.ForeColor = System.Drawing.Color.LightGray;
            this.lbTime.Location = new System.Drawing.Point(277, 5);
            this.lbTime.Name = "lbTime";
            this.lbTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbTime.Size = new System.Drawing.Size(44, 20);
            this.lbTime.TabIndex = 6;
            this.lbTime.Text = "09:00";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl1.Controls.Add(this.pnGrid);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(335, 81);
            this.panelControl1.TabIndex = 7;
            // 
            // pnGrid
            // 
            this.pnGrid.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(88)))));
            this.pnGrid.Appearance.Options.UseBackColor = true;
            this.pnGrid.Controls.Add(this.lbContent);
            this.pnGrid.Controls.Add(this.lbName);
            this.pnGrid.Controls.Add(this.pictureBox1);
            this.pnGrid.Controls.Add(this.lbTime);
            this.pnGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGrid.Location = new System.Drawing.Point(2, 2);
            this.pnGrid.Name = "pnGrid";
            this.pnGrid.Size = new System.Drawing.Size(331, 77);
            this.pnGrid.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // UCConservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.panelControl1);
            this.Name = "UCConservation";
            this.Size = new System.Drawing.Size(335, 81);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnGrid)).EndInit();
            this.pnGrid.ResumeLayout(false);
            this.pnGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbContent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbTime;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraEditors.PanelControl pnGrid;
    }
}
