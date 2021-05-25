using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RoleRepository : Repository<Models.Role>, IRoleRepository
    {
        internal RoleRepository(DatabaseContext databaseContext)
            : base(databaseContext: databaseContext)
        {
        }

    }
}
