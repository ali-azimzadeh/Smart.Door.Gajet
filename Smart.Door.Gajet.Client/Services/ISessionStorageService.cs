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
    /// tab
    /// browser
    /// </summary>
    public interface ISessionStorageService
    {
        Task<T> GetItem<T>(string key);

        Task SetItem<T>(string key, T value);

        Task RemoveItem(string key);
    }
}
