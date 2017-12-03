using System;
using static System.Console;
using Packt.CS7;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Xml.Linq;

namespace LinqWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Northwind())
            {
                var query = db.Products
                    .ProcessSequence()
                    .Where(product => product.UnitPrice < 10M)
                    .OrderByDescending(product => product.UnitPrice)
                    .Select(product => new
                    {
                        product.ProductID,
                        product.ProductName,
                        product.UnitPrice
                    });

                WriteLine("Products that cost less than $10:");
                foreach (var item in query)
                {
                    WriteLine($"{item.ProductID}: {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
                }
                WriteLine();

                // create two sequences that we want to join together 
                var categories = db.Categories.Select(
                  c => new { c.CategoryID, c.CategoryName }).ToArray();

                var products = db.Products.Select(
                  p => new { p.ProductID, p.ProductName, p.CategoryID }).ToArray();

                // join every product to its category to return 77 matches 
                var queryJoin = categories.Join(products,
                  category => category.CategoryID,
                  product => product.CategoryID,
                  (c, p) => new { c.CategoryName, p.ProductName, p.ProductID })
                  .OrderBy(cp => cp.ProductID); ;

                foreach (var item in queryJoin)
                {
                    WriteLine($"{item.ProductID}: {item.ProductName} is in {item.CategoryName}.");
                }

                // group all products by their category to return 8 matches 
                var queryGroup = categories.GroupJoin(products,
                  category => category.CategoryID,
                  product => product.CategoryID,
                  (c, Products) => new
                  {
                      c.CategoryName,
                      Products = Products.OrderBy(p => p.ProductName)
                  });

                foreach (var item in queryGroup)
                {
                    WriteLine(
                    $"{item.CategoryName} has {item.Products.Count()} products.");
                    foreach (var product in item.Products)
                    {
                        WriteLine($"  {product.ProductName}");
                    }
                }

                WriteLine("Products");
                WriteLine($"  Count: {db.Products.Count()}");
                WriteLine($"  Sum of units in stock: {db.Products.Sum(p => p.UnitsInStock):N0}");
                WriteLine($"  Sum of units on order: {db.Products.Sum(p => p.UnitsOnOrder):N0}");
                WriteLine($"  Average unit price: {db.Products.Average(p => p.UnitPrice):$#,##0.00}");
                WriteLine($"  Value of units in stock: {db.Products.Sum(p => p.UnitPrice * p.UnitsInStock):$#,##0.00}");

                WriteLine("Custom LINQ extension methods:");
                WriteLine($"  Mean units in stock: {db.Products.Average(p => p.UnitsInStock):N0}");
                WriteLine($"  Mean unit price: {db.Products.Average(p => p.UnitPrice):$#,##0.00}");
                WriteLine($"  Median units in stock: {db.Products.Median(p => p.UnitsInStock)}");
                WriteLine($"  Median unit price: {db.Products.Median(p => p.UnitPrice):$#,##0.00}");
                WriteLine($"  Mode units in stock: {db.Products.Mode(p => p.UnitsInStock)}");
                WriteLine($"  Mode unit price: {db.Products.Mode(p => p.UnitPrice):$#,##0.00}");

                var productsForXml = db.Products.ToArray();
                var xml = new XElement("products",
                  from p in productsForXml
                  select new XElement("product",
                    new XAttribute("id", p.ProductID),
                    new XAttribute("price", p.UnitPrice),
                    new XElement("name", p.ProductName)));
                WriteLine(xml.ToString());

                XDocument doc = XDocument.Load("settings.xml");
                var appSettings = doc.Descendants(
                  "appSettings").Descendants("add")
                  .Select(node => new
                  {
                      Key = node.Attribute("key").Value,
                      Value = node.Attribute("value").Value
                  })
                 .ToArray();
                foreach (var item in appSettings)
                {
                    WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}
