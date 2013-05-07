namespace Watermarking
{
    partial class AnalysisForm
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
            this.outputImgPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.outputImageLabel = new Watermarking.Controls.RotatingLabel();
            this.SuspendLayout();
            // 
            // outputImgPropertyGrid
            // 
            this.outputImgPropertyGrid.HelpVisible = false;
            this.outputImgPropertyGrid.Location = new System.Drawing.Point(31, 5);
            this.outputImgPropertyGrid.Name = "outputImgPropertyGrid";
            this.outputImgPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.outputImgPropertyGrid.Size = new System.Drawing.Size(264, 168);
            this.outputImgPropertyGrid.TabIndex = 6;
            this.outputImgPropertyGrid.ToolbarVisible = false;
            // 
            // outputImageLabel
            // 
            this.outputImageLabel.Location = new System.Drawing.Point(12, 62);
            this.outputImageLabel.Name = "outputImageLabel";
            this.outputImageLabel.NewText = "Output Image";
            this.outputImageLabel.RotateAngle = -90;
            this.outputImageLabel.Size = new System.Drawing.Size(13, 72);
            this.outputImageLabel.TabIndex = 7;
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 179);
            this.Controls.Add(this.outputImageLabel);
            this.Controls.Add(this.outputImgPropertyGrid);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "AnalysisForm";
            this.Text = "Analysis";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.RotatingLabel outputImageLabel;
        private System.Windows.Forms.PropertyGrid outputImgPropertyGrid;

    }
}