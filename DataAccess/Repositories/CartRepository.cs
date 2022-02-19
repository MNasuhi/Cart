using Data.Entities;
using Data.Helpers;
using DataAccess.Helper;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class CartRepository : BaseRepository<Cart> , ICartRepository
    {
        public CartRepository(MyDbContext context) : base(context)
        {

        }
    }
}
