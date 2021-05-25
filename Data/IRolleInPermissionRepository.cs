using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRolleInPermissionRepository : Base.IRepository<Models.RoleInPermission>
    {
        List<Models.RoleInPermission> GetByRoleId(Guid id);

        Task<List<Models.RoleInPermission>> GetByRoleIdAsync(Guid id);

        Models.RoleInPermission GetByRoleId_MenuId(Guid roleId, byte menuId);

        Task<Models.RoleInPermission> GetByRoleId_MenuIdAsync(Guid roleId, byte menuId);
    }
}
