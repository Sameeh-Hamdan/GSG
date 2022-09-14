using Restaurants.Models;
using Restaurants.ModelViews.Restaurant;
using System.Collections.Generic;

namespace Restaurants.Services
{
    public interface IRestaurantService
    {
        public List<GetRestaurantView> GetRestaurants();
        public GetRestaurantView GetRestaurantById(int id);
        public Restaurant AddNewRestaurant(AddRestaurantView addRestaurantView);
        public int UpdateRestaurant(GetRestaurantView getRestaurantView);
        public int DeleteRestaurant(int id);
    }
}
