using EngineX;
using System.Drawing.Imaging;

namespace DebugTester
{
    public partial class MainForm : Form
    {
        Bitmap m_bitmap;
        Rasterizer r;

        public MainForm()
        {
            InitializeComponent();

            m_bitmap = new Bitmap(pbCanvas.Width, pbCanvas.Height, PixelFormat.Format32bppRgb);
            pbCanvas.Image = m_bitmap;

            r = new Rasterizer(m_bitmap);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < pbCanvas.Width; i++)
            {
                int y = pbCanvas.Height / 2 + (int)(50.0*Math.Sin(0.06*i));

                r.SetPixel(i, y, Color.Azure);
            }
            r.Line(1, 1, 100, 100);

            pbCanvas.Refresh();
        }
    }
}