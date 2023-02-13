using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WeatherApp.Filter
{
    public class HttpResponseExceptionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                var statusCode = context.Exception is ArgumentException
                    ? StatusCodes.Status400BadRequest
                    : StatusCodes.Status500InternalServerError;

                context.Result = new ObjectResult(context.Exception.Message)
                {
                    StatusCode = statusCode
                };

                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
