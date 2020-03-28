using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jkMovie.Domain.Entities
{
    public class TvSerie
    {

        public TvSerie(int id, bool isPosted, string original_title, string poster_path, double vote_average)
        {
            this.Id = id;
            this.title = original_title;
            this.poster = poster_path;
            this.voteAverage = vote_average;
            this.isPosted = isPosted;
        }

        public TvSerie(int id, bool isPosted, string original_title, string poster_path, double vote_average, int numberOfSeasons)
            : this(id, isPosted, original_title, poster_path, vote_average)
        {
            this.numberOfSeasons = numberOfSeasons;
        }

        public TvSerie()
        {
            Episodes = new HashSet<Episode>();
        }

        public int Id { get; private set; }
        public string title { get; }
        public string poster { get; }
        public double voteAverage { get; }
        public ICollection<Episode> Episodes { get; }

        private int numberOfSeasons;
        private bool isPosted;

        public bool IsPosted
        {
            get { return isPosted; }
            set { isPosted = value; }
        }

        public int NumberOfSeasons
        {
            get { return this.numberOfSeasons; }
            set { this.numberOfSeasons = value; }
        }

    }
}
