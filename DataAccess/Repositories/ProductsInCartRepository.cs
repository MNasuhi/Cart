using Data.Entities;
using Data.Helpers;
using DataAccess.Helper;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class ProductsInCartRepository : BaseRepository<ProductsInCart>, IProductsInCartRepository 
    {
        public ProductsInCartRepository(MyDbContext context) : base(context) 
        {
        
        }
    }
}
