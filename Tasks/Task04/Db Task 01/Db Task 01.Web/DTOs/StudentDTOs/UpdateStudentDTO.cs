using System;
using System.ComponentModel.DataAnnotations;

namespace Db_Task_01.Web.DTOs.StudentDTOs
{
    public class UpdateStudentDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DOB { get; set; }
    }
}
