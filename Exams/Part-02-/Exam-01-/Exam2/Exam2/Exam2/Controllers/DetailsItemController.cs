using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Exam2.Models;
using Exam2.ModelViews;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exam2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsItemController : ControllerBase
    {
        private readonly Exam_DBContext _dbContext;
        private IMapper _mapper;
        public DetailsItemController(Exam_DBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //GET: api/<DetailsItemController>
        [HttpGet]
        public IEnumerable<DetailsItem> Get()
        {
            //var items = _dbContext.Items.ToArray();
            var detailsItems = _dbContext.Items.Select(item => new DetailsItem
            {
                ItemId = item.Id,
                ItemName = item.Name,
                SubCategoryName = item.Sub.Name,
                CategoryName = item.Sub.Cat.Name
            })
            .ToArray();
            //var detailsItems = _mapper.Map<IEnumerable<DetailsItem>>(items);

            return detailsItems;
        }

        [HttpGet]
        public IEnumerable<DetailsItem> CSVPrint()
        {
            var detailsItems = _dbContext.Items.Select(item => new DetailsItem
            {
                ItemId = item.Id,
                ItemName = item.Name,
                SubCategoryName = item.Sub.Name,
                CategoryName = item.Sub.Cat.Name
            })
            .ToArray();
            var listOfItem = detailsItems.ToList();
            var csvPath = Path.Combine(Environment.CurrentDirectory, $"Items-{DateTime.Now.ToFileTime()}.csv");
            using (var streamWriter = new StreamWriter(csvPath))
            {
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(listOfItem);
                }
            }

            return detailsItems;
        }

        // GET api/<DetailsItemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DetailsItemController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DetailsItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DetailsItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
