using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Door.Gajet.Server
{
    public class Startup : object
    {
        public const string ADMIN_CORS_POLICY = "ADMIN_CORS_POLICY";
        public const string OTHERS_CORS_POLICY = "OTHERS_CORS_POLICY";

        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Cross-Origin Resource Sharing (CORS)
            services.AddCors(options =>
            {
                options.AddPolicy(ADMIN_CORS_POLICY,
                    builder =>
                    {
                        builder
                            .WithOrigins("http://localhost:34983")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            //.AllowCredentials()
                            ;
                    });

                options.AddPolicy(OTHERS_CORS_POLICY,
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            //.AllowCredentials()
                            ;
                    });
            });

            //services.AddControllers();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.MaxDepth = 5;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            //services.AddDbContext<Data.DatabaseContext>(options =>
            //{
            //	options.UseSqlServer
            //		(connectionString: "Password=1234512345;Persist Security Info=True;User ID=SA;Initial Catalog=DtxSecurity;Data Source=.");
            //});

            //services.AddDbContext<Data.DatabaseContext>(options =>
            //{
            //	options.UseSqlServer
            //		(connectionString: Configuration.GetSection(key: "ConnectionStrings").GetSection(key: "MyConnectionString");
            //});

            //services.AddTransient<Data.IUnitOfWork, Data.UnitOfWork>();

            services.AddTransient<Data.IUnitOfWork, Data.UnitOfWork>(option =>
            {
                Data.Tools.Options options =
                    new Data.Tools.Options
                    {
                        Provider =
                            (Data.Tools.Enums.Provider)
                            System.Convert.ToInt32(Configuration.GetSection(key: "databaseProvider").Value),

                        //using Microsoft.EntityFrameworkCore;
                        //ConnectionString =
                        //	Configuration.GetConnectionString().GetSection(key: "MyConnectionString").Value,

                        ConnectionString =
                            Configuration.GetSection(key: "ConnectionStrings").GetSection(key: "MyConnectionString").Value,
                    };

                return new Data.UnitOfWork(options: options);
            });

            //Configure Dependency Injection for user services
            services.AddScoped<Services.IUserService, Services.UserService>();

            // Add our Config object so it can be injected
            //  بروی یک کلاس باید حتما از دستور زیر استفاده کرد AppSettings کردن  map  برای 
            services.Configure<Infrastructure.ApplicationSettings.Main>(Configuration.GetSection("AppSettings"));

            //services.AddTransient<Dtx.ILogger, Dtx.Logger>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            app.UseCors(policyName: ADMIN_CORS_POLICY);

            app.UseRouting();

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseMiddleware<Infrastructure.Middlewares.JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



            //  ها Middleware  ترتیب نوشتن 
            //The following Startup.Configure method adds middleware components for common app scenarios:

            //1 - Exception / error handling
            

            //2 - HTTP Strict Transport Security Protocol
            

            //3 - HTTPS redirection
            

            //4 - Static file server
            

            //5 - Cookie policy enforcement
            

            //6 - Authentication
            

            //7 - Session
            

            //8 - MVC

        }
    }
}
