using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Door.Gajet.Client.Services
{
    public class ApplicationSettingsService : object
    {
        public ApplicationSettingsService
            (Microsoft.Extensions.Configuration.IConfiguration configuration)
            : base()
        {
            Configuration = configuration;

            BaseUrl =
                Configuration.GetSection("BaseUrl").Value;
        }

        protected Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        public bool IsAuthenticated
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Token) == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public string Token { get; set; }

        public string FullName { get; set; }

        public string Username { get; set; }

        public string BaseUrl { get; set; }
    }
}
