using Microsoft.AspNetCore.Mvc.Filters;

namespace BookStore.API.Filter
{
    public class MyAsycFilterAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("async filter :during execution");

            await next();
            Console.WriteLine("async filter :after execution");

        }
    }
}
