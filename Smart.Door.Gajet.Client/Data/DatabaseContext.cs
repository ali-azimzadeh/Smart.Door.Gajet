using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Door.Gajet.Client.Data
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DatabaseContext(Microsoft.EntityFrameworkCore.DbContextOptions dbContextOptions)
            : base(options: dbContextOptions)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Data.LoginResponse> Users { get; set; }


        public List<Data.LoginResponse> GetUsers()
        {
            return Users.ToList<Data.LoginResponse>();
        }
    }
}
