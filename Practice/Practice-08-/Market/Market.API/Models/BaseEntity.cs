using System;
using System.ComponentModel.DataAnnotations;

namespace Market.API.Models
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        //[Required]
        //public string CreatedBy { get; set; }
        //public string ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
