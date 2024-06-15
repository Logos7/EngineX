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
            r.Clear();

            Random random = new Random();

            int numberOfEllipses = 30;

            for (int i = 0; i < numberOfEllipses; i++)
            {
                int x = random.Next(0, m_bitmap.Width);
                int y = random.Next(0, m_bitmap.Height);

                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

                r.WiredEllipse(x, y, 15, 10, randomColor);
            }

            pbCanvas.Refresh();
        }
    }
}