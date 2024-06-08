namespace EngineX.Mathematics
{
    public class float3
    {
        public double X, Y, Z;
        public float3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static float3 operator +(float3 v1, float3 v2) => new(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        public static float3 operator -(float3 v1, float3 v2) => new(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        public static float3 operator *(double a, float3 v) => new(a * v.X, a * v.Y, a * v.Z);
        public static float3 operator *(float3 v, double a) => a * v;
        public static double dot(float3 v1, float3 v2) => v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
    };
}