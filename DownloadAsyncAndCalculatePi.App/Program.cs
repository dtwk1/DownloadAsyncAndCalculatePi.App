namespace DownloadAsyncAndCalculatePi.App
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class Program
    {
        /// <summary>
        /// The address of content.
        /// </summary>
        private const string Url = "http://slowwly.robertomurray.co.uk/delay/3000/url/https://www.python.org/";

        /// <summary>
        /// # of times to download the content.
        /// </summary>
        private const int multiple = 10;

        static List<(byte[] bytes, string content)> downloads = new List<(byte[], string)>();
        static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        static List<BigInteger> PiDigits;

        public static void Main()
        {
            var task = CalculatePi();
            var task2 = Download();

            task.Start();
            task2.Start();

            task.GetAwaiter().OnCompleted(WriteToConsole);
            Console.Read();
        }

        private static Task Download() => new Task(
                async () =>
                    {
                        foreach (string download in await AsyncDownload.FromUrlRepeat(Url, multiple).ConfigureAwait(false))
                        {
                            downloads.Add((Encoding.ASCII.GetBytes(download), download.Substring(0, 200)));
                        }

                        cancellationTokenSource.Cancel();
                    });


        private static Task CalculatePi() => new Task(() => PiDigits = Math.CalcPiDigits().TakeWhileNotCancelled(cancellationTokenSource.Token));

        private static void WriteToConsole()
        {
            Console.WriteLine("Pi is" + Environment.NewLine);
            Console.WriteLine(string.Join(string.Empty, PiDigits).Insert(1, "."));

            int i = 0;
            foreach (var download in downloads)
            {
                i++;
                Console.WriteLine($"{Environment.NewLine} File {i} of {multiple}");
                Console.WriteLine($"{Environment.NewLine} # of bytes equals {download.bytes.Length}");
                Console.WriteLine($"{Environment.NewLine} content is {download.content} ...");
            }
        }
    }
}
