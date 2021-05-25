using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IUserRepository : Base.IRepository<Models.User>
    {
        Models.User GetByUserName(string username);

        System.Threading.Tasks.Task<Models.User> GetByUserNameAsync(string username);

        List<Models.User> GetActive();

        System.Threading.Tasks.Task<List<Models.User>> GetActiveAsync();

        bool IsActive(string userId);

        System.Threading.Tasks.Task<bool> IsActiveAsync(string userId);
    }
}
