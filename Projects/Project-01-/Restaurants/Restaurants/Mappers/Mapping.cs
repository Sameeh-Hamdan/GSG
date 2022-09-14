using AutoMapper;
using Restaurants.Models;
using Restaurants.ModelViews.Customer;
using Restaurants.ModelViews.Restaurant;

namespace Restaurants.Mappers
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<AddCustomerView, Customer>().ReverseMap();
            CreateMap<GetCustomersView, Customer>().ReverseMap();
            CreateMap<GetRestaurantView, Restaurant>().ReverseMap();
            CreateMap<AddRestaurantView, Restaurant>().ReverseMap();
        }
    }
}
