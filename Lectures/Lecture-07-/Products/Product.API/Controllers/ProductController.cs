using Microsoft.AspNetCore.Mvc;
using Product.API.DTOs.Product;
using Product.API.Services;

namespace Product.API.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(_productService.Get(id));
        }
        [HttpPost]
        public IActionResult Create(CreateProductDTO dto)
        {
            return Ok($"return Products");
        }
        [HttpPut]
        public IActionResult Update(UpdateProductDTO dto)
        {
            return Ok($"return Products");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok($"Deleted..");
        }
    }
}
