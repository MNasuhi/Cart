using Business.Interfaces;
using DataAccess.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class ProductsInCartService : IProductsInCartService
    {
        private IUnitOfWork uow;

        public ProductsInCartService(IUnitOfWork _uow)
        {
            uow = _uow;
        }
    }
}
