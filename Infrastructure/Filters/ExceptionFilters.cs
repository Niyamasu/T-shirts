using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Camisetas.Infrastructure.Filters
{
    public class RepositoryExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            string exceptionMessage = default;
            if(!context.ExceptionHandled)
            {
                Exception exception = context.Exception;
                
                switch(exception)
                {
                    case ArgumentNullException _:
                    exceptionMessage = 
                        "Sorry, an error occurred while connecting to the database, "
                        + "please verify your connection to the internet";
                        break;
                    case Exception _:
                    exceptionMessage = 
                        "Sorry, an error occurred while processing your request";
                        break;
                } // End of switch

                context.Result = new ViewResult(){
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary(
                        new EmptyModelMetadataProvider(),
                        new ModelStateDictionary()){
                            Model = exceptionMessage
                        }
                };

                context.RouteData.Values["controller"] = "Error";
                context.RouteData.Values["action"] = "Error";
            }
            
        } // End of method OnException.

    }// End of class ExceptionFilters.

} // End of namespace Camisetas.Infrastructure.Filters.