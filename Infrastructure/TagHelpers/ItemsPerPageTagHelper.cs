using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Camisetas.Models.ViewModels;

namespace Camisetas.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model-items-per-page")]
    public class ItemsPerPageTagHelper : TagHelper
    {
        // Fields
        private IUrlHelperFactory urlHelperFactory;

        // Properties
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext {get;set;}

        [HtmlAttributeName("page-model-items-per-page")]
        public PagingInfo PageModel {get;set;}

        public string PageAction {get;set;}

        // Ctor
        public ItemsPerPageTagHelper (IUrlHelperFactory urlHelperFactory) 
            => this.urlHelperFactory = urlHelperFactory ;

        // Methods
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            for(int i = 0; i < PageModel.TotalItems; i++)
            {
                TagBuilder aTag = new TagBuilder("a");    
                aTag.TagRenderMode = TagRenderMode.Normal;
                aTag.Attributes["href"] = urlHelper.Action(PageAction,
                    new { itemsPerPage = i, pageNumber = 1 });
                aTag.AddCssClass("dropdown-item");
                if(PageModel.ItemsPerPage == i){ aTag.AddCssClass("active"); }
                aTag.InnerHtml.Append( i == 0 ? "Show All" : $"{i} per page" );
                output.Content.AppendHtml(aTag);
            }
            //return Task.CompletedTask;
        } // End of method ProcessAsync.

    // [HtmlTargetElement("select", Attributes = "page-model")]
    // public class ItemsPerPageTagHelper : TagHelper
    // {
    //     // Fields
    //     private IUrlHelperFactory urlHelperFactory;

    //     // Properties
    //     [ViewContext]
    //     [HtmlAttributeNotBound]
    //     public ViewContext ViewContext {get;set;}

    //     public PagingInfo PageModel {get;set;}

    //     // Ctor
    //     public ItemsPerPageTagHelper (IUrlHelperFactory urlHelperFactory) 
    //         => this.urlHelperFactory = urlHelperFactory ;

    //     // Methods
    //     public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    //     {
    //         IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
    //         for(int i = 0; i < PageModel.TotalItems; i++)
    //         {
    //             TagBuilder optionTag = new TagBuilder("option");
    //             optionTag.TagRenderMode = TagRenderMode.Normal;
    //             optionTag.Attributes["value"] = i.ToString();
    //             if(i == PageModel.ItemsPerPage)
    //             {
    //                 optionTag.Attributes["selected"] = "selected";
    //             }
    //             optionTag.InnerHtml.Append( i == 0 ? "Show All" : $"{i} per page" );
    //             output.Content.AppendHtml(optionTag);
    //         }
    //         return Task.CompletedTask;
    //     } // End of method ProcessAsync.

    } // End of class ItemsPerPageTagHelper.

} // End of namespace Camisetas.Infrastructure.TagHelpers.