using Db_Task_01.Web.DTOs.StudentDTOs;
using Db_Task_01.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Db_Task_01.Web.Services
{
    public interface IStudentService
    {
        Student Get(int id);
        List<Student> GetAll();
        void Delete(int id);
        int Create(CreateStudentDTO dto);
        int Update(UpdateStudentDTO dto);
    }
}