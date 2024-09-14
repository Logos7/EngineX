using EngineX;
using EngineX.Daemons;
using EngineX.Mathematics;
using EngineX.Objects;
using System.Drawing.Imaging;
using System.Numerics;

namespace DebugTester
{
    public partial class MainForm : Form
    {
        float _globalTime;
        readonly Bitmap _bitmap;
        readonly Scene3D _scene;
        readonly Camera _camera;
        readonly Rasterizer _rasterizer;
        readonly Renderer _renderer;

        public MainForm()
        {
            InitializeComponent();

            _globalTime = 0;
            _bitmap = new Bitmap(pbCanvas.Width, pbCanvas.Height, PixelFormat.Format32bppRgb);
            pbCanvas.Image = _bitmap;
            _scene = new Scene3D();
            float aspectRatio = (float)_bitmap.Width / _bitmap.Height;
            _camera = new Camera(150, 20, aspectRatio);
            _rasterizer = new Rasterizer(_bitmap);
            _renderer = new Renderer(_scene, _rasterizer, _camera);

            Initialize4FaceObject();
            //InitializeCubeObject();
        }

        private void Initialize4FaceObject()
        {
            var obj = new Object3D();
            _scene._objects.Add(obj);

            Random random = new();

            // Mo¿esz ustawiæ ró¿ne kolory dla ka¿dej œciany, jeœli chcesz
            Color color1 = Color.LightBlue;
            Color color2 = Color.LightGreen;
            Color color3 = Color.LightCoral;
            Color color4 = Color.LightGoldenrodYellow;

            float a = 50; // D³ugoœæ krawêdzi czworoœcianu

            // Wspó³rzêdne wierzcho³ków czworoœcianu foremnego
            // Punkty s¹ rozmieszczone symetrycznie wokó³ œrodka uk³adu wspó³rzêdnych
            Vector3 v0 = new Vector3(0, 0, (float)(a * Math.Sqrt(6) / 3));
            Vector3 v1 = new Vector3(0, (float)(a * Math.Sqrt(3) / 3), 0);
            Vector3 v2 = new Vector3(-a / 2, (float)(-a * Math.Sqrt(3) / 6), 0);
            Vector3 v3 = new Vector3(a / 2, (float)(-a * Math.Sqrt(3) / 6), 0);

            // Dodanie wierzcho³ków do obiektu
            obj.Vertices.Add(v0); // Wierzcho³ek szczytowy
            obj.Vertices.Add(v1);
            obj.Vertices.Add(v2);
            obj.Vertices.Add(v3);

            // Definicja trójk¹tów (œcian czworoœcianu)
            obj.Triangles.Add(new Triangle(0, 1, 2, color1)); // Œciana przednia
            obj.Triangles.Add(new Triangle(0, 2, 3, color2)); // Œciana prawa
            obj.Triangles.Add(new Triangle(0, 3, 1, color3)); // Œciana lewa
            obj.Triangles.Add(new Triangle(1, 3, 2, color4)); // Podstawa
        }

        private void InitializeCubeObject()
        {
            var obj = new Object3D();
            _scene._objects.Add(obj);

            // Definicja kolorów dla ka¿dej œciany szeœcianu
            Color color1 = Color.LightBlue;
            Color color2 = Color.LightGreen;
            Color color3 = Color.LightCoral;
            Color color4 = Color.LightGoldenrodYellow;
            Color color5 = Color.LightPink;
            Color color6 = Color.LightSkyBlue;

            float a = 50; // D³ugoœæ krawêdzi szeœcianu

            // Wspó³rzêdne wierzcho³ków szeœcianu
            // Punkty s¹ rozmieszczone symetrycznie wokó³ œrodka uk³adu wspó³rzêdnych
            Vector3 v0 = new Vector3(-a / 2, -a / 2, -a / 2);
            Vector3 v1 = new Vector3(a / 2, -a / 2, -a / 2);
            Vector3 v2 = new Vector3(a / 2, a / 2, -a / 2);
            Vector3 v3 = new Vector3(-a / 2, a / 2, -a / 2);
            Vector3 v4 = new Vector3(-a / 2, -a / 2, a / 2);
            Vector3 v5 = new Vector3(a / 2, -a / 2, a / 2);
            Vector3 v6 = new Vector3(a / 2, a / 2, a / 2);
            Vector3 v7 = new Vector3(-a / 2, a / 2, a / 2);

            // Dodanie wierzcho³ków do obiektu
            obj.Vertices.Add(v0); // 0
            obj.Vertices.Add(v1); // 1
            obj.Vertices.Add(v2); // 2
            obj.Vertices.Add(v3); // 3
            obj.Vertices.Add(v4); // 4
            obj.Vertices.Add(v5); // 5
            obj.Vertices.Add(v6); // 6
            obj.Vertices.Add(v7); // 7

            // Definicja trójk¹tów (œcian szeœcianu)
            // Œciana przednia (v0, v1, v2, v3)
            obj.Triangles.Add(new Triangle(0, 1, 2, color1));
            obj.Triangles.Add(new Triangle(0, 2, 3, color1));

            // Œciana tylna (v4, v5, v6, v7)
            obj.Triangles.Add(new Triangle(5, 4, 7, color2));
            obj.Triangles.Add(new Triangle(5, 7, 6, color2));

            // Œciana lewa (v0, v3, v7, v4)
            obj.Triangles.Add(new Triangle(0, 3, 7, color3));
            obj.Triangles.Add(new Triangle(0, 7, 4, color3));

            // Œciana prawa (v1, v5, v6, v2)
            obj.Triangles.Add(new Triangle(1, 5, 6, color4));
            obj.Triangles.Add(new Triangle(1, 6, 2, color4));

            // Œciana dolna (v0, v4, v5, v1)
            obj.Triangles.Add(new Triangle(0, 4, 5, color5));
            obj.Triangles.Add(new Triangle(0, 5, 1, color5));

            // Œciana górna (v3, v2, v6, v7)
            obj.Triangles.Add(new Triangle(3, 2, 6, color6));
            obj.Triangles.Add(new Triangle(3, 6, 7, color6));
        }

        private void Initialize12FaceObject()
        {
            var obj = new Object3D();
            _scene._objects.Add(obj);

            // Lista wierzcho³ków dwunastoœcianu foremnego
            List<Vector3> vertices = new List<Vector3>();

            float phi = (1 + MathF.Sqrt(5)) / 2; // Z³ota liczba

            float a = 30; // Skalowanie dwunastoœcianu

            // Wierzcho³ki dwunastoœcianu
            vertices.Add(new Vector3(-1, -1, -1) * a);
            vertices.Add(new Vector3(-1, -1, 1) * a);
            vertices.Add(new Vector3(-1, 1, -1) * a);
            vertices.Add(new Vector3(-1, 1, 1) * a);
            vertices.Add(new Vector3(1, -1, -1) * a);
            vertices.Add(new Vector3(1, -1, 1) * a);
            vertices.Add(new Vector3(1, 1, -1) * a);
            vertices.Add(new Vector3(1, 1, 1) * a);

            vertices.Add(new Vector3(0, -phi, -1 / phi) * a);
            vertices.Add(new Vector3(0, -phi, 1 / phi) * a);
            vertices.Add(new Vector3(0, phi, -1 / phi) * a);
            vertices.Add(new Vector3(0, phi, 1 / phi) * a);

            vertices.Add(new Vector3(-phi, -1 / phi, 0) * a);
            vertices.Add(new Vector3(-phi, 1 / phi, 0) * a);
            vertices.Add(new Vector3(phi, -1 / phi, 0) * a);
            vertices.Add(new Vector3(phi, 1 / phi, 0) * a);

            vertices.Add(new Vector3(-1 / phi, 0, -phi) * a);
            vertices.Add(new Vector3(1 / phi, 0, -phi) * a);
            vertices.Add(new Vector3(-1 / phi, 0, phi) * a);
            vertices.Add(new Vector3(1 / phi, 0, phi) * a);

            // Dodanie wierzcho³ków do obiektu
            obj.Vertices.AddRange(vertices);

            // Definicja œcian (ka¿da jako lista indeksów wierzcho³ków)
            int[][] faces = new int[][]
            {
        new int[] {0, 8, 4, 17, 16},
        new int[] {0, 16, 2, 10, 12},
        new int[] {0, 12, 1, 13, 8},
        new int[] {8, 13, 9, 5, 4},
        new int[] {4, 5, 14, 15, 17},
        new int[] {2, 16, 17, 15, 6},
        new int[] {1, 12, 10, 3, 13},
        new int[] {5, 9, 19, 14, 4},
        new int[] {6, 15, 14, 19, 7},
        new int[] {3, 11, 18, 9, 13},
        new int[] {7, 19, 9, 18, 11},
        new int[] {2, 6, 7, 11, 10}
            };

            // Przypisanie kolorów do œcian
            Color[] colors = new Color[]
            {
        Color.LightBlue, Color.LightGreen, Color.LightCoral, Color.LightGoldenrodYellow,
        Color.LightPink, Color.LightSkyBlue, Color.LightSalmon, Color.LightSeaGreen,
        Color.LightSteelBlue, Color.LightSlateGray, Color.LightYellow, Color.LightCyan
            };

            // Podzia³ ka¿dej piêciok¹tnej œciany na trójk¹ty
            for (int i = 0; i < faces.Length; i++)
            {
                int[] face = faces[i];
                Color color = colors[i % colors.Length];

                // Dzielimy piêciok¹t na trójk¹ty (przyjmujemy, ¿e wierzcho³ki s¹ u³o¿one wokó³ œrodka)
                int v0 = face[0];
                for (int j = 1; j < face.Length - 1; j++)
                {
                    int v1 = face[j];
                    int v2 = face[j + 1];

                    obj.Triangles.Add(new Triangle(v0, v1, v2, color));
                }
            }
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            _renderer.Render(_globalTime);
            pbCanvas.Refresh();

            _globalTime += 2.51f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // tu mo¿na coœ dodaæ
        }
    }
}
