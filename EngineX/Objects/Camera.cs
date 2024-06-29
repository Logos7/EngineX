using EngineX.Mathematics;

namespace EngineX.Objects
{
    public class Camera : Object3D
    {
        private readonly int width, height;
        private readonly double near;
        public Camera(string aName) : base(aName)
        {
            width = 464;
            height = 320;
            near = 50;
        }

        public (int X, int Y) Transform(Vector3 vector)
        {
            int X = (int)Math.Round((vector.X + near) / vector.Z);
            int Y = (int)Math.Round((vector.Y + near) / vector.Z);
            return (X + (width / 2), Y + (height / 2));
        }

        /*
         * double x = 250.0 * px / pz, y = 250.0 * py / pz;
         * Canvas.SetLeft(ellipse, x + 0.5 * world.canvas.ActualWidth);
         * Canvas.SetTop(ellipse, y + 0.5 * world.canvas.ActualHeight);
        */
    }
}