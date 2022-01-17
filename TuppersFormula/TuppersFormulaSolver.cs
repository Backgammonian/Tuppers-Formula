using System.Numerics;

namespace TuppersFormula
{
    public class TuppersFormulaSolver
    {
        private readonly int _width;
        private readonly int _height;
        private BigInteger _k;
        public BigInteger K 
        { 
            get
            {
                return _k;
            }
            set
            {
                var mod = value % 17;
                if (mod != 0)
                {
                    var div = value / 17;
                    _k = div * 17;
                }
                else
                {
                    _k = value;
                }
            }
        }

        public TuppersFormulaSolver()
        {
            _width = Constants.GridWidth;
            _height = Constants.GridHeight;
            K = Constants.TuppersFormula;
        }

        public TuppersFormulaSolver(BigInteger k)
        {
            _width = Constants.GridWidth;
            _height = Constants.GridHeight;
            K = k;
        }

        public bool[,] GetResult()
        {
            var values = new bool[_width, _height];

            for (var i = 0; i < _width; i++)
            {
                for (var j = 0; j < _height; j++)
                {
                    values[i, j] = TuppersFormula(i, j, K);
                }
            }

            for (int i = 0; i < _width / 2; i++)
            {
                for (var j = 0; j < _height; j++)
                {
                    var t = values[i, j];
                    values[i, j] = values[_width - i - 1, j];
                    values[_width - i - 1, j] = t;
                }
            }

            return values;
        }

        private bool TuppersFormula(BigInteger x, BigInteger y, BigInteger k)
        {
            var pow = new BigInteger(2).Pow(17 * x + y % 17);
            var leftSide = (k + y) / 17 / pow % 2;
            return leftSide * 2 > 1;
        }
    }
}
