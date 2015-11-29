using System.Linq;
using System.Xml.Linq;

namespace Linq.Examples.XLinq
{
    public class CalculateValues : IExample
    {
        public void Run()
        {
            XNamespace ad = "http://www.adatum.com";
            var xml = @"<Root xmlns='http://www.adatum.com'>
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
            var result = root.Elements(ad + "Data")
                .Select(e => new { Quantity = (decimal)e.Element(ad + "Quantity"), Price = (decimal)e.Element(ad + "Price") })
                .Select(d => d.Quantity * d.Price)
                .Where(c => c > 25)
                .OrderBy(c => c);

            var categories = root.Elements(ad + "Data")
                .Select(e => new {
                    Quantity = (decimal)e.Element(ad + "Quantity"),
                    Price = (decimal)e.Element(ad + "Price"),
                    Category = e.Element(ad + "Category").Value })
                .GroupBy(d => d.Category)
                .Select(c => new XElement("Category", new XAttribute("Name", c.Key), 
                    new XElement("Quantity", c.Sum(s => s.Quantity)), 
                    new XElement("Price", c.Sum(s => s.Price))
                    )
                );

            var categoriesXml = new XElement("Categories", categories).ToString(); 
        }
    }
}
