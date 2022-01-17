using System;
using System.Numerics;

namespace TuppersFormula
{
    public class RandomHelper
    {
        private readonly Random _r;

        public RandomHelper()
        {
            _r = new Random();
        }

        public int Next(int minValue, int maxValue)
        {
            return _r.Next(minValue, maxValue);
        }

        private string GenerateRandomBinaryNumber(int length)
        {
            var result = "";

            for (int i = 0; i < Math.Abs(length); i++)
            {
                result += _r.Next(0, 1001) > 500 ? "1" : "0";
            }

            return result;
        }

        public BigInteger GetRandomBigInteger()
        {
            byte[] data = new byte[_r.Next(1, 10000)];
            _r.NextBytes(data);
            return new BigInteger(data);
        }

        public BigInteger GetNBitsLongRandomBigInteger(int length)
        {
            var binaryNumber = GenerateRandomBinaryNumber(length);
            return binaryNumber.BinaryToBigInteger();
        }
    }
}
