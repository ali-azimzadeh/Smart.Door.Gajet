using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DatabaseContext(Microsoft.EntityFrameworkCore.DbContextOptions<DatabaseContext> options)
            : base(options: options)
        {

            //************************************
            // این کد درست کار نمی کند و خطاهای مختلفی را برمی گرداند
            // await Database.EnsureCreatedAsync();
            //************************************

            Database.EnsureCreated();
            Seed();
        }

        // **********
        public Microsoft.EntityFrameworkCore.DbSet<Models.Log> Logs { get; set; }
        // **********

        // **********
        public Microsoft.EntityFrameworkCore.DbSet<Models.Role> Roles { get; set; }
        // **********

        // **********
        public Microsoft.EntityFrameworkCore.DbSet<Models.User> Users { get; set; }
        // **********

        // **********
        public Microsoft.EntityFrameworkCore.DbSet<Models.Device> Devices { get; set; }
        // **********

        // **********
        public Microsoft.EntityFrameworkCore.DbSet<Models.Building> Buildings { get; set; }
        // **********

        // **********
        public Microsoft.EntityFrameworkCore.DbSet<Models.LoginLog> LoginLogs { get; set; }
        // **********

        // **********
        public Microsoft.EntityFrameworkCore.DbSet<Models.UserValid> UserValids { get; set; }
        // **********

        // **********
        public Microsoft.EntityFrameworkCore.DbSet<Models.RoleInPermission> RoleInPermissions { get; set; }
        // **********

        // **********
        public Microsoft.EntityFrameworkCore.DbSet<Models.UserPasswordHistory> UserPasswordHistories { get; set; }
        // **********

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.UserValid>()
                .HasKey(userValid => new { userValid.BuildingId, userValid.UnitNo, userValid.ValidCellPhoneNumber })
                ;

            //modelBuilder.Entity<Models.Building>()
            //    .Property(building => building..somefield).IsOptional();
        }

        private void Seed()
        {

            //var newEntity =
            // new Models.Building
            // {
            //     Id = Guid.NewGuid(),
            //     IsActive = true,
            //     UnitsCount = 10,
            //     FloorsCount = 5,
            //     BuildingName = "Building1",
            //     ManagerUnitNo = "2",
            //     ManagerFullName = "Ali Azimzadeh",
            //     ManagerCellPhoneNumber = "09192757749",

            //     InsertByUser = Guid.NewGuid()
            // };

            //Buildings.AddAsync(entity: newEntity);


            //var newEntity =
            //          new Models.UserValid
            //          {
            //              Id = Guid.NewGuid(),
            //              IsActive = true,
            //              UnitNo = "100",
            //              BuildingId = Guid.NewGuid(),
            //              UserId = Guid.NewGuid(),
            //              ValidCellPhoneNumber = "+9809192757749",
            //              InsertByUser = Guid.NewGuid()
            //          };

            //UserValids.AddAsync(entity: newEntity);


            //var newEntity =
            //          new Models.User
            //          {
            //              Id = Guid.NewGuid(),
            //              IsActive = true,
            //              InsertByUser = Guid.NewGuid(),
            //              CellPhoneNumber = "09192757749",
            //              FullName = "ali azimzadeh2",
            //              GroupId = 10,
            //              Password = "F95145D3B7A732187CCDF248FA5038D8490B92ED",
            //              Username = "UserName2",
            //              RoleId = 1
            //          };

            //Users.AddAsync(entity: newEntity);

            //var newEntity =
            //          new Models.Device
            //          {
            //              Id = Guid.NewGuid(),
            //              IsActive = true,
            //              InsertByUser = Guid.NewGuid(),
            //              BuildingId = Guid.NewGuid(),
            //              SerialNo = "K002A",
            //              SimcardNo = "09192757749",
            //              Frequency = 315,
            //              DeviceModel="KASA"
            //          };

            //Devices.AddAsync(entity: newEntity);



            //var newEntity =
            //          new Models.Role
            //          {
            //              Id = Guid.NewGuid(),
            //              IsActive = true,
            //              InsertByUser = Guid.NewGuid(),
            //        RoleName="User1",
                    
            //          };

            //Roles.AddAsync(entity: newEntity);

            //this.SaveChangesAsync();
        }
    }
}
