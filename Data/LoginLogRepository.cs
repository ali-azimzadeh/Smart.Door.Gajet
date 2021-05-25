using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class LoginLogRepository : Repository<Models.LoginLog>, ILoginLogRepository
    {
        internal LoginLogRepository(DatabaseContext databaseContext)
            : base(databaseContext: databaseContext)
        {
        }

        public List<LoginLog> GeyByUserId(Guid id)
        {
            var result =
                DbSet
                .Where(current => current.UserId == id)
                .ToList()
                ;

            return result;
        }

        public async Task<List<LoginLog>> GeyByUserIdAsync(Guid id)
        {
            var result = await
                DbSet
                .Where(current => current.UserId == id)
                .ToListAsync()
                ;

            return result;
        }
    }
}
