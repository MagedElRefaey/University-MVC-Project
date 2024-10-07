using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstTaskMVC.ActionFilters
{
    public class ExceptionFilters:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception != null)
            {
                context.ExceptionHandled=true;
                context.Result = new ContentResult() { Content = "Exception" };
            }
            base.OnActionExecuted(context);
        }
    }
}
