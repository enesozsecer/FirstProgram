using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccessLayer.InterfacesDal
{
    public interface IBaseRepository<TEntity>
        where TEntity : class, IEntities
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params string[] includeList);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, params string[] includeList);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
