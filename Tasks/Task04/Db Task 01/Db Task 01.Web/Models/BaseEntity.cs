﻿using System;

namespace Db_Task_01.Web.Models
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public BaseEntity()
        {
            IsDeleted=false;
            CreatedAt=DateTime.Now;
        }
    }
}
