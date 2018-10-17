using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Camisetas.Models.ViewModels;
using Camisetas.Models;
using Camisetas.DAL;

namespace Camisetas.Infrastructure.TagHelpers
{
    [HtmlTargetElement("select", Attributes = "option-model-type")]
    public class OptionListTagHelper : TagHelper
    {
        // Fields
        private AppDbContext dbContext;

        // Properties

        [HtmlAttributeName("option-model-type")]
        public Object ModelType {get;set;}

        // [HtmlAttributeName("option-model-id")]
        // public Guid? ModelGuid {get;set;} = null;   

        // Ctor
        public OptionListTagHelper(AppDbContext ctx) => dbContext = ctx;

        // Methods
        public  override Task ProcessAsync(TagHelperContext context,
                TagHelperOutput output)
        {
            if(ModelType is Color _)
            {
                List<Color> colors = dbContext.Colors.ToList();
                foreach(Color color in colors)
                {
                    TagBuilder optionTag = new TagBuilder("option");
                    optionTag.TagRenderMode = TagRenderMode.Normal;
                    optionTag.InnerHtml.Append(color.Name);
                    optionTag.Attributes["value"] = color.Id.ToString();
                    // if(ModelGuid != null){
                    //     if(ModelGuid == color.Id)
                    //     {optionTag.Attributes["selected"] = "selected";}
                    // }
                    output.Content.AppendHtml(optionTag);
                }
                return Task.CompletedTask;
            }
            else if(ModelType is Models.Type _)
            {
                List<Models.Type> types = dbContext.Types.ToList();
                foreach(Models.Type type in types)
                {
                    TagBuilder optionTag = new TagBuilder("option");
                    optionTag.TagRenderMode = TagRenderMode.Normal;
                    optionTag.InnerHtml.Append(type.Name);
                    optionTag.Attributes["value"] = type.Id.ToString();
                    // if(ModelGuid != null){
                    //     if(ModelGuid == type.Id)
                    //     {optionTag.Attributes["selected"] = "selected";}
                    // }
                    output.Content.AppendHtml(optionTag);
                }
                return Task.CompletedTask;
            }
            else if(ModelType is Size _)
            {
                List<Size> sizes = dbContext.Sizes.ToList();
                foreach(Size size in sizes)
                {
                    TagBuilder optionTag = new TagBuilder("option");
                    optionTag.TagRenderMode = TagRenderMode.Normal;
                    optionTag.InnerHtml.Append(size.Name);
                    optionTag.Attributes["value"] = size.Id.ToString();
                    // if(ModelGuid != null){
                    //     if(ModelGuid == size.Id)
                    //     {optionTag.Attributes["selected"] = "selected";}
                    // }
                    output.Content.AppendHtml(optionTag);
                }
                return Task.CompletedTask;
            }
            else
            {
                List<Clothing> clothings = dbContext.Clothings.ToList();
                foreach(Clothing clothing in clothings)
                {
                    TagBuilder optionTag = new TagBuilder("option");
                    optionTag.TagRenderMode = TagRenderMode.Normal;
                    optionTag.InnerHtml.Append(clothing.Name);
                    optionTag.Attributes["value"] = clothing.Id.ToString();
                    // if(ModelGuid != null){
                    //     if(ModelGuid == clothing.Id)
                    //     {optionTag.Attributes["selected"] = "selected";}
                    // }
                    output.Content.AppendHtml(optionTag);
                }
                return Task.CompletedTask;
            }
        } // End of method ProcessAsync.

    } // End of class OptionListTagHelper.

} // End of namespace Camisetas.Infrastructure.TagHelpers.