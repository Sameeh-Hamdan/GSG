using Restaurants.ModelViews.Order;

namespace Restaurants.Services
{
    public interface IOrderService
    {
        public bool IsAvailable(int resturantMenuId);
        public AddOrderView Order(AddOrderView addOrderView);
        public int UpdateOrder(UpdateOrderView updateOrderView);
    }
}
