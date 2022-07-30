using Product.API.Data;
using Product.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Product.API.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ProductEntity> GetAll()
        {
            return _context.Products.ToList();
        }

        public ProductEntity Get(int id)
        {
            return _context.Products.Find(id);
        }

    }
}
