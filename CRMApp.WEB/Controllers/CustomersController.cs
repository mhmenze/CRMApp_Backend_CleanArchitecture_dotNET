//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace CRMApp.WEB.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomersController : ControllerBase
//    {
//        [HttpGet, Authorize]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "John Doe", "Jane Doe" };
//        }
//    }
//}


using System.Collections.Generic;
using System.Runtime.InteropServices;
using CRMApp.DAL.Data;
using CRMApp.DOMAIN.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRMApp.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return NotFound(); // Return 404 if customer not found

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> CreateCustomers(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Customer>>> UpdateCustomers(Customer customer)
        {
            var dbCustomer = await _context.Customers.FindAsync(customer.Id);
            if (dbCustomer == null)
                return BadRequest("Customer not found.");

            dbCustomer.Id = customer.Id;
            dbCustomer.FirstName = customer.FirstName;
            dbCustomer.LastName = customer.LastName;
            dbCustomer.Company = customer.Company;
            dbCustomer.Email = customer.Email;
            dbCustomer.PhoneNumber = customer.PhoneNumber;
            dbCustomer.Address = customer.Address;
            dbCustomer.CustomerType = customer.CustomerType;

            await _context.SaveChangesAsync();

            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Customer>>> DeleteCustomers(int id)
        {
            var dbCustomer = await _context.Customers.FindAsync(id);
            if (dbCustomer == null)
                return BadRequest("Customer not found.");

            _context.Customers.Remove(dbCustomer);
            await _context.SaveChangesAsync();

            return Ok(await _context.Customers.ToListAsync());
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //var customers = new List<TestCustomer>
        //{
        //    new TestCustomer { Position = 1, Name = "Nimal", Company = "Hayleys", Email = "nimal@hayleys.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 2, Name = "Sunil", Company = "Dialog", Email = "sunil@dialog.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 3, Name = "Ahamed", Company = "Unilever", Email = "ahamed@unilever.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 4, Name = "Dilmi", Company = "ABV", Email = "dilmi@abv.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 5, Name = "Hashan", Company = "SESW", Email = "hashan@sesw.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 6, Name = "Kamal", Company = "Singer", Email = "kamal@singer.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 7, Name = "Anjali", Company = "Cargills", Email = "anjali@cargills.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 8, Name = "Saman", Company = "Keells", Email = "saman@keells.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 9, Name = "Renuka", Company = "Ceylinco", Email = "renuka@ceylinco.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 10, Name = "Ruwan", Company = "SLT", Email = "ruwan@slt.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 11, Name = "Chaminda", Company = "Nestle", Email = "chaminda@nestle.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 12, Name = "Sanduni", Company = "Aitken Spence", Email = "sanduni@aitkenspence.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 13, Name = "Kavinda", Company = "HNB", Email = "kavinda@hnb.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 14, Name = "Manoj", Company = "HSBC", Email = "manoj@hsbc.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 15, Name = "Ishara", Company = "Sampath Bank", Email = "ishara@sampathbank.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 16, Name = "Tharindu", Company = "PABC", Email = "tharindu@pabc.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 17, Name = "Thilini", Company = "DFCC", Email = "thilini@dfcc.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 18, Name = "Asanka", Company = "Commercial Bank", Email = "asanka@combank.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 19, Name = "Janaka", Company = "Pan Asia Bank", Email = "janaka@pab.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 20, Name = "Kushan", Company = "NDB", Email = "kushan@ndb.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 21, Name = "Ranil", Company = "Peoples Bank", Email = "ranil@peoplesbank.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 22, Name = "Malika", Company = "Hatton National Bank", Email = "malika@hnb.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 23, Name = "Mahesh", Company = "Union Bank", Email = "mahesh@unionbank.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 24, Name = "Chathura", Company = "Seylan Bank", Email = "chathura@seylanbank.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 25, Name = "Sachith", Company = "Standard Chartered", Email = "sachith@sc.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 26, Name = "Tharaka", Company = "Commercial Leasing", Email = "tharaka@comleasing.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 27, Name = "Indika", Company = "Softlogic", Email = "indika@softlogic.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 28, Name = "Harsha", Company = "Hemas", Email = "harsha@hemas.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 29, Name = "Gayani", Company = "Odel", Email = "gayani@odel.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 30, Name = "Rajitha", Company = "Glitz", Email = "rajitha@glitz.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 31, Name = "Tharindra", Company = "Nike", Email = "tharindra@nike.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 32, Name = "Prasanna", Company = "Adidas", Email = "prasanna@adidas.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 33, Name = "Supun", Company = "Puma", Email = "supun@puma.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 34, Name = "Ranjan", Company = "New Balance", Email = "ranjan@newbalance.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 35, Name = "Namal", Company = "Under Armour", Email = "namal@underarmour.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 36, Name = "Dinusha", Company = "Reebok", Email = "dinusha@reebok.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 37, Name = "Roshan", Company = "Converse", Email = "roshan@converse.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 38, Name = "Sameera", Company = "Vans", Email = "sameera@vans.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 39, Name = "Lasith", Company = "Sketchers", Email = "lasith@sketchers.com", Phone = "077714345346" },
        //    new TestCustomer { Position = 40, Name = "Chamari", Company = "Fila", Email = "chamari@fila.com", Phone = "077714345346" }

        //};

        //return Ok(customers);
        //}
    }

    //public class TestCustomer
    //{
    //    public int Position { get; set; }
    //    public string Name { get; set; }
    //    public string Company { get; set; }
    //    public string Email { get; set; }
    //    public string Phone { get; set; }
    //}
}
