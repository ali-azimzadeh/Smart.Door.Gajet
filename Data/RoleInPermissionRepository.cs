using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RoleInPermissionRepository : Repository<Models.RoleInPermission>, IRolleInPermissionRepository
    {
        internal RoleInPermissionRepository(DatabaseContext databaseContext)
            : base(databaseContext: databaseContext)
        {
        }

        public List<RoleInPermission> GetByRoleId(Guid id)
        {
            var result =
                DbSet
                .Where(current => current.RoleId == id)
                .ToList()
                ;

            return result;
        }

        public async Task<List<RoleInPermission>> GetByRoleIdAsync(Guid id)
        {
            var result = await
                        DbSet
                        .Where(current => current.RoleId == id)
                        .ToListAsync()
                        ;

            return result;
        }

        public RoleInPermission GetByRoleId_MenuId(Guid roleId, byte menuId)
        {
            var result =
                DbSet
                .Where(current => current.RoleId == roleId && current.MenuId == menuId)
                .FirstOrDefault()
                ;

            return result;
        }

        public async Task<RoleInPermission> GetByRoleId_MenuIdAsync(Guid roleId, byte menuId)
        {
            var result = await
                DbSet
                .Where(current => current.RoleId == roleId && current.MenuId == menuId)
                .FirstOrDefaultAsync()
                ;

            return result;
        }
    }
}
