using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jkMovie.Domain.Entities
{
    public class Episode
    {

        public Episode(){}

        public Episode(int? id
            , int tvId
            , int seasonNumber
            , int episodeNumber
            , string episodeName
            , string videoSource
            , string stillPath
            , string overview)
        {
            Id = id;
            this.tvId = tvId;
            this.seasonNumber = seasonNumber;
            this.episodeNumber = episodeNumber;
            this.episodeName = episodeName;
            this.videoSource = videoSource;
            this.stillPath = stillPath;
            this.overview = overview;
        }

        public int? Id { get; }
        public int tvId { get; }
        public int seasonNumber { get; }
        public int episodeNumber { get; }
        public string episodeName { get; }
        public string videoSource { get; }
        public string stillPath { get; }
        public string overview { get; }
    }
}
