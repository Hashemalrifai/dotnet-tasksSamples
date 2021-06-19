using System;
using System.Threading.Tasks;

namespace TasksSample
{
    internal class TaskWithParam
    {
        private readonly int startingNumber;

        public TaskWithParam(int startingNumber)
        {
            this.startingNumber = startingNumber;
        }

        public Task<int> RunAsync()
        {
            return Task.Factory.StartNew((obj) =>
            {
                int num = (int)obj;
                return (int)Math.Pow(num, 2);
            }, this.startingNumber);
        }
    }
}