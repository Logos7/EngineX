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
            Color c1 = Color.Aqua, c2 = Color.DarkGreen;
            r.Ellipse(100, 100, 70, 50, c1);
            r.WiredEllipse(200, 200, 50, 70, c2);
            pbCanvas.Refresh();
        }
    }
}