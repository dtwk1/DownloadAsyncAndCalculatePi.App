
namespace DownloadAsyncAndCalculatePi.App
{
    using System.Collections.Generic;
    using System.Threading;

    static class Utility
    {
        public static List<T> TakeWhileNotCancelled<T>(this IEnumerable<T> enumerable, CancellationToken token)
        {
            var enumerator = enumerable.GetEnumerator();
            List<T> list = new List<T>();

            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Current);

                if (token.IsCancellationRequested)
                {
                    enumerator.Dispose();
                    break;
                }
            }

            return list;
        }
    }
}
