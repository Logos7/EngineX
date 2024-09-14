using EngineX.Objects;

namespace EngineX.Daemons
{
    public class Renderer : ADaemon
    {
        public void Render(Scene3D scene3D, Rasterizer rasterizer, Camera camera)
        {
            foreach (var object3D in scene3D._objects)
            {
                foreach (var triangle in object3D.Triangles)
                {
                    (int X, int Y) vertexA = camera.Transform(object3D.Vertices[triangle.a]);
                    (int X, int Y) vertexB = camera.Transform(object3D.Vertices[triangle.b]);
                    (int X, int Y) vertexC = camera.Transform(object3D.Vertices[triangle.c]);
                    rasterizer.Triangle(vertexA.X, vertexA.Y, vertexB.X, vertexB.Y, vertexC.X, vertexC.Y, Color.Azure);
                }
            }
        }
    }
}