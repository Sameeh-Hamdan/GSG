using System;

namespace Practice02.Web.Models
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
