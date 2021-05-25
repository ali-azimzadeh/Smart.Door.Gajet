using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Log : Base.Entity
    {
        public Log() : base()
        {
        }

        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.Display(ResourceType =
            typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Id))]
        public System.Guid Id { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.MessageLog))]
        public string Message { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.MessageTemplateLog))]
        public string MessageTemplate { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.MaxLength
            (length: Constant.Length.LEVEL_LOG,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.LevelLog))]
        public string Level { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.TimeStamp))]
        public System.DateTime TimeStamp { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.MaxLength
            (length: Constant.Length.PERSIAN_DATE,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Date))]
        public string DateLog { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Exception))]
        public string Exception { get; set; }
        // **********


        // **********
        [System.ComponentModel.DataAnnotations.Required]

        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Properties))]
        public string Properties { get; set; }
        // **********



        //[StringLength(20)]
        //public string HostAddress { get; set; }

        //[StringLength(50)]
        //public string Username { get; set; }

        //[StringLength(200)]
        //public string Browser { get; set; }

        //[StringLength(100)]
        //public string Url { get; set; }
    }
}
