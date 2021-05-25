using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Device : Base.Entity
    {
        public Device() : base()
        {
        }

        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.Display(ResourceType =
            typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.BuildingId))]
        public System.Guid BuildingId { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.MaxLength
            (length: Constant.Length.SERIAL_NO,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.SerialNo))]
        public string SerialNo { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.SimcardNo))]
             
        [System.ComponentModel.DataAnnotations.MaxLength
            (length: Constant.Length.MAX_CELL_PHONE_NUMBER,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public string SimcardNo { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.DeviceModel))]

        [System.ComponentModel.DataAnnotations.MaxLength
            (length: Constant.Length.DEVICE_MODEL,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public string DeviceModel { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Frequency))]

        public short Frequency { get; set; }
        // **********
    }
}
