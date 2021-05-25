using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Base
{
    public abstract class Entity : object
    {
        public Entity():base()
        {
            Id = System.Guid.NewGuid();
        }

        // **********
        //[System.ComponentModel.DataAnnotations.Key]

        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
            (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]

        [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Id))]
        public System.Guid Id { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.InsertDateTime))]
        public System.DateTime InsertDateTime { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.InsertByUser))]
        public System.Guid InsertByUser { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.UpdateDateTime))]
        public Nullable<System.DateTime> UpdateDateTime { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.UpdateByUser))]
        public Nullable<System.Guid> UpdateByUser { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.DeleteDateTime))]
        public Nullable<System.DateTime> DeleteDateTime { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.DeleteByUser))]
        public Nullable<System.Guid> DeleteByUser { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.IsDeleted))]
        public bool IsDeleted { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.IsActive))]
        public bool IsActive { get; set; }
        // **********
    }
}
