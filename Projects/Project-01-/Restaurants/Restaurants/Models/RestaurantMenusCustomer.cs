using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurants.Models
{
    public partial class RestaurantMenusCustomer
    {
        public int RestaurantMenuId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual RestaurantMenu RestaurantMenu { get; set; }
    }
}
