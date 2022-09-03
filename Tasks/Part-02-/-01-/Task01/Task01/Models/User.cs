using System;
using System.Collections.Generic;

#nullable disable

namespace Task01.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public byte Archived { get; set; }
    }
}
