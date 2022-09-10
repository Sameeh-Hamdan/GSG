using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Exam2.Models;
using Exam2.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<DetailsItemDTO> Get()
        {
            var detailsOfItems = _dbContext.DetailsOfItems.ToArray();
            var detailsItemsDTO = _mapper.Map<IEnumerable<DetailsItemDTO>>(detailsOfItems);

            return detailsItemsDTO;
        }

        [HttpGet("[action]")]
        public IActionResult CSVPrint()
        {
            var detailsOfItems = _dbContext.DetailsOfItems.ToList();
            var detailsItemsDTO = _mapper.Map<List<DetailsItemDTO>>(detailsOfItems);
            
            var csvPath = Path.Combine(Environment.CurrentDirectory, $"Items-{DateTime.Now.ToFileTime()}.csv");
            using (var streamWriter = new StreamWriter(csvPath))
            {
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(detailsItemsDTO);
                }
            }

            return Ok();
        }

        //GET api/<DetailsItemController>/5
        [HttpGet("{id}")]
        public DetailsItemDTO Get(int id)
        {
            var detailsOfItem = _dbContext.DetailsOfItems.Where(x=>x.ItemId==id).First();
            var detailsItemsDTO = _mapper.Map<DetailsItemDTO>(detailsOfItem);
            return detailsItemsDTO;
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
