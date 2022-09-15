using AutoMapper;
using Restaurants.Models;
using Restaurants.ModelViews.Customer;
using Restaurants.ModelViews.Details;
using Restaurants.ModelViews.Order;
using Restaurants.ModelViews.Restaurant;
using Restaurants.ModelViews.RestaurantMenu;

namespace Restaurants.Mappers
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<GetRestaurantView, Restaurant>().ReverseMap();
            CreateMap<AddRestaurantView, Restaurant>().ReverseMap();
            
            CreateMap<AddCustomerView, Customer>().ReverseMap();
            CreateMap<GetCustomersView, Customer>().ReverseMap();
            
            CreateMap<AddRestaurantMenu, RestaurantMenu>().ReverseMap();
            CreateMap<GetRestaurantMenu, RestaurantMenu>().ReverseMap();

            CreateMap<GetDetailsView, Detail>().ReverseMap();
            CreateMap<AddOrderView, Order>().ReverseMap();
            CreateMap<UpdateOrderView, Order>().ReverseMap();
        }
    }
}
