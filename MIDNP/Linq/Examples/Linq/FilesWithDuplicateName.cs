using System.IO;
using System.Linq;

namespace Linq.Examples.Linq
{
    public class FilesWithDuplicateName : IExample
    {
        public void Run()
        {
            var result = Directory.GetFiles(@"c:\Temp\", "*.*", SearchOption.AllDirectories)
            .Select(d => new FileInfo(d))
            .Select(d => new { FileName = d.Name, Directory = d.DirectoryName })
            .ToLookup(d => d.FileName)
            .Where(d => d.Count() >= 2); 
        }
    }
}
