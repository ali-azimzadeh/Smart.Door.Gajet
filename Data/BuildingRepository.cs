using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BuildingRepository : Repository<Models.Building>, IBuildingRepository
    {
        internal BuildingRepository(DatabaseContext databaseContext)
            : base(databaseContext: databaseContext)
        {
        }
    }
}
