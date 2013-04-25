using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using WeifenLuo.WinFormsUI.Docking;

namespace Watermarking
{
    public partial class PropertiesForm : DockContent
    {
        private int hostImageHash = 0;
        private int secretImageHash = 0;
        private int outputImageHash = 0;

        public PropertiesForm()
        {
            InitializeComponent();
        }

        internal void SetProperties(Bitmap hostImage, Bitmap secretImage, Bitmap outputImage)
        {
            if (hostImage != null)
            {
                if (hostImageHash == hostImage.GetHashCode())
                {
                    return;
                }
                hostImageHash = hostImage.GetHashCode();
                hostImgPropertyGrid.SelectedObject = new ImageProperties(hostImage);
                hostImgPropertyGrid.ExpandAllGridItems();
            }
            else
            {
                hostImgPropertyGrid.SelectedObject = null;
            }

            if (secretImage != null)
            {
                if (secretImageHash == secretImage.GetHashCode())
                {
                    return;
                }
                secretImageHash = secretImage.GetHashCode();
                secretImgPropertyGrid.SelectedObject = new ImageProperties(secretImage);
                secretImgPropertyGrid.ExpandAllGridItems();
            }
            else
            {
                secretImgPropertyGrid.SelectedObject = null;
            }

            if (outputImage != null)
            {
                if (outputImageHash == outputImage.GetHashCode())
                {
                    return;
                }
                outputImageHash = outputImage.GetHashCode();
                outputImgPropertyGrid.SelectedObject = new ImageProperties(outputImage);
                outputImgPropertyGrid.ExpandAllGridItems();
            }
            else
            {
                outputImgPropertyGrid.SelectedObject = null;
            }

            return;
        }
    }

    public class ImageProperties
    {
        private Bitmap image;

        [Category("Dimension")]
        public int Width
        {
            get { return image.Width; }
        }
        [Category("Dimension")]
        public int Height
        {
            get { return image.Height; }
        }
        [Category("Dimension")]
        public int PixelCount
        {
            get { return image.Width * image.Height; }
        }

        [Category("Resolution")]
        public float Horizontal
        {
            get { return image.HorizontalResolution; }
        }
        [Category("Resolution")]
        public float Vertical
        {
            get { return image.VerticalResolution; }
        }

        [Category("Format")]
        public ImageFormat ImageFormat
        {
            get { return image.RawFormat; }
        }
        [Category("Format")]
        public PixelFormat PixelFormat
        {
            get { return image.PixelFormat; }
        }

        public ImageProperties()
        {
        }

        public ImageProperties(Bitmap image)
        {
            this.image = image;
            
        }
    }
}
