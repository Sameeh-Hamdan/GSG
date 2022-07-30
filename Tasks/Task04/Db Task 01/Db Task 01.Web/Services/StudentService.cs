using Db_Task_01.Web.Data;
using Db_Task_01.Web.DTOs.StudentDTOs;
using Db_Task_01.Web.Models;
using Microsoft.AspNetCore.Mvc;
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
        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
        public int Create(CreateStudentDTO dto)
        {
            var student = new Student()
            {
                Name = dto.Name,
                DOB = dto.DOB,
            };
            _context.Students.Add(student);
            _context.SaveChanges();
            return student.Id;
        }
        public int Update(UpdateStudentDTO dto)
        {
            var student = _context.Students.Find(dto.Id);
            student.Name = dto.Name;
            student.DOB = dto.DOB;
            _context.Students.Update(student);
            _context.SaveChanges();
            return student.Id;
        }
    }
}
