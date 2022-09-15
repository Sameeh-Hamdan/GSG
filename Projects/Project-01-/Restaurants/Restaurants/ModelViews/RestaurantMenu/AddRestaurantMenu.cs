using System;

namespace Restaurants.ModelViews.RestaurantMenu
{
    public class AddRestaurantMenu
    {
        public string MealName { get; set; }
        public decimal PriceInNis { get; set; }
        public int Quantity { get; set; }
        public int RestaurantId { get; set; }
    }
}
