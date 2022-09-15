using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Restaurants.ModelViews.Details;
using Restaurants.ModelViews.RestaurantMenu;
using Restaurants.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSVHelperController : ControllerBase
    {
        private readonly IDetailService _detailService;
        public CSVHelperController(IDetailService detailService)
        {
            _detailService = detailService;
        }
        // GET: api/<CSVHelperController>
        [HttpGet]
        public IEnumerable<GetDetailsView> Get()
        {
            var details= _detailService.GetDetails();
            var csvPath = Path.Combine(Environment.CurrentDirectory, $"CSVFiles\\Details-{DateTime.Now.ToFileTime()}.csv");
            using (var streamWriter = new StreamWriter(csvPath))
            {
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(details);
                }
            }

            return details;
        }

        // GET api/<CSVHelperController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CSVHelperController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CSVHelperController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CSVHelperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
