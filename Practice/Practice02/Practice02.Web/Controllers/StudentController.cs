using Microsoft.AspNetCore.Mvc;
using Practice02.Web.Models;

namespace Practice02.Web.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult CreateStd()
        {
            var std = new Student();
            return Ok($"{std.CreatedAt.ToString()}");
        }

    }
}
