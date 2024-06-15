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

            int numberOfTriangles = 5;

            int minPosition = -100;
            int maxPositionX = m_bitmap.Width + 100;
            int maxPositionY = m_bitmap.Height + 100;

            for (int i = 0; i < numberOfTriangles; i++)
            {
                int x1 = random.Next(minPosition, maxPositionX);
                int y1 = random.Next(minPosition, maxPositionY);
                int x2 = random.Next(minPosition, maxPositionX);
                int y2 = random.Next(minPosition, maxPositionY);
                int x3 = random.Next(minPosition, maxPositionX);
                int y3 = random.Next(minPosition, maxPositionY);

                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

                r.Triangle(x1, y1, x2, y2, x3, y3, randomColor);
            }

            pbCanvas.Refresh();
        }
    }
}