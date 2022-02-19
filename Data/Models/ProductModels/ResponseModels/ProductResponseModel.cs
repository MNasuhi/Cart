using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class ProductResponseModel
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
