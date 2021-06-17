using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Door.Gajet.Client.Data
{
    public class LoginResponse : Models.User
    {
        public LoginResponse() : base()
        {
        }

        public string Token { get; set; }
    }
}
