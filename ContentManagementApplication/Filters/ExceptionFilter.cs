using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ContentManagementApplication.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, $"An error occurred : {context.Exception.Message}");

            if (context.Exception is NotFoundObjectResult)
            {
                context.Result = new NotFoundObjectResult(new
                {
                    Error = context.Exception.Message,
                    StatusCode = 404
                });
                context.HttpContext.Response.StatusCode = 404;
            }
            else if (context.Exception is BadRequestObjectResult)
            {
                context.Result = new BadRequestObjectResult(new
                {
                    Error = context.Exception.Message,
                    StatusCode = 400
                });
                context.HttpContext.Response.StatusCode = 400;
            }
            else
            {
                context.Result = new ObjectResult(new
                {
                    Error = "An unexpected error occurred.",
                    StatusCode = 500
                })
                {
                    StatusCode = 500
                };
                context.HttpContext.Response.StatusCode = 500;
            }

            context.ExceptionHandled = true;
        }
    }
}
