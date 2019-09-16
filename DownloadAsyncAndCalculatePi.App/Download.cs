namespace DownloadAsyncAndCalculatePi.App
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    class AsyncDownload
    {
        public static async Task<IEnumerable<string>> FromUrlRepeat(string url,int multiple)
        {
            ConcurrentQueue<string> coll = new ConcurrentQueue<string>();
            Task[] tasks = new Task[multiple];
            using (var client = BuildHttpClient(multiple))
            {
                for (int i = 0; i < multiple; i++)
                {
                    tasks[i] = EnqueueItemAsync(coll, GetContentAsync(client, url));
                }

                Task.WaitAll(tasks);
            }

            return coll;
        }

        private static HttpClient BuildHttpClient(int multiple) => new HttpClient(new HttpClientHandler { MaxConnectionsPerServer = multiple });

        private static async Task EnqueueItemAsync<T>(ConcurrentQueue<T> collection, Task<T> item) => collection.Enqueue(await item.ConfigureAwait(false));

        private static async Task<string> GetContentAsync(HttpClient httpClient, string url)
        {
            using (var httpResponse = await httpClient.GetAsync(url).ConfigureAwait(false))
            {
                return await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }
    }
}
