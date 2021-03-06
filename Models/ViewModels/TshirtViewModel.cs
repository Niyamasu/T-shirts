using System;
using System.ComponentModel.DataAnnotations;
using Camisetas.Models;

namespace Camisetas.Models.ViewModels
{
    public class TshirtViewModel :  ITshirt
    {
        // Properties
        [Key]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "An Id is Required")]
        public Guid Id {get;set;} = default;

        [Required(ErrorMessage = "Please, insert a name")]
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z0-9/\s-]{1,50}$", 
            ErrorMessage = "Use only lowercase and uppercase letters, "
            +"numbers, white spaces and the following tokens: / and -."
            +" Max.length: 1 - 50 characters")]
        public string Name {get;set;}

        [Required(ErrorMessage = "Please, insert a valid price")]
        [DisplayAttribute(Name = "Price")]
        [RegularExpression(@"^[0-9]{1,12}(,|.)[0-9]{1,2}$",
            ErrorMessage = "A positive number in the following pattern: 000000000000,00")]
        public decimal Price {get;set;}

        [Required(ErrorMessage = "Please, insert a size")]
        [DisplayAttribute(Name = "Size")]
        // [RegularExpression(@"^[A-Z]{1,3}$",ErrorMessage = "Use only uppercase letters."
        //     + " Max.length: 1 - 3 characters")]
        public Guid Size {get;set;}

        [Required(ErrorMessage = "Please, insert a color")]
        [DisplayAttribute(Name = "Color")]
        // [RegularExpression(@"^[A-Za-z]{1,20}$",
        //     ErrorMessage = "Use only uppercase and lowercase letters."
        //     + " Max.length: 1 - 20 characters")]
        public Guid Color {get;set;}

        [Required(ErrorMessage = "Please, insert a type")]
        [DisplayAttribute(Name = "Type")]
        // [RegularExpression(@"^[A-Za-z]{1,20}$",
        //     ErrorMessage = "Use only uppercase and lowercase letters."
        //     + " Max.length: 1 - 20 characters")]
        public Guid Type {get;set;} // Ex.: Social, Polo, Pullovers 

        [Required(ErrorMessage = "Please, insert a clothing")]
        [DisplayAttribute(Name = "Clothing")]
        // [RegularExpression(@"^[A-Za-z]{1,20}$",
        //     ErrorMessage = "Use only uppercase and lowercase letters."
        //     + " Max.length: 1 - 20 characters")]

        public Guid Clothing {get;set;}

        [DisplayAttribute(Name = "Width")]
        [RegularExpression("^[0-9]{0,3}(,|.)[0-9]{0,2}$",
            ErrorMessage = "Insert numbers as the following pattern: 000,00")]
        public double Width {get;set;}

        [DisplayAttribute(Name = "Height")]
        [RegularExpression("^[0-9]{0,3}(,|.)[0-9]{0,2}$",
            ErrorMessage = "Insert numbers as the following pattern: 000,00")]
        public double Height {get;set;}

    } // End of class TshirtPropertyViewModel.

} // End of namespace Camisetas.Models.ViewModels.