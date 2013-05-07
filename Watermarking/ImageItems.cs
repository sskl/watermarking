using System;
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
        private int pictureBoxSize;

        public delegate void SelectionEventHandler(Bitmap image, Point point);

        public event SelectionEventHandler MouseImagePosition;

        public ImageItems()
        {
            InitializeComponent();
        }

        public ImageItems(string HostImageFileName, string SecretImageFileName, string algorithm, string type, int numberOfBits)
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
                this.algorithm = algorithm;
                this.type = type;
                this.numberOfBits = numberOfBits;

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

        public ImageItems(string OutputImageFileName, string algorithm, string type, int numberOfBits)
        {
            InitializeComponent();
            if (OutputImageFileName == string.Empty)
                throw new ArgumentNullException("OutputImageFileName");

            try
            {
                hostImageBox.Visible = false;
                hostImageLabel.Visible = false;
                outputImage = new Bitmap(OutputImageFileName);
                this.algorithm = algorithm;
                this.type = type;
                this.numberOfBits = numberOfBits;

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
                case "LSBHiding":
                    try
                    {
                        LSBHiding lsb = new LSBHiding(hostImage, secretImage);
                        lsb.NumberOfBits = numberOfBits;
                        switch (type)
                        {
                            case "LSB_LSB":
                                lsb.LSB_LSB();
                                break;
                            case "LSB_MSB":
                                lsb.LSB_MSB();
                                break;
                        }

                        outputImage = (Bitmap)lsb.OutputImage.Clone();
                        outputImageBox.Image = (Image)outputImage;
                        lsb.saveOutputImage(path, "OutputImage_" + type + "_" + numberOfBits.ToString() + ".bmp");

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
                case "LSBHiding":
                    try
                    {
                        LSBHiding lsb = new LSBHiding(outputImage);
                        lsb.NumberOfBits = numberOfBits;
                        switch (type)
                        {
                            case "LSB_LSB":
                                lsb.Reverse_LSB_LSB();
                                break;
                            case "LSB_MSB":
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

        private void hostImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            MouseImagePosition((Bitmap)((PictureBox)sender).Image, e.Location);
        }

        private void secretImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            MouseImagePosition((Bitmap)((PictureBox)sender).Image, e.Location);
        }

        private void outputImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            MouseImagePosition((Bitmap)((PictureBox)sender).Image, e.Location);
        }
    }
}