using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Response;

namespace ProductCatalog.Filters
{
    public class ExceptionFilter : IAsyncActionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger) => _logger = logger;

        public async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var result = await next();
            if (result.Exception is null) return;

            result.ExceptionHandled = true;
            _logger.LogError(result.Exception, $"Error executing action - {context.ActionDescriptor.DisplayName}");
            result.Result = new BadRequestObjectResult(new ErrorResult(result.Exception.Message));
        }
    }
}
