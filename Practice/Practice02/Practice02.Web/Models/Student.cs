using System;

namespace Practice02.Web.Models
{
    public class Student:BaseEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public float GPA { get; set; }
        public bool IsActive { get; set; }
    }
}
