﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace ECommerceApp.UI.TagHelpers
{
    [HtmlTargetElement("product-list-pager")]
    public class PagingTagHelper:TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }
        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }
        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }  
        [HtmlAttributeName("current-category")]
        public int CurrentCategory { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";
            var sb=new StringBuilder();
            if (PageCount > 1)
            {
                sb.Append("<ul class='pagination'>");
                if (CurrentPage > 1)
                {
                    sb.AppendFormat("<li><a class='page-link' href='/product/index?page={0}&category={1}'>Previous</a></li>",CurrentPage - 1,CurrentCategory);
                }

                else
                {
                    sb.Append("<li class='page-item disabled'><span class='page-link'>Previous</span></li>");
                }

                for (int i = 1; i <=PageCount; i++) {
                    sb.AppendFormat("<li class='{0}'>",(i==CurrentPage) ? "page-item active":"page-item");

                    sb.AppendFormat("<a class='page-link' href='/product/index?page={0}&category={1}'>{2}</a>", i,CurrentCategory, i);

                    sb.AppendFormat("</li>");
                }
                if (CurrentPage < PageCount)
                {
                    sb.AppendFormat("<li><a class='page-link' href='/product/index?page={0}&category={1}'>Next</a></li>", CurrentPage + 1, CurrentCategory);
                }
                else {
                    sb.Append("<li class='page-item disabled'><span class='page-link'>Next</span></li>");
                }
                sb.Append("</ul>");
            }

            output.Content.SetHtmlContent(sb.ToString());

        }

    }
}
