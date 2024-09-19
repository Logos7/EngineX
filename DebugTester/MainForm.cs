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

            SelectRandomShape_Click(this, EventArgs.Empty);
        }

        private void InitializeTetrahedron()
        {
            var obj = new Object3D
            {
                Name = "Tetrahedron"
            };
            _scene._objects.Add(obj);

            // Mozesz ustawic rozne kolory dla kazdej sciany, jesli chcesz
            Color color1 = Randomness.RandomColor();
            Color color2 = Randomness.RandomColor();
            Color color3 = Randomness.RandomColor();
            Color color4 = Randomness.RandomColor();

            float a = 50; // Dlugosc krawedzi czworoscianu

            // Wspolrzedne wierzcholkow czworoscianu foremnego
            // Punkty sa rozmieszczone symetrycznie wokol srodka ukladu wspolrzednych
            Vector3 v0 = new(0, 0, (float)(a * Math.Sqrt(6) / 3));
            Vector3 v1 = new(0, (float)(a * Math.Sqrt(3) / 3), 0);
            Vector3 v2 = new(-a / 2, (float)(-a * Math.Sqrt(3) / 6), 0);
            Vector3 v3 = new(a / 2, (float)(-a * Math.Sqrt(3) / 6), 0);

            // Dodanie wierzcholkow do obiektu
            obj.Vertices.Add(v0); // Wierzcholek szczytowy
            obj.Vertices.Add(v1);
            obj.Vertices.Add(v2);
            obj.Vertices.Add(v3);

            // Definicja trojkatow (scian czworoscianu)
            obj.Triangles.Add(new Triangle(0, 1, 2, color1)); // Sciana przednia
            obj.Triangles.Add(new Triangle(0, 2, 3, color2)); // Sciana prawa
            obj.Triangles.Add(new Triangle(0, 3, 1, color3)); // Sciana lewa
            obj.Triangles.Add(new Triangle(1, 3, 2, color4)); // Podstawa
        }

        private void InitializeCube()
        {
            var obj = new Object3D
            {
                Name = "Cube"
            };
            _scene._objects.Add(obj);

            // Definicja kolorow dla kazdej sciany szescianu
            Color color1 = Randomness.RandomColor();
            Color color2 = Randomness.RandomColor();
            Color color3 = Randomness.RandomColor();
            Color color4 = Randomness.RandomColor();
            Color color5 = Randomness.RandomColor();
            Color color6 = Randomness.RandomColor();

            float a = 50; // Dlugosc krawedzi szescianu

            // Wspolrzedne wierzcholkow szeecianu
            // Punkty sa rozmieszczone symetrycznie wokol srodka ukladu wspolrzednych
            Vector3 v0 = new(-a / 2, -a / 2, -a / 2);
            Vector3 v1 = new(a / 2, -a / 2, -a / 2);
            Vector3 v2 = new(a / 2, a / 2, -a / 2);
            Vector3 v3 = new(-a / 2, a / 2, -a / 2);
            Vector3 v4 = new(-a / 2, -a / 2, a / 2);
            Vector3 v5 = new(a / 2, -a / 2, a / 2);
            Vector3 v6 = new(a / 2, a / 2, a / 2);
            Vector3 v7 = new(-a / 2, a / 2, a / 2);

            // Dodanie wierzcholkow do obiektu
            obj.Vertices.Add(v0); // 0
            obj.Vertices.Add(v1); // 1
            obj.Vertices.Add(v2); // 2
            obj.Vertices.Add(v3); // 3
            obj.Vertices.Add(v4); // 4
            obj.Vertices.Add(v5); // 5
            obj.Vertices.Add(v6); // 6
            obj.Vertices.Add(v7); // 7

            // Definicja trojkatow (scian szescianu)
            // Sciana przednia (v0, v1, v2, v3)
            obj.Triangles.Add(new Triangle(0, 1, 2, color1));
            obj.Triangles.Add(new Triangle(0, 2, 3, color1));

            // Sciana tylna (v4, v5, v6, v7)
            obj.Triangles.Add(new Triangle(5, 4, 7, color2));
            obj.Triangles.Add(new Triangle(5, 7, 6, color2));

            // Sciana lewa (v0, v3, v7, v4)
            obj.Triangles.Add(new Triangle(0, 3, 7, color3));
            obj.Triangles.Add(new Triangle(0, 7, 4, color3));

            // Sciana prawa (v1, v5, v6, v2)
            obj.Triangles.Add(new Triangle(1, 5, 6, color4));
            obj.Triangles.Add(new Triangle(1, 6, 2, color4));

            // Sciana dolna (v0, v4, v5, v1)
            obj.Triangles.Add(new Triangle(0, 4, 5, color5));
            obj.Triangles.Add(new Triangle(0, 5, 1, color5));

            // Sciana gorna (v3, v2, v6, v7)
            obj.Triangles.Add(new Triangle(3, 2, 6, color6));
            obj.Triangles.Add(new Triangle(3, 6, 7, color6));
        }

        private void InitializeDodecahedron()
        {
            var obj = new Object3D
            {
                Name = "Dodecahedron"
            };
            _scene._objects.Add(obj);

            // Lista wierzcholkow dwunastoscianu foremnego
            List<Vector3> vertices = new();

            float phi = (1 + MathF.Sqrt(5)) / 2; // Zlota liczba

            float a = 30; // Skalowanie dwunastoscianu

            // Wierzcholki dwunastoscianu
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

            // Dodanie wierzcholkow do obiektu
            obj.Vertices.AddRange(vertices);

            // Definicja scian (kazda jako lista indeksow wierzcholkow)
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

            // Podzial kazdej pieciokatnej sciany na trojkaty
            for (int i = 0; i < faces.Length; i++)
            {
                int[] face = faces[i];
                Color color = Randomness.RandomColor();

                // Dzielimy pieciokat na trojkaty (przyjmujemy, ze wierzcholki sa ulozone wokol srodka)
                int v0 = face[0];
                for (int j = 1; j < face.Length - 1; j++)
                {
                    int v1 = face[j];
                    int v2 = face[j + 1];

                    obj.Triangles.Add(new Triangle(v0, v1, v2, color));
                }
            }
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            _renderer.Render(_globalTime);
            pbCanvas.Refresh();

            _globalTime += 2.51f;
        }

        private void RandomizeColors_Click(object sender, EventArgs e)
        {
            Object3D obj = _scene._objects[0];
            foreach (Triangle triangle in obj.Triangles)
            {
                triangle.color = Randomness.RandomColor();
            }
        }

        private void RandomScale_Click(object sender, EventArgs e)
        {
            Object3D obj = _scene._objects[0];
            float randomScale = Randomness.RandomFloat(0.75f, 1.25f);

            for (ushort i = 0; i < obj.Vertices.Count; i++)
            {
                obj.Vertices[i] *= randomScale;
            }
        }

        private void SelectRandomShape_Click(object sender, EventArgs e)
        {
            Dictionary<string, Action> AllShapes = new()
            {
                { "Tetrahedron", InitializeTetrahedron },
                { "Cube",  InitializeCube },
                { "Dodecahedron", InitializeDodecahedron }
            };

            if (_scene._objects.Count == 1)
            {
                string PreviousShape = _scene._objects[0].Name;
                AllShapes.Remove(PreviousShape);
                _scene._objects.Clear();
            }
            
            List<string> Keys = AllShapes.Keys.ToList();
            string RandomShape = Randomness.Choose(Keys);
            AllShapes.GetValueOrDefault(RandomShape)?.Invoke();
        }
    }
}