using AutoMapper;
using jkMovie.Application.Common.AutoMapperExtension;
using jkMovie.Application.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jkMovie.Application.Common.Dtos
{
    public class SearchDto : IMapFrom<TvSerieDto>
    {
        public int id { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }

        private void Mapping(Profile profile)
        {
            profile.CreateMap<TvSerieDto, SearchDto>()
                .ForMember(x => x.title, x => x.MapFrom(y => y.name))
                .ForMember(x => x.release_date, x => x.MapFrom(y => y.first_air_date));
            profile.CreateMap<MovieDto, SearchDto>();
        }

    }
}