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
            this.PSNRDataGridView = new System.Windows.Forms.DataGridView();
            this.btnCopyDataGridView = new System.Windows.Forms.Button();
            this.outputImageLabel = new Watermarking.Controls.RotatingLabel();
            ((System.ComponentModel.ISupportInitialize)(this.PSNRDataGridView)).BeginInit();
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
            // PSNRDataGridView
            // 
            this.PSNRDataGridView.AllowUserToAddRows = false;
            this.PSNRDataGridView.AllowUserToDeleteRows = false;
            this.PSNRDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PSNRDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.PSNRDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.PSNRDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PSNRDataGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.PSNRDataGridView.Location = new System.Drawing.Point(302, 5);
            this.PSNRDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.PSNRDataGridView.Name = "PSNRDataGridView";
            this.PSNRDataGridView.RowHeadersVisible = false;
            this.PSNRDataGridView.RowHeadersWidth = 10;
            this.PSNRDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PSNRDataGridView.Size = new System.Drawing.Size(371, 168);
            this.PSNRDataGridView.TabIndex = 8;
            // 
            // btnCopyDataGridView
            // 
            this.btnCopyDataGridView.Location = new System.Drawing.Point(677, 5);
            this.btnCopyDataGridView.Name = "btnCopyDataGridView";
            this.btnCopyDataGridView.Size = new System.Drawing.Size(112, 23);
            this.btnCopyDataGridView.TabIndex = 9;
            this.btnCopyDataGridView.Text = "Copy PSNR Table";
            this.btnCopyDataGridView.UseVisualStyleBackColor = true;
            this.btnCopyDataGridView.Click += new System.EventHandler(this.btnCopyDataGridView_Click);
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
            this.ClientSize = new System.Drawing.Size(892, 179);
            this.Controls.Add(this.btnCopyDataGridView);
            this.Controls.Add(this.PSNRDataGridView);
            this.Controls.Add(this.outputImageLabel);
            this.Controls.Add(this.outputImgPropertyGrid);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "AnalysisForm";
            this.Text = "Analysis";
            ((System.ComponentModel.ISupportInitialize)(this.PSNRDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.RotatingLabel outputImageLabel;
        private System.Windows.Forms.PropertyGrid outputImgPropertyGrid;
        private System.Windows.Forms.DataGridView PSNRDataGridView;
        private System.Windows.Forms.Button btnCopyDataGridView;

    }
}