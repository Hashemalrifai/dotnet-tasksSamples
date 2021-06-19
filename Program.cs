using System;
using System.Threading;
using System.Threading.Tasks;

namespace TasksSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program main");

            Console.WriteLine("Task Continuation:");
            var taskContinuation = new TaskContinuation();
            taskContinuation.RunAsync().Wait();

            Console.WriteLine("Passing param to task");
            var tasksWithParam = new TaskWithParam(3);
            var result = tasksWithParam.RunAsync().Result;
            Console.WriteLine($"Should get result 9. Result is: {result}");


            Console.WriteLine("Task cancellation:");
            var taskCancellation = new TaskCancellation();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            Console.WriteLine("Let's cancel after 5 seconds");
            Task.Factory.StartNew(() =>
            {
                Task.Delay(5000).Wait();
                cancellationTokenSource.Cancel();
            });

            try
            {
                taskCancellation.RunAsync(cancellationTokenSource.Token).Wait();
            }
            catch (AggregateException ex)
            {
                if (ex?.InnerException is TaskCanceledException)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
            
            
            Console.WriteLine("Closing app");
        }

        ~Program()
        {
            Console.WriteLine("Finalizing app");
        }
    }
}
