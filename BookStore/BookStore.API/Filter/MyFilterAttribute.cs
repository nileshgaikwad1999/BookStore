using Microsoft.AspNetCore.Mvc.Filters;

namespace BookStore.API.Filter
{
    public class MyFilterAttribute : Attribute, IActionFilter
    {
        private readonly string _callerName;

        public MyFilterAttribute(string callerName)
        {
            _callerName = callerName;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"{_callerName} -OnActionExecuting exicuted");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"{_callerName} -OnActionExecuted exicuted");
        }

    }
}
