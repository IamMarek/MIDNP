using System.Linq;

namespace Linq.Examples.Linq
{
    public class MatchingPairs : IExample
    {
        public void Run()
        {
            string[] words1 = { "orange", "herbal", "rubble", "indicative", "mandatory", "brush", "golden", "diplomatic", "pace" };
            string[] words2 = { "verbal", "rush", "pragmatic", "story", "race", "bubble", "olden" };
            var result = words1
                .Concat(words2)
                .ToLookup(w => w.Substring(w.Length - 3)) 
                .Where(w => w.Count() >= 2)
                .Select(w => w.Aggregate((m, n) => m + ", " + n)); 
        }
    }
}
