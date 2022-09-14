using Microsoft.AspNetCore.Mvc;
using Restaurants.ModelViews.Customer;
using Restaurants.ModelViews.Restaurant;
using Restaurants.Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        // GET: api/<RestaurantsController>
        [HttpGet]
        public IEnumerable<GetRestaurantView> Get()
        {
            return _restaurantService.GetRestaurants();
        }

        // GET api/<RestaurantsController>/5
        [HttpGet("{id}")]
        public GetRestaurantView Get(int id)
        {
            return _restaurantService.GetRestaurantById(id);
        }

        // POST api/<RestaurantsController>
        [HttpPost]
        public IActionResult Post([FromBody] AddRestaurantView addRestaurantView)
        {
            var addNewRest = _restaurantService.AddNewRestaurant(addRestaurantView);
            if (addNewRest != null)
            {
                return Ok();
            }
            return BadRequest("Does Not Added");
        }

        // PUT api/<RestaurantsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GetRestaurantView getRestaurantView)
        {
            getRestaurantView.Id = id;
            var rest = _restaurantService.UpdateRestaurant(getRestaurantView);
            if (rest != 0)
            {
                return Ok();
            }
            return BadRequest("Not Updated");
        }

        // DELETE api/<RestaurantsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _restaurantService.DeleteRestaurant(id);
            if (isDeleted == 0)
            {
                return BadRequest("Not Deleted");
            }
            return Ok();
        }
    }
}
