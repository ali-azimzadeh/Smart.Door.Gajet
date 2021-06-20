using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Smart.Door.Gajet.Client.Services
{
    /// <summary>
    /// این کلاس برای ذخیره اطلاعات کاربر مانند توکن که از سمت سرور برمی گردند استفاده می شود
    /// توجه کنید که این کلاس اطلاعات را فقط برای یک 
    /// tab 
    /// browser
    /// ذخیره می کند یعنی اگر کاربر  تب رو ببندد و دوباره باز کند باید دوباره لاگین کند
    /// </summary>
    public class SessionStorageService : ISessionStorageService
    {
        protected IJSRuntime JsRuntime { get; }

        public SessionStorageService(IJSRuntime jsRuntime)
        {
            JsRuntime = jsRuntime;
        }

        /// <summary>
        /// وظیفه این متد دریافت اطلاعات ذخیره شده کاربر مثل توکن در 
        /// storage 
        /// tab
        /// browser 
        /// است
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> GetItem<T>(string key)
        {
            var json =
                await JsRuntime.InvokeAsync<string>
                ("sessionStorage.getItem", key);

            if (json == null)
                return default;

            var result =
                JsonSerializer.Deserialize<T>(json);

            return result;
        }

        /// <summary>
        /// وظیفه این متد ذخیره سازی اطلاعات کاربر مانند توکن است
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task SetItem<T>(string key, T value)
        {
            await
                JsRuntime.InvokeVoidAsync
                ("sessionStorage.setItem", key, JsonSerializer.Serialize(value));
        }

        /// <summary>
        /// وظیفه این متد هم پاک کردن اطلاعات کاربر که ذخیره شده است 
        /// این متد در زمان 
        /// log out
        /// کاربر از سیستم کاربرد دارد
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task RemoveItem(string key)
        {
            await
                JsRuntime.InvokeVoidAsync
                ("sessionStorage.removeItem", key);
        }
    }

}
