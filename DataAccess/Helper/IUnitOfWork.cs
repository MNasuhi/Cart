using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Helper
{
    public interface IUnitOfWork : IDisposable
    {
        ICartRepository CartRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductsInCartRepository ProductsInCartRepository { get; }
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
        bool SaveChanges();
    }
}
