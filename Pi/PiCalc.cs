
namespace PiCalc
{
    using System.Collections.Generic;
    using System.Numerics;

    /// <summary>
    /// https://rosettacode.org/wiki/Pi
    /// </summary>
    public class Math
    {
        private readonly BigInteger FOUR = new BigInteger(4);
        private readonly BigInteger SEVEN = new BigInteger(7);
        private readonly BigInteger TEN = new BigInteger(10);
        private readonly BigInteger THREE = new BigInteger(3);
        private readonly BigInteger TWO = new BigInteger(2);

        private BigInteger k = BigInteger.One;
        private BigInteger l = new BigInteger(3);
        private BigInteger n = new BigInteger(3);
        private BigInteger q = BigInteger.One;
        private BigInteger r = BigInteger.Zero;
        private BigInteger t = BigInteger.One;

        public IEnumerable<BigInteger> CalcPiDigits()
        {
            BigInteger nn, nr;
            bool first = true;
            while (true)
            {
                if ((FOUR * q + r - t).CompareTo(n * t) == -1)
                {
                    yield return n;
                    //if (first)
                    //{
                    //    Console.Write(".");
                    //    first = false;
                    //}
                    nr = TEN * (r - (n * t));
                    n = TEN * (THREE * q + r) / t - (TEN * n);
                    q *= TEN;
                    r = nr;
                }
                else
                {
                    nr = (TWO * q + r) * l;
                    nn = (q * (SEVEN * k) + TWO + r * l) / (t * l);
                    q *= k;
                    t *= l;
                    l += TWO;
                    k += BigInteger.One;
                    n = nn;
                    r = nr;
                }
            }
        }
    }
}

