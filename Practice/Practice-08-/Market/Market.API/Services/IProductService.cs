using Market.API.DTOs.Product;
using Market.API.Models;
using System.Collections.Generic;

namespace Market.API.Services
{
    public interface IProductService
    {
        int Add(AddProductDTO dto);
        Product Find(int id);
        List<Product> Products();
        void Remove(int id);
        int Update(UpdateProductDTO dto);
    }
}