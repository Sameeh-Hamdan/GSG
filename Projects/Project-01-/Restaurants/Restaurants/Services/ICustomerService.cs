using Restaurants.Models;
using Restaurants.ModelViews.Customer;
using System.Collections.Generic;

namespace Restaurants.Services
{
    public interface ICustomerService
    {
        public List<GetCustomersView> GetCustomers();
        public GetCustomersView GetCustomerById(int id);
        public Customer AddNewCustomer(AddCustomerView customerView);
        public int UpdateCustomer(GetCustomersView getCustomersView);
        public int DeleteCustomer(int id);
    }
}
