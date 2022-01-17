using System;
using System.Numerics;
using System.Text;
using System.Diagnostics;

namespace TuppersFormula
{
    public static class BigIntegerExtensions
    {
        public static string ToBinaryString(this BigInteger bigint)
        {
            var bytes = bigint.ToByteArray();
            var idx = bytes.Length - 1;
            var base2 = new StringBuilder(bytes.Length * 8);
            var binary = Convert.ToString(bytes[idx], 2);

            if (binary[0] != '0' && bigint.Sign == 1)
            {
                base2.Append('0');
            }

            base2.Append(binary);

            for (idx--; idx >= 0; idx--)
            {
                base2.Append(Convert.ToString(bytes[idx], 2).PadLeft(8, '0'));
            }

            return base2.ToString();
        }

        public static BigInteger BinaryToBigInteger(this string value)
        {
            var result = new BigInteger(0);

            foreach (char c in value)
            {
                if (c == '0' || c == '1')
                {
                    result <<= 1;
                    result += c == '1' ? 1 : 0;
                }
                else
                {
                    throw new Exception("Invalid character found in string representaion of binary number!");
                }
            }

            return result;
        }

        public static BigInteger Pow(this BigInteger value, BigInteger exponent)
        {
            var originalValue = value;
            while (exponent-- > 1)
            {
                value = BigInteger.Multiply(value, originalValue);
            }

            return value;
        }

        public static BigInteger NextBigInteger(this Random random, BigInteger minValue, BigInteger maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException();
            }

            if (minValue == maxValue)
            {
                return minValue;
            }

            var zeroBasedUpperBound = maxValue - 1 - minValue;
            var bytes = zeroBasedUpperBound.ToByteArray();

            byte lastByteMask = 0b11111111;
            for (byte mask = 0b10000000; mask > 0; mask >>= 1, lastByteMask >>= 1)
            {
                if ((bytes[bytes.Length - 1] & mask) == mask)
                {
                    break;
                }
            }

            while (true)
            {
                random.NextBytes(bytes);
                bytes[bytes.Length - 1] &= lastByteMask;
                var result = new BigInteger(bytes);

                if (result <= zeroBasedUpperBound)
                {
                    return result + minValue;
                }
            }
        }
    }
}
