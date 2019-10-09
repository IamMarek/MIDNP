using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace MIDNP.Linq
{
    [TestClass]
    public sealed class PLinqTest
    {
        [TestMethod]
        public void Test1_PrimeNumbers()
        {
            //Calculate a list of primes in parallel. With degree of parallelism 4. Do not use sophisticated algorithms. 
            var numbersCount = 1000000;
            var numbers = Enumerable.Range(3, numbersCount - 3);
            var primes = new int[122]; //TODO

            Assert.IsTrue(primes.First() == 3 && primes.Last() == 999983); 
        }

        /// <summary>
        /// Create a parallel spellchecker to find if an array of words is correctly spelled. 
        /// </summary>
        [TestMethod]
        public void Test3_Spellchecker()
        {
            var wordLookupFile = Path.Combine(Path.GetTempPath(), "WordLookup.txt");

            if (!File.Exists(wordLookupFile))
            {
                new WebClient().DownloadFile("http://www.albahari.com/ispell/allwords.txt", wordLookupFile);
            }

            var wordLookup = new HashSet<string>(File.ReadAllLines(wordLookupFile), StringComparer.InvariantCultureIgnoreCase);
            var wordList = wordLookup.ToArray();

            // Here, we're using ThreadLocal to generate a thread-safe random number generator,
            // so we can parallelize the building of the wordsToTest array.
            var localRandom = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));
            var wordsToTest = Enumerable.Range(0, 1000000)
                .AsParallel()
                .Select(i => wordList[localRandom.Value.Next(0, wordList.Length)])
                .ToArray();

            wordsToTest[12345] = "woozsh";     // Introduce a couple
            wordsToTest[23456] = "wubsie";     // of spelling mistakes.

            var incorrectWords = new[] { new { Word = "", Index = 666 } }; //TODO

            Assert.IsTrue(incorrectWords.First().Word == "woozsh" 
                          && incorrectWords.First().Index == 12345 
                          && incorrectWords.Last().Word == "wubsie"
                          && incorrectWords.Last().Index == 23456); 
        }
    }
}
