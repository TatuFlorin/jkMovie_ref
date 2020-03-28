using AutoMapper;
using jkMovie.Application.Common.AutoMapperExtension;
using jkMovie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jkMovie.Application.Common.Dtos
{
    public class MovieDto : IMapFrom<Movie>
    {
        public MovieDto() { }

        public MovieDto(int id, string poster_path, string realise_date, string title, double vote_average, string source_path, bool isPosted)
            => (this.id, this.poster_path, this.release_date, this.title, this.vote_average, this.source_path, this.isPosted)
            = (id, poster_path, realise_date, title, vote_average, source_path, isPosted);

        public int id { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
        public string source_path { get; set; }
        public bool isPosted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MovieDto, Movie>()
                .ConvertUsing(x => new Movie(x.id, x.title, x.poster_path, x.vote_average, x.source_path, x.isPosted));
        }
    }

    public class MovieComplexDto : MovieDto
    {
        public MovieComplexDto(int id, string poster_path, string realise_date, string title, double vote_average, string source_path, bool isPosted
            , int vote_count, int runtime, string overview, List<GenreDto> genres, string backdrop_path, string status, string buttonStatus)
            : base(id, poster_path, realise_date, title, vote_average, source_path, isPosted)
            => (this.vote_count, this.runtime, this.overview, this.genres, this.backdrop_path, this.status, this.buttonStatus)
            = (vote_count, runtime, overview, genres, backdrop_path, status, buttonStatus);

        public int vote_count { get; set; }
        public int runtime { get; set; }
        public string overview { get; set; }
        public List<GenreDto> genres { get; set; }
        public string backdrop_path { get; set; }
        public string status { get; set; }

        //Extra fields
        public string buttonStatus { get; set; }
    }
}