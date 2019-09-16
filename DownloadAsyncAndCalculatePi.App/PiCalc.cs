namespace DownloadAsyncAndCalculatePi.App
{
    using System.Collections.Generic;
    using System.Numerics;

    /// <summary>
    /// Based on <a href="https://rosettacode.org/wiki/Pi"></a>
    /// </summary>
    class Math
    {
        private static readonly BigInteger FOUR = new BigInteger(4);
        private static readonly BigInteger SEVEN = new BigInteger(7);
        private static readonly BigInteger TEN = new BigInteger(10);
        private static readonly BigInteger THREE = new BigInteger(3);
        private static readonly BigInteger TWO = new BigInteger(2);

        /// <summary>
        /// Calculates Pi to infinite # of decimal places.
        /// </summary>
        /// <returns>Pi</returns>
        public static IEnumerable<BigInteger> CalcPiDigits()
        {
            BigInteger k = BigInteger.One;
            BigInteger l = new BigInteger(3);
            BigInteger n = new BigInteger(3);
            BigInteger q = BigInteger.One;
            BigInteger r = BigInteger.Zero;
            BigInteger t = BigInteger.One;

            BigInteger nn, nr;
            bool first = true;
            while (true)
            {
                if ((FOUR * q + r - t).CompareTo(n * t) == -1)
                {
                    yield return n;
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

