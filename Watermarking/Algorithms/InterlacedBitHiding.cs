using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Watermarking.Algorithms
{
    class InterlacedBitHiding
    {
        private Bitmap hostImage;
        public Bitmap HostImage
        {
            get { return hostImage; }
            set { hostImage = value; }
        }

        private Bitmap secretImage;
        public Bitmap SecretImage
        {
            get { return secretImage; }
            set { secretImage = value; }
        }

        private Bitmap outputImage;
        public Bitmap OutputImage
        {
            get { return outputImage; }
            set { outputImage = value; }
        }

        public InterlacedBitHiding(Bitmap hostImage, Bitmap secretImage)
        {
            if (secretImage.Width > hostImage.Width || secretImage.Height > hostImage.Height || secretImage.Width < hostImage.Width || secretImage.Height < hostImage.Height)
                throw new Exception("Secret image must be equal to host image.");
            
            this.hostImage = hostImage;
            this.secretImage = secretImage;
        }

        public InterlacedBitHiding(Bitmap outputImage)
        {
            this.outputImage = outputImage;
        }

        public void saveOutputImage(String path, String filename)
        {
            OutputImage.Save(path + filename, ImageFormat.Bmp);
            OutputImage.Dispose();
        }

        internal void Odd_Even()
        {
            Color hostImgPixelColor;
            Color secretImgPixelColor;
            Color newPixelColor;
            int width = HostImage.Width;
            int height = HostImage.Height;
            OutputImage = new Bitmap(width, height);
            byte hostImgbits = (byte)170;
            byte secretImgbits = (byte)85;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    hostImgPixelColor = HostImage.GetPixel(x, y);
                    secretImgPixelColor = SecretImage.GetPixel(x, y);

                    newPixelColor = Color.FromArgb((hostImgPixelColor.R & hostImgbits) | (secretImgPixelColor.R & secretImgbits),
                                                   (hostImgPixelColor.G & hostImgbits) | (secretImgPixelColor.G & secretImgbits),
                                                   (hostImgPixelColor.B & hostImgbits) | (secretImgPixelColor.B & secretImgbits));

                    OutputImage.SetPixel(x, y, newPixelColor);
                }
            }
        }

        internal void Reverse_Odd_Even()
        {
            Color outputImgPixelColor;
            Color newPixelColor;
            int width = OutputImage.Width;
            int height = OutputImage.Height;
            secretImage = new Bitmap(width, height);
            byte secretImgbits = (byte)85;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    outputImgPixelColor = outputImage.GetPixel(x, y);

                    newPixelColor = Color.FromArgb((outputImgPixelColor.R & secretImgbits),
                                                   (outputImgPixelColor.G & secretImgbits),
                                                   (outputImgPixelColor.B & secretImgbits));

                    secretImage.SetPixel(x, y, newPixelColor);
                }
            }
        }

        internal void Pair_Wise()
        {
            Color hostImgPixelColor;
            Color secretImgPixelColor;
            Color newPixelColor;
            int width = HostImage.Width;
            int height = HostImage.Height;
            OutputImage = new Bitmap(width, height);
            byte hostImgbits = (byte)204;
            byte secretImgbits = (byte)51;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    hostImgPixelColor = HostImage.GetPixel(x, y);
                    secretImgPixelColor = SecretImage.GetPixel(x, y);

                    newPixelColor = Color.FromArgb((hostImgPixelColor.R & hostImgbits) | (secretImgPixelColor.R & secretImgbits),
                                                   (hostImgPixelColor.G & hostImgbits) | (secretImgPixelColor.G & secretImgbits),
                                                   (hostImgPixelColor.B & hostImgbits) | (secretImgPixelColor.B & secretImgbits));

                    OutputImage.SetPixel(x, y, newPixelColor);
                }
            }
        }

        internal void Reverse_Pair_Wise()
        {
            Color outputImgPixelColor;
            Color newPixelColor;
            int width = OutputImage.Width;
            int height = OutputImage.Height;
            secretImage = new Bitmap(width, height);
            byte secretImgbits = (byte)51;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    outputImgPixelColor = outputImage.GetPixel(x, y);

                    newPixelColor = Color.FromArgb((outputImgPixelColor.R & secretImgbits),
                                                   (outputImgPixelColor.G & secretImgbits),
                                                   (outputImgPixelColor.B & secretImgbits));

                    secretImage.SetPixel(x, y, newPixelColor);
                }
            }
        }
    }
}
