using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RoleInPermission : Base.Entity
    {
        public RoleInPermission() : base()
        {
        }

        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.Display(ResourceType =
            typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.RoleId))]
        public System.Guid RoleId { get; set; }
        // **********


        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.Display(ResourceType =
            typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.MenuId))]
        public byte MenuId { get; set; }
        // **********
    }
}
