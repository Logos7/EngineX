using EngineX.Mathematics;
using System.Collections.Generic;
using System.Numerics;

namespace EngineX.Objects
{
    public class Object3D
    {
        public string Name { get; set; }
        public Vector3 Position;
        public bool IsVisible;

        public readonly List<Vector3> Vertices;
        public readonly List<Triangle> Triangles;

        public Object3D()
        {
            Name = "";
            Position = new Vector3();
            IsVisible = true;

            Vertices = new List<Vector3>();
            Triangles = new List<Triangle>();
        }
    }
}
