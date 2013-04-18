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

            Hashtable htAlgorithms = new Hashtable();
            htAlgorithms.Add("LSBHiding", "LSB Hiding");
            cmbAlgorithm.DataSource = new BindingSource(htAlgorithms, null);

            Hashtable htLSBHidingTypes = new Hashtable();
            htLSBHidingTypes.Add("LSB_LSB", "LSB-LSB");
            htLSBHidingTypes.Add("LSB_MSB", "LSB-MSB");
            cmbType.DataSource = new BindingSource(htLSBHidingTypes, null);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedAlgorithm = cmbAlgorithm.SelectedValue.ToString();
            Type = cmbType.SelectedValue.ToString();
            NumberOfBits = (int)spnBitCount.Value;
        }
    }
}
