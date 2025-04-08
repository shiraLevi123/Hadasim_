using Grocery.Core.DTOs;
using Grocery.Core.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Grocery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        // GET: api/<Supplier>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Register dto)
        {
            var supplier = await _supplierService.RegisterSupplierAsync(dto);
            return Ok(supplier); 
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login dto)
        {
            var supplier = await _supplierService.LoginAsync(dto);

            if (supplier == null)
                return Unauthorized("Phone number or password is incorrect.");

            return Ok(new
            {
                supplier.Id,
                supplier.CompanyName,
                supplier.AgentName
            });
        }

        // GET api/<Supplier>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<Supplier>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<Supplier>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
