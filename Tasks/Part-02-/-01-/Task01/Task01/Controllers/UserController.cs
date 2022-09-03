using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Task01.Extentions;
using Task01.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Task01_DBContext _dbContext; 
        public UserController(Task01_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _dbContext.IgnoreFilter=true;
            var users = _dbContext.Users.DistinctByName().ToList();
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
