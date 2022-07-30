using Db_Task_01.Web.DTOs.StudentDTOs;
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
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var student = _studentService.Get(id);
            _studentService.Delete(id);
            return Ok("Deleted..");
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateStudentDTO dto)
        {
            
            return Ok(_studentService.Create(dto));
        }

        [HttpPut]
        public IActionResult Update([FromBody]UpdateStudentDTO dto)
        {

            return Ok(_studentService.Update(dto));
        }
    }
}
