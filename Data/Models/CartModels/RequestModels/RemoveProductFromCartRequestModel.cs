using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class RemoveProductFromCartRequestModel
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int CartId { get; set; }
        public int ProductCount { get; set; }
    }
}
