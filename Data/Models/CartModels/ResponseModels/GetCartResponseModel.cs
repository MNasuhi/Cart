using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class GetCartResponseModel
    {
        public int CartId { get; set; }
        public int UserId { get; set; }

        public List<Product> Products { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalCount { get; set; }
    }
}
