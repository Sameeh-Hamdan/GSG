using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurants.Models
{
    public partial class RestaurantMenu
    {
        public RestaurantMenu()
        {
            RestaurantMenusCustomers = new HashSet<RestaurantMenusCustomer>();
        }

        public int Id { get; set; }
        public string MealName { get; set; }
        public decimal PriceInNis { get; set; }
        public decimal? PriceInUsd { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Archived { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<RestaurantMenusCustomer> RestaurantMenusCustomers { get; set; }
    }
}
