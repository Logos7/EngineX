namespace EngineX.Mathematics
{
    public class Matrix44
    {
        public const byte size = 4;
        private double[,] Rows = new double[size,size];

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
    }
}