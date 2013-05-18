using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Watermarking.Algorithms
{
    class VisualCryptography
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

        private Bitmap shareImage1;
        public Bitmap ShareImage1
        {
            get { return shareImage1; }
            set { shareImage1 = value; }
        }

        private Bitmap shareImage2;
        public Bitmap ShareImage2
        {
            get { return shareImage2; }
            set { shareImage2 = value; }
        }

        private int numberOfBits = 1;
        public int NumberOfBits
        {
            get { return numberOfBits; }
            set { numberOfBits = value; }
        }

        public VisualCryptography(Bitmap hostImage, Bitmap secretImage)
        {
            if (secretImage.Width > hostImage.Width || secretImage.Height > hostImage.Height)
            {
                throw new Exception("Secret image must be small than host image.");
            }

            if (secretImage.Width > (hostImage.Width / 2))
            {
                throw new Exception("Secret image width must be small than host image width.");
            }
            
            HostImage = hostImage;
            SecretImage = secretImage;
        }

        public VisualCryptography(Bitmap outputImage)
        {
            OutputImage = outputImage;
        }

        public void CreateShareImages()
        {
            int width = SecretImage.Width;
            int height = SecretImage.Height;
            int index;
            Color pixelColor;
            shareImage1 = new Bitmap(width * 2, height, PixelFormat.Format24bppRgb);
            shareImage2 = new Bitmap(width * 2, height, PixelFormat.Format24bppRgb);
            Random rand = new Random();

            ConvertBitmap();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    index = rand.Next(2);
                    pixelColor = SecretImage.GetPixel(x, y);
                 
                    if (pixelColor.Name == "ffffffff")
                    {
                        if (index == 0)
                        {
                            shareImage1.SetPixel(x * 2, y, Color.Black);
                            shareImage1.SetPixel(x * 2 + 1, y, Color.White);
                            shareImage2.SetPixel(x * 2, y, Color.Black);
                            shareImage2.SetPixel(x * 2 + 1, y, Color.White);
                        }
                        else
                        {
                            shareImage1.SetPixel(x * 2, y, Color.White);
                            shareImage1.SetPixel(x * 2 + 1, y, Color.Black);
                            shareImage2.SetPixel(x * 2, y, Color.White);
                            shareImage2.SetPixel(x * 2 + 1, y, Color.Black);
                        }
                    }
                    else
                    {
                        if (index == 0)
                        {
                            shareImage1.SetPixel(x * 2, y, Color.Black);
                            shareImage1.SetPixel(x * 2 + 1, y, Color.White);
                            shareImage2.SetPixel(x * 2, y, Color.White);
                            shareImage2.SetPixel(x * 2 + 1, y, Color.Black);
                        }
                        else
                        {
                            shareImage1.SetPixel(x * 2, y, Color.White);
                            shareImage1.SetPixel(x * 2 + 1, y, Color.Black);
                            shareImage2.SetPixel(x * 2, y, Color.Black);
                            shareImage2.SetPixel(x * 2+ 1, y, Color.White);
                        }
                    }
                }
            }
            CreateSecretImage();
        }

        public void CreateSecretImage()
        {
            int width = ShareImage1.Width;
            int height = ShareImage1.Height;
            Color pixelColor1, pixelColor2, newPixelColor;

            Bitmap tempSecretImage = new Bitmap(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    pixelColor1 = ShareImage1.GetPixel(x, y);
                    if (pixelColor1.R > 0)
                    {
                        pixelColor1 = Color.White;
                    }
                    pixelColor2 = ShareImage2.GetPixel(x, y);
                    newPixelColor = Color.FromArgb(pixelColor1.R | pixelColor2.R,
                                                   pixelColor1.G | pixelColor2.G,
                                                   pixelColor1.B | pixelColor2.B);
                    tempSecretImage.SetPixel(x, y, newPixelColor);
                }
            }
            SecretImage = (Bitmap)tempSecretImage.Clone();
        }

        private void ConvertBitmap()
        {
            int width = SecretImage.Width;
            int height = SecretImage.Height;
            Color pixelColor;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    pixelColor = SecretImage.GetPixel(i, j);

                    if (ConvertGray(pixelColor) < 128)
                    {
                        pixelColor = Color.Black;
                    }
                    else
                    {
                        pixelColor = Color.White;
                    }

                    SecretImage.SetPixel(i, j, pixelColor);
                }
            }
        }

        private int ConvertGray(Color color)
        {
            return (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
        }

        internal void LSB_LSB()
        {
            OutputImage = new Bitmap(hostImage);
            Color outputImgPixelColor;
            Color tmpShareImg1PixelColor;
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
                    tmpShareImg1PixelColor = ShareImage1.GetPixel(x, y);

                    pixelNewColor = Color.FromArgb((outputImgPixelColor.R & outputImgbits) | (tmpShareImg1PixelColor.R & secretImgbits),
                                                   (outputImgPixelColor.G & outputImgbits) | (tmpShareImg1PixelColor.G & secretImgbits),
                                                   (outputImgPixelColor.B & outputImgbits) | (tmpShareImg1PixelColor.B & secretImgbits));

                    OutputImage.SetPixel(x, y, pixelNewColor);
                }
            }
        }

        internal void Reverse_LSB_LSB()
        {
            shareImage1 = new Bitmap(outputImage);
            Color outputImgPixelColor;
            Color pixelNewColor;
            int width = outputImage.Width;
            int height = outputImage.Height;
            byte secretImgbits = (byte)(255 >> (8 - NumberOfBits));

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    outputImgPixelColor = outputImage.GetPixel(x, y);

                    pixelNewColor = Color.FromArgb((outputImgPixelColor.R & secretImgbits),
                                                   (outputImgPixelColor.G & secretImgbits),
                                                   (outputImgPixelColor.B & secretImgbits));

                    shareImage1.SetPixel(x, y, pixelNewColor);
                }
            }
        }

        internal void LSB_MSB()
        {
            OutputImage = new Bitmap(hostImage);
            Bitmap tmpShareImage1 = new Bitmap(shareImage1);
            Color outputImgPixelColor;
            Color tmpShareImg1PixelColor;
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
                    tmpShareImg1PixelColor = tmpShareImage1.GetPixel(x, y);
                    tmpShareImg1PixelColor = Color.FromArgb(tmpShareImg1PixelColor.R >> (8 - NumberOfBits),
                                                            tmpShareImg1PixelColor.G >> (8 - NumberOfBits),
                                                            tmpShareImg1PixelColor.B >> (8 - NumberOfBits));

                    pixelNewColor = Color.FromArgb((outputImgPixelColor.R & outputImgbits) | (tmpShareImg1PixelColor.R),
                                                   (outputImgPixelColor.G & outputImgbits) | (tmpShareImg1PixelColor.G),
                                                   (outputImgPixelColor.B & outputImgbits) | (tmpShareImg1PixelColor.B));

                    OutputImage.SetPixel(x, y, pixelNewColor);
                }
            }
        }

        internal void Reverse_LSB_MSB()
        {
            shareImage1 = new Bitmap(outputImage);
            Color outputImgPixelColor;
            Color pixelNewColor;
            int width = outputImage.Width;
            int height = outputImage.Height;
            byte secretImgbits = (byte)(255 >> (8 - NumberOfBits));

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    outputImgPixelColor = outputImage.GetPixel(x, y);

                    pixelNewColor = Color.FromArgb(((outputImgPixelColor.R & secretImgbits) << (8 - NumberOfBits)),
                                                   ((outputImgPixelColor.G & secretImgbits) << (8 - NumberOfBits)),
                                                   ((outputImgPixelColor.B & secretImgbits) << (8 - NumberOfBits)));

                    shareImage1.SetPixel(x, y, pixelNewColor);
                }
            }
        }

        public void saveShareImage1(String path, String filename)
        {
            ShareImage1.Save(path + filename, ImageFormat.Bmp);
        }

        public void saveShareImage2(String path, String filename)
        {
            ShareImage2.Save(path + filename, ImageFormat.Bmp);
            ShareImage2.Dispose();
        }

        public void saveOutputImage(String path, String filename)
        {
            OutputImage.Save(path + filename, ImageFormat.Bmp);
            OutputImage.Dispose();
        }
    }
}
