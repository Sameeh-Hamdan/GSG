using AutoMapper;
using Restaurants.Models;
using Restaurants.ModelViews.Customer;

namespace Restaurants.Mappers
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<AddCustomerView, Customer>().ReverseMap();
            CreateMap<GetCustomersView, Customer>().ReverseMap();
        }
    }
}
