using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.User
{
    public class LoginResponseViewModel : object
    {
        public LoginResponseViewModel(Models.User user, string token)
        {
            if (user == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(user));
            }
            if (string.IsNullOrWhiteSpace(token) == true)
            {
                throw new System.ArgumentNullException(paramName: nameof(token));
            }

            Token = token;

            Id = user.Id;
            FullName = user.FullName;
            UserName = user.Username;
            IsActive = user.IsActive;
        }

        public Guid Id { get; set; }

        public string Token { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public bool IsActive { get; set; }
    }
}
