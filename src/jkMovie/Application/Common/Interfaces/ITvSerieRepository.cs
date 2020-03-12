using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jkMovie.Application.Common.Interfaces
{
    public interface ITvSerieRepository : IBaseRepository<jkMovie.Domain.Entities.TvSerie>
    {
        Task<jkMovie.Domain.Entities.TvSerie> GetByIdAsync(int id);
        Task<IEnumerable<jkMovie.Domain.Entities.TvSerie>> GetAllAsync();
        Task<IEnumerable<jkMovie.Domain.Entities.TvSerie>> GetByTitleAsync(string title);
        Task<bool> FindAsync(int id);
    }
}
