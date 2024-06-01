namespace EngineX
{
    public class Rasterizer
    {
        int cx;
        int cy;
        bool aa;

        Bitmap b;

        public Rasterizer(Bitmap bitmap, bool antialiasing = false)
        {
            b = bitmap;
            aa = antialiasing;
        }

        public void SetAntialiasing(bool antialiasing = true)
        {
            aa = antialiasing;
        }

        public void SetPixel(int x, int y, Color c)
        {
            b.SetPixel(x, y, c);
        }

        public Color GetPixel(int x, int y)
        {
            return b.GetPixel(x, y);
        }

        public void HLine(int x, int y, int w)
        {

        }

        public void VLine(int x, int y, int h)
        {

        }

        public void MoveTo(int x, int y)
        {
            cx = x;
            cy = y;
        }

        public void LineTo(int x, int y)
        {
            Line(cx, cy, x, y);

            cx = x;
            cy = y;
        }

        public void Clear(Color c)
        {
            // rś
        }

        public void WiredDrawRectangle(int x1, int y1, int x2, int y2)
        {
            // dave
        }

        public void DrawRectangle(int x1, int y1, int x2, int y2)
        {
            // dave
        }

        public void Line(int x1, int y1, int x2, int y2)
        { 
            // artur
        }

        public void Circle(int x, int y, int r)
        {
            // seba
        }

        public void Disc(int x, int y, int r)
        {
            // seba
        }

        public void WiredEllipse(int x, int y, int r1, int r2)
        {
            // dom
        }

        public void Ellipse(int x, int y, int r1, int r2)
        {
            // dom
        }

        public void WireTriangle(int x1, int y1, int x2 , int y2, int x3, int y3)
        {
            // magdalena
        }

        public void Triangle(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            // magdalena
        }
    }
}
