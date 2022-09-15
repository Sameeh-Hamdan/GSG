using Microsoft.AspNetCore.Mvc;
using Restaurants.ModelViews.Customer;
using Restaurants.ModelViews.Order;
using Restaurants.Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<UpdateOrderView> Get()
        {
            return _orderService.GetOrders();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public IActionResult Post([FromBody] AddOrderView addOrderView)
        {
            var addNewOrder = _orderService.Order(addOrderView);
            if (addNewOrder != null)
            {
                return Ok();
            }
            return BadRequest("Does Not Added");
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] UpdateOrderView updateOrderView)
        {
            updateOrderView.Id=Id;
            var updateOrder = _orderService.UpdateOrder(updateOrderView);
            if (updateOrder != 0)
            {
                return Ok();
            }
            return BadRequest("Not Updated");
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _orderService.DeleteOrder(id);
            if (isDeleted == 0)
            {
                return BadRequest("Not Deleted");
            }
            return Ok();
        }
    }
}
