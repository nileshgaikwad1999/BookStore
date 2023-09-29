using Microsoft.AspNetCore.Mvc.Filters;

namespace BookStore.API.Filter
{
    public class MyFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {

            Console.WriteLine("OnActionExecuting exicuted");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("OnActionExecuted exicuted");
        }


    }
}
