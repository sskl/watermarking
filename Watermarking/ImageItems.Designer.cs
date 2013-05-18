namespace Watermarking
{
    partial class ImageItems
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
            this.hostImageBox = new System.Windows.Forms.PictureBox();
            this.secretImageBox = new System.Windows.Forms.PictureBox();
            this.outputImageBox = new System.Windows.Forms.PictureBox();
            this.hostImageLabel = new System.Windows.Forms.Label();
            this.secretImageLabel = new System.Windows.Forms.Label();
            this.outputImageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hostImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secretImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // hostImageBox
            // 
            this.hostImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hostImageBox.Location = new System.Drawing.Point(0, 0);
            this.hostImageBox.Margin = new System.Windows.Forms.Padding(0);
            this.hostImageBox.MinimumSize = new System.Drawing.Size(200, 200);
            this.hostImageBox.Name = "hostImageBox";
            this.hostImageBox.Size = new System.Drawing.Size(200, 200);
            this.hostImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hostImageBox.TabIndex = 0;
            this.hostImageBox.TabStop = false;
            // 
            // secretImageBox
            // 
            this.secretImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secretImageBox.Location = new System.Drawing.Point(0, 0);
            this.secretImageBox.Margin = new System.Windows.Forms.Padding(0);
            this.secretImageBox.MinimumSize = new System.Drawing.Size(200, 200);
            this.secretImageBox.Name = "secretImageBox";
            this.secretImageBox.Size = new System.Drawing.Size(200, 200);
            this.secretImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.secretImageBox.TabIndex = 1;
            this.secretImageBox.TabStop = false;
            // 
            // outputImageBox
            // 
            this.outputImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputImageBox.Location = new System.Drawing.Point(0, 0);
            this.outputImageBox.Margin = new System.Windows.Forms.Padding(0);
            this.outputImageBox.MinimumSize = new System.Drawing.Size(200, 200);
            this.outputImageBox.Name = "outputImageBox";
            this.outputImageBox.Size = new System.Drawing.Size(200, 200);
            this.outputImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.outputImageBox.TabIndex = 2;
            this.outputImageBox.TabStop = false;
            // 
            // hostImageLabel
            // 
            this.hostImageLabel.Location = new System.Drawing.Point(0, 0);
            this.hostImageLabel.Name = "hostImageLabel";
            this.hostImageLabel.Size = new System.Drawing.Size(80, 15);
            this.hostImageLabel.TabIndex = 3;
            this.hostImageLabel.Text = "Host Image";
            this.hostImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // secretImageLabel
            // 
            this.secretImageLabel.AutoSize = true;
            this.secretImageLabel.Location = new System.Drawing.Point(0, 0);
            this.secretImageLabel.Name = "secretImageLabel";
            this.secretImageLabel.Size = new System.Drawing.Size(70, 13);
            this.secretImageLabel.TabIndex = 4;
            this.secretImageLabel.Text = "Secret Image";
            this.secretImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // outputImageLabel
            // 
            this.outputImageLabel.AutoSize = true;
            this.outputImageLabel.Location = new System.Drawing.Point(0, 0);
            this.outputImageLabel.Name = "outputImageLabel";
            this.outputImageLabel.Size = new System.Drawing.Size(71, 13);
            this.outputImageLabel.TabIndex = 4;
            this.outputImageLabel.Text = "Output Image";
            this.outputImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImageItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(674, 543);
            this.Controls.Add(this.hostImageLabel);
            this.Controls.Add(this.secretImageLabel);
            this.Controls.Add(this.outputImageLabel);
            this.Controls.Add(this.outputImageBox);
            this.Controls.Add(this.secretImageBox);
            this.Controls.Add(this.hostImageBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "ImageItems";
            this.Text = "ImageItems";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.ImageItems_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.hostImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secretImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox hostImageBox;
        private System.Windows.Forms.PictureBox secretImageBox;
        private System.Windows.Forms.PictureBox outputImageBox;
        private System.Windows.Forms.Label hostImageLabel;
        private System.Windows.Forms.Label secretImageLabel;
        private System.Windows.Forms.Label outputImageLabel;
    }
}