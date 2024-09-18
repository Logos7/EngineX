namespace EngineX.Mathematics
{
    public class Randomness
    {
        public static Color RandomColor()
        {
            System.Random r = new();
            byte[] argb = new byte[4];
            r.NextBytes(argb);
            return Color.FromArgb(argb[0], argb[1], argb[2], argb[3]);
        }
    }
}