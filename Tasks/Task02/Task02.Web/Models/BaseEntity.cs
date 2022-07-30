using System;
using System.ComponentModel.DataAnnotations;

namespace Task02.Web.Models
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }

    }
}
