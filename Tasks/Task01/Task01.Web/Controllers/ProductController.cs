using Microsoft.AspNetCore.Mvc;
using Task02.Web.Models;

namespace Task02.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult GetYourName(string name)
        {
            return Ok($"Your Name Is {name}");
        }

        [HttpPost]
        public IActionResult GetPrice(string name,float price)
        {
            var product = new Product()
            {
                Id=1,
                Name=name,
                Price = price,
            };
            return Ok($" The price for {product.Name} is ${product.Price}");
        }      
    }
}
