using System.Data;
using System.Drawing;
using Watermarking.Algorithms;
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

        internal void SetPSNRForDataGrid(DataTable dt)
        {
            PSNRDataGridView.DataSource = dt;
        }

        internal void Clear()
        {
            outputImgPropertyGrid.SelectedObject = null;
            outputImgPropertyGrid.Refresh();
        }

    }
}
