using EngineX.Mathematics;
using System.Collections.Generic;

namespace EngineX.Objects
{
    public class Object3D
    {
        public string Name { get; set; }
        public Vector3 Position;
        public bool IsVisible;

        public readonly List<Vector3> Vertices;
        public readonly List<Edge> Edges;
        public readonly List<Triangle> Triangles;

        public Object3D(string aName)
        {
            Name = aName;
            Position = new Vector3();
            IsVisible = true;

            Vertices = new List<Vector3>();
            Edges = new List<Edge>();
            Triangles = new List<Triangle>();
        }
    }
}
