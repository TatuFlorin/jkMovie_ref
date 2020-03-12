using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jkMovie.Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository Movies { get; }
        ITvSerieRepository TvSeries { get; }
        IEpisodeRepository Episodes { get; }


        void Complete();
    }
}
