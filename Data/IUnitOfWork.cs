using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IUnitOfWork : Base.IUnitOfWork
    {
        // **********
        IBuildingRepository BuildingRepository { get; }
        // **********

        // **********
        IUserValidRepository UserValidRepository { get; }
        // **********

        // **********
        IUserRepository UserRepository { get; }
        // **********

        // **********
        IDeviceRepository DeviceRepository { get; }
        // **********

        // **********
        IRoleRepository RoleRepository { get; }
        // **********

        // **********
        IRolleInPermissionRepository RoleInPermissionRepository { get; }
        // **********

        // **********
        ILoginLogRepository LoginLogRepository { get; }
        // **********

        // **********
        ILogRepository LogRepository { get; }
        // **********

        // **********
        IUserPasswordHistoryRepository UserPasswordHistoryRepository { get; }
        // **********
    }
}
