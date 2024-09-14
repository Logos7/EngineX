using EngineX;
using EngineX.Daemons;
using EngineX.Mathematics;
using EngineX.Objects;
using System.Drawing.Imaging;

namespace DebugTester
{
    public partial class MainForm : Form
    {
        Bitmap m_bitmap;
        Rasterizer r;
        Renderer re;
        Scene3D s;
        Camera c;
        float time = 0;

        public MainForm()
        {
            InitializeComponent();

            m_bitmap = new Bitmap(pbCanvas.Width, pbCanvas.Height, PixelFormat.Format32bppRgb);
            pbCanvas.Image = m_bitmap;

            r = new Rasterizer(m_bitmap);
            re = new Renderer();
            s = new Scene3D();
            c = new Camera("cam");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var obj = new Object3D("obiekt");
            s._objects.Add(obj);

            Random random = new Random();

            int numberOfTriangles = 5;

            int minPosition = -100;
            int maxPositionX = m_bitmap.Width + 100;
            int maxPositionY = m_bitmap.Height + 100;

            int x1 = random.Next(minPosition, maxPositionX);
            int y1 = random.Next(minPosition, maxPositionY);
            int x2 = random.Next(minPosition, maxPositionX);
            int y2 = random.Next(minPosition, maxPositionY);
            int x3 = random.Next(minPosition, maxPositionX);
            int y3 = random.Next(minPosition, maxPositionY);

            Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

            obj.Vertices.Add(new Vector3(0, 1000, 0));
            obj.Vertices.Add(new Vector3(500, 0, 0));
            obj.Vertices.Add(new Vector3(-500, 0, 0));

            obj.Triangles.Add(new Triangle(0, 1, 2));
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            c.a = time;

            r.Clear();
            re.Render(s, r, c);
            pbCanvas.Refresh();

            time += 0.1f;
    }
}
}