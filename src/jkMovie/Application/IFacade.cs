using jkMovie.Application.Common.Dtos;
using jkMovie.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace jkMovie.Application
{
    public interface IFacade
    {
        Task AddEpisode(int tvId, string videoPath);
        Task AddMovieAsync(MovieDto movie);
        Task AddTvAsync(TvSerieDto tv);
        Task<IEnumerable<Movie>> DbMoviesAsync();
        Task<IEnumerable<TvSerie>> DbTvSeriesAsync();
        Task<VideoSourceDto> EpisodeSourceAsync(int tvId, int episodeNumber, int seasonNumber);
        Task<MovieComplexDto> MovieDetailsAsync(int movieId);
        Task<ApiResponseDto<SearchDto>> MoviesAsync(string keyword, int? page);
        Task<VideoSourceDto> MovieSourceAsync(int movieId);
        Task<TrailerDto> MovieTrailerAsync(int movieId);
        Task<IEnumerable<Movie>> SearchMovieAsync(string title);
        Task<IEnumerable<TvSerie>> SearchTvAsync(string title);
        Task<TvSerieComplexDto> TvDetailsAsync(int tvId);
        Task<ApiResponseDto<SearchDto>> TvSeriesAsync(string keyword, int? page);
        Task<TrailerDto> TvTrailerAsync(int tvId);
        Task<SeasonDto> TvSeasonAsync(int tvId, int seasonNumber);
    }
}