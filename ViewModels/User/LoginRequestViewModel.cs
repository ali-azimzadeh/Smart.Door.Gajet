using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.User
{
    public class LoginRequestViewModel : object
    {
        public LoginRequestViewModel() : base()
        {
        }

        [System.ComponentModel.DataAnnotations.Required
            (AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [System.ComponentModel.DataAnnotations.Required
           (AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}
