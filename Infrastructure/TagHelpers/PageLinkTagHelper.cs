using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Camisetas.Models.ViewModels;

namespace Camisetas.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model-links")]
    public class PageLinkTagHelper : TagHelper
    {
        // Fields
        private IUrlHelperFactory urlHelperFactory;

        // Properties
        [HtmlAttributeName("page-model-links")]
        public PagingInfo PageModel {get;set;}
        public string PageAction {get;set;}

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        // Ctor
        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory )
        {
            this.urlHelperFactory = urlHelperFactory;
        } // End of ctor

        // Methods
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {   
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            if(PageModel.QtdPages > 0)
            {
                for(int i = 1; i <= PageModel.QtdPages; i++)
                {
                    TagBuilder aTag = new TagBuilder("a");    
                    aTag.TagRenderMode = TagRenderMode.Normal;
                    aTag.Attributes["href"] = urlHelper.Action(PageAction,new {pageNumber = i});
                    aTag.AddCssClass("dropdown-item");
                    if(PageModel.CurrentPage == i){ aTag.AddCssClass("active"); }
                    aTag.InnerHtml.Append($"Page {i}");

                    output.Content.AppendHtml(aTag);
                }
            }else
            {
                TagBuilder aTag = new TagBuilder("a");    
                aTag.TagRenderMode = TagRenderMode.Normal;
                aTag.Attributes["href"] = urlHelper.Action(PageAction,new {pageNumber = 1});
                aTag.AddCssClass("dropdown-item");
                if(PageModel.CurrentPage == 1){ aTag.AddCssClass("active"); }
                aTag.InnerHtml.Append($"Page {1}");

                output.Content.AppendHtml(aTag);
            }

            return Task.CompletedTask;
        } // End of method ProcessAsync.

    } // End of class PageLinkTagHelper.

} // End of namespace Camisetas.Infrastructure.Infrastructure.