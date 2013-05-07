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
            dlgSelectHostImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.tif;*.tiff";
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
            dlgSelectSecretImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.tif;*.tiff";
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
                                            settingsForm.SelectedAlgorithm,
                                            settingsForm.Type,
                                            settingsForm.NumberOfBits);
                imageItems.Text = System.IO.Path.GetFileName(HostImageFileName);
                imageItems.Show(dockPanel);
                SetupDocumentsEvents(imageItems);
                imageItems.Focus();
                propertiesForm.SetProperties(imageItems.HostImage,
                                             imageItems.SecretImage,
                                             imageItems.OutputImage);
                histogramForm.SetHistograms(imageItems.HostImage,
                                            imageItems.SecretImage,
                                            imageItems.OutputImage);
                analysisForm.SetPSNR(imageItems.HostImage,
                                     imageItems.OutputImage);
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

        private void SetupDocumentsEvents(ImageItems item)
        {
            item.MouseMove += new System.Windows.Forms.MouseEventHandler(this.document_MousePosition);
            item.MouseImagePosition += new ImageItems.SelectionEventHandler(this.document_MouseImagePosition);
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

        // On mouse position over image changed
        private void document_MouseImagePosition(Bitmap image, Point point)
        {
            if (point.X >= 0)
            {
                this.toolStripStatusLabelPosition.Text = string.Format("({0}, {1})", point.X, point.Y);
                try
                {
                    Color color = image.GetPixel(point.X, point.Y);

                    if (image.PixelFormat == PixelFormat.Format32bppArgb || image.PixelFormat == PixelFormat.Format24bppRgb)
                    {
                        this.toolStripStatusLabelRGB.Text = string.Format("RGB: {0}; {1}; {2}", color.R, color.G, color.B);
                    }
                    else if (image.PixelFormat == PixelFormat.Format8bppIndexed)
                    {
                        this.toolStripStatusLabelRGB.Text = "Gray: " + color.R.ToString();
                    }
                }
                catch (Exception)
                {
                    this.toolStripStatusLabelPosition.Text = "";
                    this.toolStripStatusLabelRGB.Text = "";
                }
            }
        }

        private void document_MousePosition(object image, MouseEventArgs point)
        {
            this.toolStripStatusLabelPosition.Text = "";
            this.toolStripStatusLabelRGB.Text = "";
        }

        private void dockPanel_ActiveDocumentChanged(object sender, EventArgs e)
        {
            IDockContent content = dockPanel.ActiveDocument;
            ImageItems imgItems = (content is ImageItems) ? (ImageItems)content : null;

            UpdateProperties(imgItems);
            UpdateHistogram(imgItems);
            UpdateAnalysis(imgItems);
        }

        private void UpdateAnalysis(ImageItems imgItems)
        {
            if (imageItems != null)
            {
                if (imageItems.HostImage != null)
                {
                    analysisForm.SetPSNR(imageItems.HostImage,
                                         imageItems.OutputImage);
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
            dlgSelectOutputImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.tif;*.tiff;*.bmp";
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
                                            settingsForm.SelectedAlgorithm,
                                            settingsForm.Type,
                                            settingsForm.NumberOfBits);
                imageItems.Text = System.IO.Path.GetFileName(OutputImageFileName);
                imageItems.Show(dockPanel);
                SetupDocumentsEvents(imageItems);
                imageItems.Focus();
                propertiesForm.SetProperties(imageItems.HostImage,
                                             imageItems.SecretImage,
                                             imageItems.OutputImage);
                histogramForm.SetHistograms(imageItems.HostImage,
                                            imageItems.SecretImage,
                                            imageItems.OutputImage);
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
    }
}
