using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Door.Gajet.Client.Data
{
    public class UseInMemoryDatabase : object
    {
        public UseInMemoryDatabase(Data.DatabaseContext dbContext) : base()
        {
            DatabaseContext = dbContext;
        }

        protected Data.DatabaseContext DatabaseContext { get; }

        public async Task<bool> SetItemsAsync(LoginResponse loginResponse)
        {
            try
            {
                DatabaseContext.Users.Add(entity: loginResponse);
                await DatabaseContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<LoginResponse> GetItemsAsync()
        {
            try
            {
                var users = DatabaseContext.GetUsers();

                Data.LoginResponse foundedUser =
                  await
                  DatabaseContext.Users.FirstOrDefaultAsync()
                  ;

                if (foundedUser == null)
                {
                    return null;
                }

                return foundedUser;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<string> GetTokenAsync()
        {
            Data.LoginResponse foundedUser =
                await 
                DatabaseContext.Users.FirstOrDefaultAsync()
                ;

            if (foundedUser == null)
            {
                return null;
            }

            var token = foundedUser.Token;

            return token;
        }
        public async Task<bool> RemoveItemAsync()
        {
            try
            {
                Data.LoginResponse foundedUser =
                    await 
                    DatabaseContext.Users.FirstOrDefaultAsync()
                    ;

                if (foundedUser == null)
                {
                    return false;
                }

                DatabaseContext.Remove(entity: foundedUser);
                await DatabaseContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
