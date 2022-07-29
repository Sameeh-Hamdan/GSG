using System;

namespace Practice1.Web.Models
{
    public class Employee:BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public bool IsActive { get; set; }
    }
}
