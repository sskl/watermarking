using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WeifenLuo.WinFormsUI.Docking;

namespace Watermarking
{
    public partial class AnalysisForm : DockContent
    {
        private int outputImageHash = 0;

        public AnalysisForm()
        {
            InitializeComponent();
        }

        internal void SetPSNR(Bitmap hostImage, Bitmap outputImage)
        {
            if (outputImage != null)
            {
                if (outputImageHash == outputImage.GetHashCode())
                {
                    return;
                }
                outputImageHash = outputImage.GetHashCode();
                outputImgPropertyGrid.SelectedObject = new PSNR(hostImage, outputImage);
                outputImgPropertyGrid.ExpandAllGridItems();
            }
            else
            {
                outputImgPropertyGrid.SelectedObject = null;
            }

            return;
        }

        internal void Clear()
        {
            outputImgPropertyGrid.SelectedObject = null;
        }

    }

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
            r.MSE = r.sum / (double)(m * n);
            g.MSE = g.sum / (double)(m * n);
            b.MSE = b.sum / (double)(m * n);
            gray.MSE = gray.sum / (double)(m * n);

            r.PSNR = 20 * Math.Log10(255) - 10 * Math.Log10(r.MSE);
            g.PSNR = 20 * Math.Log10(255) - 10 * Math.Log10(g.MSE);
            b.PSNR = 20 * Math.Log10(255) - 10 * Math.Log10(b.MSE);
            gray.PSNR = 20 * Math.Log10(255) - 10 * Math.Log10(gray.MSE);
        }

        private int ConvertGray(Color color)
        {
            return (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
        }
    }
}
