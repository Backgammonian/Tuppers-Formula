using System;
using System.Drawing;

namespace TuppersFormula
{
    public class GridUpdatedEventArgs : EventArgs
    {
        public Bitmap Bitmap { get; set; }
        public GridUpdatedEventArgs(Bitmap bitmap)
        {
            Bitmap = bitmap;
        }
    }
}
