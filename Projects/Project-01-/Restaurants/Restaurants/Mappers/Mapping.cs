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
            CreateMap<AddCustomerView, Customer>().ReverseMap();
            CreateMap<GetCustomersView, Customer>().ReverseMap();
            CreateMap<GetRestaurantView, Restaurant>().ReverseMap();
            CreateMap<AddRestaurantView, Restaurant>().ReverseMap();
            CreateMap<AddRestaurantMenu, RestaurantMenu>().ReverseMap();
            CreateMap<GetRestaurantMenu, RestaurantMenu>().ReverseMap();
            CreateMap<GetDetailsView, Detail>().ReverseMap();
            CreateMap<AddOrderView, RestaurantMenusCustomer>().ReverseMap();
            CreateMap<UpdateOrderView, RestaurantMenusCustomer>().ReverseMap();
        }
    }
}
