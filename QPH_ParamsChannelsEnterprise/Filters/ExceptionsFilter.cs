using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QPH_ParamsChannelsEnterprise.Filters
{
    public class ExceptionsFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var errors = new { messages = context.Exception.Message };
            context.HttpContext.Response.StatusCode = 400;
            context.Result = new JsonResult(errors);
        }
    }
}
