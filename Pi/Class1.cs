//namespace Pi
//{
//    using System.Collections;
//    using System.Collections.Generic;
//    using System.Runtime.InteropServices.ComTypes;
//    using System;
//    using System.Numerics;

//    public class Math
//    {
//        /// <summary>
//        /// https://stackoverflow.com/questions/11677369/how-to-calculate-pi-to-n-number-of-places-in-c-sharp-using-loops
//        /// answered Jul 26 '12 at 22:32 nicholas
//        /// </summary>
//        /// <param name="digits"></param>
//        /// <returns></returns>
//        //public static string Calculate(int digits)
//        //{
//        //    digits++;

//        //    uint[] x = new uint[digits * 10 / 3 + 2];
//        //    uint[] r = new uint[digits * 10 / 3 + 2];

//        //    uint[] pi = new uint[digits];

//        //    for (int j = 0; j < x.Length; j++)
//        //        x[j] = 20;

//        //    for (int i = 0; i < digits; i++)
//        //    {
//        //        uint carry = 0;
//        //        for (int j = 0; j < x.Length; j++)
//        //        {
//        //            uint num = (uint)(x.Length - j - 1);
//        //            uint dem = num * 2 + 1;

//        //            x[j] += carry;

//        //            uint q = x[j] / dem;
//        //            r[j] = x[j] % dem;

//        //            carry = q * num;
//        //        }


//        //        pi[i] = (x[x.Length - 1] / 10);


//        //        r[x.Length - 1] = x[x.Length - 1] % 10; ;

//        //        for (int j = 0; j < x.Length; j++)
//        //            x[j] = r[j] * 10;
//        //    }

//        //    var result = "";

//        //    uint c = 0;

//        //    for (int i = pi.Length - 1; i >= 0; i--)
//        //    {
//        //        pi[i] += c;
//        //        c = pi[i] / 10;

//        //        result = (pi[i] % 10) + result;
//        //    }

//        //    return result;
//        //}


//        /// <summary>
//        /// https://stackoverflow.com/questions/11677369/how-to-calculate-pi-to-n-number-of-places-in-c-sharp-using-loops
//        /// answered Jul 26 '12 at 22:32 nicholas
//        /// </summary>
//        /// <param name="digits"></param>
//        /// <returns></returns>
//        public static IEnumerable<uint> Calculate(int digits)
//        {
//            digits++;

//            uint[] x = new uint[digits * 10 / 3 + 2];
//            uint[] r = new uint[digits * 10 / 3 + 2];

//            uint[] pi = new uint[digits];

//            for (int j = 0; j < x.Length; j++)
//                x[j] = 20;

//            for (int i = 0; i < digits; i++)
//            {
//                uint carry = 0;
//                for (int j = 0; j < x.Length; j++)
//                {
//                    uint num = (uint)(x.Length - j - 1);
//                    uint dem = num * 2 + 1;

//                    x[j] += carry;

//                    uint q = x[j] / dem;
//                    r[j] = x[j] % dem;

//                    carry = q * num;
//                }


//                pi[i] = (x[x.Length - 1] / 10);


//                r[x.Length - 1] = x[x.Length - 1] % 10;
//                ;

//                for (int j = 0; j < x.Length; j++)
//                    x[j] = r[j] * 10;
//            }

//            var result = "";

//            uint c = 0;

//            for (int i = 0; i < pi.Length; i++)
//            {
//                pi[i] += c;
//                c = pi[i] / 10;

//                yield return (pi[i] % 10);
//            }
//        }
//    }

//}

