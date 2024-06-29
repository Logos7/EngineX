using EngineX.Mathematics;

namespace EngineX.Objects
{
    public class Camera : Object3D
    {
        private readonly double near;
        public Camera(string aName) : base(aName)
        {
            near = 50;
        }

        public (int X, int Y) Transform(Vector3 vector)
        {
            int X = (int)Math.Round((vector.X + near) / vector.Z);
            int Y = (int)Math.Round((vector.Y + near) / vector.Z);
            return (X, Y);
        }
    }
}