using Microsoft.AspNetCore.Mvc;
using Restaurants.ModelViews.Restaurant;
using Restaurants.ModelViews.RestaurantMenu;
using Restaurants.Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantMenusController : ControllerBase
    {
        private readonly IRestaurantMenuService _restaurantMenuService;
        public RestaurantMenusController(IRestaurantMenuService restaurantMenuService)
        {
            _restaurantMenuService = restaurantMenuService;
        }
        // GET: api/<RestaurantMenusController>
        [HttpGet]
        public IEnumerable<GetRestaurantMenu> Get()
        {
            return _restaurantMenuService.GetRestaurantMenus();
        }

        // GET api/<RestaurantMenusController>/5
        [HttpGet("{id}")]
        public GetRestaurantMenu Get(int id)
        {
            return _restaurantMenuService.GetRestaurantMenuById(id);
        }

        // POST api/<RestaurantMenusController>
        [HttpPost]
        public IActionResult Post([FromBody] AddRestaurantMenu addRestaurantMenu)
        {
            var addNewMeal = _restaurantMenuService.AddNewRestaurantMenu(addRestaurantMenu);
            if (addNewMeal != null)
            {
                return Ok();
            }
            return BadRequest("Does Not Added");
        }

        // PUT api/<RestaurantMenusController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GetRestaurantMenu getRestaurantMenu)
        {
            getRestaurantMenu.Id = id;
            var rest = _restaurantMenuService.UpdateRestaurantMenu(getRestaurantMenu);
            if (rest != 0)
            {
                return Ok();
            }
            return BadRequest("Not Updated");
        }

        // DELETE api/<RestaurantMenusController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _restaurantMenuService.DeleteRestaurantMenu(id);
            if (isDeleted == 0)
            {
                return BadRequest("Not Deleted");
            }
            return Ok();
        }
    }
}
