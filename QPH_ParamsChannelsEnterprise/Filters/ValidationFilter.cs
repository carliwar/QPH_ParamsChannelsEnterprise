using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                CustomErrors cErrors = new CustomErrors();
                foreach (var modelState in context.ModelState)
                {
                    foreach (var errors in modelState.Value.Errors)
                    {
                        cErrors.messages.Add(errors.ErrorMessage);
                    }
                }
                context.Result = new BadRequestObjectResult(cErrors);
                return;
            }
            await next();
        }
    }
}
