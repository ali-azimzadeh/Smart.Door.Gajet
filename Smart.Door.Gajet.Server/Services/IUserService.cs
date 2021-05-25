using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        Models.User GetById(Guid id);

        IEnumerable<Models.User> GetAll();

        Task<Models.User> GetByIdAsync(Guid id);

        Task<IEnumerable<Models.User>> GetAllAsync();


        ViewModels.User.LoginResponseViewModel
            Login(ViewModels.User.LoginRequestViewModel loginRequestViewModel);

        Task<ViewModels.User.LoginResponseViewModel>
            LoginAsync(ViewModels.User.LoginRequestViewModel loginRequestViewModel);
    }
}
