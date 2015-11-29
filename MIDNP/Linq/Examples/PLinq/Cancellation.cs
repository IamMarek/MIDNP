using System;
using System.Linq;
using System.Threading;

namespace Linq.Examples.PLinq
{
    public class Cancellation : IExample
    {
        public void Run()
        {
            var million = Enumerable.Range(3, 1000000);
            var cancelSource = new CancellationTokenSource();
            var primeNumberQuery = million
               .AsParallel()
               .WithCancellation(cancelSource.Token)
               .AsOrdered()
               .Where(n => Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0));

            new Thread(() => {
                Thread.Sleep(100);      // Cancel query after
                cancelSource.Cancel();   // 100 milliseconds.
            }
                       ).Start();
            try
            {
                // Start query running:
                int[] primes = primeNumberQuery.ToArray();
                // We'll never get here because the other thread will cancel us.
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Query canceled");
            }
        }
    }
}
