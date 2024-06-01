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

        public void HLine(int x, int y, int w, Color c)
        {
            for (int i = x; i < x + w; i++)
            {
                SetPixel(i, y, c);
            }
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

        public void Clear()
        {
            for (int i = 0; i < b.Height; i++)
            {
                HLine(0, i, b.Width, Color.Black);
            }
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

        public void WiredEllipse(int x, int y, int r1, int r2, Color c)
        {
            for (int x1 = 0; x1 < b.Width; x1++)
            {
                for (int y1 = 0; y1 < b.Height; y1++)
                {
                    double distanceSquared = Math.Pow(x1 - x, 2) / Math.Pow(r1, 2) + Math.Pow(y1 - y, 2) / Math.Pow(r2, 2);
                    if (distanceSquared <= 1) SetPixel(x1, y1, c);
                }
            }
        }

        public void Ellipse(int x, int y, int r1, int r2, Color c)
        {
            for (int x1 = 0; x1 < b.Width; x1++)
            {
                for (int y1 = 0; y1 < b.Height; y1++)
                {
                    double distanceSquared = Math.Pow(x1 - x, 2) / Math.Pow(r1, 2) + Math.Pow(y1 - y, 2) / Math.Pow(r2, 2);
                    if (distanceSquared <= 1) SetPixel(x1, y1, c);
                }
            }
        }

        public void WireTriangle(int x1, int y1, int x2 , int y2, int x3, int y3)
        {
            Line(x1, y1, x2, y2);
            Line(x2, y2, x3, y3);
            Line(x3, y3, x1, y1);
        }

        public void Triangle(int x1, int y1, int x2, int y2, int x3, int y3, Color c)
        {
            SortVertices(ref x1, ref y1, ref x2, ref y2, ref x3, ref y3);

            // Compute slopes
            double dx1 = x2 == x1 ? 0 : (double)(x2 - x1) / (y2 - y1);
            double dx2 = x3 == x1 ? 0 : (double)(x3 - x1) / (y3 - y1);
            double dx3 = x3 == x2 ? 0 : (double)(x3 - x2) / (y3 - y2);

            // Initial x values
            double xs1 = x1;
            double xs2 = x1;

            // Fill the triangle
            if (y2 == y3)
            {
                // Bottom flat triangle
                for (int y = y1; y <= y3; y++)
                {
                    DrawScanline((int)xs1, (int)xs2, y, c);
                    xs1 += dx1;
                    xs2 += dx2;
                }
            }
            else if (y1 == y2)
            {
                // Top flat triangle
                xs1 = x2;
                for (int y = y1; y <= y3; y++)
                {
                    DrawScanline((int)xs1, (int)xs2, y, c);
                    xs1 += dx3;
                    xs2 += dx2;
                }
            }
            else
            {
                // General case
                for (int y = y1; y <= y2; y++)
                {
                    DrawScanline((int)xs1, (int)xs2, y, c);
                    xs1 += dx1;
                    xs2 += dx2;
                }

                xs1 = x2;
                for (int y = y2; y <= y3; y++)
                {
                    DrawScanline((int)xs1, (int)xs2, y, c);
                    xs1 += dx3;
                    xs2 += dx2;
                }
            }
        }

        private void SortVertices(ref int x1, ref int y1, ref int x2, ref int y2, ref int x3, ref int y3)
        {
            if (y1 > y2)
            {
                Swap(ref x1, ref x2);
                Swap(ref y1, ref y2);
            }

            if (y1 > y3)
            {
                Swap(ref x1, ref x3);
                Swap(ref y1, ref y3);
            }

            if (y2 > y3)
            {
                Swap(ref x2, ref x3);
                Swap(ref y2, ref y3);
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }

        private void DrawScanline(int x1, int x2, int y, Color c)
        {
            if (x1 > x2) Swap(ref x1, ref x2);
            for (int x = x1; x <= x2; x++)
            {
                SetPixel(x, y, c);
            }
        }
    }
}
