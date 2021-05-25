using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserValid : Base.Entity
    {
        public UserValid() : base()
        {
        }

        // **********
                   
        [System.ComponentModel.DataAnnotations.Display(ResourceType = 
            typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.BuildingId))]
        public System.Guid BuildingId { get; set; }
        // **********

        // **********
   
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.UnitNo))]

        [System.ComponentModel.DataAnnotations.MaxLength
            (length: Constant.Length.UNIT_NO,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]

        public string UnitNo { get; set; }
        // **********

        // **********
 
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.CellPhoneNumber))]

        [System.ComponentModel.DataAnnotations.MinLength
            (length: Constant.Length.MIN_CELL_PHONE_NUMBER,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MinLength))]

        [System.ComponentModel.DataAnnotations.MaxLength
            (length: Constant.Length.MAX_CELL_PHONE_NUMBER,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public string ValidCellPhoneNumber { get; set; }
        // **********

        // **********
       
        [System.ComponentModel.DataAnnotations.Display(ResourceType =
            typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.UserId))]
        public System.Guid UserId { get; set; }
        // **********
    }
}
