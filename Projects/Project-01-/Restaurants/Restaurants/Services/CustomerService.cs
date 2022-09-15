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
        private readonly RestaurantDBContext _context;
        private readonly IMapper _mapper;
        public CustomerService(RestaurantDBContext context, IMapper mapper)
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
            if(customer != null)
            {
                var customerView = _mapper.Map<GetCustomersView>(customer);
                return customerView;
            }
            return null;
        }
        
        public Customer AddNewCustomer(AddCustomerView customerView)
        {
            var customer = _context.Customers.FirstOrDefault(cust =>
            cust.FirstName.ToLower().Equals(customerView.FirstName.ToLower())
            && cust.LastName.ToLower().Equals(customerView.LastName.ToLower())
            );
            if(customer == null)
            {
                customerView.FirstName.Capitalize();
                customerView.LastName.Capitalize();
                var newcustomer = _mapper.Map<Customer>(customerView);
                newcustomer = _context.Customers.Add(newcustomer).Entity;
                _context.SaveChanges();
                return newcustomer;
            }
            return customer;
            
        }

        public int UpdateCustomer(GetCustomersView getCustomersView)
        {
            var customer = _context.Customers.Find(getCustomersView.Id);
            if (customer != null)
            {
                getCustomersView.FirstName.Capitalize();
                getCustomersView.LastName.Capitalize();
                customer.FirstName=getCustomersView.FirstName;
                customer.LastName=getCustomersView.LastName;
                var updatedcustomer = _mapper.Map<Customer>(getCustomersView);
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return updatedcustomer.Id;
            }
            return 0;
        }
        public int DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                customer.Archived = true;
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return customer.Id;
            }
            return 0;
        }
    }
}
