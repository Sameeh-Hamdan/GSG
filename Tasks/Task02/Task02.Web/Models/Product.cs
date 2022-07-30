using System.ComponentModel.DataAnnotations;

namespace Task02.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public float Price { get; set; }
        public int Amount { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; }
    }
}
