using System;
using System.ComponentModel.DataAnnotations;
using Camisetas.Models.BaseEntity;

namespace Camisetas.Models
{
    // Ex.: Social, Polo, Pullovers 
    public class Type : Base
    {
        [Required(ErrorMessage = "Please, insert a type")]
        [DisplayAttribute(Name = "Type")]
        [RegularExpression(@"^[A-Za-z]{1,20}$",
            ErrorMessage = "Use only uppercase and lowercase letters."
            + " Max.length: 1 - 20 characters")]
        public override string Name {get;set;} = default;
    } // End of class Type.

} // End of namespace Camisetas.Models.