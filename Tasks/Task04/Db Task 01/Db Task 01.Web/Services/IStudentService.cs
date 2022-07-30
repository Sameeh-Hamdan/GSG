using Db_Task_01.Web.Models;
using System.Collections.Generic;

namespace Db_Task_01.Web.Services
{
    public interface IStudentService
    {
        Student Get(int id);
        List<Student> GetAll();
    }
}