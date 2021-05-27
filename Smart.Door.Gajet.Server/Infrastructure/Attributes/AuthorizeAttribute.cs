using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Infrastructure.Attributes
{
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true)]
    public class AuthorizeAttribute :
        System.Attribute, Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter
    {
        public AuthorizeAttribute() : base()
        {
            //this._allowAnonymous = false;
        }
        //private bool _allowAnonymous;
        //public virtual bool AllowAnonymous
        //{
        //    get
        //    {
        //        return _allowAnonymous;
        //    }
        //    set
        //    {
        //        _allowAnonymous = value;
        //    }
        //}

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var descriptor =
                context.ActionDescriptor as
                Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor;

            //string strActionName = descriptor.ActionName;

            var methodInfo = descriptor.MethodInfo;

            // آنرا هم بنویسیم باید   Ignore  که نوشتیم   CustomAttribute  اگر بخواهیم برای     
            //  بنویسیم   IgnoreAuthorizeAttribute  اول کلاس آنرا مثل  
            //بعدا اینجا آنرا چک کنیم که اگر آن اتریبیوت برای اکشن مورد نظر وجود دارد بی خیال شود 
            //  که نوشتیم کار نمی کند Ignore  در غیر اینصورت اتریبیوت 

            var result =
                methodInfo.CustomAttributes
                .Where(current => current.AttributeType.Name == "IgnoreAuthorizeAttribute")
                .FirstOrDefault()
                ;

            //            if (strActionName != "Login")
            if (result == null)
            {
                Models.User user =
                    context.HttpContext.Items[Resources.DataDictionary.User] as Models.User;

                //Not Login!
                if (user == null)
                {
                    context.Result =
                        new Microsoft.AspNetCore.Mvc.JsonResult(new
                        {
                            message = 
                                 Resources.ErrorMessages.Unauthorized
                        })
                        {
                            StatusCode = 
                                 Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized
                        };
                }
            }
        }
    }
}
