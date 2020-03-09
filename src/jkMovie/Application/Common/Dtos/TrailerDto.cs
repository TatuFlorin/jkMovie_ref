using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jkMovie.Application.Common.Dtos
{
    public class TrailerDto
    {
        public int id { get; set; }
        public List<SourcesDto> results { get; set; }
    }

    public class SourcesDto
    {
        public string key { get; set; }
        public string site { get; set; }
        public string type { get; set; }

        //public string id { get; set; }
        //public string name { get; set; }
        //public int size { get; set; }
    }
}