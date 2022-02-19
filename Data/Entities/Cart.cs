using Data.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Cart : BaseEntity
    {
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalProductCount { get; set; }

    }
}
