using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurants.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int RestaurantMenuId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Archived { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual RestaurantMenu RestaurantMenu { get; set; }
    }
}
