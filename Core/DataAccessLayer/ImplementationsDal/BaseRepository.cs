using Core.DataAccessLayer.InterfacesDal;
using Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccessLayer.ImplementationsDal
{
    public abstract class BaseRepository<TEntity, TContext> : BaseRepository<TEntity>
        where TEntity : class, IEntities
        where TContext : DbContext, new()
    {
        public async Task DeleteAsync(TEntity entity)
        {
            using var ctx = new TContext();
            ctx.Set<TEntity>().Remove(entity);
            await ctx.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params string[] includeList)
        {
            using (var ctx = new TContext())
            {
                IQueryable<TEntity> dbset = ctx.Set<TEntity>();
                if (includeList.Length > 0)
                {
                    foreach (var include in includeList)
                    {
                        dbset = dbset.Include(include);
                    }
                }
                return await dbset.SingleOrDefaultAsync(predicate);
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params string[] includeList)
        {
            using (var ctx = new TContext())
            {
                IQueryable<TEntity> dbset = ctx.Set<TEntity>();
                if (includeList.Length > 0)
                {
                    foreach (var item in includeList)
                    {
                        dbset = dbset.Include(item);
                    }
                }
                if (predicate == null) { return await dbset.ToListAsync(); }
                else { return await dbset.Where(predicate).ToListAsync(); }
            }
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            using var ctx = new TContext();
            var entityT = ctx.Set<TEntity>().AddAsync(entity);
            await ctx.SaveChangesAsync();
            return entityT.Result.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using var ctx = new TContext();
            var entityT = ctx.Set<TEntity>().Update(entity);
            await ctx.SaveChangesAsync();
            return entityT.Entity;
        }
    }
}
