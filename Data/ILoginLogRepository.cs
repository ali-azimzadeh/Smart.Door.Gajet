using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface ILoginLogRepository : Base.IRepository<Models.LoginLog>
    {
        List<Models.LoginLog> GeyByUserId(Guid id);

        Task<List<Models.LoginLog>> GeyByUserIdAsync(Guid id);
    }
}
