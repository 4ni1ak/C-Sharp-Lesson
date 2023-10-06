namespace ImgBx_Presentation
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lbAboveImage = new System.Windows.Forms.Label();
            this.pbxFrog = new System.Windows.Forms.PictureBox();
            this.lbBelowImage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFrog)).BeginInit();
            this.SuspendLayout();
            // 
            // lbAboveImage
            // 
            this.lbAboveImage.AutoSize = true;
            this.lbAboveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbAboveImage.Location = new System.Drawing.Point(269, 18);
            this.lbAboveImage.Name = "lbAboveImage";
            this.lbAboveImage.Size = new System.Drawing.Size(226, 39);
            this.lbAboveImage.TabIndex = 0;
            this.lbAboveImage.Text = "This is a label";
            // 
            // pbxFrog
            // 
            this.pbxFrog.Image = ((System.Drawing.Image)(resources.GetObject("pbxFrog.Image")));
            this.pbxFrog.Location = new System.Drawing.Point(200, 60);
            this.pbxFrog.Name = "pbxFrog";
            this.pbxFrog.Size = new System.Drawing.Size(538, 408);
            this.pbxFrog.TabIndex = 1;
            this.pbxFrog.TabStop = false;
            // 
            // lbBelowImage
            // 
            this.lbBelowImage.AutoSize = true;
            this.lbBelowImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbBelowImage.Location = new System.Drawing.Point(254, 471);
            this.lbBelowImage.Name = "lbBelowImage";
            this.lbBelowImage.Size = new System.Drawing.Size(309, 39);
            this.lbBelowImage.TabIndex = 2;
            this.lbBelowImage.Text = "Well done good job";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 521);
            this.Controls.Add(this.lbBelowImage);
            this.Controls.Add(this.pbxFrog);
            this.Controls.Add(this.lbAboveImage);
            this.Name = "frmMain";
            this.Text = "Lab1";
            ((System.ComponentModel.ISupportInitialize)(this.pbxFrog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbAboveImage;
        private System.Windows.Forms.PictureBox pbxFrog;
        private System.Windows.Forms.Label lbBelowImage;
    }
}

