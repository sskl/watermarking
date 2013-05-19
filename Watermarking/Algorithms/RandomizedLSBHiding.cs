using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Watermarking.Algorithms
{

    class RandomizedLSBHiding
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

        private int numberOfRndNumbers = 1;
        public int NumberOfRndNumbers
        {
            get { return numberOfRndNumbers; }
            set { numberOfRndNumbers = value; }
        }

        private String direction = String.Empty;
        public String Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        private List<int> rndNumbers = new List<int>();
        public List<int> RndNumbers
        {
            get { return rndNumbers; }
            set { rndNumbers = value; }
        }
        private int modNumber = 0;
        public int ModNumber
        {
            get { return modNumber; }
            set { modNumber = value; }
        }

        public RandomizedLSBHiding(Bitmap hostImage, Bitmap secretImage, int numberOfRndNumbers, string direction)
        {
            if (secretImage.Width > hostImage.Width || secretImage.Height > hostImage.Height)
                throw new Exception("Secret image must be small than host image.");
            
            HostImage = hostImage;
            SecretImage = secretImage;
            NumberOfRndNumbers = numberOfRndNumbers;
            Direction = direction;

            if (NumberOfRndNumbers < 1)
            {
                NumberOfRndNumbers = 1;
            }
            else if (NumberOfRndNumbers > SecretImage.Width || NumberOfRndNumbers > SecretImage.Height)
            {
                if (Direction == "Horizontally")
                {
                    NumberOfRndNumbers = SecretImage.Width;
                }
                else if (Direction == "Vertically")
                {
                    NumberOfRndNumbers = SecretImage.Height;
                }
            }

            if (Direction == "Horizontally")
            {
                ModNumber = SecretImage.Width;
            }
            else if (Direction == "Vertically")
            {
                ModNumber = SecretImage.Height;
            }
        }

        public RandomizedLSBHiding(Bitmap outputImage, int numberOfRndNumbers, string direction)
        {
            OutputImage = outputImage;
            NumberOfRndNumbers = numberOfRndNumbers;
            Direction = direction;

            if (NumberOfRndNumbers < 1)
            {
                NumberOfRndNumbers = 1;
            }
            else if (NumberOfRndNumbers > OutputImage.Width || NumberOfRndNumbers > OutputImage.Height)
            {
                if (Direction == "Horizontally")
                {
                    NumberOfRndNumbers = OutputImage.Width;
                }
                else if (Direction == "Vertically")
                {
                    NumberOfRndNumbers = OutputImage.Height;
                }
            }

            if (Direction == "Horizontally")
            {
                ModNumber = OutputImage.Width;
            }
            else if (Direction == "Vertically")
            {
                ModNumber = OutputImage.Height;
            }
        }

        public void saveOutputImage(String path, String filename)
        {
            OutputImage.Save(path + filename, ImageFormat.Bmp);
            OutputImage.Dispose();
        }

        public void GenerateRandomNumbers()
        {
            Random rnd = new Random(NumberOfRndNumbers);

            int rndNumber = rnd.Next() % ModNumber;
            for (int i = 0; i < NumberOfRndNumbers; i++)
            {
                if (RndNumbers.Contains(rndNumber))
                {
                    i--;
                    rndNumber = (rndNumber + 1) % ModNumber;
                    continue;
                }
                RndNumbers.Add(rndNumber);
                rndNumber = (rndNumber + rnd.Next()) % ModNumber;
            }
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

            if (Direction == "Horizontally")
            {
                for (int x = 0; x < NumberOfRndNumbers; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        outputImgPixelColor = HostImage.GetPixel(RndNumbers[x], y);
                        tmpSecretImgPixelColor = tmpSecretImage.GetPixel(RndNumbers[x], y);

                        pixelNewColor = Color.FromArgb((outputImgPixelColor.R & outputImgbits) | (tmpSecretImgPixelColor.R & secretImgbits),
                                                       (outputImgPixelColor.G & outputImgbits) | (tmpSecretImgPixelColor.G & secretImgbits),
                                                       (outputImgPixelColor.B & outputImgbits) | (tmpSecretImgPixelColor.B & secretImgbits));
                        OutputImage.SetPixel(RndNumbers[x], y, pixelNewColor);
                    }
                }
            }
            else if (Direction == "Vertically")
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < NumberOfRndNumbers; y++)
                    {
                        outputImgPixelColor = HostImage.GetPixel(x, RndNumbers[y]);
                        tmpSecretImgPixelColor = tmpSecretImage.GetPixel(x, RndNumbers[y]);

                        pixelNewColor = Color.FromArgb((outputImgPixelColor.R & outputImgbits) | (tmpSecretImgPixelColor.R & secretImgbits),
                                                       (outputImgPixelColor.G & outputImgbits) | (tmpSecretImgPixelColor.G & secretImgbits),
                                                       (outputImgPixelColor.B & outputImgbits) | (tmpSecretImgPixelColor.B & secretImgbits));

                        OutputImage.SetPixel(x, RndNumbers[y], pixelNewColor);
                    }
                }
            }
        }

        internal void Reverse_LSB_LSB()
        {
            Color outputImgPixelColor;
            Color pixelNewColor;
            int width = outputImage.Width;
            int height = outputImage.Height;
            secretImage = new Bitmap(width, height);
            byte secretImgbits = (byte)(255 >> (8 - NumberOfBits));

            if (Direction == "Horizontally")
            {
                for (int x = 0; x < NumberOfRndNumbers; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        outputImgPixelColor = outputImage.GetPixel(RndNumbers[x], y);

                        pixelNewColor = Color.FromArgb((outputImgPixelColor.R & secretImgbits),
                                                       (outputImgPixelColor.G & secretImgbits),
                                                       (outputImgPixelColor.B & secretImgbits));

                        secretImage.SetPixel(RndNumbers[x], y, pixelNewColor);
                    }
                }
            }
            else if (Direction == "Vertically")
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < NumberOfRndNumbers; y++)
                    {
                        outputImgPixelColor = outputImage.GetPixel(x, RndNumbers[y]);

                        pixelNewColor = Color.FromArgb((outputImgPixelColor.R & secretImgbits),
                                                       (outputImgPixelColor.G & secretImgbits),
                                                       (outputImgPixelColor.B & secretImgbits));

                        secretImage.SetPixel(x, RndNumbers[y], pixelNewColor);
                    }
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

            if (Direction == "Horizontally")
            {
                for (int x = 0; x < NumberOfRndNumbers; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        outputImgPixelColor = HostImage.GetPixel(RndNumbers[x], y);
                        tmpSecretImgPixelColor = tmpSecretImage.GetPixel(RndNumbers[x], y);
                        tmpSecretImgPixelColor = Color.FromArgb(tmpSecretImgPixelColor.R >> (8 - NumberOfBits),
                                                                tmpSecretImgPixelColor.G >> (8 - NumberOfBits),
                                                                tmpSecretImgPixelColor.B >> (8 - NumberOfBits));

                        pixelNewColor = Color.FromArgb((outputImgPixelColor.R & outputImgbits) | (tmpSecretImgPixelColor.R),
                                                       (outputImgPixelColor.G & outputImgbits) | (tmpSecretImgPixelColor.G),
                                                       (outputImgPixelColor.B & outputImgbits) | (tmpSecretImgPixelColor.B));

                        OutputImage.SetPixel(RndNumbers[x], y, pixelNewColor);
                    }
                }
            }
            else if (Direction == "Vertically")
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < NumberOfRndNumbers; y++)
                    {
                        outputImgPixelColor = HostImage.GetPixel(x, RndNumbers[y]);
                        tmpSecretImgPixelColor = tmpSecretImage.GetPixel(x, RndNumbers[y]);
                        tmpSecretImgPixelColor = Color.FromArgb(tmpSecretImgPixelColor.R >> (8 - NumberOfBits),
                                                                tmpSecretImgPixelColor.G >> (8 - NumberOfBits),
                                                                tmpSecretImgPixelColor.B >> (8 - NumberOfBits));

                        pixelNewColor = Color.FromArgb((outputImgPixelColor.R & outputImgbits) | (tmpSecretImgPixelColor.R),
                                                       (outputImgPixelColor.G & outputImgbits) | (tmpSecretImgPixelColor.G),
                                                       (outputImgPixelColor.B & outputImgbits) | (tmpSecretImgPixelColor.B));

                        OutputImage.SetPixel(x, RndNumbers[y], pixelNewColor);
                    }
                }
            }
        }

        internal void Reverse_LSB_MSB()
        {
            Color outputImgPixelColor;
            Color pixelNewColor;
            int width = outputImage.Width;
            int height = outputImage.Height;
            secretImage = new Bitmap(width, height);
            byte secretImgbits = (byte)(255 >> (8 - NumberOfBits));


            if (Direction == "Horizontally")
            {
                for (int x = 0; x < NumberOfRndNumbers; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        outputImgPixelColor = outputImage.GetPixel(RndNumbers[x], y);

                        pixelNewColor = Color.FromArgb(((outputImgPixelColor.R & secretImgbits) << (8 - NumberOfBits)),
                                                       ((outputImgPixelColor.G & secretImgbits) << (8 - NumberOfBits)),
                                                       ((outputImgPixelColor.B & secretImgbits) << (8 - NumberOfBits)));

                        secretImage.SetPixel(RndNumbers[x], y, pixelNewColor);
                    }
                }
            }
            else if (Direction == "Vertically")
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < NumberOfRndNumbers; y++)
                    {
                        outputImgPixelColor = outputImage.GetPixel(x, RndNumbers[y]);

                        pixelNewColor = Color.FromArgb(((outputImgPixelColor.R & secretImgbits) << (8 - NumberOfBits)),
                                                       ((outputImgPixelColor.G & secretImgbits) << (8 - NumberOfBits)),
                                                       ((outputImgPixelColor.B & secretImgbits) << (8 - NumberOfBits)));

                        secretImage.SetPixel(x, RndNumbers[y], pixelNewColor);
                    }
                }
            }
        }
    }
}
