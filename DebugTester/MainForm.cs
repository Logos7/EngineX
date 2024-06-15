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
            r.DrawRectangle(10, 10, 210, 210,Color.Blue);
            pbCanvas.Refresh();
        }
    }
}