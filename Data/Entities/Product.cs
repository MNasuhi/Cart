using Data.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Product : BaseEntity
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        //amount for one item
        public decimal Amount { get; set; }
    }
}
