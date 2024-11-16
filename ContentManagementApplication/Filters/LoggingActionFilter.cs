using ContentManagementApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ContentManagementApplication.Filters
{
    public class LoggingActionFilterAttribute : IActionFilter
    {
        private readonly ILogger<LoggingActionFilterAttribute> _logger;

        public LoggingActionFilterAttribute(ILogger<LoggingActionFilterAttribute> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Content beforeAction = new Content();
            var actionname = context.ActionDescriptor.DisplayName;
            _logger.LogInformation($"Action name : {actionname}");

            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            var method = context.HttpContext.Request.Method;

            if (method == "POST")
            {
                _logger.LogInformation("User is attempting to {Action} content in {Controller} at {Timestamp}.",actionName, controllerName, DateTime.UtcNow);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            var method = context.HttpContext.Request.Method;
            if (method == "POST")
            {
                _logger.LogInformation("User {Username} successfully performed {Action} on {Controller} at {Timestamp}.",actionName, controllerName, DateTime.UtcNow);
            }

        }
    }
}
