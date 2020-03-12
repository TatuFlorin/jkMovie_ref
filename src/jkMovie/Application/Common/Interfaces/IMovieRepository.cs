using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jkMovie.Application.Common.Interfaces
{
    public interface IMovieRepository : IBaseRepository<jkMovie.Domain.Entities.Movie>
    {
        Task<jkMovie.Domain.Entities.Movie> GetByIdAsync(int id);
        Task<IEnumerable<jkMovie.Domain.Entities.Movie>> GetAllAsync();
        Task<IEnumerable<jkMovie.Domain.Entities.Movie>> GetByTitleAsync(string title);
        Task<bool> FindAsync(int id);
    }
}
