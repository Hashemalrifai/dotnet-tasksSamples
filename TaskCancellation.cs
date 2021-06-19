using System;
using System.Threading;
using System.Threading.Tasks;

namespace TasksSample
{
    class TaskCancellation
    {
        public TaskCancellation()
        {
        }

        public Task RunAsync(CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    Console.WriteLine($"Iteration {i + 1}");
                    Task.Delay(1000).Wait();
                }
            }, cancellationToken);
        }
    }
}