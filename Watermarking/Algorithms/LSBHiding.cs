using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Watermarking.Algorithms
{

    class LSBHiding
    {
        private Bitmap hostImage;
        private Bitmap secretImage;

        private Bitmap outputImage;
        public Bitmap OutputImage
        {
            get { return outputImage; }
            set { outputImage = value; }
        }

        private int numberOfBits = 1;
        public int NumberOfBits
        {
            get { return numberOfBits; }
            set { numberOfBits = value; }
        }

        public LSBHiding(Bitmap hostImage, Bitmap secretImage)
        {
            if (secretImage.Width > hostImage.Width || secretImage.Height > hostImage.Height)
                throw new Exception("Secret image must be small than host image.");
            
            this.hostImage = hostImage;
            this.secretImage = secretImage;
        }

        private void maskImage(Bitmap image, byte bits)
        {
            int width = image.Width;
            int height = image.Height;
            Color pixelColor;
            Color pixelNewColor;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    pixelColor = image.GetPixel(x, y);
                    pixelNewColor = Color.FromArgb(pixelColor.R & bits, pixelColor.G & bits, pixelColor.B & bits);
                    image.SetPixel(x, y, pixelNewColor);
                }
            }
        }

        public void saveOutputImage(String path)
        {
            string filename = "OutputImage_LSB-MSB_" + NumberOfBits.ToString() + ".jpg";
            OutputImage.Save(path + filename, ImageFormat.Jpeg);
            OutputImage.Dispose();
        }

        internal void LSB_LSB()
        {
            OutputImage = new Bitmap(hostImage);
            Bitmap tmpSecretImage = new Bitmap(secretImage);
            Color outputImgPixelColor;
            Color tmpSecretImgPixelColor;
            Color pixelNewColor;
            int width = OutputImage.Width;
            int height = OutputImage.Height;
            byte outputImgbits = (byte)(255 << NumberOfBits);
            byte secretImgbits = (byte)(255 >> (8 - NumberOfBits));

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    outputImgPixelColor = OutputImage.GetPixel(x, y);
                    tmpSecretImgPixelColor = tmpSecretImage.GetPixel(x, y);

                    pixelNewColor = Color.FromArgb((outputImgPixelColor.R & outputImgbits) | (tmpSecretImgPixelColor.R & secretImgbits),
                                                   (outputImgPixelColor.G & outputImgbits) | (tmpSecretImgPixelColor.G & secretImgbits),
                                                   (outputImgPixelColor.B & outputImgbits) | (tmpSecretImgPixelColor.B & secretImgbits));

                    OutputImage.SetPixel(x, y, pixelNewColor);
                }
            }
        }

        internal void LSB_MSB()
        {
            OutputImage = new Bitmap(hostImage);
            Bitmap tmpSecretImage = new Bitmap(secretImage);
            Color outputImgPixelColor;
            Color tmpSecretImgPixelColor;
            Color pixelNewColor;
            int width = OutputImage.Width;
            int height = OutputImage.Height;
            byte outputImgbits = (byte)(255 << NumberOfBits);
            byte secretImgbits = (byte)(255 << (8 - NumberOfBits));

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    outputImgPixelColor = OutputImage.GetPixel(x, y);
                    tmpSecretImgPixelColor = tmpSecretImage.GetPixel(x, y);
                    tmpSecretImgPixelColor = Color.FromArgb(tmpSecretImgPixelColor.R >> (8 - NumberOfBits),
                                                            tmpSecretImgPixelColor.G >> (8 - NumberOfBits),
                                                            tmpSecretImgPixelColor.B >> (8 - NumberOfBits));
                    pixelNewColor = Color.FromArgb((outputImgPixelColor.R & outputImgbits) | (tmpSecretImgPixelColor.R & secretImgbits),
                                                   (outputImgPixelColor.G & outputImgbits) | (tmpSecretImgPixelColor.G & secretImgbits),
                                                   (outputImgPixelColor.B & outputImgbits) | (tmpSecretImgPixelColor.B & secretImgbits));

                    OutputImage.SetPixel(x, y, pixelNewColor);
                }
            }
        }
    }
}
