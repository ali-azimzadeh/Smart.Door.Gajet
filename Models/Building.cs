using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Building : Base.Entity
    {
        public Building() : base()
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
            Name = nameof(Resources.DataDictionary.BuildingName))]
        public string BuildingName { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.MaxLength
            (length: Constant.Length.GENERAL_NAME,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.ManagerFullName))]
        public string ManagerFullName { get; set; }
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
        public string ManagerCellPhoneNumber { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.FloorsCount))]

          public byte FloorsCount { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.UnitsCount))]

        public byte UnitsCount { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.ManagerUnitNo))]

        [System.ComponentModel.DataAnnotations.MaxLength
            (length: Constant.Length.UNIT_NO,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]

        public string ManagerUnitNo { get; set; }
        // **********
    }
}
