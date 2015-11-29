using System.Linq;

namespace Linq.Examples.PLinq
{
    public class Aggregation : IExample
    {
        public void Run()
        {
            new[] { 1, 2, 3 }.AsParallel().Aggregate(
                () => 0,                                     // seedFactory
                (localTotal, n) => localTotal + n,           // updateAccumulatorFunc
                (mainTot, localTot) => mainTot + localTot,   // combineAccumulatorFunc
                finalResult => finalResult);                 // resultSelector

            var text = "Let’s suppose this is a really long string";
            var functionalResult = text.Aggregate(
                new int[26],                // Create the "accumulator"
                (letterFrequencies, c) =>   // Aggregate a letter into the accumulator
                {
                    int index = char.ToUpper(c) - 'A';
                    if (index >= 0 && index <= 26) letterFrequencies[index]++;
                    return letterFrequencies;
                });

            var result = text.AsParallel().Aggregate(
                    () => new int[26],             // Create a new local accumulator

                    (localFrequencies, c) =>       // Aggregate into the local accumulator
                    {
                        int index = char.ToUpper(c) - 'A';
                        if (index >= 0 && index <= 26) localFrequencies[index]++;
                        return localFrequencies;
                    },
                    // Aggregate local->main accumulator
                    (mainFreq, localFreq) =>
                        mainFreq.Zip(localFreq, (f1, f2) => f1 + f2).ToArray(),

                    finalResult => finalResult     // Perform any final transformation
                );                                 // on the end result.
        }
    }
}
