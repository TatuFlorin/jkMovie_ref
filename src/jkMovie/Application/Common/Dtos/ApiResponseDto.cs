using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jkMovie.Application.Common.Dtos
{
    public class ApiResponseDto<T>
        where T : class
    {
        public ApiResponseDto()
        {
        }

        public ApiResponseDto(
            string media_type
            , string title_search
            , int page
            , List<T> results
            , int total_pages
            , int total_results
            )
        {
            Media_type = media_type;
            Title_search = title_search;
            Page = page;
            Results = results;
            Total_pages = total_pages;
            Total_results = total_results;
        }

        public string Media_type { get; set; }
        public string Title_search { get; set; }
        public int Page { get; set; }
        public List<T> Results { get; set; }
        public int Total_pages { get; set; }
        public int Total_results { get; set; }
    }
}