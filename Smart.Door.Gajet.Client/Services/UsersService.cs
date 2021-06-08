
using Azx.Razor;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.User;

namespace Smart.Door.Gajet.Client.Services
{
    public class UsersService : Infrastructure.ServiceBase, IUserService
    {
        public UsersService
            (System.Net.Http.HttpClient httpClient, ApplicationSettingsService applicationSettingsService, LogsService logsService)
            : base(httpClient: httpClient, applicationSettingsService: applicationSettingsService, logsService: logsService)
        {

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

        public async Task<LoginResponseViewModel> LoginAsync(LoginRequestViewModel loginRequestViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
