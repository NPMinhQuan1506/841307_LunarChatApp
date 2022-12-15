namespace Client.GUI.Custom
{
    partial class UCYourMessage
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
            this.txtSender = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.pbAvatar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSender
            // 
            this.txtSender.AutoSize = true;
            this.txtSender.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSender.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSender.ForeColor = System.Drawing.Color.Black;
            this.txtSender.Location = new System.Drawing.Point(82, 50);
            this.txtSender.Name = "txtSender";
            this.txtSender.Size = new System.Drawing.Size(55, 22);
            this.txtSender.TabIndex = 9;
            this.txtSender.Text = "label2";
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.Black;
            this.labelName.Location = new System.Drawing.Point(82, 17);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(477, 23);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "label1";
            // 
            // pbAvatar
            // 
            this.pbAvatar.Location = new System.Drawing.Point(12, 17);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.Size = new System.Drawing.Size(54, 53);
            this.pbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAvatar.TabIndex = 7;
            this.pbAvatar.TabStop = false;
            // 
            // UCYourMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.txtSender);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.pbAvatar);
            this.Name = "UCYourMessage";
            this.Size = new System.Drawing.Size(582, 104);
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtSender;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.PictureBox pbAvatar;
    }
}
