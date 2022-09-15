namespace Restaurants.ModelViews.Order
{
    public class UpdateOrderView
    {
        public int Id { get; set; }
        public int RestaurantMenuId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
    }
}
