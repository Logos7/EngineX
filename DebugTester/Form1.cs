using EngineX;
using System.Drawing.Imaging;

namespace DebugTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            pbCanvas.Image = new Bitmap(pbCanvas.Width, pbCanvas.Height, PixelFormat.Format32bppRgb);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            (pbCanvas.Image as Bitmap).SetPixel(10, 20, Color.Azure);
            pbCanvas.Refresh();

        }
    }
}