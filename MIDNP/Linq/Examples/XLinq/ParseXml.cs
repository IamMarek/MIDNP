using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linq.Examples.XLinq
{
    public class ParseXml : IExample
    {
        public void Run()
        {
            var xml = @"<books>
            <book>
            <title>Pro LINQ: Language Integrated Query in C#2010</title>
            <author>Joe Rattz</author>
            </book>
            <book>
            <title>Pro .NET 4.0 Parallel Programming in C#</title>
            <author>Adam Freeman</author>
            </book>
            <book>
            <title>Pro VB 2010 and the .NET 4.0 Platform</title>
            <author>Andrew Troelsen</author>
            </book>
            </books>"; 

            var books = XElement.Parse(xml);
            var titles = books.Descendants("title").Select(e => e.Value); 
        }
    }
}
