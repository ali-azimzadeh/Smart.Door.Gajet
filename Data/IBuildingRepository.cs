using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IBuildingRepository : Base.IRepository<Models.Building>
    {
        //Models.Building GetByBuildingId(System.Guid id);

        //System.Threading.Tasks.Task<Models.Building> GetByBuildingIdAsync(System.Guid id);


    }
}
