namespace Restaurants.ModelViews.RestaurantMenu
{
    public class GetRestaurantMenu
    {
        public int Id { get; set; }
        public string MealName { get; set; }
        public decimal PriceInNis { get; set; }
        public int Quantity { get; set; }
        public int RestaurantId { get; set; }
    }
}
