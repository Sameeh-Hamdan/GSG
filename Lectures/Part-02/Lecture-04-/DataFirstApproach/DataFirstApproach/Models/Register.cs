using System;
using System.Collections.Generic;

#nullable disable

namespace DataFirstApproach.Models
{
    public partial class Register
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int SId { get; set; }
        public int TId { get; set; }

        public virtual Student SIdNavigation { get; set; }
        public virtual Teacher TIdNavigation { get; set; }
    }
}
