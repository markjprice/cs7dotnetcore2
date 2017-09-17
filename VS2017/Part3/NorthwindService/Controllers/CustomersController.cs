using Microsoft.AspNetCore.Mvc;
using Packt.CS7;
using NorthwindService.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindService.Controllers
{
    // base address: api/customers 
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private ICustomerRepository repo;

        // constructor injects registered repository 
        public CustomersController(ICustomerRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/customers 
        // GET: api/customers/?country=[country] 
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers(string country)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                return await repo.RetrieveAllAsync();
            }
            else
            {
                return (await repo.RetrieveAllAsync())
                    .Where(customer => customer.Country == country);
            }
        }

        // GET: api/customers/[id] 
        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(string id)
        {
            Customer c = await repo.RetrieveAsync(id);

            if (c == null)
            {
                return NotFound(); // 404 Resource not found 
            }

            return new ObjectResult(c); // 200 OK 
        }

        // POST: api/customers 
        // BODY: Customer (JSON, XML) 
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer c)
        {
            if (c == null)
            {
                return BadRequest(); // 400 Bad request 
            }

            Customer added = await repo.CreateAsync(c);

            return CreatedAtRoute("GetCustomer", // use named route
                new { id = added.CustomerID.ToLower() }, c); // 201 Created 
        }

        // PUT: api/customers/[id] 
        // BODY: Customer (JSON, XML) 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Customer c)
        {
            // normalize to UPPER CASE
            id = id.ToUpper();
            c.CustomerID = c.CustomerID.ToUpper();

            if (c == null || c.CustomerID != id)
            {
                return BadRequest(); // 400 Bad request 
            }

            var existing = await repo.RetrieveAsync(id);
            if (existing == null)
            {
                return NotFound(); // 404 Resource not found 
            }

            await repo.UpdateAsync(id, c);

            return new NoContentResult(); // 204 No content 
        }

        // DELETE: api/customers/[id] 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await repo.RetrieveAsync(id);
            if (existing == null)
            {
                return NotFound(); // 404 Resource not found 
            }

            bool deleted = await repo.DeleteAsync(id);

            if (deleted)
            {
                return new NoContentResult(); // 204 No content 
            }
            else
            {
                return BadRequest();
            }
        }
    }
}