using Db_Task_01.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Db_Task_01.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_studentService.GetAll());
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(_studentService.Get(id));
        }
    }
}
