using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : Base.UnitOfWork, IUnitOfWork
    {
        public UnitOfWork(Tools.Options options)
            : base(options: options)
        {
        }

        // **************************************************
        private IUserRepository _userRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository =
                        new UserRepository(DatabaseContext);
                }

                return _userRepository;
            }
        }
        // **************************************************

        // **************************************************
        private IBuildingRepository _buildingRepository;

        public IBuildingRepository BuildingRepository
        {
            get
            {
                if (_buildingRepository == null)
                {
                    _buildingRepository =
                        new BuildingRepository(DatabaseContext);
                }

                return _buildingRepository;
            }
        }
        // **************************************************

        // **************************************************
        private IUserValidRepository _userValidRepository;

        public IUserValidRepository UserValidRepository
        {
            get
            {
                if (_userValidRepository == null)
                {
                    _userValidRepository =
                        new UserValidRepository(DatabaseContext);
                }

                return _userValidRepository;
            }
        }
        // **************************************************

        // **************************************************
        private IDeviceRepository _deviceRepository;

        public IDeviceRepository DeviceRepository
        {
            get
            {
                if (_deviceRepository == null)
                {
                    _deviceRepository =
                        new DeviceRepository(DatabaseContext);
                }

                return _deviceRepository;
            }
        }
        // **************************************************

        // **************************************************
        private IRoleRepository _roleRepository;

        public IRoleRepository RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository =
                        new RoleRepository(DatabaseContext);
                }

                return _roleRepository;
            }
        }
        // **************************************************

        // **************************************************
        private IRolleInPermissionRepository _roleInPermissionRepository;

        public IRolleInPermissionRepository RoleInPermissionRepository
        {
            get
            {
                if (_roleInPermissionRepository == null)
                {
                    _roleInPermissionRepository =
                        new RoleInPermissionRepository(DatabaseContext);
                }

                return _roleInPermissionRepository;
            }
        }
        // **************************************************

        // **************************************************
        private ILogRepository _logRepository;

        public ILogRepository LogRepository
        {
            get
            {
                if (_logRepository == null)
                {
                    _logRepository =
                        new LogRepository(DatabaseContext);
                }

                return _logRepository;
            }
        }
        // **************************************************

        // **************************************************
        private ILoginLogRepository _loginLogRepository;

        public ILoginLogRepository LoginLogRepository
        {
            get
            {
                if (_loginLogRepository == null)
                {
                    _loginLogRepository =
                        new LoginLogRepository(DatabaseContext);
                }

                return _loginLogRepository;
            }
        }
        // *************************************************

        // **************************************************
        private IUserPasswordHistoryRepository _userPasswordHistoryRepository;

        public IUserPasswordHistoryRepository UserPasswordHistoryRepository
        {
            get
            {
                if (_userPasswordHistoryRepository == null)
                {
                    _userPasswordHistoryRepository =
                        new UserPasswordHistoryRepository(DatabaseContext);
                }

                return _userPasswordHistoryRepository;
            }
        }


        // **************************************************

        // **************************************************
        //private IXXXXXRepository _xXXXXRepository;

        //public IXXXXXRepository XXXXXRepository
        //{
        //	get
        //	{
        //		if (_xXXXXRepository == null)
        //		{
        //			_xXXXXRepository =
        //				new XXXXXRepository(DatabaseContext);
        //		}

        //		return _xXXXXRepository;
        //	}
        //}
        // **************************************************

    }
}
