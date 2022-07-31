using System;

namespace Market.API.Models
{
    public class Product:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float? Cost { get; set; }
        public float Price { get; set; }
        //public DateTime? ProductionDate { get; set; }
        //public DateTime? ExpiryDate { get; set; }
        public bool IsAvailable { get; set; }
    }
}
