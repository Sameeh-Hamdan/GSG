using Market.API.DTOs.Product;
using Market.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Products()
        {
            return Ok(_productService.Products());
        }
        [HttpGet]
        public IActionResult Find(int id)
        {
            return Ok(_productService.Find(id));
        }
        [HttpPost]
        public IActionResult Add([FromBody]AddProductDTO dto)
        {
            return Ok(_productService.Add(dto));
        }
        [HttpPut]
        public IActionResult Update([FromBody]UpdateProductDTO dto)
        {
            return Ok(_productService.Update(dto));
        }
        [HttpDelete]
        public IActionResult Remove(int id)
        {
            _productService.Remove(id);
            return Ok("Product Deleted Successfully");
        }
    }
}
