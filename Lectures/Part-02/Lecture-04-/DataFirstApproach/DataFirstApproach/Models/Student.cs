using System;
using System.Collections.Generic;

#nullable disable

namespace DataFirstApproach.Models
{
    public partial class Student
    {
        public Student()
        {
            Registers = new HashSet<Register>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Register> Registers { get; set; }
    }
}
