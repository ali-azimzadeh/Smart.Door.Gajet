
using Azx.Razor;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Models;
using Smart.Door.Gajet.Client.Data;
using Smart.Door.Gajet.Client.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ViewModels.User;

namespace Smart.Door.Gajet.Client.Services
{
    /// <summary>
    /// این کلاس یک سرویس برای اتصال به سرور و انجام عملیات 
    /// مورد نیاز کاربر می باشدکه از روش 
    /// DI
    /// کلیه متغیرهای مورد نیاز از جنس کلاسهای مختلف 
    /// در زمان ایجاد یک شی از این کلاس 
    /// inject  
    /// می شود و مورد استفاده قرار می گیرد
    /// </summary>
    public class UsersService : Infrastructure.ServiceBase, IUserService
    {
        public UsersService
            (System.Net.Http.HttpClient httpClient, ApplicationSettingsService applicationSettingsService, LogsService logsService,
            Data.UseInMemoryDatabase inMemoryDatabase, AuthenticationStateProvider _authStateProvider, ILocalStorageService _localStorageService,
            ISessionStorageService sessionStorageService)
            : base(httpClient: httpClient, applicationSettingsService: applicationSettingsService, logsService: logsService,
                  inMemoryDatabase: inMemoryDatabase, _authStateProvider: _authStateProvider, localStorageService: _localStorageService,
                  sessionStorage: sessionStorageService)
        {
        }

        public LoginResponse User { get; private set; }

        public async Task Initialize()
        {
            //برای ذخیره اطلاعات کاربر بروی 
            //storage
            //browser
            //به کار می رود

            User =
                await
                LocalStorage.GetItemAsync<LoginResponse>("user");

            //********************************************************
            //برای ذخیره اطلاعات کاربر بروی 
            //storage
            //tab
            //browser
            //به کار می رود

            //User = 
            //   await 
            //   SessionStorage.GetItem<LoginResponse>("user");

            //********************************************************
            //برای ذخیره اطلاعات کاربر بروی 
            //in memory database
            //ef core
            //به کار می رود
            //که به استفاده از این روش توصیه نمی شود

            //User = 
            //    await 
            //    InMemoryDatabase.GetItemsAsync();
        }

        /// <summary>
        /// این متد لیستی از کاربرهایی که در سیستم 
        /// active
        /// هستند رو برمی گرداند
        /// </summary>
        /// <returns>
        /// IEnumerable<Result<User>>
        /// </returns>
        public async Task<IEnumerable<Result<User>>> GetActiveAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// این متد لیستی از کاربران را ارائه می دهد
        /// </summary>
        /// <returns>
        /// IEnumerable<User>
        /// </returns>
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            string url = "users";

            var result =
                await
                GetAsync
                <System.Collections.Generic.IList<Models.User>>
                (url: url)
                ;

            return result;
        }

        /// <summary>
        /// این متد یک کاربر با 
        /// id 
        /// خاص را برمیگرداند
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// User
        /// </returns>
        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// این متد عملیات لاگین کردن کاربر را از طریق اتصال به 
        /// backend
        /// برعهده  دارد
        /// </summary>
        /// <param name="loginRequestViewModel"></param>
        /// <returns>
        /// LoginResponse
        /// </returns>
        public async Task<LoginResponse> LoginAsync(LoginRequestViewModel loginRequestViewModel)
        {
            var content =
                JsonSerializer.Serialize(loginRequestViewModel);

            var bodyContent =
                new StringContent(content, Encoding.UTF8, "application/json");

            var authResult =
                await
                HttpClient.PostAsync("http://localhost:34983/users/loginasync", bodyContent);

            var authContent =
                await
                authResult.Content.ReadAsStringAsync();

            var result =
                JsonSerializer.Deserialize<LoginResponse>
                (authContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (authResult.IsSuccessStatusCode == false)
            {
                return result;
            }

            await LocalStorage.SetItemAsync<LoginResponse>("user", result);

            // await SessionStorage.SetItem<LoginResponse>("user", result);

            //await InMemoryDatabase.SetItemsAsync(loginResponse: result);

            ((CustomAuthenticationStateProvider)AuthenticationStateProvider)
                .NotifyUserAuthentication(loginRequestViewModel.UserName);

            HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", result.Token);

            ApplicationSettingsService.Token = result.Token;

            return result as LoginResponse;
        }

        /// <summary>
        /// این متد برای 
        /// log out
        /// کردن کاربر به کار می رود
        /// </summary>
        /// <returns>
        /// چیزی بر نمی گرداند
        /// </returns>
        public async Task Logout()
        {

            await LocalStorage.RemoveItemAsync("user");

            //await SessionStorage.RemoveItem("user");

            //await InMemoryDatabase.RemoveItemAsync();

            ((CustomAuthenticationStateProvider)AuthenticationStateProvider).NotifyUserLogout();

            HttpClient.DefaultRequestHeaders.Authorization = null;
        }

    }
}
