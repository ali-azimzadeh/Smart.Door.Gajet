using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using System.Net.Http.Headers;
using Smart.Door.Gajet.Client.Data;
using Smart.Door.Gajet.Client.Infrastructure;

namespace Smart.Door.Gajet.Client.Infrastructure
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        protected Services.ILocalStorageService LocalStorageService { get; }

        protected Services.ISessionStorageService SessionStorageService { get; }

        //    public IUserService _userService { get; set; }
        protected UseInMemoryDatabase InMemoryDatabase { get; }

        private readonly HttpClient _httpClient;
        private readonly AuthenticationState _anonymous;

//        public CustomAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        public CustomAuthenticationStateProvider(HttpClient httpClient, UseInMemoryDatabase inMemoryDatabase,
            Services.ILocalStorageService localStorage, Services.ISessionStorageService sessionStorage)
        {
            _httpClient = httpClient;
            InMemoryDatabase = inMemoryDatabase;
            LocalStorageService = localStorage;
            SessionStorageService = sessionStorage;
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        //    public CustomAuthenticationStateProvider(ILocalStorageService localStorageService,
        //        IUserService userService,
        //        HttpClient httpClient)
        //    {
        //        //throw new Exception("CustomAuthenticationStateProviderException");
        //        _localStorageService = localStorageService;
        //        _userService = userService;
        //        _httpClient = httpClient;
        //    }

        //    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        //    {
        //        var accessToken = await _localStorageService.GetItemAsync<string>("accessToken");

        //        ClaimsIdentity identity;

        //        if (accessToken != null && accessToken != string.Empty)
        //        {
        //            Models.User user = await _userService.GetUserByAccessTokenAsync(accessToken);
        //            identity = GetClaimsIdentity(user);
        //        }
        //        else
        //        {
        //            identity = new ClaimsIdentity();
        //        }

        //        var claimsPrincipal = new ClaimsPrincipal(identity);

        //        return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        //    }

        public async Task MarkUserAsAuthenticated(LoginResponse user)
        {
            //await _localStorageService.SetItemAsync("accessToken", user.AccessToken);
            //await _localStorageService.SetItemAsync("refreshToken", user.RefreshToken);

             await LocalStorageService.SetItem<LoginResponse>("user", user);

            // await SessionStorageService.SetItem<LoginResponse>("user", user);

            //await InMemoryDatabase.SetItemsAsync(loginResponse: user);

            var identity = GetClaimsIdentity(user);

            var claimsPrincipal = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task MarkUserAsLoggedOut()
        {
            //await _localStorageService.RemoveItemAsync("refreshToken");
            //await _localStorageService.RemoveItemAsync("accessToken");


            await LocalStorageService.RemoveItem("user");

            //await SessionStorageService.RemoveItem("user");

            //await InMemoryDatabase.RemoveItemAsync();

            var identity = new ClaimsIdentity();

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        private ClaimsIdentity GetClaimsIdentity(LoginResponse user)
        {
            var claimsIdentity = new ClaimsIdentity();

            if (user.Username != null)
            {
                claimsIdentity = new ClaimsIdentity(new[]
                                {
                         new System.Security.Claims.Claim(type: nameof(user.FullName), value: user.FullName),

                        new System.Security.Claims.Claim(type: nameof(user.RoleId), value: user.RoleId.ToString()),

                        new System.Security.Claims.Claim(type: System.Security.Claims.ClaimTypes.Name, value: user.Username),

                        new System.Security.Claims.Claim(type: System.Security.Claims.ClaimTypes.Role, value: user.Type.ToString()),

                        new System.Security.Claims.Claim(type: System.Security.Claims.ClaimTypes.NameIdentifier, value: user.Id.ToString()),
                                    //new Claim(ClaimTypes.Name, user.Id.ToString()),
                                    //new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                                    //new Claim("IsUserEmployedBefore1990", IsUserEmployedBefore1990(user))
                                }, "apiauth_type");
            }

            return claimsIdentity;
        }

        //    //private string IsUserEmployedBefore1990(User user)
        //    //{
        //    //    if (user.HireDate.Value.Year < 1990)
        //    //        return "true";
        //    //    else
        //    //        return "false";
        //    //}

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //            var token = await _localStorageService.GetItemAsync<string>("authToken");
            var user = await LocalStorageService.GetItem<LoginResponse>("user");
           
            // var user = await SessionStorageService.GetItem<LoginResponse>("user");

            //var user = await InMemoryDatabase.GetItemsAsync();

            var token = string.Empty;
            if (user!=null)
            {
                token = user.Token;
            }


            if (string.IsNullOrWhiteSpace(token))
                return _anonymous;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType")));
        }
        public void NotifyUserAuthentication(string email)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }
        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(_anonymous);
            NotifyAuthenticationStateChanged(authState);
        }

        //   public override Task<AuthenticationState> GetAuthenticationStateAsync()
        //   {
        //       var identity = new ClaimsIdentity(new[]
        //{
        //       new Claim(ClaimTypes.Name, "mrfibuli"),
        //   }, "Fake authentication type");

        //       var user = new ClaimsPrincipal(identity);

        //       return Task.FromResult(new AuthenticationState(user));
        //   }
    }
}
