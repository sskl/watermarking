﻿using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Watermarking.Algorithms
{

    class LSBHiding
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

        public LSBHiding(Bitmap outputImage)
        {
            this.outputImage = outputImage;
        }

        public void saveOutputImage(String path, String filename)
        {
            OutputImage.Save(path + filename, ImageFormat.Bmp);
            OutputImage.Dispose();
        }

        internal void LSB_LSB()
        {
            OutputImage = new Bitmap(HostImage);
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

        internal void Reverse_LSB_LSB()
        {
            secretImage = new Bitmap(outputImage);
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

                    secretImage.SetPixel(x, y, pixelNewColor);
                }
            }
        }

        internal void LSB_MSB()
        {
            OutputImage = new Bitmap(HostImage);
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

                    pixelNewColor = Color.FromArgb((outputImgPixelColor.R & outputImgbits) | (tmpSecretImgPixelColor.R),
                                                   (outputImgPixelColor.G & outputImgbits) | (tmpSecretImgPixelColor.G),
                                                   (outputImgPixelColor.B & outputImgbits) | (tmpSecretImgPixelColor.B));

                    OutputImage.SetPixel(x, y, pixelNewColor);
                }
            }
        }

        internal void Reverse_LSB_MSB()
        {
            secretImage = new Bitmap(outputImage);
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

                    secretImage.SetPixel(x, y, pixelNewColor);
                }
            }
        }
    }
}
