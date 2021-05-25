using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IDeviceRepository : Base.IRepository<Models.Device>
    {
        Models.Device GetByBuildingId(Guid id);

        Task<Models.Device> GetByBuildingIdAsync(Guid id);

        Models.Device GetBySerialNo(string serialNo);

        Task<Models.Device> GetBySerialNoAsync(string serialNo);

        Models.Device GetBySimcardNo(string simcardNo);

        Task<Models.Device> GetBySimcardNoAsync(string simcardNo);

        List<Models.Device> GetActive();

        System.Threading.Tasks.Task<List<Models.Device>> GetActiveAsync();
    }
}
