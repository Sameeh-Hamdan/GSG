using System;

namespace School.Web.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DOB { get; set; }
    }
}
