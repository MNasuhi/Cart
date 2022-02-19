using Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Helper
{
    public interface IBaseRepository<T> where T : BaseEntity
    {

        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> Get(Expression<Func<T, bool>> filter = null);
        Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);
    }
}
