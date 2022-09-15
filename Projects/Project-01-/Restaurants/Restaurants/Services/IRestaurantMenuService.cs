using Restaurants.Models;
using Restaurants.ModelViews.Customer;
using Restaurants.ModelViews.Restaurant;
using Restaurants.ModelViews.RestaurantMenu;
using System.Collections.Generic;

namespace Restaurants.Services
{
    public interface IRestaurantMenuService
    {
        public List<GetRestaurantMenu> GetRestaurantMenus();
        public GetRestaurantMenu GetRestaurantMenuById(int id);
        public RestaurantMenu AddNewRestaurantMenu(AddRestaurantMenu restaurantMenu);
        public int UpdateRestaurantMenu(GetRestaurantMenu getRestaurantMenu);
        public int DeleteRestaurantMenu(int id);
    }
}
