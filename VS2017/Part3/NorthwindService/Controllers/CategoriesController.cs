using Microsoft.AspNetCore.Mvc;
using Packt.CS7;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly Northwind db;

        public CategoriesController(Northwind db)
        {
            this.db = db;
        }

        // GET: api/categories
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var categories = db.Categories.ToArray();
            return categories;
        }

        // GET api/categories/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            var category = db.Categories.Find(id);
            return category;
        }
    }
}
