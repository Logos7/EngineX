namespace EngineX.Mathematics
{
    public class Randomness
    {
        static Random r = new();
        public static Color RandomColor()
        {
            byte[] argb = new byte[4];
            r.NextBytes(argb);
            return Color.FromArgb(argb[0], argb[1], argb[2], argb[3]);
        }

        public static float RandomFloat(float a, float b) => (float) ((r.NextDouble() * (b - a)) + a);

        public static T Choose<T>(List<T> list)
        {
            int index = r.Next(list.Count);
            return list[index];
        }
    }
}