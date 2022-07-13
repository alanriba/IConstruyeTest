using IConstruye.Api.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.CodeAnalysis;

namespace IConstruye.Api.Filters
{
    [ExcludeFromCodeCoverage]
    public class InternalErrorExceptionFilter : IExceptionFilter
    {
        
        public void OnException(ExceptionContext context)
        {
            string errorMessage = $"{context.RouteData.Values["controller"]} - {context.RouteData.Values["action"]}";
            
            var result = new ObjectResult(new { message = Strings.InternalError })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.Result = result;
        }

    }
}

