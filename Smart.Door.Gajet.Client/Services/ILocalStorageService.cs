using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Door.Gajet.Client.Services
{
    /// <summary>
    /// متد های مورد نیاز برای ذخیره سازی اطلاعات کاربر
    /// در 
    /// storage
    /// browser
    /// </summary>
    public interface ILocalStorageService
    {
        Task<T> GetItemAsync<T>(string key);

        Task SetItemAsync<T>(string key, T value);
        
        Task RemoveItemAsync(string key);
    }
}
