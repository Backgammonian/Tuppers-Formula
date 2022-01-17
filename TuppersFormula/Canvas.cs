using System;
using System.Drawing;

namespace TuppersFormula
{
    public class Canvas
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public DirectBitmap DirectBitmap { get; private set; }

        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;

            DirectBitmap = new DirectBitmap(Width, Height);
        }

        public void Clear(Color color)
        {
            using (var gr = Graphics.FromImage(DirectBitmap.Bitmap))
            {
                gr.Clear(color);
            }
        }

        public void DrawPoint(int x, int y, Color color)
        {
            DirectBitmap.DrawPoint(x, y, color);
        }

        public void DrawLine(int x0, int y0, int x1, int y1, Color color)
        {
            var dx = Math.Abs(x1 - x0);
            var dy = Math.Abs(y1 - y0);
            var sx = (x0 < x1) ? 1 : -1;
            var sy = (y0 < y1) ? 1 : -1;
            var err = dx - dy;

            while (true)
            {
                DrawPoint(x0, y0, color);

                if ((x0 == x1) && (y0 == y1))
                {
                    break;
                }

                var e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy; 
                    x0 += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y0 += sy;
                }
            }
        }

        public void FillRectangle(int x, int y, int width, int height, Color color)
        {
            for (var i = x; i <= x + width; i++)
            {
                DrawLine(i, y, i, y + height, color);
            }
        }

        public void DrawRectangle(int x, int y, int width, int height, Color color)
        {
            DrawLine(x, y, x + width, y, color);
            DrawLine(x, y, x, y + height, color);
            DrawLine(x, y + height, x + width, y + height, color);
            DrawLine(x + width, y, x + width, y + height, color);
        }

        public void FillCell(int x, int y, int width, int height, Color color)
        {
            for (var i = x; i < x + width; i++)
            {
                DrawLine(i, y, i, y + height - 1, color);
            }
        }

        public void DrawCell(int x, int y, int width, int height, Color color)
        {
            DrawLine(x, y, x + width - 1, y, color);
            DrawLine(x, y + height - 1, x + width - 1, y + height - 1, color);
            DrawLine(x, y, x, y + height - 1, color);
            DrawLine(x + width - 1, y, x + width - 1, y + height - 1, color);
        }
    }
}
