
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
    public class UsersService : Infrastructure.ServiceBase, IUserService
    {
        public UsersService
            (System.Net.Http.HttpClient httpClient, ApplicationSettingsService applicationSettingsService, LogsService logsService,
            Data.UseInMemoryDatabase inMemoryDatabase, AuthenticationStateProvider _authStateProvider, ILocalStorageService _localStorageService,
            ISessionStorageService sessionStorageService)
            : base(httpClient: httpClient, applicationSettingsService: applicationSettingsService, logsService: logsService,
                  inMemoryDatabase:inMemoryDatabase,_authStateProvider:_authStateProvider,localStorageService:_localStorageService,
                  sessionStorage:sessionStorageService)
        {
            
        }

        public LoginResponse User { get; private set; }
        public async Task Initialize()
        {
            User = await LocalStorage.GetItem<LoginResponse>("user");

           //// User = await SessionStorage.GetItem<LoginResponse>("user");

            //User = await InMemoryDatabase.GetItemsAsync();
        }

        public async Task<IEnumerable<Result<User>>> GetActiveAsync()
        {
            throw new NotImplementedException();
        }

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

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginResponse> LoginAsync(LoginRequestViewModel loginRequestViewModel)
        {
            var content = JsonSerializer.Serialize(loginRequestViewModel);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var authResult = await HttpClient.PostAsync("http://localhost:34983/users/loginasync", bodyContent);
            var authContent = await authResult.Content.ReadAsStringAsync();

            var result =
                JsonSerializer.Deserialize<LoginResponse>
                (authContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!authResult.IsSuccessStatusCode)
                return result;

            //            await LocalStorage.SetItem<string>("authToken", result.Token);


            await LocalStorage.SetItem<LoginResponse>("user", result);

           // await SessionStorage.SetItem<LoginResponse>("user", result);


            //await InMemoryDatabase.SetItemsAsync(loginResponse: result);

            ((CustomAuthenticationStateProvider)AuthenticationStateProvider).NotifyUserAuthentication(loginRequestViewModel.UserName);

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
            ApplicationSettingsService.Token = result.Token;

            
            return result as LoginResponse;
        }

        public async Task Logout()
        {
            //  await LocalStorage.RemoveItemAsync("authToken");

             await LocalStorage.RemoveItem("user");

            //await SessionStorage.RemoveItem("user");

            //await InMemoryDatabase.RemoveItemAsync();

            ((CustomAuthenticationStateProvider)AuthenticationStateProvider).NotifyUserLogout();
            HttpClient.DefaultRequestHeaders.Authorization = null;
        }

 
    }
}
