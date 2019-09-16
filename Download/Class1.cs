using System;

namespace Download
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class Async
    {

        public static async Task<IEnumerable<string>> DownloadContentFromUrl(string url, int times)
        {
            ConcurrentQueue<string> coll = new ConcurrentQueue<string>();
            Task[] tasks = new Task[times];
            using (var client = BuildHttpClient(times))
            {
                for (int i = 0; i < times; i++)
                {
                    tasks[i] = EnqueuItemAsync(coll, GetContentAsync(client, url));
                }

                Task.WaitAll(tasks);
            }

            return coll;
        }


        private static HttpClient BuildHttpClient(int maxConnections) => new HttpClient(new HttpClientHandler { MaxConnectionsPerServer = maxConnections });

        public static async Task EnqueuItemAsync<T>(ConcurrentQueue<T> collection, Task<T> item)
        {
           collection.Enqueue(await item);
        }

        public static async Task<string> GetContentAsync(HttpClient httpClient, string url)
        {
            using (var httpResponse = await httpClient.GetAsync(url).ConfigureAwait(false))
            {
                return await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }

        //public IEnumerable<TContent> DownloadContentFromUrls<TContent>(IEnumerable<string> urls)
        //{
        //    var queue = new ConcurrentQueue<TContent>();

        //    using (var client = new HttpClient())
        //    {

        //        await Task.Run(() => Parallel.ForEach(strings, s =>
        //            {
        //                client.GetAsync(url).ContinueWith(async response => await (await response).Content.ReadAsStringAsync())).ToArray()
        //            }));
        //    }

        //    return queue;
        //}

    }
}
