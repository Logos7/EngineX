namespace EngineX.Mathematics
{
    public class Vector3
    {
        public double X, Y, Z;

        public Vector3()
        {
            X = Y = Z = 0;
        }

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2) => new(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        public static Vector3 operator -(Vector3 v1, Vector3 v2) => new(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        public static Vector3 operator *(double a, Vector3 v) => new(a * v.X, a * v.Y, a * v.Z);
        public static Vector3 operator *(Vector3 v, double a) => a * v;
        public double Dot(Vector3 v) => X * v.X + Y * v.Y + Z * v.Z;
        public double Length() => Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
        public Vector3 Normalize() => this * (1 / Length());
        public Vector3 Cross(Vector3 v) => new(Y * v.Z - Z * v.Y, Z * v.X - X * v.Z, X * v.Y - Y * v.X);
    };
}