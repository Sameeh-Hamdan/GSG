using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PracticeProject.DTOs.Rest;
using RestSharp;
using System.Collections.Generic;
using System.IO.Pipelines;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestController : ControllerBase
    {
        // GET: api/<RestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("[action]")]
        public IActionResult GetRest()
        {
            var baseUrl = "https://mocki.io/v1/";
            var client = new RestClient(baseUrl);
            var request = new RestRequest("d4867d8b-b5d5-4a48-a4ab-79131b5809b8");
            var res = client.Execute(request);
            //
            if (res.IsSuccessful)
            {
                var con = res.Content;
                var deserializedFile = JsonConvert.DeserializeObject<List<RestDTO>>(con);
                return Ok(deserializedFile);
            }

            return BadRequest("Bad Request");
        }

        // GET api/<RestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
