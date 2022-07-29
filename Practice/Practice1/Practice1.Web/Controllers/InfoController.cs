using Microsoft.AspNetCore.Mvc;

namespace Practice1.Web.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetName()
        {
            return Ok("Sameeh Abutaima");
        }
    }
}
