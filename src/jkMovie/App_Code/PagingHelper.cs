using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace jkMovie.App_Code
{
        public static class PagingHelper
        {

            public static IHtmlString Paging(this HtmlHelper helper, PageInfo info, Func<int?, string> pageUrl)
            {

                StringBuilder htmlstring = new StringBuilder();


                for (int i = 1; i <= info.TotalPages; i++)
                {
                    TagBuilder ATag = new TagBuilder("a");
                var htmlAnchor = AnchorInnerHtml(i, info);

                if (htmlAnchor == "..")
                    ATag.MergeAttribute("href", "#");
                else
                    ATag.MergeAttribute("href", pageUrl(i));

                ATag.InnerHtml = htmlAnchor;
                
                if (htmlAnchor != "")
                    htmlstring.Append(ATag.ToString());
                }

                return new HtmlString(htmlstring.ToString());

            }

            public static string AnchorInnerHtml(int i, PageInfo pagingInfo)
            {
                string anchorInnerHtml = "";
                if (pagingInfo.TotalPages <= 10)
                    anchorInnerHtml = i.ToString();
                else
                {
                    if (pagingInfo.CurrentPage <= 5)
                    {
                        if ((i <= 8) || (i == pagingInfo.TotalPages))
                            anchorInnerHtml = i.ToString();
                        else if (i == pagingInfo.TotalPages - 1)
                            anchorInnerHtml = "..";
                    }
                    else if ((pagingInfo.CurrentPage > 5) && (pagingInfo.TotalPages - pagingInfo.CurrentPage >= 5))
                    {
                        if ((i == 1) || (i == pagingInfo.TotalPages) || ((pagingInfo.CurrentPage - i >= -3) && (pagingInfo.CurrentPage - i <= 3)))
                            anchorInnerHtml = i.ToString();
                        else if ((i == pagingInfo.CurrentPage - 4) || (i == pagingInfo.CurrentPage + 4))
                            anchorInnerHtml = "..";
                    }
                    else if (pagingInfo.TotalPages - pagingInfo.CurrentPage < 5)
                    {
                        if ((i == 1) || (pagingInfo.TotalPages - i <= 7))
                            anchorInnerHtml = i.ToString();
                        else if (pagingInfo.TotalPages - i == 8)
                            anchorInnerHtml = "..";
                    }
                }
                return anchorInnerHtml;
            }

        }
}