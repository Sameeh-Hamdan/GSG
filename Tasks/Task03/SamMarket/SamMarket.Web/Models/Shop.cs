using System.ComponentModel.DataAnnotations;

namespace SamMarket.Web.Models
{
    public class Shop
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
    }
}
