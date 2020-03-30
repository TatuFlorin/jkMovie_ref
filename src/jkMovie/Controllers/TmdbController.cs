using jkMovie.Application;
using jkMovie.Application.Common.Dtos;
using jkMovie.Application.Common.Enums;
using jkMovie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace jkMovie.Controllers
{
    public class TmdbController : Controller
    {
        private readonly IFacade facade;

        public TmdbController()
        {

        }
        public TmdbController(IFacade facade)
        {
            this.facade = facade;
        }

        // GET: Tmdb
        public async Task<ActionResult> Search(ApiResponseDto<SearchDto> model)
        {
            switch (model.Media_type)
            {
                case MediaType.Movie:
                    return View(await facade.MoviesAsync(model.Title_search, model.Page));
                case MediaType.TvSerie:
                    return View(await facade.TvSeriesAsync(model.Title_search, model.Page));
                default:
                    return View();
            }
        }

        public async Task<ActionResult> MovieDetails(int id)
        {
            return View(await facade.MovieDetailsAsync(id));
        }

        public async Task SaveMovie(MovieDto model)
        {
            if (ModelState.IsValid)
            {
                await facade.AddMovieAsync(model);
            }
        }

        public  async Task<ActionResult> TvDetails(int id)
        {
            return View(await facade.TvDetailsAsync(id));
        }

        public async Task SaveTv(TvSerieDto model)
        {
            if (ModelState.IsValid)
            {
                await facade.AddTvAsync(model);
            }
        }

        public async Task AddNextEpisode(int id, string videoSource)
        {
            if (ModelState.IsValid)
            {
                await facade.AddEpisode(id, videoSource);
            }
        }

        public async Task<PartialViewResult> GetSeason(int id, int seasonNumber)
        {
            var result = await facade.TvSeasonAsync(id, seasonNumber);

            return PartialView("_GetSeasonPartial", result);

        }
    }
}