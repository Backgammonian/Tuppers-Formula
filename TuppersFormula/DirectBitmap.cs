using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace TuppersFormula
{
    public class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void Dispose()
        {
            if (Disposed)
            {
                return;
            }

            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }

        public void SetPixel(int x, int y, Color color)
        {
            var index = x + (y * Width);
            var col = color.ToArgb();

            Bits[index] = col;
        }

        public Color GetPixel(int x, int y)
        {
            var index = x + (y * Width);
            var color = Bits[index];
            var result = Color.FromArgb(color);

            return result;
        }

        public void DrawPoint(int x, int y, Color color)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                SetPixel(x, y, color);
            }
        }

        public DirectBitmap Clone()
        {
            var bm = new DirectBitmap(Width, Height);
            using (var gr = Graphics.FromImage(bm.Bitmap))
            {
                gr.DrawImageUnscaled(Bitmap, 0, 0, Width, Height);
            }

            return bm;
        }
    }
}
