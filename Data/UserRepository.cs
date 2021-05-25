using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserRepository : Repository<Models.User>, IUserRepository
    {

        internal UserRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }


        public List<User> GetActive()
        {
            var result =
                DbSet
                .Where(current => current.IsActive == true)
                .ToList()
                ;

            return result;
        }

        public async Task<List<User>> GetActiveAsync()
        {
            var result = await
                DbSet
                .Where(current => current.IsActive == true)
                .ToListAsync()
                ;

            return result;
        }

        public User GetByUserName(string username)
        {
            if (string.IsNullOrWhiteSpace(username) == true)
            {
                return null;
            }

            var result =
                DbSet.Where(current => current.Username.ToLower() == username.ToLower())
                .FirstOrDefault()
                ;

            return result;
        }

        public async Task<User> GetByUserNameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username) == true)
            {
                return null;
            }

            var result = await
                DbSet
                .Where(current => current.Username.ToLower() == username.ToLower())
                .FirstOrDefaultAsync()
                ;

            return result;
        }

        public bool IsActive(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId) == true)
            {
                return false;
            }

            var foundedUser =
                DbSet
                .Find(keyValues: userId)
                ;

            if (foundedUser == null)
            {
                return false;
            }

            var result =
                foundedUser
                .IsActive;

            return result;
        }

        public async Task<bool> IsActiveAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId) == true)
            {
                return false;
            }

            var foundedUser = await
                DbSet
                .FindAsync(keyValues: userId)
                ;

            if (foundedUser == null)
            {
                return false;
            }

            var result =
                foundedUser
                .IsActive;

            return result;
        }
    }
}
