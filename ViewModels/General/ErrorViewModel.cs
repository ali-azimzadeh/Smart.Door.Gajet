using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.General
{
    public class ErrorViewModel : object
    {
        public ErrorViewModel(string message) : base()
        {
            if (string.IsNullOrWhiteSpace(message) == true)
            {
                throw new System.ArgumentNullException(paramName: message);
            }

            Message = message;
        }

        public string Message { get; set; }
    }
}
