using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WeifenLuo.WinFormsUI.Docking;

namespace Watermarking
{
    public partial class HistogramForm : DockContent
    {
        private int hostImageHash = 0;
        private int secretImageHash = 0;
        private int outputImageHash = 0;
        private Series[] hostImageSeries = new Series[4];
        private Series[] secretImageSeries = new Series[4];
        private Series[] outputImageSeries = new Series[4];

        public HistogramForm()
        {
            InitializeComponent();
        }

        internal void SetHistograms(Bitmap hostImage, Bitmap secretImage, Bitmap outputImage)
        {
            if (hostImage != null)
            {
                if (hostImageHash == hostImage.GetHashCode())
                {
                    return;
                }
                hostImageHash = hostImage.GetHashCode();
                CreateSeries(ref hostImageSeries, hostImage, "HostImageChartArea");
                hostImageComboBox.Enabled = true;
                hostImageComboBox.SelectedIndex = 0;
            }
            else
            {
                hostImageChart.Series.Clear();
            }

            if (secretImage != null)
            {
                if (secretImageHash == secretImage.GetHashCode())
                {
                    return;
                }
                secretImageHash = secretImage.GetHashCode();
                CreateSeries(ref secretImageSeries, secretImage, "SecretImageChartArea");
                secretImageComboBox.Enabled = true;
                secretImageComboBox.SelectedIndex = 0;
            }
            else
            {
                secretImageChart.Series.Clear();
            }

            if (outputImage != null)
            {
                if (outputImageHash == outputImage.GetHashCode())
                {
                    return;
                }
                outputImageHash = outputImage.GetHashCode();
                CreateSeries(ref outputImageSeries, outputImage, "OutputImageChartArea");
                outputImageComboBox.Enabled = true;
                outputImageComboBox.SelectedIndex = 0;
            }
            else
            {
                outputImageChart.Series.Clear();
            }

            if (hostImage != null && secretImage != null && outputImage != null)
                allImageComboBox.Enabled = true;

            return;
        }

        private static void CreateSeries(ref Series[] imageSeries, Bitmap image, string chartArea)
        {
            imageSeries[0] = new Series();
            imageSeries[1] = new Series();
            imageSeries[2] = new Series();
            imageSeries[3] = new Series();
            imageSeries[0].ChartArea = chartArea;
            imageSeries[1].ChartArea = chartArea;
            imageSeries[2].ChartArea = chartArea;
            imageSeries[3].ChartArea = chartArea;
            imageSeries[0].ChartType = SeriesChartType.Range;
            imageSeries[1].ChartType = SeriesChartType.Range;
            imageSeries[2].ChartType = SeriesChartType.Range;
            imageSeries[3].ChartType = SeriesChartType.Range;
            imageSeries[0].Color = System.Drawing.Color.Red;
            imageSeries[1].Color = System.Drawing.Color.Green;
            imageSeries[2].Color = System.Drawing.Color.Blue;
            imageSeries[3].Color = System.Drawing.Color.Gray;

            Histogram imageHistogram = new Histogram(image);

            for (int key = 0; key < imageHistogram.R.Length; ++key)
                imageSeries[0].Points.AddXY(key, imageHistogram.R[key]);

            for (int key = 0; key < imageHistogram.G.Length; ++key)
                imageSeries[1].Points.AddXY(key, imageHistogram.G[key]);

            for (int key = 0; key < imageHistogram.B.Length; ++key)
                imageSeries[2].Points.AddXY(key, imageHistogram.B[key]);

            for (int key = 0; key < imageHistogram.Gray.Length; ++key)
                imageSeries[3].Points.AddXY(key, imageHistogram.Gray[key]);
        }

        private void hostImageComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (hostImageChart.Series.Count > 0)
                    hostImageChart.Series.RemoveAt(0);
                hostImageChart.Series.Add(hostImageSeries[hostImageComboBox.SelectedIndex]);
            }
            catch { }
        }

        private void secretImageComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (secretImageChart.Series.Count > 0)
                    secretImageChart.Series.RemoveAt(0);
                secretImageChart.Series.Add(secretImageSeries[secretImageComboBox.SelectedIndex]);
            }
            catch { }
        }

        private void outputImageComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (outputImageChart.Series.Count > 0)
                    outputImageChart.Series.RemoveAt(0);
                outputImageChart.Series.Add(outputImageSeries[outputImageComboBox.SelectedIndex]);
            }
            catch { }
        }

        private void allImageComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (hostImageChart.Series.Count > 0)
                    hostImageChart.Series.RemoveAt(0);
                if (secretImageChart.Series.Count > 0)
                    secretImageChart.Series.RemoveAt(0);
                if (outputImageChart.Series.Count > 0)
                    outputImageChart.Series.RemoveAt(0);
                hostImageChart.Series.Add(hostImageSeries[allImageComboBox.SelectedIndex]);
                secretImageChart.Series.Add(secretImageSeries[allImageComboBox.SelectedIndex]);
                outputImageChart.Series.Add(outputImageSeries[allImageComboBox.SelectedIndex]);
            }
            catch { }
        }

        private void hostImageChart_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                int cursorX = Convert.ToInt32(hostImageChart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X));
                DataPoint dp = hostImageChart.Series[0].Points[cursorX];
                hostImageChart.Series[0].ToolTip = "Level : " + cursorX + Environment.NewLine + "Count : " + dp.YValues[0];
            }
            catch { }
        }

        private void secretImageChart_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
               int cursorX = Convert.ToInt32(secretImageChart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X));
                DataPoint dp = hostImageChart.Series[0].Points[cursorX];
                secretImageChart.Series[0].ToolTip = "Level : " + cursorX + Environment.NewLine + "Count : " + dp.YValues[0];
            }
            catch { }
        }

        private void outputImageChart_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                int cursorX = Convert.ToInt32(outputImageChart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X));
                DataPoint dp = hostImageChart.Series[0].Points[cursorX];
                outputImageChart.Series[0].ToolTip = "Level : " + cursorX + Environment.NewLine + "Count : " + dp.YValues[0];
            }
            catch { }
        }

        internal void Clear()
        {
            try
            {
                hostImageChart.Series.RemoveAt(0);
                secretImageChart.Series.RemoveAt(0);
                outputImageChart.Series.RemoveAt(0);
            }
            catch { }
        }

        private void hostImageChart_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
        }

        private void hostImageChart_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void secretImageChart_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
        }

        private void secretImageChart_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void outputImageChart_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
        }

        private void outputImageChart_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
    }

    public class Histogram
    {
        private Bitmap image;
        public Bitmap Image
        {
            get { return image;  }
        }

        private int[] gray = new int[256];
        public int[] Gray
        {
            get { return gray; }
        }

        private int[] r = new int[256];
        public int[] R
        {
            get { return r; }
        }

        private int[] g = new int[256];
        public int[] G
        {
            get { return g; }
        }

        private int[] b = new int[256];
        public int[] B
        {
            get { return b; }
        }

        public Histogram(Bitmap img)
        {
            this.image = img;
            int width = image.Width;
            int height = image.Height;
            byte Red, Green, Blue;
            Color pixelColor;

            for (int i = 0, j; i < width; i++)
            {
                for (j = 0; j < height; j++)
                {
                    pixelColor = image.GetPixel(i, j);
                    Red = pixelColor.R;
                    Green = pixelColor.G;
                    Blue = pixelColor.B;
                    ++gray[(int)(0.114 * Blue + 0.587 * Green + 0.299 * Red)];
                    ++r[Red];
                    ++g[Green];
                    ++b[Blue];
                }
            }

        }
    }
}
