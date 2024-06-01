namespace EngineX
{
    public class Rasterizer
    {
        int cx;
        int cy;
        bool aa;

        Bitmap b;

        Rasterizer(Bitmap bitmap, bool antialiasing = false)
        {
            b = bitmap;
            aa = antialiasing;
        }

        void SetAntialiasing(bool antialiasing = true)
        {
            aa = antialiasing;
        }

        void SetPixel(int x, int y, Color c)
        {
            b.SetPixel(x, y, c);
        }

        Color GetPixel(int x, int y)
        {
            return b.GetPixel(x, y);
        }

        void HLine(int x, int y, int w)
        {

        }

        void VLine(int x, int y, int h)
        {

        }

        void MoveTo(int x, int y)
        {
            cx = x;
            cy = y;
        }

        void LineTo(int x, int y)
        {
            Line(cx, cy, x, y);

            cx = x;
            cy = y;
        }
    
        void Clear(Color c)
        {
            // rś
        }

        void WiredDrawRectangle(int x1, int y1, int x2, int y2)
        {
            // dave
        }

        void DrawRectangle(int x1, int y1, int x2, int y2)
        {
            // dave
        }

        void Line(int x1, int y1, int x2, int y2)
        { 
            // artur
        }

        void Circle(int x, int y, int r)
        {
            // seba
        }

        void Disc(int x, int y, int r)
        {
            // seba
        }

        void WiredEllipse(int x, int y, int r1, int r2)
        {
            // dom
        }

        void Ellipse(int x, int y, int r1, int r2)
        {
            // dom
        }

        void WireTriangle(int x1, int y1, int x2 , int y2, int x3, int y3)
        {
            // magdalena
        }

        void Triangle(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            // magdalena
        }
    }
}
