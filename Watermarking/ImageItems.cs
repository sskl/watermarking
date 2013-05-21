using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Watermarking.Algorithms;
using WeifenLuo.WinFormsUI.Docking;

namespace Watermarking
{
    public partial class ImageItems : DockContent
    {
        private Bitmap hostImage;
        public Bitmap HostImage
        {
            get { return hostImage; }
        }

        private Bitmap secretImage;
        public Bitmap SecretImage
        {
            get { return secretImage; }
        }

        private Bitmap outputImage;
        public Bitmap OutputImage
        {
            get { return outputImage; }
        }

        private string path = "D:\\WorkSpaces\\VisualStudio\\Projects\\Watermarking\\Watermarking\\Outputs\\";
        private string algorithm;
        private string type;
        private int numberOfBits;
        private string direction;
        private int numberOfRndNumbers;
        private AnalysisForm analysisForm;
        private int pictureBoxSize;

        public ImageItems()
        {
            InitializeComponent();
        }

        public ImageItems(string HostImageFileName,
                          string SecretImageFileName,
                          SettingsForm settingsForm,
                          AnalysisForm analysisForm)
        {
            InitializeComponent();
            if (HostImageFileName == string.Empty)
                throw new ArgumentNullException("HostImageFileName");
            if (SecretImageFileName == string.Empty)
                throw new ArgumentNullException("SecretImageFileName");

            try
            {
                hostImage = new Bitmap(HostImageFileName);
                secretImage = new Bitmap(SecretImageFileName);
                this.algorithm = settingsForm.SelectedAlgorithm;
                this.type = settingsForm.Type;
                this.numberOfBits = settingsForm.NumberOfBits;
                this.direction = settingsForm.Direction;
                this.numberOfRndNumbers = settingsForm.NumberOfRndNumber;
                this.analysisForm = analysisForm;

                RunAlgorithm();
                
                hostImageBox.Image = (Image)hostImage;
                secretImageBox.Image = (Image)secretImage;
            }
            catch (Exception E)
            {
                MessageBox.Show(
                    E.ToString(),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public ImageItems(string OutputImageFileName, SettingsForm settingsForm)
        {
            InitializeComponent();
            if (OutputImageFileName == string.Empty)
                throw new ArgumentNullException("OutputImageFileName");

            try
            {
                hostImageBox.Visible = false;
                hostImageLabel.Visible = false;
                outputImage = new Bitmap(OutputImageFileName);
                this.algorithm = settingsForm.SelectedAlgorithm;
                this.type = settingsForm.Type;
                this.numberOfBits = settingsForm.NumberOfBits;
                this.direction = settingsForm.Direction;
                this.numberOfRndNumbers = settingsForm.NumberOfRndNumber;

                DeRunAlgorithm();

                outputImageBox.Image = (Image)outputImage;
            }
            catch (Exception E)
            {
                MessageBox.Show(
                    E.ToString(),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SetPictureBoxesPosition()
        {
            int height = this.Height;
            int y = (height - pictureBoxSize)/2;
            Point p1, p2, p3;

            if (HostImage != null)
            {
                p1 = new Point(10, y);
                p2 = new Point(pictureBoxSize + 20, y);
                p3 = new Point(2 * pictureBoxSize + 30, y);
            }
            else
            {
                p1 = new Point(2 * pictureBoxSize + 30, y);
                p2 = new Point(pictureBoxSize + 20, y);
                p3 = new Point(10, y);
            }

            hostImageBox.Location = p1;
            hostImageLabel.Location = new Point(hostImageBox.Location.X + (hostImageBox.Width / 2) - (hostImageLabel.Width / 2),
                                                hostImageBox.Location.Y - hostImageLabel.Height - 5);
            secretImageBox.Location = p2;
            secretImageLabel.Location = new Point(secretImageBox.Location.X + (secretImageBox.Width / 2) - (secretImageLabel.Width / 2),
                                                  secretImageBox.Location.Y - secretImageLabel.Height - 5);
            outputImageBox.Location = p3;
            outputImageLabel.Location = new Point(outputImageBox.Location.X + (outputImageBox.Width / 2) - (outputImageLabel.Width / 2),
                                                  outputImageBox.Location.Y - outputImageLabel.Height - 5);
        }

        private void SetPictureBoxesSize()
        {
            this.pictureBoxSize = ((this.Width - 60) / 3);
            if (this.pictureBoxSize <= 210)
            {
                this.pictureBoxSize = 210;
                return;
            }
            Size size = new Size(pictureBoxSize, pictureBoxSize);
            hostImageBox.Size = size;
            secretImageBox.Size = size;
            outputImageBox.Size = size;
        }

        private void RunAlgorithm()
        {
            switch (algorithm)
            {
                case "LSB Hiding":
                    try
                    {
                        LSBHiding lsb = new LSBHiding(hostImage, secretImage);
                        lsb.NumberOfBits = numberOfBits;

                        DataTable dt = new DataTable();
                        dt.Columns.Add("Bit");
                        dt.Columns.Add("PSNR R");
                        dt.Columns.Add("PSNR G");
                        dt.Columns.Add("PSNR B");
                        dt.Columns.Add("PSNR GY");

                        switch (type)
                        {
                            case "LSB-LSB":
                                lsb.LSB_LSB();
                                outputImage = (Bitmap)lsb.OutputImage.Clone();
                                lsb.saveOutputImage(path, "OutputImage_" + type + "_" + numberOfBits.ToString() + ".bmp");
                                for (int i = 1; i <= 7; i++)
                                {
                                    lsb.NumberOfBits = i;
                                    lsb.LSB_LSB();
                                    PSNR psnr = new PSNR(hostImage, lsb.OutputImage);
                                    dt.Rows.Add(i.ToString(), psnr.R.ToString(), psnr.G.ToString(), psnr.B.ToString(), psnr.Gray.ToString());

                                    lsb.saveOutputImage(path, "OutputImage_" + type + "_" + i.ToString() + ".bmp");
                                }
                                analysisForm.SetPSNRForDataGrid(dt);
                                break;

                            case "LSB-MSB":
                                lsb.LSB_MSB();
                                outputImage = (Bitmap)lsb.OutputImage.Clone();
                                lsb.saveOutputImage(path, "OutputImage_" + type + "_" + numberOfBits.ToString() + ".bmp");
                                for (int i = 1; i <= 7; i++)
                                {
                                    lsb.NumberOfBits = i;
                                    lsb.LSB_MSB();
                                    PSNR psnr = new PSNR(hostImage, lsb.OutputImage);
                                    dt.Rows.Add(i.ToString(), psnr.R.ToString(), psnr.G.ToString(), psnr.B.ToString(), psnr.Gray.ToString());

                                    lsb.saveOutputImage(path, "OutputImage_" + type + "_" + i.ToString() + ".bmp");
                                }
                                analysisForm.SetPSNRForDataGrid(dt);
                                break;
                        }

                        outputImageBox.Image = (Image)outputImage;

                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(
                            E.ToString(),
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    break;

                case "Visual Cryptography":
                    try
                    {
                        VisualCryptography vc = new VisualCryptography(hostImage, secretImage);
                        vc.NumberOfBits = numberOfBits;
                        vc.CreateShareImages();
                        vc.saveShareImage1(path, "ShareImage1.bmp");
                        vc.saveShareImage2(path, "ShareImage2.bmp");

                        DataTable dt = new DataTable();
                        dt.Columns.Add("Bit");
                        dt.Columns.Add("PSNR R");
                        dt.Columns.Add("PSNR G");
                        dt.Columns.Add("PSNR B");
                        dt.Columns.Add("PSNR GY");

                        switch (type)
                        {
                            case "LSB-LSB":
                                vc.LSB_LSB();
                                outputImage = (Bitmap)vc.OutputImage.Clone();
                                vc.saveOutputImage(path, "OutputImage_" + type + "_" + numberOfBits.ToString() + ".bmp");
                                for (int i = 1; i <= 7; i++)
                                {
                                    vc.NumberOfBits = i;
                                    vc.LSB_LSB();
                                    PSNR psnr = new PSNR(hostImage, vc.OutputImage);
                                    dt.Rows.Add(i.ToString(), psnr.R.ToString(), psnr.G.ToString(), psnr.B.ToString(), psnr.Gray.ToString());

                                    vc.saveOutputImage(path, "OutputImage_" + type + "_" + i.ToString() + ".bmp");
                                }
                                analysisForm.SetPSNRForDataGrid(dt);
                                break;

                            case "LSB-MSB":
                                vc.LSB_MSB();
                                outputImage = (Bitmap)vc.OutputImage.Clone();
                                vc.saveOutputImage(path, "OutputImage_" + type + "_" + numberOfBits.ToString() + ".bmp");
                                for (int i = 1; i <= 7; i++)
                                {
                                    vc.NumberOfBits = i;
                                    vc.LSB_MSB();
                                    PSNR psnr = new PSNR(hostImage, vc.OutputImage);
                                    dt.Rows.Add(i.ToString(), psnr.R.ToString(), psnr.G.ToString(), psnr.B.ToString(), psnr.Gray.ToString());

                                    vc.saveOutputImage(path, "OutputImage_" + type + "_" + i.ToString() + ".bmp");
                                }
                                analysisForm.SetPSNRForDataGrid(dt);
                                break;
                        }

                        outputImageBox.Image = (Image)outputImage;
                        secretImage = vc.SecretImage;

                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(
                            E.ToString(),
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    break;

                case "Randomized LSB Hiding":
                    try
                    {
                        RandomizedLSBHiding rlsb = new RandomizedLSBHiding(hostImage, secretImage, numberOfRndNumbers, direction);
                        rlsb.NumberOfBits = numberOfBits;
                        rlsb.GenerateRandomNumbers();

                        DataTable dt = new DataTable();
                        dt.Columns.Add("Bit");
                        dt.Columns.Add("PSNR R");
                        dt.Columns.Add("PSNR G");
                        dt.Columns.Add("PSNR B");
                        dt.Columns.Add("PSNR GY");

                        switch (type)
                        {
                            case "LSB-LSB":
                                rlsb.LSB_LSB();
                                outputImage = (Bitmap)rlsb.OutputImage.Clone();
                                rlsb.saveOutputImage(path, "OutputImage_" + type + "_" + numberOfBits.ToString() + "_" + numberOfRndNumbers.ToString() + ".bmp");
                                for (int i = 1; i <= 7; i++)
                                {
                                    rlsb.NumberOfBits = i;
                                    rlsb.LSB_LSB();
                                    PSNR psnr = new PSNR(hostImage, rlsb.OutputImage);
                                    dt.Rows.Add(i.ToString(), psnr.R.ToString(), psnr.G.ToString(), psnr.B.ToString(), psnr.Gray.ToString());

                                    rlsb.saveOutputImage(path, "OutputImage_" + type + "_" + i.ToString() + "_" + numberOfRndNumbers.ToString() + ".bmp");
                                }
                                analysisForm.SetPSNRForDataGrid(dt);
                                break;

                            case "LSB-MSB":
                                rlsb.LSB_MSB();
                                outputImage = (Bitmap)rlsb.OutputImage.Clone();
                                rlsb.saveOutputImage(path, "OutputImage_" + type + "_" + numberOfBits.ToString() + "_" + numberOfRndNumbers.ToString() + ".bmp");
                                for (int i = 1; i <= 7; i++)
                                {
                                    rlsb.NumberOfBits = i;
                                    rlsb.LSB_MSB();
                                    PSNR psnr = new PSNR(hostImage, rlsb.OutputImage);
                                    dt.Rows.Add(i.ToString(), psnr.R.ToString(), psnr.G.ToString(), psnr.B.ToString(), psnr.Gray.ToString());

                                    rlsb.saveOutputImage(path, "OutputImage_" + type + "_" + i.ToString() + "_" + numberOfRndNumbers.ToString() + ".bmp");
                                }
                                analysisForm.SetPSNRForDataGrid(dt);
                                break;
                        }

                        outputImageBox.Image = (Image)outputImage;
                        secretImage = rlsb.SecretImage;

                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(
                            E.ToString(),
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    break;

                case "Interlaced Bit Hiding":
                    try
                    {
                        analysisForm.HidePSNRDataGridView();
                        InterlacedBitHiding ibh = new InterlacedBitHiding(hostImage, secretImage);
                        switch (type)
                        {
                            case "Odd-Even":
                                ibh.Odd_Even();
                                outputImage = (Bitmap)ibh.OutputImage.Clone();
                                ibh.saveOutputImage(path, "OutputImage_" + type + ".bmp");
                                break;

                            case "Pair-Wise":
                                ibh.Pair_Wise();
                                outputImage = (Bitmap)ibh.OutputImage.Clone();
                                ibh.saveOutputImage(path, "OutputImage_" + type + ".bmp");
                                break;
                        }

                        outputImageBox.Image = (Image)outputImage;
                        secretImage = ibh.SecretImage;

                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(
                            E.ToString(),
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    break;
                default:
                    MessageBox.Show(
                        "Please select algorithm!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    break;
            }
        }

        private void DeRunAlgorithm()
        {
            switch (algorithm)
            {
                case "LSB Hiding":
                    try
                    {
                        LSBHiding lsb = new LSBHiding(outputImage);
                        lsb.NumberOfBits = numberOfBits;

                        switch (type)
                        {
                            case "LSB-LSB":
                                lsb.Reverse_LSB_LSB();
                                break;

                            case "LSB-MSB":
                                lsb.Reverse_LSB_MSB();
                                break;
                        }

                        secretImage = (Bitmap)lsb.SecretImage.Clone();
                        secretImageBox.Image = (Image)secretImage;

                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(
                            E.ToString(),
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    break;

                case "Visual Cryptography":
                    try
                    {
                        Bitmap shareImage2;
                        OpenFileDialog dlgSelectShareImage2 = new OpenFileDialog();
                        dlgSelectShareImage2.Title = "Select Share Image 2 File";
                        dlgSelectShareImage2.Filter = "Image Files|*.bmp";
                        dlgSelectShareImage2.FilterIndex = 1;
                        dlgSelectShareImage2.Multiselect = false;

                        if (dlgSelectShareImage2.ShowDialog() == DialogResult.OK)
                        {
                            if (dlgSelectShareImage2.FileName == String.Empty)
                                return;

                            shareImage2 = new Bitmap(dlgSelectShareImage2.FileName);
                        }
                        else
                        {
                            return;
                        }

                        VisualCryptography vc = new VisualCryptography(outputImage);
                        vc.ShareImage2 = shareImage2;
                        vc.NumberOfBits = numberOfBits;

                        switch (type)
                        {
                            case "LSB-LSB":
                                vc.Reverse_LSB_LSB();
                                break;

                            case "LSB-MSB":
                                vc.Reverse_LSB_MSB();
                                break;
                        }

                        vc.CreateSecretImage();
                        secretImage = (Bitmap)vc.SecretImage.Clone();
                        secretImageBox.Image = (Image)secretImage;

                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(
                            E.ToString(),
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    break;

                case "Randomized LSB Hiding":
                    try
                    {
                        RandomizedLSBHiding rlsb = new RandomizedLSBHiding(outputImage, numberOfRndNumbers, direction);
                        rlsb.NumberOfBits = numberOfBits;
                        rlsb.GenerateRandomNumbers();

                        switch (type)
                        {
                            case "LSB-LSB":
                                rlsb.Reverse_LSB_LSB();
                                break;

                            case "LSB-MSB":
                                rlsb.Reverse_LSB_MSB();
                                break;
                        }

                        secretImage = (Bitmap)rlsb.SecretImage.Clone();
                        secretImageBox.Image = (Image)secretImage;

                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(
                            E.ToString(),
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    break;

                case "Interlaced Bit Hiding":
                    try
                    {
                        InterlacedBitHiding ibh = new InterlacedBitHiding(outputImage);

                        switch (type)
                        {
                            case "Odd-Even":
                                ibh.Reverse_Odd_Even();
                                break;

                            case "Pair-Wise":
                                ibh.Reverse_Pair_Wise();
                                break;
                        }

                        secretImage = (Bitmap)ibh.SecretImage.Clone();
                        secretImageBox.Image = (Image)secretImage;

                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(
                            E.ToString(),
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    break;
                default:
                    MessageBox.Show(
                        "Please select algorithm!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    break;
            }
        }

        private void ImageItems_SizeChanged(object sender, EventArgs e)
        {
            SetPictureBoxesSize();
            SetPictureBoxesPosition();
        }
    }
}