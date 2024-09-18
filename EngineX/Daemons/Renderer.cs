using EngineX.Objects;
using System.Numerics;

namespace EngineX.Daemons
{
    public class Renderer : ADaemon
    {
        private Scene3D _scene3D;
        private Rasterizer _rasterizer;
        private Camera _camera;

        public Renderer(Scene3D scene3D, Rasterizer rasterizer, Camera camera)
        {
            _scene3D = scene3D;
            _rasterizer = rasterizer;
            _camera = camera;
        }

        public void Render(float angle)
        {
            // Czyszczenie ekranu
            _rasterizer.Clear();

            // Ustawianie rotacji kamery
            _camera.SetRotation(angle);

            // Pobranie rozmiaru ekranu z bitmapy lub kontrolki
            int screenWidth = 400;
            int screenHeight = 300;

            // Iteracja przez obiekty 3D w scenie
            foreach (var object3D in _scene3D._objects)
            {
                // Iteracja przez trójkąty obiektu
                foreach (var triangle in object3D.Triangles)
                {
                    // Transformacja wierzchołków do przestrzeni NDC
                    Vector4 vertexA = _camera.TransformWithDepth(object3D.Vertices[triangle.a]);
                    Vector4 vertexB = _camera.TransformWithDepth(object3D.Vertices[triangle.b]);
                    Vector4 vertexC = _camera.TransformWithDepth(object3D.Vertices[triangle.c]);

                    // Sprawdzenie, czy trójkąt jest w przestrzeni widocznej
                    if (IsOutsideViewFrustum(vertexA) && IsOutsideViewFrustum(vertexB) && IsOutsideViewFrustum(vertexC))
                    {
                        continue;
                    }

                    // Obliczenie normalnej trójkąta w przestrzeni kamery
                    Vector3 pA = new Vector3(vertexA.X, vertexA.Y, vertexA.Z);
                    Vector3 pB = new Vector3(vertexB.X, vertexB.Y, vertexB.Z);
                    Vector3 pC = new Vector3(vertexC.X, vertexC.Y, vertexC.Z);

                    Vector3 edge1 = pB - pA;
                    Vector3 edge2 = pC - pA;
                    Vector3 normal = Vector3.Cross(edge1, edge2);

                    // Wektor do kamery (w przestrzeni kamery kamera jest w (0,0,0))
                    Vector3 toCamera = -pA;

                    // Sprawdzenie, czy trójkąt jest skierowany w stronę kamery
                    if (Vector3.Dot(normal, toCamera) <= 0)
                    {
                        // Trójkąt jest odwrócony tyłem do kamery, pomijamy go
                        continue;
                    }

                    // Przekształcenie współrzędnych na ekran
                    (int X, int Y) screenA = ToScreenCoordinates(vertexA, screenWidth, screenHeight);
                    (int X, int Y) screenB = ToScreenCoordinates(vertexB, screenWidth, screenHeight);
                    (int X, int Y) screenC = ToScreenCoordinates(vertexC, screenWidth, screenHeight);

                    // Rysowanie trójkąta
                    _rasterizer.Triangle(screenA.X, screenA.Y, screenB.X, screenB.Y, screenC.X, screenC.Y, triangle.color);
                }
            }
        }

        private bool IsOutsideViewFrustum(Vector4 vertex)
        {
            return vertex.X < -1 || vertex.X > 1 ||
                   vertex.Y < -1 || vertex.Y > 1 ||
                   vertex.Z < -1 || vertex.Z > 1;
        }

        private (int X, int Y) ToScreenCoordinates(Vector4 ndcPoint, int screenWidth, int screenHeight)
        {
            int screenX = (int)((ndcPoint.X + 1.0f) * 0.5f * screenWidth);
            int screenY = (int)((1.0f - ndcPoint.Y) * 0.5f * screenHeight);
            return (screenX, screenY);
        }
    }
}
