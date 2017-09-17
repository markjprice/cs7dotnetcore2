using Microsoft.AspNetCore.Mvc;
using Packt.CS7;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly Northwind db;

        public ProductsController(Northwind db)
        {
            this.db = db;
        }

        // GET: api/products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = db.Products.ToArray();
            return products;
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public IEnumerable<Product> GetByCategory(int id)
        {
            var products = db.Products.Where(p => p.CategoryID == id).ToArray();
            return products;
        }
    }
}
