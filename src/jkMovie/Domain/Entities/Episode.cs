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

        public Episode(int tvId, int seasonNumber, int episodeNumber, string videoSource)
            => (this.tvId, this.seasonNumber, this.episodeNumber, this.videoSource)
            = (tvId, seasonNumber, episodeNumber, videoSource);

        public int? Id { get; }
        public int tvId { get; }
        public int seasonNumber { get; }
        public int episodeNumber { get; }
        public string videoSource { get; }
    }
}
