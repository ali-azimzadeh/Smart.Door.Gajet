using Azx.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Door.Gajet.Client.Services
{
    public interface IUserService
    {
        Task<Models.User> GetByIdAsync(Guid id);

        Task<IEnumerable<Models.User>> GetAllAsync();
 
        Task<ViewModels.User.LoginResponseViewModel>
            LoginAsync(ViewModels.User.LoginRequestViewModel loginRequestViewModel);

        Task<System.Collections.Generic.IEnumerable<Result<Models.User>>> GetActiveAsync();


    }
}
