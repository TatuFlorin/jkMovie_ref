using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jkMovie.Application.Common.Dtos
{
    public class VideoSourceDto
    {
        public VideoSourceDto(string source)
            => (source_path) = (source);

        public string source_path { get; set; }
    }
}