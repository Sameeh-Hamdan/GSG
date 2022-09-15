using AutoMapper;
using Restaurants.Models;
using Restaurants.ModelViews.Customer;
using Restaurants.ModelViews.Order;
using System.Collections.Generic;
using System.Linq;

namespace Restaurants.Services
{
    public class OrderService : IOrderService
    {
        private readonly RestaurantDBContext _context;
        private readonly IMapper _mapper;
        public OrderService(RestaurantDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool IsAvailable(int id,int quantity)
        {
            var meal = _context.RestaurantMenus.Find(id);
            if (meal.Quantity > 0 && meal.Quantity-quantity>=0)
            {
                return true;
            }
            return false;
        }
        public List<UpdateOrderView> GetOrders()
        {
            var orders = _context.Orders.ToList();
            var orderssView = _mapper.Map<List<UpdateOrderView>>(orders);
            return orderssView;
        }
        public AddOrderView Order(AddOrderView addOrderView)
        {
            var isAvailable = IsAvailable(addOrderView.RestaurantMenuId,addOrderView.Quantity);
            if (isAvailable)
            {
                var newOrder = _mapper.Map<Order>(addOrderView);
                newOrder = _context.Orders.Add(newOrder).Entity;
                _context.SaveChanges();

                //Minus Quantity
                var newQuanMeal = _context.RestaurantMenus.Find(addOrderView.RestaurantMenuId);
                newQuanMeal.Quantity -= addOrderView.Quantity;
                _context.RestaurantMenus.Update(newQuanMeal);
                _context.SaveChanges();

                return addOrderView;
            }

            return null;
        }

        public int UpdateOrder(UpdateOrderView updateOrderView)
        {
            var isAvailable = IsAvailable(updateOrderView.RestaurantMenuId,updateOrderView.Quantity);
            if (isAvailable)
            {
                var order = _context.Orders.Find(updateOrderView.Id);
                var newQuanMeal = _context.RestaurantMenus.Find(updateOrderView.RestaurantMenuId);
                var veriousQuan = order.Quantity;
                var veriousRestaurantMenuId = order.RestaurantMenuId;
                if (veriousQuan > updateOrderView.Quantity && veriousRestaurantMenuId == updateOrderView.RestaurantMenuId)
                {
                    //Ponus Quantity
                    newQuanMeal.Quantity += (veriousQuan-updateOrderView.Quantity);
                    _context.RestaurantMenus.Update(newQuanMeal);
                    _context.SaveChanges();
                }
                else if(veriousQuan < updateOrderView.Quantity && veriousRestaurantMenuId == updateOrderView.RestaurantMenuId)
                {
                    //Minus Quantity
                    newQuanMeal.Quantity -= (updateOrderView.Quantity-veriousQuan);
                    _context.RestaurantMenus.Update(newQuanMeal);
                    _context.SaveChanges();
                }
                if (order != null)
                {
                    order.RestaurantMenuId = updateOrderView.RestaurantMenuId;
                    order.CustomerId= updateOrderView.CustomerId;
                    order.Quantity = updateOrderView.Quantity;
                    var newoOrder = _mapper.Map<Order>(updateOrderView);
                    _context.Orders.Update(order);
                    _context.SaveChanges();
                    return order.CustomerId;
                }
            }
            
            return 0;
        }
        public int DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                order.Archived = true;
                _context.Orders.Update(order);
                _context.SaveChanges();
                return order.Id;
            }
            return 0;
        }
    }
}
