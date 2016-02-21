namespace EstateSocialSystem.Data.Models
{
    using Common.Models;
    using System.ComponentModel.DataAnnotations;
    using System;

    public class Setting : AuditInfo, IDeletableEntity
    {
        [Key]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Value { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
