using Db_Task_01.Web.Data;
using Db_Task_01.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace Db_Task_01.Web.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;
        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }
        public Student Get(int id)
        {
            return _context.Students.Find(id);
        }
    }
}
