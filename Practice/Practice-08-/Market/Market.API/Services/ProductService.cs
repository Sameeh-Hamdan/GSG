using Market.API.Data;
using Market.API.DTOs.Product;
using Market.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Market.API.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Product> Products()
        {
            return _context.Products.ToList();
        }
        public Product Find(int id)
        {
            return _context.Products.Find(id);
        }
        public int Add(AddProductDTO dto)
        {
            var product = new Product()
            {
                Name = dto.Name,
                Cost = dto.Cost,
                Price = dto.Price,
                IsAvailable = dto.IsAvailable
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return product.Id;
        }
        public int Update(UpdateProductDTO dto)
        {
            var product = _context.Products.Find(dto.Id);
            product.Name = dto.Name;
            product.Cost = dto.Cost;
            product.Price = dto.Price;
            product.IsAvailable = dto.IsAvailable;
            product.ModifiedAt = DateTime.Now;
            _context.Products.Update(product);
            _context.SaveChanges();
            return product.Id;
        }
        public void Remove(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
