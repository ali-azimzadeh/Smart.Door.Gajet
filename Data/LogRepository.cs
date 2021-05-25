using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class LogRepository : Repository<Models.Log>, ILogRepository
    {
        internal LogRepository(DatabaseContext databaseContext)
            : base(databaseContext: databaseContext)
        {
        }
    }
}
