using Restaurants.ModelViews.Customer;
using Restaurants.ModelViews.Order;
using System.Collections.Generic;

namespace Restaurants.Services
{
    public interface IOrderService
    {
        public bool IsAvailable(int resturantMenuId, int quantity);
        public List<UpdateOrderView> GetOrders();
        public AddOrderView Order(AddOrderView addOrderView);
        public int UpdateOrder(UpdateOrderView updateOrderView);
        public int DeleteOrder(int id);
    }
}
