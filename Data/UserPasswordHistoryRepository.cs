using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserPasswordHistoryRepository : 
        Repository<Models.UserPasswordHistory>, IUserPasswordHistoryRepository
    {
        internal UserPasswordHistoryRepository(DatabaseContext databaseContext)
            : base(databaseContext: databaseContext)
        {
        }

        public List<UserPasswordHistory> GetByUserId(Guid id)
        {
            var result =
                DbSet
                .Where(current => current.UserId == id)
                .ToList()
                ;

            return result;
        }

        public async Task<List<UserPasswordHistory>> GetByUserIdAsync(Guid id)
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
