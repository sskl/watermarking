namespace Watermarking
{
    partial class HistogramForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.hostImageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.hostImageChannelLabel = new System.Windows.Forms.Label();
            this.hostImageComboBox = new System.Windows.Forms.ComboBox();
            this.secretImageComboBox = new System.Windows.Forms.ComboBox();
            this.secretImageChannelLabel = new System.Windows.Forms.Label();
            this.secretImageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.outputImageComboBox = new System.Windows.Forms.ComboBox();
            this.outputImageChannelLabel = new System.Windows.Forms.Label();
            this.outputImageChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.allImageComboBox = new System.Windows.Forms.ComboBox();
            this.allImageChannelLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hostImageChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secretImageChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputImageChart)).BeginInit();
            this.SuspendLayout();
            // 
            // hostImageChart
            // 
            this.hostImageChart.BackColor = System.Drawing.Color.LightGray;
            this.hostImageChart.BorderlineColor = System.Drawing.Color.DarkGray;
            this.hostImageChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.Maximum = 255D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.LabelStyle.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "HostImageChartArea";
            this.hostImageChart.ChartAreas.Add(chartArea1);
            this.hostImageChart.Location = new System.Drawing.Point(9, 36);
            this.hostImageChart.Margin = new System.Windows.Forms.Padding(0);
            this.hostImageChart.Name = "hostImageChart";
            this.hostImageChart.Size = new System.Drawing.Size(258, 136);
            this.hostImageChart.TabIndex = 0;
            this.hostImageChart.MouseLeave += new System.EventHandler(this.hostImageChart_MouseLeave);
            this.hostImageChart.MouseHover += new System.EventHandler(this.hostImageChart_MouseHover);
            this.hostImageChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.hostImageChart_MouseMove);
            // 
            // hostImageChannelLabel
            // 
            this.hostImageChannelLabel.AutoSize = true;
            this.hostImageChannelLabel.Location = new System.Drawing.Point(6, 12);
            this.hostImageChannelLabel.Name = "hostImageChannelLabel";
            this.hostImageChannelLabel.Size = new System.Drawing.Size(103, 13);
            this.hostImageChannelLabel.TabIndex = 1;
            this.hostImageChannelLabel.Text = "Host Image Channel";
            // 
            // hostImageComboBox
            // 
            this.hostImageComboBox.Enabled = false;
            this.hostImageComboBox.FormattingEnabled = true;
            this.hostImageComboBox.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "Gray"});
            this.hostImageComboBox.Location = new System.Drawing.Point(146, 9);
            this.hostImageComboBox.Name = "hostImageComboBox";
            this.hostImageComboBox.Size = new System.Drawing.Size(121, 21);
            this.hostImageComboBox.TabIndex = 2;
            this.hostImageComboBox.SelectedIndexChanged += new System.EventHandler(this.hostImageComboBox_SelectedIndexChanged);
            // 
            // secretImageComboBox
            // 
            this.secretImageComboBox.Enabled = false;
            this.secretImageComboBox.FormattingEnabled = true;
            this.secretImageComboBox.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "Gray"});
            this.secretImageComboBox.Location = new System.Drawing.Point(428, 9);
            this.secretImageComboBox.Name = "secretImageComboBox";
            this.secretImageComboBox.Size = new System.Drawing.Size(121, 21);
            this.secretImageComboBox.TabIndex = 5;
            this.secretImageComboBox.SelectedIndexChanged += new System.EventHandler(this.secretImageComboBox_SelectedIndexChanged);
            // 
            // secretImageChannelLabel
            // 
            this.secretImageChannelLabel.AutoSize = true;
            this.secretImageChannelLabel.Location = new System.Drawing.Point(288, 12);
            this.secretImageChannelLabel.Name = "secretImageChannelLabel";
            this.secretImageChannelLabel.Size = new System.Drawing.Size(112, 13);
            this.secretImageChannelLabel.TabIndex = 4;
            this.secretImageChannelLabel.Text = "Secret Image Channel";
            // 
            // secretImageChart
            // 
            this.secretImageChart.BackColor = System.Drawing.Color.LightGray;
            this.secretImageChart.BorderlineColor = System.Drawing.Color.DarkGray;
            this.secretImageChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.AxisX.Interval = 1D;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.Maximum = 255D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisY.LabelStyle.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.CursorY.IsUserSelectionEnabled = true;
            chartArea2.Name = "SecretImageChartArea";
            this.secretImageChart.ChartAreas.Add(chartArea2);
            this.secretImageChart.Location = new System.Drawing.Point(291, 36);
            this.secretImageChart.Margin = new System.Windows.Forms.Padding(0);
            this.secretImageChart.Name = "secretImageChart";
            this.secretImageChart.Size = new System.Drawing.Size(258, 136);
            this.secretImageChart.TabIndex = 3;
            this.secretImageChart.MouseLeave += new System.EventHandler(this.secretImageChart_MouseLeave);
            this.secretImageChart.MouseHover += new System.EventHandler(this.secretImageChart_MouseHover);
            this.secretImageChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.secretImageChart_MouseMove);
            // 
            // outputImageComboBox
            // 
            this.outputImageComboBox.Enabled = false;
            this.outputImageComboBox.FormattingEnabled = true;
            this.outputImageComboBox.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "Gray"});
            this.outputImageComboBox.Location = new System.Drawing.Point(710, 9);
            this.outputImageComboBox.Name = "outputImageComboBox";
            this.outputImageComboBox.Size = new System.Drawing.Size(121, 21);
            this.outputImageComboBox.TabIndex = 8;
            this.outputImageComboBox.SelectedIndexChanged += new System.EventHandler(this.outputImageComboBox_SelectedIndexChanged);
            // 
            // outputImageChannelLabel
            // 
            this.outputImageChannelLabel.AutoSize = true;
            this.outputImageChannelLabel.Location = new System.Drawing.Point(570, 12);
            this.outputImageChannelLabel.Name = "outputImageChannelLabel";
            this.outputImageChannelLabel.Size = new System.Drawing.Size(113, 13);
            this.outputImageChannelLabel.TabIndex = 7;
            this.outputImageChannelLabel.Text = "Output Image Channel";
            // 
            // outputImageChart
            // 
            this.outputImageChart.BackColor = System.Drawing.Color.LightGray;
            this.outputImageChart.BorderlineColor = System.Drawing.Color.DarkGray;
            this.outputImageChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea3.AxisX.Interval = 1D;
            chartArea3.AxisX.LabelStyle.Enabled = false;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisX.Maximum = 255D;
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.AxisY.LabelStyle.Enabled = false;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.CursorX.IsUserSelectionEnabled = true;
            chartArea3.CursorY.IsUserSelectionEnabled = true;
            chartArea3.Name = "OutputImageChartArea";
            this.outputImageChart.ChartAreas.Add(chartArea3);
            this.outputImageChart.Location = new System.Drawing.Point(573, 36);
            this.outputImageChart.Margin = new System.Windows.Forms.Padding(0);
            this.outputImageChart.Name = "outputImageChart";
            this.outputImageChart.Size = new System.Drawing.Size(258, 136);
            this.outputImageChart.TabIndex = 6;
            this.outputImageChart.MouseLeave += new System.EventHandler(this.outputImageChart_MouseLeave);
            this.outputImageChart.MouseHover += new System.EventHandler(this.outputImageChart_MouseHover);
            this.outputImageChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.outputImageChart_MouseMove);
            // 
            // allImageComboBox
            // 
            this.allImageComboBox.Enabled = false;
            this.allImageComboBox.FormattingEnabled = true;
            this.allImageComboBox.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "Gray"});
            this.allImageComboBox.Location = new System.Drawing.Point(992, 9);
            this.allImageComboBox.Name = "allImageComboBox";
            this.allImageComboBox.Size = new System.Drawing.Size(121, 21);
            this.allImageComboBox.TabIndex = 10;
            this.allImageComboBox.SelectedIndexChanged += new System.EventHandler(this.allImageComboBox_SelectedIndexChanged);
            // 
            // allImageChannelLabel
            // 
            this.allImageChannelLabel.AutoSize = true;
            this.allImageChannelLabel.Location = new System.Drawing.Point(855, 12);
            this.allImageChannelLabel.Name = "allImageChannelLabel";
            this.allImageChannelLabel.Size = new System.Drawing.Size(92, 13);
            this.allImageChannelLabel.TabIndex = 9;
            this.allImageChannelLabel.Text = "All Image Channel";
            // 
            // HistogramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 179);
            this.Controls.Add(this.allImageComboBox);
            this.Controls.Add(this.allImageChannelLabel);
            this.Controls.Add(this.outputImageComboBox);
            this.Controls.Add(this.outputImageChannelLabel);
            this.Controls.Add(this.outputImageChart);
            this.Controls.Add(this.secretImageComboBox);
            this.Controls.Add(this.secretImageChannelLabel);
            this.Controls.Add(this.secretImageChart);
            this.Controls.Add(this.hostImageComboBox);
            this.Controls.Add(this.hostImageChannelLabel);
            this.Controls.Add(this.hostImageChart);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "HistogramForm";
            this.Text = "Histogram";
            ((System.ComponentModel.ISupportInitialize)(this.hostImageChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secretImageChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputImageChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart hostImageChart;
        private System.Windows.Forms.Label hostImageChannelLabel;
        private System.Windows.Forms.ComboBox hostImageComboBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart secretImageChart;
        private System.Windows.Forms.Label secretImageChannelLabel;
        private System.Windows.Forms.ComboBox secretImageComboBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart outputImageChart;
        private System.Windows.Forms.Label outputImageChannelLabel;
        private System.Windows.Forms.ComboBox outputImageComboBox;
        private System.Windows.Forms.ComboBox allImageComboBox;
        private System.Windows.Forms.Label allImageChannelLabel;

    }
}