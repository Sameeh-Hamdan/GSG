using AutoMapper;
using Restaurants.Models;
using Restaurants.ModelViews.Customer;
using Restaurants.ModelViews.Order;
using System.Linq;

namespace Restaurants.Services
{
    public class OrderService:IOrderService
    {
        private readonly restaurantdbTestContext _context;
        private readonly IMapper _mapper;
        public OrderService(restaurantdbTestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool IsAvailable(int resturantMenuId)
        {
            var meal=_context.RestaurantMenus.Find(resturantMenuId);
            if (meal.Quantity > 0)
            {
                return true;
            }
            return false;
        }

        public AddOrderView Order(AddOrderView addOrderView)
        {
            var order = _context.RestaurantMenusCustomers.FirstOrDefault(ordr =>
            ordr.RestaurantMenuId==addOrderView.RestaurantMenuId
            && ordr.CustomerId == addOrderView.CustomerId
            );
            if (order == null)
            {
                var newOrder = _mapper.Map<RestaurantMenusCustomer>(addOrderView);
                newOrder = _context.RestaurantMenusCustomers.Add(newOrder).Entity;
                _context.SaveChanges();
                return addOrderView;
            }
            return null;
        }

        public int UpdateOrder(UpdateOrderView updateOrderView)
        {
            var order = _context.RestaurantMenusCustomers.Find(updateOrderView.RestaurantMenuId,updateOrderView.CustomerId);
            if (order != null)
            {
                var updatedOrder = _mapper.Map<RestaurantMenusCustomer>(updateOrderView);
                _context.RestaurantMenusCustomers.Update(updatedOrder);
                _context.SaveChanges();
                return updatedOrder.CustomerId;
            }
            return 0;
        }
    }
}
