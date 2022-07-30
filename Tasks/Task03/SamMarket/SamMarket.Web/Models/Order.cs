using System;
using System.ComponentModel.DataAnnotations;

namespace SamMarket.Web.Models
{
    public class Order
    {
        public int Id { get; set; }
        public float TotalPrice { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string OrderStatus { get; set; }
    }
}
