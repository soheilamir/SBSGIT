using System.Net;
using System.Web.Http.ExceptionHandling;
using SBSWebProject.Data.Exceptions;
using SBSWebProject.Common;

namespace SBSWebProject.Web.Common.ErrorHandling
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var exception = context.Exception;
            var httpException = exception as System.Web.HttpException;
            if (httpException != null)
            {
                context.Result = new SimpleErrorResult(context.Request,
                (HttpStatusCode)httpException.GetHttpCode(), httpException.Message);
                return;
            }
            if (exception is RootObjectNotFoundException)
            {
                context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.NotFound, exception.Message);
                return;
            }
            if (exception is ChildObjectNotFoundException)
            {
                context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.Conflict, exception.Message);
                return;
            }
            if (exception is BusinessRuleViolationException)
            {
                context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.PaymentRequired, exception.Message);
                return;
            }
            context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.InternalServerError,
            exception.Message);
        }
    }
}
