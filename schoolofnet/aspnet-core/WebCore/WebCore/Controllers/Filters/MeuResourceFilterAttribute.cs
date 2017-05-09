using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Controllers.Filters
{
    public class MeuResourceFilterAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //throw new NotImplementedException();
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        
    }
}
