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

        private String direction = String.Empty;
        public String Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        private int numberOfRndNumber = 0;
        public int NumberOfRndNumber
        {
            get { return numberOfRndNumber; }
            set { numberOfRndNumber = value; }
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
            if (SelectedAlgorithm == "Randomized LSB Hiding")
            {
                Direction = cmbDirection.Text;
                NumberOfRndNumber = Convert.ToInt32(txtRndNumbers.Text);
            }
            this.Close();
        }

        private void cmbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedAlgorithm = cmbAlgorithm.Text;
            if (SelectedAlgorithm == "Interlaced Bit Hiding")
            {
                cmbType.Items.Clear();
                cmbType.Items.Add("Odd-Even");
                cmbType.Items.Add("Pair-Wise");
                cmbType.Text = "Odd-Even";
            }
            else
            {
                cmbType.Items.Clear();
                cmbType.Items.Add("LSB-LSB");
                cmbType.Items.Add("LSB-MSB");
                cmbType.Text = "LSB-LSB";
            }

            switch (SelectedAlgorithm)
            {
                case "Interlaced Bit Hiding":
                    spnBitCount.Hide();
                    lblBitCount.Hide();
                    lblRNumberCount.Hide();
                    lblDirection.Hide();
                    txtRndNumbers.Hide();
                    cmbDirection.Hide();
                    break;
                case "LSB Hiding":
                    cmbType.Show();
                    lblType.Show();
                    spnBitCount.Show();
                    lblBitCount.Show();
                    lblRNumberCount.Hide();
                    lblDirection.Hide();
                    txtRndNumbers.Hide();
                    cmbDirection.Hide();
                    break;
                case "Visual Cryptography":
                    cmbType.Show();
                    lblType.Show();
                    spnBitCount.Show();
                    lblBitCount.Show();
                    lblRNumberCount.Hide();
                    lblDirection.Hide();
                    txtRndNumbers.Hide();
                    cmbDirection.Hide();
                    break;
                case "Randomized LSB Hiding":
                    lblType.Show();
                    lblBitCount.Show();
                    lblRNumberCount.Show();
                    lblDirection.Show();
                    cmbType.Show();
                    cmbDirection.Show();
                    spnBitCount.Show();
                    txtRndNumbers.Show();
                    break;
            }
        }
    }
}
