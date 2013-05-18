using System;
using System.Collections;
using System.Windows.Forms;

namespace Watermarking
{
    public partial class SettingsForm : Form
    {
        private String selectedAlgorithm = String.Empty;
        public String SelectedAlgorithm
        {
            get { return selectedAlgorithm; }
            set { selectedAlgorithm = value; }
        }

        private String type = String.Empty;
        public String Type
        {
            get { return type; }
            set { type = value; }
        }


        private int numberOfBits = 1;
        public int NumberOfBits
        {
            get { return numberOfBits; }
            set { numberOfBits = value; }
        }

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedAlgorithm = cmbAlgorithm.Text;
            Type = cmbType.Text;
            NumberOfBits = (int)spnBitCount.Value;
            this.Close();
        }

        private void cmbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedAlgorithm = cmbAlgorithm.Text;
            switch (SelectedAlgorithm)
            {
                case "LSB Hiding":
                    cmbType.Show();
                    lblType.Show();
                    spnBitCount.Show();
                    lblBitCount.Show();
                    break;
                case "Visual Cryptography":
                    cmbType.Show();
                    lblType.Show();
                    spnBitCount.Show();
                    lblBitCount.Show();
                    break;
            }
        }
    }
}
