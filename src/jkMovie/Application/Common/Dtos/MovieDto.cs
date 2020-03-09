using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jkMovie.Application.Common.Dtos
{
    public class MovieDto
    {
        public int id { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }


    }

    public class MovieComplexDto : MovieDto
    {
        public int vote_count { get; set; }
        public int runtime { get; set; }
        public string overview { get; set; }
        public List<GenreDto> genres { get; set; }
        public string backdrop_path { get; set; }
        public string status { get; set; }

        //Extra fields
        public string videoSource { get; set; }
        public string trailer { get; set; }
        public string total_time { get; set; }
        public string buttonStatus { get; set; }
    }
}