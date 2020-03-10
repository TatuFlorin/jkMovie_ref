using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jkMovie.Application.Common.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        Task AddAsync(TEntity entity);

        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetByTitleAsync(string title);
        Task<bool> FindAsync(int id);

        void Remove(TEntity entity);
    }
}
