using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IUserValidRepository : Base.IRepository<Models.UserValid>
    {
        List<Models.UserValid> GetByBuildingId(System.Guid id);

        Task<List<Models.UserValid>> GetByBuildingIdAsync(System.Guid id);

        Models.UserValid GetByMobileNo(string mobileNo);

        Task<Models.UserValid> GetByMobileNoAsync(string mobileNo);

        Models.UserValid GetByBuildingId_MobileNo(Guid buildingId, string mobileNo);

        Task<Models.UserValid> GetByBuildingId_MobileNoAsync(Guid buildingId, string mobileNo);

        Task<bool> DeleteByBuildingId_MobileNoAsync(Guid buildingId, string mobileno);
    }
}
