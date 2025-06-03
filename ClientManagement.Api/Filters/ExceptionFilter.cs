using ClientManagement.Application.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClientManagement.Api.Middleware
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;
            var problemDetails = new ProblemDetails();

            switch (exception)
            {
                case UserFriendlyException userFriendlyEx:

                    _logger.LogWarning(userFriendlyEx, "User friendly error occurred");

                    problemDetails.Title = userFriendlyEx.Message;
                    problemDetails.Status = (int)HttpStatusCode.BadRequest;
                    problemDetails.Extensions["errorCode"] = userFriendlyEx.ErrorCode;

                    if (userFriendlyEx.AdditionalData != null)
                    {
                        foreach (var data in userFriendlyEx.AdditionalData)
                        {
                            problemDetails.Extensions[data.Key] = data.Value;
                        }
                    }
                    break;

                case OperationCanceledException:

                    _logger.LogWarning("Request was cancelled");

                    problemDetails.Title = "Request was cancelled";
                    problemDetails.Status = (int)HttpStatusCode.BadRequest;

                    break;

                default:

                    _logger.LogError(exception, "An unhandled exception has occurred");

                    problemDetails.Title = "An unexpected error occurred";
                    problemDetails.Status = (int)HttpStatusCode.InternalServerError;
                    problemDetails.Detail = exception.Message;

                    break;
            }

            context.Result = new ObjectResult(problemDetails)
            {
                StatusCode = problemDetails.Status
            };

            context.ExceptionHandled = true;
        }
    }
}
