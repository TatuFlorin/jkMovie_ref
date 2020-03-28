using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jkMovie.Application.Common.Dtos
{
    public class TrailerListDto
    {

        public int id { get; set; }
        public List<SourcesDto> results { get; set; }
    }


    public class TrailerDto
    {
        public TrailerDto(string path)
            => (this.path) = (path);

        public string path { get; set; }
    }

    public class SourcesDto
    {
        public string key { get; set; }
        public string site { get; set; }
        public string type { get; set; }

    }
}