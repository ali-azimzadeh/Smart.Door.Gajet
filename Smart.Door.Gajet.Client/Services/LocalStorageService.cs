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
    /// browser
    /// ذخیره می کند یعنی اگر
    /// browser
    /// دیگری را باز کند باید دوباره لاگین کند
    /// </summary>
    public class LocalStorageService : ILocalStorageService
    {
        protected IJSRuntime JsRuntime { get; }

        public LocalStorageService(IJSRuntime jsRuntime)
        {
            JsRuntime = jsRuntime;
        }

        /// <summary>
        /// وظیفه این متد دریافت اطلاعات ذخیره شده کاربر مثل توکن در 
        /// storage 
        /// browser 
        /// است
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> GetItemAsync<T>(string key)
        {
            var json =
                await JsRuntime.InvokeAsync<string>
                ("localStorage.getItem", key);

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
        public async Task SetItemAsync<T>(string key, T value)
        {
            await
                JsRuntime.InvokeVoidAsync
                ("localStorage.setItem", key, JsonSerializer.Serialize(value));
        }

        /// <summary>
        /// وظیفه این متد هم پاک کردن اطلاعات کاربر که ذخیره شده است 
        /// این متد در زمان 
        /// log out
        /// کاربر از سیستم کاربرد دارد
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task RemoveItemAsync(string key)
        {
            await
                JsRuntime.InvokeVoidAsync
                ("localStorage.removeItem", key);
        }
    }
}
