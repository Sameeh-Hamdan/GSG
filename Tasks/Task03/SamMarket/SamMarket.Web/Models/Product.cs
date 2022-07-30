using System.ComponentModel.DataAnnotations;

namespace SamMarket.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public float Price { get; set; }

    }
}
