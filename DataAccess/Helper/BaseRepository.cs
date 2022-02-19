using Data.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Helper
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly MyDbContext context;

        public BaseRepository(MyDbContext _context)
        {
            context = _context;
        }
        public async Task Add(T entity)
        {
                entity.Status = Data.Enums.Status.Created;
                entity.CreatedUser = 1;
                entity.CreatedDate = DateTime.Now;
                await Task.FromResult(context.Set<T>().AddAsync(entity));

        }
        public async Task Update(T entity)
        {
            entity.Status = Data.Enums.Status.Updated;
            entity.UpdatedUser = 1;
            entity.UpdatedDate = DateTime.Now;
            context.Entry(entity).State = EntityState.Modified;
            await Task.FromResult(context.Set<T>().Update(entity));
        }
        public async Task Delete(T entity)
        {
            entity.Status = Data.Enums.Status.Deleted;
            entity.UpdatedUser = 1;
            entity.UpdatedDate = DateTime.Now;
            await Task.FromResult(context.Set<T>().Update(entity));
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter = null)
        {
            return await context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<List<T>> GetList(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? await context.Set<T>().ToListAsync()
                  : await context.Set<T>().Where(filter).ToListAsync();
        }

    }
}
