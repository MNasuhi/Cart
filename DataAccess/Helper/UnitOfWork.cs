using Data.Helpers;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DataAccess.Helper
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MyDbContext context;
        private CartRepository _CartRepository { get; set; }
        private ProductRepository _ProductRepository { get; set; }
        private ProductsInCartRepository _ProductsInCartRepository { get; set; }
        public ICartRepository CartRepository => this._CartRepository ?? (this._CartRepository = new CartRepository(context));
        public IProductRepository ProductRepository => this._ProductRepository ?? (this._ProductRepository = new ProductRepository(context));
        public IProductsInCartRepository ProductsInCartRepository => this._ProductsInCartRepository ?? (this._ProductsInCartRepository = new ProductsInCartRepository(context));



        public UnitOfWork(MyDbContext _context)
        {
            context = _context;
        }
        public void BeginTransaction()
        {
            context.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
            context.Database.CommitTransaction();
        }
        public void RollBackTransaction()
        {
            context.Database.RollbackTransaction();
        }
        public bool SaveChanges()
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        int value = context.SaveChanges();
                        transaction.Commit();
                        return Convert.ToBoolean(value);
                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex.InnerException.ToString());
                        transaction.Rollback();

                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return false;

        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
