using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IUserPasswordHistoryRepository : Base.IRepository<Models.UserPasswordHistory>
    {
        List<Models.UserPasswordHistory> GetByUserId(Guid id);

        Task<List<Models.UserPasswordHistory>> GetByUserIdAsync(Guid id);

    }
}
