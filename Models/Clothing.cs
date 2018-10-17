using Camisetas.Models.BaseEntity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Camisetas.Models
{
    public class Clothing : Base
    {
        [Required(ErrorMessage = "Please, insert a clothing")]
        [DisplayAttribute(Name = "Clothing")]
        [RegularExpression(@"^[A-Za-z]{1,20}$",
            ErrorMessage = "Use only uppercase and lowercase letters."
            + " Max.length: 1 - 20 characters")]
        public override string Name {get;set;}
    } // End of class Clothing.

} // End of namespace Camisetas.Models.