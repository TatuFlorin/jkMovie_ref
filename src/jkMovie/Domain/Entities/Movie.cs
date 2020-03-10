using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jkMovie.Domain.Entities
{
    public class Movie
    {

        public Movie(){}

        public Movie(int id
            , string title
            , string poster
            , double voteAverage
            , string videoSource
            , bool isPosted)
        {
            Id = id;
            this.title = title;
            this.poster = poster;
            this.voteAverage = voteAverage;
            this.videoSource = videoSource;
            IsPosted = isPosted;
        }
        
        public int Id { get; private set; }
        public string title { get; }
        public string poster { get; }
        public double voteAverage { get; }
        public string videoSource { get; }

        private bool isPosted = false;

        public bool IsPosted
        {
            get { return isPosted; }
            set { this.isPosted = value; }
        }

    }
}
