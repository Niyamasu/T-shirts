using Camisetas.Models.BaseEntity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Camisetas.Models
{
    public interface IColor{}
    public class Color : Base, IColor
    {

        [Required(ErrorMessage = "Please, insert a color")]
        [DisplayAttribute(Name = "Color")]
        [RegularExpression(@"^[A-Za-z]{1,20}$",
            ErrorMessage = "Use only uppercase and lowercase letters."
            + " Max.length: 1 - 20 characters")]
        public override string Name {get;set;}
        
    } // End of class Color.

} // End of namespace Camisetas.Models.