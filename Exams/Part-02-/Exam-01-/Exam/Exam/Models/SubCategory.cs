using System;
using System.Collections.Generic;

#nullable disable

namespace Exam.Models
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CatId { get; set; }

        public virtual Category Cat { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
