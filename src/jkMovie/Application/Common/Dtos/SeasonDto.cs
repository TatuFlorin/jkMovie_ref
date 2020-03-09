using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jkMovie.Application.Common.Dtos
{
    public class SeasonDto
    {
        public SeasonDto(int id
            , string name
            , string air_date
            , int episode_count
            , string overview
            , string poster_path
            , int season_number
            , List<EpisodeDto> episodes
            , int db_episode_count)
        {
            this.id = id;
            this.name = name;
            this.air_date = air_date;
            this.episode_count = episode_count;
            this.overview = overview;
            this.poster_path = poster_path;
            this.season_number = season_number;
            this.episodes = episodes;
            this.db_episode_count = db_episode_count;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string air_date { get; set; }
        public int episode_count { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public int season_number { get; set; }
        public List<EpisodeDto> episodes { get; set; }

        //Extra fieldss
        public int db_episode_count { get; private set; }
    }

    public class EpisodeDto
    {
        public EpisodeDto(int id
            , string air_date
            , int episode_number
            , string name
            , string overview
            , int season_number
            , string still_path)
        {
            this.id = id;
            this.air_date = air_date;
            this.episode_number = episode_number;
            this.name = name;
            this.overview = overview;
            this.season_number = season_number;
            this.still_path = still_path;
        }

        public int id { get; set; }
        public string air_date { get; set; }
        public int episode_number { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public int season_number { get; set; }
        public string still_path { get; set; }
    }
}