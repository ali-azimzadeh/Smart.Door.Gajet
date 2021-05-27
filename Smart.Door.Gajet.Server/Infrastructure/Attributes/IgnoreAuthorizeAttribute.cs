using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class IgnoreAuthorizeAttribute : System.Attribute
    {
        public IgnoreAuthorizeAttribute() : base()
        {
        }
    }
}
