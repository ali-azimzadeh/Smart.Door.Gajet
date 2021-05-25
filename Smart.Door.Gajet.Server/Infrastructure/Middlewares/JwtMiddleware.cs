using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Middlewares
{
    public class JwtMiddleware : object
    {
        public JwtMiddleware(Microsoft.AspNetCore.Http.RequestDelegate next,
            Microsoft.Extensions.Options.IOptions<ApplicationSettings.Main> options) : base()
        {
            Next = next;
            MainSettings = options.Value;
        }

        protected ApplicationSettings.Main MainSettings { get; }

        protected Microsoft.AspNetCore.Http.RequestDelegate Next { get; }

        public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context, Services.IUserService userService)
        {
            var requestHeader =
                context.Request.Headers[nameof(Resources.DataDictionary.Authorization)];

            string token =
                requestHeader.FirstOrDefault()
                ?.Split(" ")
                .Last()
                ;

            if (string.IsNullOrWhiteSpace(token) == false)
            {
                JwtUtility.AttachUserToContextByToken
                    (context: context, userService: userService, token: token, signKey: MainSettings.SignKey);
            }

            await Next(context);
        }
    }
}
