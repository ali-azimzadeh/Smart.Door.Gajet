using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Role : Base.Entity
    {
        public Role() : base()
        {
        }

        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.MaxLength
            (length: Constant.Length.GENERAL_NAME,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.RoleName))]
        public string RoleName { get; set; }
        // **********
    }
}
