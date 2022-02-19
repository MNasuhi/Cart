using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class ClearCartRequestModel
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
    }
}
