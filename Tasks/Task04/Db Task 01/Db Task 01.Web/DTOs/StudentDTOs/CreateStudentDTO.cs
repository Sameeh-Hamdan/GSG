using System;
using System.ComponentModel.DataAnnotations;

namespace Db_Task_01.Web.DTOs.StudentDTOs
{
    public class CreateStudentDTO
    {
        [Required]
        public string Name { get; set; }
        public DateTime DOB { get; set; }
    }
}
