using EngineX.Mathematics;

namespace EngineX.Objects
{
    public class Camera : Object3D
    {
        private readonly int width, height;
        private readonly double near;
        public Matrix44 mat;
        public float a;
        public Camera(string aName) : base(aName)
        {
            width = 464;
            height = 320;
            near = 5;
            mat = new Matrix44();
            a = 0;
        }

        public (int X, int Y) Transform(Vector3 vector)
        {
            //vector = mat * vector;
            double ax = vector.X * Math.Sin(a) + vector.Y * Math.Cos(a);
            double ay = vector.Y * Math.Sin(a) - vector.X * Math.Cos(a);
            double az = vector.Z;

            int X = (int)Math.Round(ax / (az + near));
            int Y = (int)Math.Round(ay / (az + near));

            return (X + (width / 2), Y + (height / 2));
        }
    }
}