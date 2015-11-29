using System.Collections.Generic;
using System.Linq;

namespace Linq.Examples.Linq
{
    public class Substrings : IExample
    {
        public static IEnumerable<string> NGrams(string sentence, int q)
        {
            return Enumerable.Range(0, sentence.Length - q + 1)
                .Select(i => sentence.Substring(i, q)); 
        }

        public void Run()
        {
            var name = "LINQ";
            var result = Enumerable.Range(0, name.Length + 1)
            .SelectMany(z => NGrams(name, z))
            .Distinct()
            .Where(b => b.Length != 0);  
        }
    }
}
