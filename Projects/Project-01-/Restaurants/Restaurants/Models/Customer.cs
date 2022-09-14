using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurants.Models
{
    public partial class Customer
    {
        public Customer()
        {
            RestaurantMenusCustomers = new HashSet<RestaurantMenusCustomer>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Archived { get; set; }

        public virtual ICollection<RestaurantMenusCustomer> RestaurantMenusCustomers { get; set; }
    }
}
