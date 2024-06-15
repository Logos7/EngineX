namespace EngineX.Mathematics
{
    public class Matrix44
    {
        public const byte size = 4;
        private readonly double[,] Rows = new double[size,size];

        public Matrix44()
        {
            for (byte i = 0; i < size; i++)
            {
                for (byte j = 0; j < size; j++) Rows[i,j] = i == j? 1 : 0;
            }
        }

        public Matrix44(double[,] array)
        {
            Rows = array;
        }

        public static Matrix44 operator +(Matrix44 m1, Matrix44 m2)
        {
            Matrix44 result = new();
            for (byte i = 0; i < size; i++)
            {
                for (byte j = 0; j < size; j++) result.Rows[i,j] = m1.Rows[i,j] + m2.Rows[i,j];
            }
            return result;
        }

        public static Matrix44 operator -(Matrix44 m1, Matrix44 m2) => m1 + (-1 * m2);

        public static Matrix44 operator *(double a, Matrix44 m)
        {
            Matrix44 result = new();
            for (byte i = 0; i < size; i++)
            {
                for (byte j = 0; j < size; j++) result.Rows[i,j] = a * m.Rows[i,j];
            }
            return result;
        }

        public static Matrix44 operator *(Matrix44 m, double a) => a * m;

        public Matrix44 T()
        {
            Matrix44 result = new();
            for (byte i = 0; i < size; i++)
            {
                for (byte j = 0; j < size; j++) result.Rows[i,j] = Rows[j,i];
            }
            return result;
        }

        public static Matrix44 operator *(Matrix44 m1, Matrix44 m2)
        {
            Matrix44 result = new();
            for (byte i = 0; i < size; i++)
            {
                for (byte j = 0; j < size; j++)
                {
                    double sum = 0;
                    for (byte k = 0; k < size; k++) sum += m1.Rows[i,k] * m2.Rows[k,j];
                    result.Rows[i,j] = sum;
                }
            }
            return result;
        }

        public static Vector3 operator *(Matrix44 m, Vector3 v)
        {
            double[] array = new double[size], vector = new double[] { v.X, v.Y, v.Z, 1 };
            for (byte i = 0; i < size; i++)
            {
                double sum = 0;
                for (byte j = 0; j < size; j++) sum += m.Rows[i,j] * vector[j];
                array[i] = sum;
            }
            return new(array[0], array[1], array[2]);
        }

        public static Matrix44 LookAt(Vector3 position, Vector3 target, Vector3 up)
        {
            /*
             * Left-handed look-at matrix
             * https://learn.microsoft.com/en-us/previous-versions/windows/desktop/bb281710(v=vs.85)
            */
            Vector3 z = (target - position).Normalize();
            Vector3 x = up.Cross(z).Normalize();
            Vector3 y = z.Cross(x);

            double[,] array = new double[,] {
                { x.X, y.X, z.X, 0 },
                { x.Y, y.Y, z.Y, 0 },
                { x.Z, y.Z, z.Z, 0 },
                { -x.Dot(position), -y.Dot(position), -z.Dot(position), 1 }
            };

            return new(array);
        }

        public static Matrix44 Perspective(double width, double height, double near, double far)
        {
            /*
             * Left-handed perspective projection matrix
             * https://learn.microsoft.com/en-us/previous-versions/windows/desktop/bb281729(v=vs.85)
            */
            double[,] array = new double[,] {
                { 2*near/width, 0, 0, 0 },
                { 0, 2*near/height, 0, 0 },
                { 0, 0, far/(far-near), 1 },
                { 0, 0, near*far/(near-far), 0 }
            };

            return new(array);
        }
    }
}