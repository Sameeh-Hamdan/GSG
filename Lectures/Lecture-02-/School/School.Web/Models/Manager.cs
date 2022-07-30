using System.ComponentModel.DataAnnotations;

namespace School.Web.Models
{
    public class Manager
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        [Key]
        public string Email { get; set; }
    }
}
