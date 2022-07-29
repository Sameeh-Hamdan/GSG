using Microsoft.AspNetCore.Mvc;
using Practice1.Web.Models;

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
        public IActionResult Welcome()
        {
            return Ok("Welcome To Our App");
        }
        public IActionResult CreateEmp()
        {
            var emp = new Employee();
            return Ok($"{emp.CreatedAt.ToString()}");
        }
    }
}
