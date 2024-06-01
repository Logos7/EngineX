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
            int d, dx, dy, ai, bi, xi, yi;
            int x = x1, y = y1;
            // ustalenie kierunku rysowania
            if (x1 < x2)
            {
                xi = 1;
                dx = x2 - x1;
            }
            else
            {
                xi = -1;
                dx = x1 - x2;
            }
            // ustalenie kierunku rysowania
            if (y1 < y2)
            {
                yi = 1;
                dy = y2 - y1;
            }
            else
            {
                yi = -1;
                dy = y1 - y2;
            }
            // pierwszy piksel
            SetPixel(x, y, Color.Red);
            // oś wiodąca OX
            if (dx > dy)
            {
                ai = (dy - dx) * 2;
                bi = dy * 2;
                d = bi - dx;
                // pętla po kolejnych x
                while (x != x2)
                {
                    // test współczynnika
                    if (d >= 0)
                    {
                        x += xi;
                        y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        x += xi;
                    }
                    SetPixel(x, y, Color.Red);
                }
            }
            // oś wiodąca OY
            else
            {
                ai = (dx - dy) * 2;
                bi = dx * 2;
                d = bi - dy;
                // pętla po kolejnych y
                while (y != y2)
                {
                    // test współczynnika
                    if (d >= 0)
                    {
                        x += xi;
                        y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        y += yi;
                    }
                    SetPixel(x, y, Color.Red);
                }
            }
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
