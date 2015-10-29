using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AutoBid.Helper
{
    public static class PaginateHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                        PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            if (pagingInfo.TotalPages == 1)
                return MvcHtmlString.Create(String.Empty);

            StringBuilder result = new StringBuilder();
            for (int index = 0; index < pagingInfo.TotalPages; index++)
            {
                TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
                tag.MergeAttribute("href", pageUrl(index));
                tag.InnerHtml = (index + 1).ToString();
                if (index == pagingInfo.CurrentPage)
                    tag.AddCssClass("selected");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}