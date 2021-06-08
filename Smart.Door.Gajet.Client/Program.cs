using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Door.Gajet.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddDevExpressBlazor();

            builder.Services.AddSingleton
                (current => new HttpClient
                {
                    BaseAddress =
                    new Uri(builder.HostEnvironment.BaseAddress),
                });

            //            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>();

            //builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            //builder.Services.AddSingleton(typeof(IDxLocalizationService), typeof(LocalizationService));

            await builder.Build().RunAsync();
        }
    }
}
