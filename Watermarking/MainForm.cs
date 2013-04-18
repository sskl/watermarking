using System;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Watermarking.Algorithms;

namespace Watermarking
{
    public partial class MainForm : Form
    {
        private SettingsForm settingsForm;

        private String hostImageFileName = String.Empty;
        public String HostImageFileName
        {
            get { return hostImageFileName; }
            set { hostImageFileName = value; }
        }

        private String secretImageFileName = String.Empty;
        public String SecretImageFileName
        {
            get { return secretImageFileName; }
            set { secretImageFileName = value; }
        }

        public MainForm()
        {
            InitializeComponent();
            CreateStandardControls();
        }

        private void CreateStandardControls()
        {
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgSelectHostImage = new OpenFileDialog();
            dlgSelectHostImage.Title = "Select Host Image File";
            dlgSelectHostImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.tif;*.tiff";
            dlgSelectHostImage.FilterIndex = 1;
            dlgSelectHostImage.Multiselect = false;

            DialogResult hostClickedOK = dlgSelectHostImage.ShowDialog();

            if (hostClickedOK == DialogResult.OK)
            {
                if (dlgSelectHostImage.FileName == String.Empty)
                    return;

                HostImageFileName = dlgSelectHostImage.FileName;
            }
            else { return; }

            OpenFileDialog dlgSelectSecretImage = new OpenFileDialog();
            dlgSelectSecretImage.Title = "Select Secret Image File";
            dlgSelectSecretImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.tif;*.tiff";
            dlgSelectSecretImage.FilterIndex = 1;
            dlgSelectSecretImage.Multiselect = false;

            DialogResult secretClickedOK = dlgSelectSecretImage.ShowDialog();

            if (secretClickedOK == DialogResult.OK)
            {
                if (dlgSelectSecretImage.FileName == String.Empty)
                    return;

                SecretImageFileName = dlgSelectSecretImage.FileName;
            }
            else { return; }

            settingsForm = new SettingsForm();
            settingsForm.Owner = this;
            settingsForm.ShowDialog();

            settingsForm.Dispose();            
            return;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }
    }
}
