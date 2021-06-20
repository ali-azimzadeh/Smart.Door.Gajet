using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Door.Gajet.Client.Services
{
    /// <summary>
    /// این کلاس برای ذخیره ی 
    /// settings های
    /// سیستم بکار می رود
    /// البته در سمت کلاینت
    /// </summary>
    public class ApplicationSettingsService : object
    {
        /// <summary>
        /// در زمان ساخت یک شی از این کلاس دات نت بصورت 
        /// DI
        /// عمل می کند و یک شی از جنس 
        /// IConfiguration
        /// می سازد و به این کلاس 
        /// inject
        /// می کند
        /// ضمنا از فایل 
        /// appsettings.json
        /// از بخش 
        /// BaseUrl
        /// آدرس مورد نظر برای اتصال به 
        /// backend
        /// را دریافت می کند و در  
        /// BaseUrl
        /// قرار می دهد
        /// </summary>
        /// <param name="configuration"></param>
        public ApplicationSettingsService
            (Microsoft.Extensions.Configuration.IConfiguration configuration)
            : base()
        {
            Configuration = configuration;

         
            BaseUrl =
                Configuration.GetSection("BaseUrl").Value;
        }

        protected Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        /// <summary>
        /// property این
        /// در زمان لاگین کردن کاربر و پس از موفقیت آمیز بودن یا نبودن عملیات 
        /// مقدار دهی می شود
        /// </summary>
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

        /// <summary>
        /// property این 
        /// برای ذخیره توکن ساخته شده و ارسال شده به کلاینت از سمت سرور 
        /// به کار می رود که برای درخواستهای بعدی که قرار است به سمت سرور برود 
        /// استفاده می شود
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// property این 
        /// برای ذخیره نام و نام خانوادگی کاربری که لاگین کرده به کار می رود
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// property این 
        /// برای ذخیره نام کاربری 
        /// کاربر مورد استفاده قرار می گیرد
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// property این 
        /// برای ذخیره آدرس 
        /// url  بک اند
        /// مورد استفاده است
        /// </summary>
        public string BaseUrl { get; set; }


    }
}
