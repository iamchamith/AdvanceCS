using System;
using System.Threading; 
using System.Threading.Tasks;

namespace CShard
{
    internal class TasksAndThreads
    {
        public void Execute()
        {
            var start = DateTime.Now;
            var cancelationTokenSource = new CancellationTokenSource();
            var t1 = Task.Factory.StartNew(() => RenderVideo(140, 500, cancelationTokenSource))
                .ContinueWith(p =>
                {
                    SaveVideo(1000, p.Result.Item2, cancelationTokenSource);
                });

            var t2 = Task.Factory.StartNew(() => RenderVideo(720, 1000, cancelationTokenSource))
                 .ContinueWith(p =>
                 {
                     SaveVideo(2000, p.Result.Item2, cancelationTokenSource);
                 });

            Task.WaitAll(t1, t2);
            Console.WriteLine((DateTime.Now - start).Seconds);
        }

        public (bool, string) RenderVideo(int quality, int sleep, CancellationTokenSource ct)
        {
            if (ct.IsCancellationRequested) {

                Thread.Sleep(sleep * 2);
                Console.WriteLine($"Rolleback Render {quality} video.");
            }

            for (int i = 0; i < 5; i++)
            {
                if (new Random().Next(1, 5) == 2) {                 
                    ct.Cancel();
                }
                Thread.Sleep(sleep);
                Console.WriteLine($"Render {quality} video \t {i}");
            }
            return (true, $"{quality}.mp3");
        }
        public void SaveVideo(int sleep, string fileName, CancellationTokenSource ct)
        {
            if (ct.IsCancellationRequested)
            {
                Thread.Sleep(sleep * 2);
                Console.WriteLine($"Rolleback Save {fileName} video.");
                return;
            }

            Thread.Sleep(sleep);
            Console.WriteLine($"Save {fileName} video.");
        }
    }
}
