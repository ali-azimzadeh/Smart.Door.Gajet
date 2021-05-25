using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.ApplicationSettings
{
    public class Main : object
    {
        public Main() : base()
        {
        }

        public string SignKey { get; set; }

        public int TokenExpiresInMinutes { get; set; }
    }
}
