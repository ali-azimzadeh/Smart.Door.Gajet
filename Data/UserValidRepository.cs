using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserValidRepository : Repository<Models.UserValid>, IUserValidRepository
    {
        internal UserValidRepository(DatabaseContext databaseContext)
            : base(databaseContext: databaseContext)
        {
        }

        public List<UserValid> GetByBuildingId(Guid id)
        {
            var result =
                DbSet
                .Where(current => current.BuildingId == id)
                .ToList()
                ;

            if (result == null)
            {
                return null;
            }

            return result;
        }

        public async Task<List<UserValid>> GetByBuildingIdAsync(Guid id)
        {
            var result = await
                DbSet
                .Where(current => current.BuildingId == id)
                .ToListAsync()
                ;

            if (result == null)
            {
                return null;
            }

            return result;
        }

        public UserValid GetByMobileNo(string mobileNo)
        {
            if (string.IsNullOrWhiteSpace(mobileNo) == true)
            {
                return null;
            }

            var result =
                DbSet
                 .Where(current => current.ValidCellPhoneNumber == mobileNo)
                 .FirstOrDefault()
                ;

            return result;
        }

        public async Task<UserValid> GetByMobileNoAsync(string mobileNo)
        {
            if (string.IsNullOrWhiteSpace(mobileNo) == true)
            {
                return null;
            }

            var result = await
                DbSet
                .Where(current => current.ValidCellPhoneNumber == mobileNo)
                .FirstOrDefaultAsync()
                ;

            return result;
        }

        public UserValid GetByBuildingId_MobileNo(Guid buildingId, string mobileNo)
        {
            if (string.IsNullOrWhiteSpace(mobileNo) == true)
            {
                return null;
            }

            var result =
                DbSet
                 .Where(current => current.BuildingId == buildingId)
                 .Where(current => current.ValidCellPhoneNumber == mobileNo)
                 .FirstOrDefault()
                ;

            return result;
        }

        public async Task<UserValid> GetByBuildingId_MobileNoAsync(Guid buildingId, string mobileNo)
        {
            if (string.IsNullOrWhiteSpace(mobileNo) == true)
            {
                return null;
            }

            var result = await
                DbSet
                 .Where(current => current.BuildingId == buildingId)
                 .Where(current => current.ValidCellPhoneNumber == mobileNo)
                 .FirstOrDefaultAsync()
                ;

            return result;
        }

        public async Task<bool> DeleteByBuildingId_MobileNoAsync(Guid buildingId, string mobileNo)
        {
            Models.UserValid entity =
                await GetByBuildingId_MobileNoAsync(buildingId: buildingId, mobileNo: mobileNo);

            if (entity == null)
            {
                return false;
            }

            await DeleteAsync(entity);

            return true;
        }
    }
}

