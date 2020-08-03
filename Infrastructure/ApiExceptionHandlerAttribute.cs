using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Http.Filters;

namespace AspMVCAdminLTE.Infrastructure
{
    public class ApiExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception.GetType() == typeof(DbEntityValidationException))
            {
                var errorMessages = ((DbEntityValidationException)actionExecutedContext.Exception).EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);
                actionExecutedContext.Exception = new DbEntityValidationException(string.Join("\n", errorMessages), ((DbEntityValidationException)actionExecutedContext.Exception).EntityValidationErrors);
            }
            base.OnException(actionExecutedContext);
        }
    }
}