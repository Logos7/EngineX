using System.Numerics;

namespace EngineX.Objects
{
    public class Camera : Object3D
    {
        private readonly double near;
        public Camera(string aName) : base(aName)
        {
            near = 50;
        }

        public (double X, double Y) Transform(Vector3 vector)
        {
            return ((vector.X + near) / vector.Z, (vector.Y + near) / vector.Z);
        }
    }
}