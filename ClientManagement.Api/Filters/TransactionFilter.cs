using ClientManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClientManagement.Api.Middleware
{
    public class TransactionFilter : IAsyncActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Request.Method == HttpMethods.Get)
            {
                await next();
                return;
            }

            await _unitOfWork.BeginTransaction();
            var executedContext = await next();

            if (executedContext.Exception == null)
            {
                await _unitOfWork.CommitTransaction();
            }
            else
            {
                await _unitOfWork.RollbackTransaction();
            }
        }
    }
}
