using System;
using System.Collections.Generic;

#nullable disable

namespace Exam2.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubId { get; set; }

        public virtual SubCategory Sub { get; set; }
    }
}
