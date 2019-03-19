using System;
using static System.Console;
using Packt.CS7;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Storage;

namespace WorkingWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // QueryingCategories();
            // QueryingProducts();
            // QueryingWithLike();

            // AddProduct(6, "Bob's Burgers", 500M);
            // IncreaseProductPrice("Bob", 20M);

            int deleted = DeleteProducts("Bob");
            WriteLine($"{deleted} product(s) were deleted.");
            ListProducts();
        }

        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                WriteLine("Categories and how many products they have:");

                // a query to get all categories and their related products
                IQueryable<Category> cats;
                // = db.Categories;//.Include(c => c.Products);

                Write("Enable eager loading? (Y/N): ");
                bool eagerloading = (ReadKey().Key == ConsoleKey.Y);
                bool explicitloading = false;
                WriteLine();
                if (eagerloading)
                {
                    cats = db.Categories.Include(c => c.Products);
                }
                else
                {
                    cats = db.Categories;
                    Write("Enable explicit loading? (Y/N): ");
                    explicitloading = (ReadKey().Key == ConsoleKey.Y);
                    WriteLine();
                }

                foreach (Category c in cats)
                {
                    if (explicitloading)
                    {
                        Write($"Explicitly load products for {c.CategoryName}? (Y/N):");
                        if (ReadKey().Key == ConsoleKey.Y)
                        {
                            var products = db.Entry(c).Collection(c2 => c2.Products);
                            if (!products.IsLoaded) products.Load();
                        }
                        WriteLine();
                    }
                    WriteLine(
                        $"{c.CategoryName} has {c.Products.Count} products.");
                }
            }
        }
        static void QueryingProducts()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                WriteLine("Products that cost more than a price, and sorted.");
                string input;
                decimal price;
                do
                {
                    Write("Enter a product price: ");
                    input = ReadLine();
                } while (!decimal.TryParse(input, out price));

                IQueryable<Product> prods = db.Products
                  .Where(product => product.Cost > price)
                  .OrderByDescending(product => product.Cost);

                foreach (Product item in prods)
                {
                    WriteLine($"{item.ProductID}: {item.ProductName} costs {item.Cost:$#,##0.00} and has {item.Stock} units in stock.");
                }
            }
        }

        static void QueryingWithLike()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                Write("Enter part of a product name: ");
                string input = ReadLine();

                IQueryable<Product> prods = db.Products
                    .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));

                foreach (Product item in prods)
                {
                    WriteLine($"{item.ProductName} has {item.Stock} units in stock. Discontinued? {item.Discontinued}");
                }
            }
        }

        static bool AddProduct(int categoryID,
          string productName, decimal? price)
        {
            using (var db = new Northwind())
            {
                var newProduct = new Product
                {
                    CategoryID = categoryID,
                    ProductName = productName,
                    Cost = price
                };

                // mark product as added in change tracking 
                db.Products.Add(newProduct);

                // save tracked changes to database 
                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }
        static void ListProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine("------------------------------------------------------------------------");
                WriteLine("| ID  | Product Name                        |     Cost | Stock | Disc. |");
                WriteLine("------------------------------------------------------------------------");
                foreach (var item in db.Products
                    .OrderByDescending(p => p.Cost))
                {
                    WriteLine($"| {item.ProductID:000} | {item.ProductName,-35} | {item.Cost,8:$#,##0.00} | {item.Stock,5} | {item.Discontinued} |");
                }
                WriteLine("------------------------------------------------------------------------");
            }
        }

        static bool IncreaseProductPrice(string name, decimal amount)
        {
            using (var db = new Northwind())
            {
                Product updateProduct = db.Products.First(
                  p => p.ProductName.StartsWith(name));
                updateProduct.Cost += amount;
                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }

        static int DeleteProducts(string name)
        {
            using (var db = new Northwind())
            {
                using (IDbContextTransaction t =
                    db.Database.BeginTransaction())
                {
                    WriteLine($"Transaction started with this isolation level: {t.GetDbTransaction().IsolationLevel}");

                    var products = db.Products.Where(
                        p => p.ProductName.StartsWith(name));
                    db.Products.RemoveRange(products);
                    int affected = db.SaveChanges();
                    t.Commit();
                    return affected;
                }
            }
        }
    }
}

