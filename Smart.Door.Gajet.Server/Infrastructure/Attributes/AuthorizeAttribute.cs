using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Attributes
{
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute :
        System.Attribute, Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter
    {
        public AuthorizeAttribute() : base()
        {
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Models.User user =
                context.HttpContext.Items[Resources.DataDictionary.User] as Models.User;

            //Not Login!
            if (user == null)
            {
                context.Result =
                    new Microsoft.AspNetCore.Mvc.JsonResult(new
                    {
                        message = Resources.ErrorMessages.Unauthorized
                    })
                    {
                        StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized
                    };
            }
        }
    }
}
