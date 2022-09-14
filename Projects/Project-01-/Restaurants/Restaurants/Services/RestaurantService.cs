using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurants.Extentions;
using Restaurants.Models;
using Restaurants.ModelViews.Customer;
using Restaurants.ModelViews.Restaurant;
using System.Collections.Generic;
using System.Linq;

namespace Restaurants.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly restaurantdbTestContext _context;
        private readonly IMapper _mapper;
        public RestaurantService(restaurantdbTestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Restaurant AddNewRestaurant(AddRestaurantView addRestaurantView)
        {
            var customer = _context.Restaurants.FirstOrDefault(rest =>
            rest.Name.ToLower().Equals(addRestaurantView.Name.ToLower())
            );
            if (customer == null)
            {
                addRestaurantView.Name= addRestaurantView.Name.Capitalize();
                var newRestaurant = _mapper.Map<Restaurant>(addRestaurantView);
                newRestaurant = _context.Restaurants.Add(newRestaurant).Entity;
                _context.SaveChanges();
                return newRestaurant;
            }
            return customer;
        }

        public int DeleteRestaurant(int id)
        {
            var rest = _context.Restaurants.Find(id);
            if (rest != null)
            {
                _context.Restaurants.Remove(rest);
                _context.SaveChanges();
                return rest.Id;
            }
            return 0;
        }

        public GetRestaurantView GetRestaurantById(int id)
        {
            var rest = _context.Restaurants.Find(id);
            if (rest != null)
            {
                var restaurantView = _mapper.Map<GetRestaurantView>(rest);
                return restaurantView;
            }
            return null;
        }

        public List<GetRestaurantView> GetRestaurants()
        {
            var restaurants = _context.Restaurants.ToList();
            var restaurantViews = _mapper.Map<List<GetRestaurantView>>(restaurants);
            return restaurantViews;
        }

        public int UpdateRestaurant(GetRestaurantView getRestaurantView)
        {
            var rest = _context.Restaurants.Find(getRestaurantView.Id);
            if (rest != null)
            {
                rest.Name = getRestaurantView.Name.Capitalize();
                rest.PhoneNumber=getRestaurantView.PhoneNumber;
                var updatedRest = _mapper.Map<Restaurant>(getRestaurantView);
                _context.Restaurants.Update(rest);
                _context.SaveChanges();
                return updatedRest.Id;
            }
            return 0;
        }
    }
}
