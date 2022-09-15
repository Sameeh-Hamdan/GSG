using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Restaurants.Models
{
    public partial class Detail
    {
        public string RestaurantName { get; set; }
        public int? NumberOfOrderedCustomer { get; set; }
        public decimal? ProfitInUsd { get; set; }
        public decimal? ProfitInNis { get; set; }
    }
}
