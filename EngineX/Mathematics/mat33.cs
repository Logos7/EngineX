namespace EngineX.Mathematics
{
    public class mat33
    {
        public float3[] Rows = new float3[3];

        public mat33()
        {
            Rows[0] = new float3(1, 0, 0);
            Rows[1] = new float3(0, 1, 0);
            Rows[2] = new float3(0, 0, 1);
        }

        public mat33(float3 row0, float3 row1, float3 row2)
        {
            Rows[0] = row0;
            Rows[1] = row1;
            Rows[2] = row2;
        }

        public static mat33 operator +(mat33 m1, mat33 m2)
        {
            mat33 result = new();
            for (byte i = 0; i < 3; i++)
            {
                result.Rows[i] = m1.Rows[i] + m2.Rows[i];
            }
            return result;
        }

        public static mat33 operator -(mat33 m1, mat33 m2) => m1 + (-1 * m2);

        public static mat33 operator *(double a, mat33 m1)
        {
            mat33 result = new();
            for (byte i = 0; i < 3; i++)
            {
                result.Rows[i] = a * m1.Rows[i];
            }
            return result;
        }

        public static mat33 operator *(mat33 m1, mat33 m2)
        {
            return new mat33();
        }
    }
}