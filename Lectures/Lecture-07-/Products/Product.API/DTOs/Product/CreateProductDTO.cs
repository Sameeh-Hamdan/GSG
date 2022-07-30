using System.ComponentModel.DataAnnotations;

namespace Product.API.DTOs.Product
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public float Cost { get; set; }
        public float Price { get; set; }
    }
}
