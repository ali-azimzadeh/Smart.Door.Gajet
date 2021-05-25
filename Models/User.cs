using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User : Base.Entity
    {
        public User() : base()
        {
        }

        // **********
        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Type))]
        public Enums.UserType Type { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.FullName))]

        [System.ComponentModel.DataAnnotations.MaxLength
            (length: Constant.Length.FULL_NAME,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public string FullName { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Username))]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessageResourceType = typeof(Resources.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]

		[System.ComponentModel.DataAnnotations.MaxLength
			(length: Constant.Length.USERNAME,
			ErrorMessageResourceType = typeof(Resources.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
		public string Username { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Password))]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessageResourceType = typeof(Resources.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]

		[System.ComponentModel.DataAnnotations.MaxLength
			(length: Constant.Length.PASSWORD,
			ErrorMessageResourceType = typeof(Resources.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]

		//دستور زیر باعث می شود که هنگام ارسال مدل  یوزر به سمت کلاینت پسورد را بی خیال شود و ارسال نکند
		[System.Text.Json.Serialization.JsonIgnore]
		public string Password { get; set; }
		// **********


		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.UserImage))]

		public byte[] UserImage { get; set; }
		// **********


		// **********
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
		public string CellPhoneNumber { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.RegisterIP))]

		[System.ComponentModel.DataAnnotations.MaxLength
			(length: Constant.Length.IP,
			ErrorMessageResourceType = typeof(Resources.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
		public string RegisterIP { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.GroupId))]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessageResourceType = typeof(Resources.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]

		public byte GroupId { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.RoleId))]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessageResourceType = typeof(Resources.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]

		public int RoleId { get; set; }
		// **********

		//public System.Collections.Generic.IList<LoginLog> LoginLogs { get; set; }
		// **********




		//// **********
		//[System.ComponentModel.DataAnnotations.Display
		//	(ResourceType = typeof(Resources.DataDictionary),
		//	Name = nameof(Resources.DataDictionary.NationalCode))]

		//[System.ComponentModel.DataAnnotations.MaxLength
		//	(length: Constant.Length.NATIONAL_CODE,
		//	ErrorMessageResourceType = typeof(Resources.ErrorMessages),
		//	ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
		//public string NationalCode { get; set; }
		//// **********
		///

		//// **********
		//[System.ComponentModel.DataAnnotations.Display
		//	(ResourceType = typeof(Resources.DataDictionary),
		//	Name = nameof(Resources.DataDictionary.EmailAddress))]

		//[System.ComponentModel.DataAnnotations.MaxLength
		//	(length: Constant.Length.EMAIL_ADDRESS,
		//	ErrorMessageResourceType = typeof(Resources.ErrorMessages),
		//	ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
		//public string EmailAddress { get; set; }
		//// **********
	}
}
