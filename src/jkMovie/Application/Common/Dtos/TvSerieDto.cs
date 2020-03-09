using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jkMovie.Application.Common.Dtos
{
    public class TvSerieDto
    {
        public string first_air_date { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string poster_path { get; set; }
        public double vote_average { get; set; }
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
        public string trailer { get; set; }
    }
}