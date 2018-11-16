using Camisetas.Models.BaseEntity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Camisetas.Models
{
    public class Size : Base
    {
        [Required(ErrorMessage = "Please, insert a size")]
        [DisplayAttribute(Name = "Size")]
        [RegularExpression(@"^[A-Z]{1,3}$",ErrorMessage = "Use only uppercase letters."
            + " Max.length: 1 - 3 characters")]
        public override string Name {get;set;} = default;
    } // End of class Size.

} // End of namespace Camisetas.Models.