using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Watermarking
{
    public partial class MainForm : Form
    {
        private SettingsForm settingsForm;
        private ImageItems imageItems;
        private PropertiesForm propertiesForm;
        private HistogramForm histogramForm;
        private AnalysisForm analysisForm;

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

        private String outputImageFileName = String.Empty;
        public String OutputImageFileName
        {
            get { return outputImageFileName; }
            set { outputImageFileName = value; }
        }

        public MainForm()
        {
            InitializeComponent();
            CreateStandardControls();
        }

        private void CreateStandardControls()
        {
            propertiesForm = new PropertiesForm();
            histogramForm = new HistogramForm();
            analysisForm = new AnalysisForm();
            propertiesForm.Show(dockPanel, DockState.DockBottom);
            histogramForm.Show(dockPanel, DockState.DockBottom);
            analysisForm.Show(dockPanel, DockState.DockBottom);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgSelectHostImage = new OpenFileDialog();
            dlgSelectHostImage.Title = "Select Host Image File";
            dlgSelectHostImage.Filter = "Image Files|*.bmp";
            dlgSelectHostImage.FilterIndex = 1;
            dlgSelectHostImage.Multiselect = false;

            if (dlgSelectHostImage.ShowDialog() == DialogResult.OK)
            {
                if (dlgSelectHostImage.FileName == String.Empty)
                    return;

                HostImageFileName = dlgSelectHostImage.FileName;
            }
            else { return; }

            OpenFileDialog dlgSelectSecretImage = new OpenFileDialog();
            dlgSelectSecretImage.Title = "Select Secret Image File";
            dlgSelectSecretImage.Filter = "Image Files|*.bmp";
            dlgSelectSecretImage.FilterIndex = 1;
            dlgSelectSecretImage.Multiselect = false;

            if (dlgSelectSecretImage.ShowDialog() == DialogResult.OK)
            {
                if (dlgSelectSecretImage.FileName == String.Empty)
                    return;

                SecretImageFileName = dlgSelectSecretImage.FileName;
            }
            else { return; }

            try
            {
                settingsForm = new SettingsForm();
                settingsForm.Owner = this;
                settingsForm.ShowDialog();

                Cursor = Cursors.WaitCursor;

                imageItems = new ImageItems(HostImageFileName,
                                            SecretImageFileName,
                                            settingsForm,
                                            analysisForm);
                imageItems.Text = System.IO.Path.GetFileName(HostImageFileName);
                imageItems.Show(dockPanel);
                imageItems.Focus();
                settingsForm.Dispose();

                Cursor = Cursors.Arrow;
            }
            catch (Exception E)
            {
                MessageBox.Show(
                    E.ToString(),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void dockPanel_ActiveDocumentChanged(object sender, EventArgs e)
        {
            IDockContent content = dockPanel.ActiveDocument;
            ImageItems imgItems = (content is ImageItems) ? (ImageItems)content : null;

            UpdateProperties(imgItems);
            UpdateHistogram(imgItems);
            UpdateAnalysis(imgItems);
        }

        private void UpdateProperties(ImageItems imageItems)
        {
            if (imageItems != null)
                propertiesForm.SetProperties(imageItems.HostImage,
                                             imageItems.SecretImage,
                                             imageItems.OutputImage);
            else
                propertiesForm.Clear();
        }

        private void UpdateHistogram(ImageItems imageItems)
        {
            if (imageItems != null)
                histogramForm.SetHistograms(imageItems.HostImage,
                                            imageItems.SecretImage,
                                            imageItems.OutputImage);
            else
                histogramForm.Clear();
        }

        private void UpdateAnalysis(ImageItems imageItems)
        {
            if (imageItems != null)
            {
                if (imageItems.HostImage != null)
                {
                    analysisForm.SetPSNR(imageItems.HostImage,
                                         imageItems.OutputImage);
                    if (analysisForm.IsHidden == true)
                    {
                        analysisForm.Show();
                    }
                }
                else
                {
                    analysisForm.Clear();
                }
            }
            else
            {
                analysisForm.Clear();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDockContent content = dockPanel.ActiveContent;
            SaveFileDialog dlgSaveOutputImage = new SaveFileDialog();
            if (content != null)
            {
                // set initial file name
                if ((content is ImageItems) && (((ImageItems)content).OutputImage != null))
                {
                    if (dlgSaveOutputImage.ShowDialog(this) == DialogResult.OK)
                    {
                        ImageFormat format = ImageFormat.Jpeg;
                        switch (Path.GetExtension(dlgSaveOutputImage.FileName).ToLower())
                        {
                            case ".jpg":
                                format = ImageFormat.Jpeg;
                                break;
                            case ".bmp":
                                format = ImageFormat.Bmp;
                                break;
                            default:
                                MessageBox.Show(this, "Unsupported image format was specified", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                        }
                        try
                        {
                            if (((ImageItems)content).HostImage != null)
                                ((ImageItems)content).OutputImage.Save(dlgSaveOutputImage.FileName, format);
                            else
                                ((ImageItems)content).SecretImage.Save(dlgSaveOutputImage.FileName, format);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(this, "Failed writing image file", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgSelectOutputImage = new OpenFileDialog();
            dlgSelectOutputImage.Title = "Select Host Image File";
            dlgSelectOutputImage.Filter = "Image Files|*.bmp";
            dlgSelectOutputImage.FilterIndex = 1;
            dlgSelectOutputImage.Multiselect = false;

            if (dlgSelectOutputImage.ShowDialog() == DialogResult.OK)
            {
                if (dlgSelectOutputImage.FileName == String.Empty)
                    return;

                OutputImageFileName = dlgSelectOutputImage.FileName;
            }
            else { return; }

            try
            {
                settingsForm = new SettingsForm();
                settingsForm.Owner = this;
                settingsForm.ShowDialog();

                Cursor = Cursors.WaitCursor;
                
                analysisForm.Hide();

                imageItems = new ImageItems(OutputImageFileName,
                                            settingsForm);
                imageItems.Text = System.IO.Path.GetFileName(OutputImageFileName);
                imageItems.Show(dockPanel);
                imageItems.Focus();
                settingsForm.Dispose();

                Cursor = Cursors.Arrow;
            }
            catch (Exception E)
            {
                MessageBox.Show(
                    E.ToString(),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return;

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageItems != null)
            {
                if (imageItems.HostImage != null)
                {
                    Clipboard.SetImage(imageItems.OutputImage);
                }
                else
                {
                    Clipboard.SetImage(imageItems.SecretImage);
                }
            }
        }
    }
}
