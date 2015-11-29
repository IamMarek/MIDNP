using System;
using System.Linq;

namespace Linq.Examples.PLinq
{
    public class PrimeNumbers : IExample
    {
        public void Run()
        {
            var numbersCount = 1000000; 
            var numbers = Enumerable.Range(3, numbersCount - 3);
            var parallelQuery = numbers
                .AsParallel()
                .WithDegreeOfParallelism(4)
                .AsOrdered()
                .Where(n => Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0)); 

            int[] primes = parallelQuery.ToArray();
            primes.Take(100);
        }
    }
}
