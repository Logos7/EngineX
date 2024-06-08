namespace EngineX.Mathematics
{
    public class mat44
    {
        public const byte size = 4;
        public double[] Rows = new double[size];

        public mat44()
        {
            Rows = [ [ 1, 0, 0, 0 ], [ 0, 1, 0, 0 ], [ 0, 0, 1, 0 ], [ 0, 0, 0, 1 ] ];
        }

        public mat44(double[size][size] array)
        {
            Rows = array;
        }

        public static mat44 operator +(mat44 m1, mat44 m2)
        {
            mat44 result = new();
            for (byte i = 0; i < size; i++)
            {
                for (byte j = 0; j < size; j++) result.Rows[i][j] = m1.Rows[i][j] + m2.Rows[i][j];
            }
            return result;
        }

        public static mat44 operator -(mat44 m1, mat44 m2) => m1 + (-1 * m2);

        public static mat44 operator *(double a, mat44 m)
        {
            mat44 result = new();
            for (byte i = 0; i < size; i++)
            {
                for (byte j = 0; j < size; j++) result.Rows[i][j] = a * m.Rows[i][j];
            }
            return result;
        }

        public static mat44 T(mat44 m)
        {
            mat44 result = new();
            for (byte i = 0; i < size; i++)
            {
                for (byte j = 0; j < size; j++) result.Rows[i][j] = m.Rows[j][i];
            }
            return result;
        }

        public static mat44 operator *(mat44 m1, mat44 m2)
        {
            mat44 result = new();
            for (byte i = 0; i < size; i++)
            {
                for (byte j = 0; j < size; j++)
                {
                    double sum = 0;
                    for (byte k = 0; k < size; k++) sum += m1.Rows[i][k] * m2.Rows[k][j];
                    result.Rows[i][j] = sum;
                }
            }
            return result;
        }
    }
}