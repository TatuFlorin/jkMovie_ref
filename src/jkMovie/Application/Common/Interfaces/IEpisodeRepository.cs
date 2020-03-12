using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = jkMovie.Domain.Entities;

namespace jkMovie.Application.Common.Interfaces
{
    public interface IEpisodeRepository : IBaseRepository<Entities.Episode>
    {
        Task<int> Count(int SeasonNumber, int tv_id);
        Task<IEnumerable<Entities.Episode>> GetEpisodesBySeason(int id, int seasonNumer);
        Task<string> GetVideoSource(int id, int episode_number, int season_number);
        Task<bool> Find(int id, int episode_number, int season_number);
    }
}
