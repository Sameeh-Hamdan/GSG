using System.ComponentModel.DataAnnotations;

namespace Restaurants.ModelViews.Details
{
    public class GetDetailsView
    {
        public string RestaurantName { get; set; }
        public int? NumberOfOrderedCustomer { get; set; }
        public decimal? ProfitInUsd { get; set; }
        public decimal? ProfitInNis { get; set; }
    }
}
