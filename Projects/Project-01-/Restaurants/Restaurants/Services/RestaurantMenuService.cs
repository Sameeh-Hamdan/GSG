using AutoMapper;
using Restaurants.Extentions;
using Restaurants.Models;
using Restaurants.ModelViews.Restaurant;
using Restaurants.ModelViews.RestaurantMenu;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurants.Services
{
    public class RestaurantMenuService : IRestaurantMenuService
    {
        private readonly restaurantdbTestContext _context;
        private readonly IMapper _mapper;
        public RestaurantMenuService(restaurantdbTestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public RestaurantMenu AddNewRestaurantMenu(AddRestaurantMenu restaurantMenu)
        {
            var restMenu = _context.RestaurantMenus.FirstOrDefault(meal =>
            meal.MealName.ToLower().Equals(restaurantMenu.MealName.ToLower())
            && meal.RestaurantId==restaurantMenu.RestaurantId
            );
            if (restMenu == null)
            {
                restaurantMenu.MealName = restaurantMenu.MealName.Capitalize();
                var newMeal = _mapper.Map<RestaurantMenu>(restaurantMenu);
                newMeal = _context.RestaurantMenus.Add(newMeal).Entity;
                _context.SaveChanges();
                return newMeal;
            }
            return restMenu;
        }

        public int DeleteRestaurantMenu(int id)
        {
            var meal = _context.RestaurantMenus.Find(id);
            if (meal != null)
            {
                _context.RestaurantMenus.Remove(meal);
                _context.SaveChanges();
                return meal.Id;
            }
            return 0;
        }

        public GetRestaurantMenu GetRestaurantMenuById(int id)
        {
            var meal = _context.RestaurantMenus.Find(id);
            if (meal != null)
            {
                var mealView = _mapper.Map<GetRestaurantMenu>(meal);
                return mealView;
            }
            return null;
        }

        public List<GetRestaurantMenu> GetRestaurantMenus()
        {
            var meals = _context.RestaurantMenus.ToList();
            var mealViews = _mapper.Map<List<GetRestaurantMenu>>(meals);
            return mealViews;
        }

        public int UpdateRestaurantMenu(GetRestaurantMenu getRestaurantMenu)
        {
            var meal = _context.RestaurantMenus.Find(getRestaurantMenu.Id);
            if (meal != null)
            {
                getRestaurantMenu.MealName = getRestaurantMenu.MealName.Capitalize();
                var updatedMeal = _mapper.Map<RestaurantMenu>(getRestaurantMenu);
                _context.RestaurantMenus.Update(updatedMeal);
                _context.SaveChanges();
                return updatedMeal.Id;
            }
            return 0;
        }
    }
}
