namespace Watermarking
{
    partial class PropertiesForm
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
            this.hostImgPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.secretImgPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.outputImgPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.hostImageLabel = new Watermarking.Controls.RotatingLabel();
            this.secretImageLabel = new Watermarking.Controls.RotatingLabel();
            this.outputImageLabel = new Watermarking.Controls.RotatingLabel();
            this.SuspendLayout();
            // 
            // hostImgPropertyGrid
            // 
            this.hostImgPropertyGrid.HelpVisible = false;
            this.hostImgPropertyGrid.Location = new System.Drawing.Point(33, 5);
            this.hostImgPropertyGrid.Name = "hostImgPropertyGrid";
            this.hostImgPropertyGrid.Size = new System.Drawing.Size(264, 168);
            this.hostImgPropertyGrid.TabIndex = 0;
            this.hostImgPropertyGrid.ToolbarVisible = false;
            // 
            // secretImgPropertyGrid
            // 
            this.secretImgPropertyGrid.HelpVisible = false;
            this.secretImgPropertyGrid.Location = new System.Drawing.Point(348, 5);
            this.secretImgPropertyGrid.Name = "secretImgPropertyGrid";
            this.secretImgPropertyGrid.Size = new System.Drawing.Size(264, 168);
            this.secretImgPropertyGrid.TabIndex = 1;
            this.secretImgPropertyGrid.ToolbarVisible = false;
            // 
            // outputImgPropertyGrid
            // 
            this.outputImgPropertyGrid.HelpVisible = false;
            this.outputImgPropertyGrid.Location = new System.Drawing.Point(664, 5);
            this.outputImgPropertyGrid.Name = "outputImgPropertyGrid";
            this.outputImgPropertyGrid.Size = new System.Drawing.Size(264, 168);
            this.outputImgPropertyGrid.TabIndex = 2;
            this.outputImgPropertyGrid.ToolbarVisible = false;
            // 
            // hostImageLabel
            // 
            this.hostImageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.hostImageLabel.Location = new System.Drawing.Point(14, 62);
            this.hostImageLabel.Name = "hostImageLabel";
            this.hostImageLabel.NewText = "Host Image";
            this.hostImageLabel.RotateAngle = -90;
            this.hostImageLabel.Size = new System.Drawing.Size(13, 61);
            this.hostImageLabel.TabIndex = 3;
            // 
            // secretImageLabel
            // 
            this.secretImageLabel.Location = new System.Drawing.Point(329, 62);
            this.secretImageLabel.Name = "secretImageLabel";
            this.secretImageLabel.NewText = "Secret Image";
            this.secretImageLabel.RotateAngle = -90;
            this.secretImageLabel.Size = new System.Drawing.Size(13, 70);
            this.secretImageLabel.TabIndex = 4;
            // 
            // outputImageLabel
            // 
            this.outputImageLabel.Location = new System.Drawing.Point(645, 62);
            this.outputImageLabel.Name = "outputImageLabel";
            this.outputImageLabel.NewText = "Output Image";
            this.outputImageLabel.RotateAngle = -90;
            this.outputImageLabel.Size = new System.Drawing.Size(13, 72);
            this.outputImageLabel.TabIndex = 5;
            // 
            // PropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 179);
            this.Controls.Add(this.outputImageLabel);
            this.Controls.Add(this.secretImageLabel);
            this.Controls.Add(this.hostImageLabel);
            this.Controls.Add(this.outputImgPropertyGrid);
            this.Controls.Add(this.secretImgPropertyGrid);
            this.Controls.Add(this.hostImgPropertyGrid);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "PropertiesForm";
            this.Text = "Properties";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid hostImgPropertyGrid;
        private System.Windows.Forms.PropertyGrid secretImgPropertyGrid;
        private System.Windows.Forms.PropertyGrid outputImgPropertyGrid;
        private Watermarking.Controls.RotatingLabel hostImageLabel;
        private Watermarking.Controls.RotatingLabel secretImageLabel;
        private Watermarking.Controls.RotatingLabel outputImageLabel;
    }
}