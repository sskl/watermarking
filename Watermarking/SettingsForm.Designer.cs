namespace Watermarking
{
    partial class SettingsForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.cmbAlgorithm = new System.Windows.Forms.ComboBox();
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.lblBitCount = new System.Windows.Forms.Label();
            this.spnBitCount = new System.Windows.Forms.NumericUpDown();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblRNumberCount = new System.Windows.Forms.Label();
            this.lblDirection = new System.Windows.Forms.Label();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.txtRndNumbers = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.spnBitCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(185, 225);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(76, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cmbAlgorithm
            // 
            this.cmbAlgorithm.FormattingEnabled = true;
            this.cmbAlgorithm.Items.AddRange(new object[] {
            "Interlaced Bit Hiding",
            "LSB Hiding",
            "Randomized LSB Hiding",
            "Visual Cryptography"});
            this.cmbAlgorithm.Location = new System.Drawing.Point(124, 27);
            this.cmbAlgorithm.Name = "cmbAlgorithm";
            this.cmbAlgorithm.Size = new System.Drawing.Size(137, 21);
            this.cmbAlgorithm.Sorted = true;
            this.cmbAlgorithm.TabIndex = 13;
            this.cmbAlgorithm.Text = "LSB Hiding";
            this.cmbAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cmbAlgorithm_SelectedIndexChanged);
            // 
            // lblAlgorithm
            // 
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.Location = new System.Drawing.Point(30, 30);
            this.lblAlgorithm.Name = "lblAlgorithm";
            this.lblAlgorithm.Size = new System.Drawing.Size(50, 13);
            this.lblAlgorithm.TabIndex = 12;
            this.lblAlgorithm.Text = "Algorithm";
            // 
            // lblBitCount
            // 
            this.lblBitCount.AutoSize = true;
            this.lblBitCount.Location = new System.Drawing.Point(30, 110);
            this.lblBitCount.Name = "lblBitCount";
            this.lblBitCount.Size = new System.Drawing.Size(76, 13);
            this.lblBitCount.TabIndex = 10;
            this.lblBitCount.Text = "Number of Bits";
            // 
            // spnBitCount
            // 
            this.spnBitCount.Location = new System.Drawing.Point(124, 108);
            this.spnBitCount.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.spnBitCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnBitCount.Name = "spnBitCount";
            this.spnBitCount.Size = new System.Drawing.Size(37, 20);
            this.spnBitCount.TabIndex = 9;
            this.spnBitCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "LSB-LSB",
            "LSB-MSB"});
            this.cmbType.Location = new System.Drawing.Point(124, 67);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(137, 21);
            this.cmbType.Sorted = true;
            this.cmbType.TabIndex = 16;
            this.cmbType.Text = "LSB-LSB";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(30, 70);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 15;
            this.lblType.Text = "Type";
            // 
            // lblRNumberCount
            // 
            this.lblRNumberCount.Location = new System.Drawing.Point(30, 150);
            this.lblRNumberCount.Name = "lblRNumberCount";
            this.lblRNumberCount.Size = new System.Drawing.Size(88, 26);
            this.lblRNumberCount.TabIndex = 17;
            this.lblRNumberCount.Text = "Number of Rnd Numbers";
            this.lblRNumberCount.Visible = false;
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(30, 190);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(49, 13);
            this.lblDirection.TabIndex = 18;
            this.lblDirection.Text = "Direction";
            this.lblDirection.Visible = false;
            // 
            // cmbDirection
            // 
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Items.AddRange(new object[] {
            "Horizontally",
            "Vertically"});
            this.cmbDirection.Location = new System.Drawing.Point(124, 187);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(137, 21);
            this.cmbDirection.Sorted = true;
            this.cmbDirection.TabIndex = 20;
            this.cmbDirection.Text = "Horizontally";
            this.cmbDirection.Visible = false;
            // 
            // txtRndNumbers
            // 
            this.txtRndNumbers.Location = new System.Drawing.Point(124, 153);
            this.txtRndNumbers.Name = "txtRndNumbers";
            this.txtRndNumbers.Size = new System.Drawing.Size(67, 20);
            this.txtRndNumbers.TabIndex = 21;
            this.txtRndNumbers.Visible = false;
            // 
            // SettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(294, 266);
            this.Controls.Add(this.txtRndNumbers);
            this.Controls.Add(this.cmbDirection);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.lblRNumberCount);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbAlgorithm);
            this.Controls.Add(this.lblAlgorithm);
            this.Controls.Add(this.lblBitCount);
            this.Controls.Add(this.spnBitCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.spnBitCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cmbAlgorithm;
        private System.Windows.Forms.Label lblAlgorithm;
        private System.Windows.Forms.Label lblBitCount;
        private System.Windows.Forms.NumericUpDown spnBitCount;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblRNumberCount;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.TextBox txtRndNumbers;
    }
}