using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jkMovie.App_Code
{
    public class PageInfo
    {
        public PageInfo(int totalItems, int itemsPerPage, int? currentPage)
        {
            TotalItems = totalItems;
            ItemsPerPage = itemsPerPage;
            CurrentPage = currentPage;
        }

        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int? CurrentPage { get; set; }
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
            }
        }

    }
}