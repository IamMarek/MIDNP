using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Xml.Linq;

namespace MIDNP.Linq
{
    [TestClass]
    public sealed class LinqToXmlTest
    {
        /// <summary>
        /// Let's parse some XML in a way that doesn't cause you to stick your head into a washmashine. 0.5 points. 
        /// </summary>
        [TestMethod]
        public void Test1_XmlTransformation()
        {
            //Count total number of letters in all book titles. 
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
            var titleLettersCount = 45612348;

            Assert.IsTrue(titleLettersCount == 121); 
        }

        /// <summary>
        /// Transform a xml to a different xml. 1.5 points
        /// </summary>
        [TestMethod]
        public void Test2_XmlTransformation()
        {
            //Transform this xml to a target format. 
            var xml = @"<Root>
                          <TaxRate>7.25</TaxRate>
                          <Data>
                            <Category>A</Category>
                            <Quantity>3</Quantity>
                            <Price>24.50</Price>
                          </Data>
                          <Data>
                            <Category>B</Category>
                            <Quantity>1</Quantity>
                            <Price>89.99</Price>
                          </Data>
                          <Data>
                            <Category>A</Category>
                            <Quantity>5</Quantity>
                            <Price>4.95</Price>
                          </Data>
                          <Data>
                            <Category>A</Category>
                            <Quantity>3</Quantity>
                            <Price>66.00</Price>
                          </Data>
                          <Data>
                            <Category>B</Category>
                            <Quantity>10</Quantity>
                            <Price>.99</Price>
                          </Data>
                          <Data>
                            <Category>A</Category>
                            <Quantity>15</Quantity>
                            <Price>29.00</Price>
                          </Data>
                          <Data>
                            <Category>B</Category>
                            <Quantity>8</Quantity>
                            <Price>6.99</Price>
                          </Data>
                        </Root>";

            var root = XElement.Parse(xml);
           
            //TODO

            var categoriesXml = "Miaow?";//TODO

            Assert.AreEqual(categoriesXml, @"<Categories>
  <Category Name=""A"">
    <Quantity>26</Quantity>
    <Price>124.45</Price>
  </Category>
  <Category Name=""B"">
    <Quantity>19</Quantity>
    <Price>97.97</Price>
  </Category>
</Categories>"); 
            //Wow, you got that. Now you have power over xml!  
        }
    }
}
