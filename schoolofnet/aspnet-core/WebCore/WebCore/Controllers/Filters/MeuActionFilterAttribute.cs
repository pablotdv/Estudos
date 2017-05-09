using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Controllers.Filters
{
    public class MeuActionFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
        
    }
}
