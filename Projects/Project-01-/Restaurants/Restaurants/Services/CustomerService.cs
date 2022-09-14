using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurants.Extentions;
using Restaurants.Models;
using Restaurants.ModelViews.Customer;
using System.Collections.Generic;
using System.Linq;

namespace Restaurants.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly restaurantdbTestContext _context;
        private readonly IMapper _mapper;
        public CustomerService(restaurantdbTestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetCustomersView> GetCustomers()
        {
            var customers = _context.Customers.ToList();
            var customersView=_mapper.Map<List<GetCustomersView>>(customers);
            return customersView;
        }
        public GetCustomersView GetCustomerById(int id)
        {
            var customer = _context.Customers.Find(id);
            var customerView = _mapper.Map<GetCustomersView>(customer);
            return customerView;
        }
        
        public Customer AddNewCustomer(AddCustomerView customerView)
        {
            var customer = _context.Customers.FirstOrDefault(cust =>
            cust.FirstName.ToLower().Equals(customerView.FirstName.ToLower())
            && cust.LastName.ToLower().Equals(customerView.LastName.ToLower())
            );
            if(customer == null)
            {
                customerView.FirstName=CapitalizeFirstLetter.Capitalize(customerView.FirstName);
                customerView.LastName=CapitalizeFirstLetter.Capitalize(customerView.LastName);
                var newcustomer = _mapper.Map<Customer>(customerView);
                newcustomer = _context.Customers.Add(customer).Entity;
                _context.SaveChanges();
                return newcustomer;
            }
            return customer;
            
        }
    }
}
