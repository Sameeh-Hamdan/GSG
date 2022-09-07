using Exam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly Exam_DBContext _DBContext;
        public ItemsController(Exam_DBContext dBContext)
        {
            _DBContext = dBContext;
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public IEnumerable<string> GetItems()
        {
            _DBContext.IgnoreFilter = true;
            var users = _DBContext.Items.ToList();
            return new string[] {""};
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ItemsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
