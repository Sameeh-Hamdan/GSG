using Microsoft.AspNetCore.Mvc;
using Restaurants.Models;
using Restaurants.ModelViews.Customer;
using Restaurants.Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<GetCustomersView> Get()
        {
            return _customerService.GetCustomers();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public GetCustomersView Get(int id)
        {
            return _customerService.GetCustomerById(id);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public IActionResult Post([FromBody] AddCustomerView addCustomerView)
        {
            var addNewCustomer=_customerService.AddNewCustomer(addCustomerView);
            if(addNewCustomer != null)
            {
                return Ok();
            }
            return BadRequest("Does Not Added");
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
