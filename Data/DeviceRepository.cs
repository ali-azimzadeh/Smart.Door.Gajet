using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DeviceRepository : Repository<Models.Device>, IDeviceRepository
    {
        internal DeviceRepository(DatabaseContext databaseContext)
            : base(databaseContext: databaseContext)
        {
        }

        public Device GetByBuildingId(Guid id)
        {
            var result =
                DbSet
                .Where(current => current.BuildingId == id)
                .FirstOrDefault()
                ;

            return result;
        }

        public async Task<Device> GetByBuildingIdAsync(Guid id)
        {
            var result = await
                DbSet
                .Where(current => current.BuildingId == id)
                .FirstOrDefaultAsync()
                ;

            return result;
        }

        public Device GetBySerialNo(string serialNo)
        {
            if (string.IsNullOrWhiteSpace(serialNo) == true)
            {
                return null;
            }

            var result =
                DbSet
                .Where(current => current.SerialNo == serialNo)
                .FirstOrDefault()
                ;

            return result;

        }

        public async Task<Device> GetBySerialNoAsync(string serialNo)
        {
            if (string.IsNullOrWhiteSpace(serialNo) == true)
            {
                return null;
            }

            var result = await
                DbSet
                .Where(current => current.SerialNo == serialNo)
                .FirstOrDefaultAsync()
                ;

            return result;
        }

        public Device GetBySimcardNo(string simcardNo)
        {
            if (string.IsNullOrWhiteSpace(simcardNo) == true)
            {
                return null;
            }

            var result =
                DbSet
                .Where(current => current.SimcardNo == simcardNo)
                .FirstOrDefault()
                ;

            return result;

        }

        public async Task<Device> GetBySimcardNoAsync(string simcardNo)
        {
            if (string.IsNullOrWhiteSpace(simcardNo) == true)
            {
                return null;
            }

            var result = await
                DbSet
                .Where(current => current.SimcardNo == simcardNo)
                .FirstOrDefaultAsync()
                ;

            return result;
        }

        public List<Device> GetActive()
        {
            var result =
                DbSet
                .Where(current => current.IsActive == true)
                .ToList()
                ;

            return result;
        }

        public async Task<List<Device>> GetActiveAsync()
        {
            var result = await
                DbSet
                .Where(current => current.IsActive == true)
                .ToListAsync()
                ;

            return result;
        }
    }
}
