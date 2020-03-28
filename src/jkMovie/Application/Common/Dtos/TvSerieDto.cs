using AutoMapper;
using jkMovie.Application.Common.AutoMapperExtension;
using jkMovie.Domain.Entities;
using System.Collections.Generic;

namespace jkMovie.Application.Common.Dtos
{
    public class TvSerieDto : IMapFrom<TvSerie>
    {
        public string first_air_date { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string poster_path { get; set; }
        public double vote_average { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TvSerieDto, TvSerie>()
                .ConstructUsing(x => new TvSerie(x.id, false, x.name, x.poster_path, vote_average));
        }

    }

    public class TvSerieComplexDto : TvSerieDto
    {
        public string overview { get; set; }
        public string backdrop_path { get; set; }
        public List<int> episode_run_time { get; set; }
        public int number_of_episodes { get; set; }
        public int number_of_seasons { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public int vote_count { get; set; }
        public List<SeasonDto> seasons { get; set; }
        public List<GenreDto> genres { get; set; }

        //Extra fields
        public string buttonStatus { get; set; }
        public int dbnos { get; set; }
    }
}