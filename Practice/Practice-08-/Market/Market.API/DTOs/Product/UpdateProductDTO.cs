using System;
using System.ComponentModel.DataAnnotations;

namespace Market.API.DTOs.Product
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float? Cost { get; set; }
        public float Price { get; set; }
        //public DateTime? ProductionDate { get; set; }
        //public DateTime? ExpiryDate { get; set; }
        public bool IsAvailable { get; set; }

        //public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        //public bool IsDeleted { get; set; }

    }
}
