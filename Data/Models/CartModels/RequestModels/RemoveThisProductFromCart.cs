using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class RemoveThisProductFromCart
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int CartId { get; set; }
    }
}
