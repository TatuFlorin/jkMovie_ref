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

        void Remove(TEntity entity);
    }
}
