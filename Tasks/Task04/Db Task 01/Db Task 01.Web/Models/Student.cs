using System;
using System.ComponentModel.DataAnnotations;

namespace Db_Task_01.Web.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        
    }
}
