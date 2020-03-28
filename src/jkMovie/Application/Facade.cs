using AutoMapper;
using jkMovie.Application.Common.Dtos;
using jkMovie.Application.Common.Enums;
using jkMovie.Application.Common.Exceptions;
using jkMovie.Application.Common.Interfaces;
using jkMovie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace jkMovie.Application
{
    public class Facade : IFacade
    {
        private readonly ITmdbService tmdb;
        private readonly IUnitOfWork context;
        private readonly IMapper mapper;

        public Facade(ITmdbService tmdb, IUnitOfWork context, IMapper mapper)
        {
            this.tmdb = tmdb;
            this.context = context;
            this.mapper = mapper;
        }


        public async Task AddMovieAsync(MovieDto movie)
        {
            var dbModel = mapper.Map<Movie>(movie);
            await context.Movies.AddAsync(dbModel);
            context.Complete();
        }

        public async Task<ApiResponseDto<MovieDto>> MoviesAsync(string keyword, int? page)
            => await tmdb.GetAllAsync<MovieDto>(keyword, page);

        public async Task<IEnumerable<Movie>> DbMoviesAsync()
            => await context.Movies.GetAllAsync();

        public async Task<IEnumerable<Movie>> SearchMovieAsync(string title)
            => await context.Movies.GetByTitleAsync(title);

        public async Task<MovieComplexDto> MovieDetailsAsync(int movieId)
            => await tmdb.GetByIdAsync<MovieComplexDto>(movieId);

        public async Task<VideoSourceDto> MovieSourceAsync(int movieId)
        {
            var movie = await context.Movies.GetByIdAsync(movieId);
            return new VideoSourceDto(movie.videoSource);
        }

        public async Task<TrailerDto> MovieTrailerAsync(int movieId)
        {
            var trailers = await tmdb.GetTrailers(MediaType.Movie, movieId);
            var trailer = trailers.results.Where(x => x.type.ToLower().Contains("trailer")).FirstOrDefault();
            return new TrailerDto($"https://www.youtube.com/embed/{ trailer.key }");
        }


        public async Task AddTvAsync(TvSerieDto tv)
        {
            var dbModel = mapper.Map<TvSerie>(tv);
            await context.TvSeries.AddAsync(dbModel);
            context.Complete();
        }

        public async Task<ApiResponseDto<TvSerieDto>> TvSeriesAsync(string keyword, int? page)
            => await tmdb.GetAllAsync<TvSerieDto>(keyword, page);

        public async Task<IEnumerable<TvSerie>> DbTvSeriesAsync()
            => await context.TvSeries.GetAllAsync();

        public async Task<IEnumerable<TvSerie>> SearchTvAsync(string title)
            => await context.TvSeries.GetByTitleAsync(title);

        public async Task<TvSerieComplexDto> TvDetailsAsync(int tvId)
            => await tmdb.GetByIdAsync<TvSerieComplexDto>(tvId);

        public async Task<VideoSourceDto> EpisodeSourceAsync(int tvId, int episodeNumber, int seasonNumber)
            => new VideoSourceDto(await context.Episodes.GetVideoSource(tvId, episodeNumber, seasonNumber));


        public async Task<TrailerDto> TvTrailerAsync(int tvId)
        {
            var trailers = await tmdb.GetTrailers(MediaType.TvSerie, tvId);
            var trailer = trailers.results.Where(x => x.type.ToLower().Contains("trailer")).FirstOrDefault();
            return new TrailerDto($"https://www.youtube.com/embed/{ trailer.key }");
        }

        public async Task<SeasonDto> TvSeasonAsync(int tvId, int seasonNumber)
        {
            var season = await tmdb.GetSeasonAsync(tvId, seasonNumber);
            var numberOfEpisodes = await context.Episodes.Count(seasonNumber, tvId);
            season.episodes = season.episodes.GetRange(0, numberOfEpisodes);

            return season;
        }

        public async Task AddEpisode(int tvId, string videoPath)
        {
            var lastEpisode = await context.Episodes.GetLastEpisode(tvId);
            var tvDetails = await tmdb.GetByIdAsync<TvSerieComplexDto>(tvId);
            var tv = await context.TvSeries.GetByIdAsync(tvId);

            _ = tv ?? throw new NotFoundException(nameof(TvSerie), tvId);

            var newEpisode = new Episode();

            newEpisode = lastEpisode == null
                ? new Episode(tvId, 1, 1, videoPath)
                : lastEpisode.episodeNumber + 1 > tvDetails.seasons.Where(x => x.season_number == lastEpisode.seasonNumber).FirstOrDefault().episode_count
                    ? lastEpisode.seasonNumber + 1 > tvDetails.number_of_seasons
                    ? throw new Exception()
                    : new Episode(tvId, lastEpisode.seasonNumber + 1, 1, videoPath)
                : new Episode(tvId, lastEpisode.seasonNumber, lastEpisode.episodeNumber + 1, videoPath);

            tv.NumberOfSeasons = newEpisode.seasonNumber;
            await context.Episodes.AddAsync(newEpisode);
            context.Complete();
        }

    }
}