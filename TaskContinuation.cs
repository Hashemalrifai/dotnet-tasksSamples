using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TasksSample
{
    class TaskContinuation
    {
        public Task RunAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Inside parent task. ThreadId = {Thread.CurrentThread.ManagedThreadId}");
            }).ContinueWith(t =>
            {
                Console.WriteLine($"Inside child 1 task. ThreadId = {Thread.CurrentThread.ManagedThreadId}");
            }).ContinueWith(t =>
            {
                Console.WriteLine($"Inside child 2 task. ThreadId = {Thread.CurrentThread.ManagedThreadId}");
            });
        }
    }
}
