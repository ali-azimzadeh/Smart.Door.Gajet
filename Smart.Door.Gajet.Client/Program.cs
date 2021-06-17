using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Smart.Door.Gajet.Client.Infrastructure;
using Smart.Door.Gajet.Client.Services;
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

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddDevExpressBlazor();

            builder.Services.AddSingleton
                (current => new HttpClient
                {
                    BaseAddress =
                    new Uri(builder.HostEnvironment.BaseAddress),
                });

            //builder.Services.AddSingleton
            //        (current => new HttpClient
            //        {
            //            BaseAddress =
            //            new Uri(builder.HostEnvironment.BaseAddress),
            //        }).AddBlazoredLocalStorage();

            //            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            //  builder.Services.AddScoped<AuthenticationStateProvider>();




            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            //    builder.Services.AddScoped<ILocalStorageService>();


            builder.Services.AddSingleton<Services.LogsService>();
            builder.Services.AddScoped<Services.IUserService, Services.UsersService>();
            builder.Services.AddSingleton<Services.ApplicationSettingsService>();



            builder.Services.AddDbContext<Data.DatabaseContext>(options =>
               options.UseInMemoryDatabase(databaseName:"LoginUsersData"));
            builder.Services.AddScoped<Data.DatabaseContext>();
            builder.Services.AddScoped<Data.UseInMemoryDatabase>();

            builder.Services.AddSingleton<StateContainer>();

            builder.Services.AddScoped<Services.ILocalStorageService, LocalStorageService>();

            builder.Services.AddScoped<Services.ISessionStorageService, SessionStorageService>();

            //builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            //builder.Services.AddSingleton(typeof(IDxLocalizationService), typeof(LocalizationService));
            //  builder.Services.AddBlazoredLocalStorage();

            var host = builder.Build();

            var authenticationService = host.Services.GetRequiredService<IUserService>();
            await authenticationService.Initialize();

            await host.RunAsync();

            // await builder.Build().RunAsync();
        }
    }
}
