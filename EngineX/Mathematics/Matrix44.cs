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

        public static Matrix44 LookAt(Vector3 cameraPosition, Vector3 cameraTarget, Vector3 cameraUpVector)
        {
            /*
             * Left-handed look-at matrix
             * https://learn.microsoft.com/en-us/previous-versions/windows/desktop/bb281710(v=vs.85)
            */
            Vector3 z = (cameraTarget - cameraPosition).Normalize(), x = cameraUpVector.Cross(z).Normalize(), y = z.Cross(x);

            double[,] array = new double[,] {
                { x.X, y.X, z.X, 0 },
                { x.Y, y.Y, z.Y, 0 },
                { x.Z, y.Z, z.Z, 0 },
                { -x.Dot(cameraPosition), -y.Dot(cameraPosition), -z.Dot(cameraPosition), 1 }
            };

            return new(array);
        }

        public static Matrix44 Perspective(double width, double height, double znearPlane, double zfarPlane)
        {
            /*
             * Left-handed perspective projection matrix
             * https://learn.microsoft.com/en-us/previous-versions/windows/desktop/bb281729(v=vs.85)
            */
            double[,] array = new double[,] {
                { 2*znearPlane/width, 0, 0, 0 },
                { 0, 2*znearPlane/height, 0, 0 },
                { 0, 0, zfarPlane/(zfarPlane-znearPlane), 1 },
                { 0, 0, znearPlane*zfarPlane/(znearPlane-zfarPlane), 0 }
            };

            return new(array);
        }

        public static Matrix44 PerspectiveFov(double fieldOfViewY, double aspectRatio, double znearPlane, double zfarPlane)
        {
            /*
             * Left-handed perspective projection matrix based on a field of view
             * https://learn.microsoft.com/en-us/previous-versions/windows/desktop/bb281727(v=vs.85)
            */
            double h = 1 / (Math.Tan(fieldOfViewY / 2));
            double[,] array = new double[,] {
                { h/aspectRatio, 0, 0, 0 },
                { 0, h, 0, 0 },
                { 0, 0, zfarPlane/(zfarPlane-znearPlane), 1 },
                { 0, 0, -znearPlane*zfarPlane/(zfarPlane-znearPlane), 0 }
            };

            return new(array);
        }

        public static Matrix44 RotationX(double angle)
        {
            double cos = Math.Cos(angle), sin = Math.Sin(angle);
            double[,] array = new double[,] {
                { 1, 0, 0, 0 },
                { 0, cos, -sin, 0 },
                { 0, sin, cos, 0 },
                { 0, 0, 0, 1 }
            };

            return new(array);
        }

        public static Matrix44 RotationY(double angle)
        {
            double cos = Math.Cos(angle), sin = Math.Sin(angle);
            double[,] array = new double[,] {
                { cos, 0, sin, 0 },
                { 0, 1, 0, 0 },
                { -sin, 0, cos, 0 },
                { 0, 0, 0, 1 }
            };

            return new(array);
        }

        public static Matrix44 RotationZ(double angle)
        {
            double cos = Math.Cos(angle), sin = Math.Sin(angle);
            double[,] array = new double[,] {
                { cos, -sin, 0, 0 },
                { sin, cos, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            };

            return new(array);
        }
    }
}