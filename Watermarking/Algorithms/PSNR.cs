using System;
using System.ComponentModel;
using System.Drawing;

namespace Watermarking.Algorithms
{

    public struct PSNRType
    {
        public double PSNR;
        public double MSE;
        public double sum;
    }

    public class PSNR
    {
        private PSNRType r;
        private PSNRType g;
        private PSNRType b;
        private PSNRType gray;

        [Category("PSNR")]
        public double R
        {
            get { return r.PSNR; }
        }
        [Category("PSNR")]
        public double G
        {
            get { return g.PSNR; }
        }
        [Category("PSNR")]
        public double B
        {
            get { return b.PSNR; }
        }
        [Category("PSNR")]
        public double Gray
        {
            get { return gray.PSNR; }
        }

        [Category("MSE")]
        public double R_
        {
            get { return r.MSE; }
        }
        [Category("MSE")]
        public double G_
        {
            get { return g.MSE; }
        }
        [Category("MSE")]
        public double B_
        {
            get { return b.MSE; }
        }
        [Category("MSE")]
        public double Gray_
        {
            get { return gray.MSE; }
        }

        public PSNR(Bitmap hostImage, Bitmap outputImage)
        {
            int m = outputImage.Width;
            int n = outputImage.Height;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    r.sum += Math.Pow((double)(hostImage.GetPixel(i, j).R - outputImage.GetPixel(i, j).R), 2.0);
                    g.sum += Math.Pow((double)(hostImage.GetPixel(i, j).G - outputImage.GetPixel(i, j).G), 2.0);
                    b.sum += Math.Pow((double)(hostImage.GetPixel(i, j).B - outputImage.GetPixel(i, j).B), 2.0);
                    gray.sum += Math.Pow((double)(ConvertGray(hostImage.GetPixel(i, j)) - ConvertGray(outputImage.GetPixel(i, j))), 2.0);
                }
            }
            r.MSE = Math.Round(r.sum / (double)(m * n), 2);
            g.MSE = Math.Round(g.sum / (double)(m * n), 2);
            b.MSE = Math.Round(b.sum / (double)(m * n), 2);
            gray.MSE = Math.Round(gray.sum / (double)(m * n), 2);

            //r.PSNR = Math.Round(10 * (Math.Log10(((2 * (m * n)) - 1) * 2 / r.MSE)), 2);
            //g.PSNR = Math.Round(10 * (Math.Log10(((2 * (m * n)) - 1) * 2 / g.MSE)), 2);
            //b.PSNR = Math.Round(20 * (Math.Log10(((2 * (m * n)) - 1) * 2 / b.MSE)), 2);
            //gray.PSNR = Math.Round(10 * (Math.Log10(((2 * (m * n)) - 1) * 2 / gray.MSE)), 2);

            r.PSNR = Math.Round(20 * Math.Log10(255) - 10 * Math.Log10(r.MSE), 2);
            g.PSNR = Math.Round(20 * Math.Log10(255) - 10 * Math.Log10(g.MSE), 2);
            b.PSNR = Math.Round(20 * Math.Log10(255) - 10 * Math.Log10(b.MSE), 2);
            gray.PSNR = Math.Round(20 * Math.Log10(255) - 10 * Math.Log10(gray.MSE), 2);
        }

        private int ConvertGray(Color color)
        {
            return (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
        }
    }

}
