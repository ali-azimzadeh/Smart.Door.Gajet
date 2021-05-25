using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.User;

namespace Services
{
    public class UserService : object, IUserService
    {
        public UserService(Microsoft.Extensions.Options.IOptions<Infrastructure.ApplicationSettings.Main> options, Data.IUnitOfWork unitOfWork)
            : base()
        {
            MainSettings = options.Value;
            UnitOfWork = unitOfWork;
        }

        protected Infrastructure.ApplicationSettings.Main MainSettings { get; }

        private Data.IUnitOfWork UnitOfWork { get; }


        /// <summary>
        /// Generate Mock Data! For Testing Without Database
        /// </summary>
        //private List<Models.User> _users = null;

        //public List<Models.User> Users
        //{
        //    get
        //    {
        //        if (_users == null)
        //        {
        //            _users = new List<User>();
        //            for (int index = 1; index < 5; index++)
        //            {
        //                Models.User user = new User
        //                {
        //                    Id = Guid.NewGuid(),
        //                    Password = "123456789",
        //                    Username = $"UserName{index}",
        //                    FullName = $"FullName{index}",

        //                };
        //                _users.Add(user);
        //            }
        //        }
        //        return _users;
        //    }
        //}


        public async Task<LoginResponseViewModel> LoginAsync(LoginRequestViewModel loginRequestViewModel)
        {
            if (loginRequestViewModel == null)
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(loginRequestViewModel.UserName) == true)
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(loginRequestViewModel.Password) == true)
            {
                return null;
            }

            Models.User foundedUser = await
                UnitOfWork.UserRepository.GetByUserNameAsync(username: loginRequestViewModel.UserName);

            //Models.User foundedUser =
            //         Users.Where(current => current.Username.ToLower() == loginRequestViewModel.UserName.ToLower())
            //         .FirstOrDefault()
            //         ;

            if (foundedUser == null)
            {
                return null;
            }

            string strHashOfPassword = 
                Azx.Security.Hash.GetSha1(loginRequestViewModel.Password);

            if (string.Compare(foundedUser.Password, strHashOfPassword, ignoreCase: false) != 0)
            {
                return null;
            }

            string token =
                Infrastructure.JwtUtility.GenerateJwtToken(user: foundedUser, mainSettings: MainSettings);

            ViewModels.User.LoginResponseViewModel loginResponse =
                new LoginResponseViewModel(user: foundedUser, token: token);

            return loginResponse;

        }

        public LoginResponseViewModel Login(LoginRequestViewModel loginRequestViewModel)
        {
            if (loginRequestViewModel == null)
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(loginRequestViewModel.UserName) == true)
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(loginRequestViewModel.Password) == true)
            {
                return null;
            }

            Models.User foundedUser =
                UnitOfWork.UserRepository.GetByUserName(username: loginRequestViewModel.UserName);

            //Models.User foundedUser =
            //         Users.Where(current => current.Username.ToLower() == loginRequestViewModel.UserName.ToLower())
            //         .FirstOrDefault()
            //         ;

            if (foundedUser == null)
            {
                return null;
            }

            string strHashOfPassword =
                Azx.Security.Hash.GetSha1(loginRequestViewModel.Password);

            if (string.Compare(foundedUser.Password, strHashOfPassword, ignoreCase: false) != 0)
            {
                return null;
            }

            string token =
                Infrastructure.JwtUtility.GenerateJwtToken(user: foundedUser, mainSettings: MainSettings);

            ViewModels.User.LoginResponseViewModel loginResponse =
                new LoginResponseViewModel(user: foundedUser, token: token);

            return loginResponse;

        }

        public IEnumerable<User> GetAll()
        {
            //**************************
            //when use Mock data
            //**************************

            //  return Users;

            //**************************
            //when use database
            //**************************
            IList<Models.User> foundedUsers =
                UnitOfWork.UserRepository.GetAll();

            return foundedUsers;
        }

        public User GetById(Guid id)
        {
            //**************************
            //when use Mock data
            //**************************
            //Models.User foundedUser =
            //    Users.Where(current => current.Id == id)
            //    .FirstOrDefault()
            //    ;

            //return foundedUser;



            //**************************
            //when use database
            //**************************
            Models.User foundedUser =
                UnitOfWork.UserRepository.GetById(id: id);

            return foundedUser;
        }
        public async Task<User> GetByIdAsync(Guid id)
        {
            //**************************
            //when use database
            //**************************
            Models.User foundedUser = await
                UnitOfWork.UserRepository.GetByIdAsync(id: id);

            return foundedUser;
        }



        public async Task<IEnumerable<User>> GetAllAsync()
        {
            IList<Models.User> foundedUsers = await
                UnitOfWork.UserRepository.GetAllAsync();

            return foundedUsers;
        }
    }
}
