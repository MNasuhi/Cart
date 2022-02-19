using Data.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class ProductsInCart : BaseEntity
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
    }
}
