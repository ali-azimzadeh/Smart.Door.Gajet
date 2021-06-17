﻿using Azx.Razor;
using Smart.Door.Gajet.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Door.Gajet.Client.Services
{
    public interface IUserService
    {
        LoginResponse User { get; }

        Task<Models.User> GetByIdAsync(Guid id);

        Task<IEnumerable<Models.User>> GetAllAsync();
 
        Task<LoginResponse>
            LoginAsync(ViewModels.User.LoginRequestViewModel loginRequestViewModel);

        Task<System.Collections.Generic.IEnumerable<Result<Models.User>>> GetActiveAsync();

        Task Initialize();
        Task Logout();
    }
}
