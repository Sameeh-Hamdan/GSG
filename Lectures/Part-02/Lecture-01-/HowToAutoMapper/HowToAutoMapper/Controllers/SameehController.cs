using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HowToAutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SameehController : ControllerBase
    {
        // GET: api/<SameehController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SameehController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SameehController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SameehController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SameehController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
