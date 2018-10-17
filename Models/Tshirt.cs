// using Camisetas.Models.BaseEntity;
// using System;
// using System.ComponentModel.DataAnnotations;

// namespace Camisetas.Models
// {
//     public interface ITshirt {}
//     public class Tshirt : Base
//     {

//         [Required(ErrorMessage = "Please, insert a name")]
//         [Display(Name = "Name")]
//         [RegularExpression(@"^[a-zA-Z0-9/\s-]{1,50}$", 
//             ErrorMessage = "Use only lowercase and uppercase letters, "
//             +"numbers, white spaces and the following tokens: / and -."
//             +" Max.length: 1 - 50 characters")]
//         public override string Name {get;set;}

//         [Required(ErrorMessage = "Please, insert a valid price")]
//         [DisplayAttribute(Name = "Price")]
//         [RegularExpression(@"^[0-9]{1,12}(,|.)[0-9]{1,2}$",
//             ErrorMessage = "A positive number in the following pattern: 000000000000,00")]
//         public decimal Price {get;set;}

//         [Required(ErrorMessage = "Please, insert a size")]
//         [DisplayAttribute(Name = "Size")]
//         [RegularExpression(@"^[A-Z]{1,3}$",ErrorMessage = "Use only uppercase letters."
//             + " Max.length: 1 - 3 characters")]
//         public string Size {get;set;}

//         [Required(ErrorMessage = "Please, insert a color")]
//         [DisplayAttribute(Name = "Color")]
//         [RegularExpression(@"^[A-Za-z]{1,20}$",
//             ErrorMessage = "Use only uppercase and lowercase letters."
//             + " Max.length: 1 - 20 characters")]
//         public string Color {get;set;}

//         [Required(ErrorMessage = "Please, insert a type")]
//         [DisplayAttribute(Name = "Type")]
//         [RegularExpression(@"^[A-Za-z]{1,20}$",
//             ErrorMessage = "Use only uppercase and lowercase letters."
//             + " Max.length: 1 - 20 characters")]
//         public string Type {get;set;} // Ex.: Social, Polo, Pullovers 

//         [Required(ErrorMessage = "Please, insert a clothing")]
//         [DisplayAttribute(Name = "Clothing")]
//         [RegularExpression(@"^[A-Za-z]{1,20}$",
//             ErrorMessage = "Use only uppercase and lowercase letters."
//             + " Max.length: 1 - 20 characters")]

//         public string Clothing {get;set;}

//         [DisplayAttribute(Name = "Width")]
//         [RegularExpression("^[0-9]{0,3}(,|.)[0-9]{0,2}$",
//             ErrorMessage = "Insert numbers as the following pattern: 000,00")]
//         public double Width {get;set;}

//         [DisplayAttribute(Name = "Height")]
//         [RegularExpression("^[0-9]{0,3}(,|.)[0-9]{0,2}$",
//             ErrorMessage = "Insert numbers as the following pattern: 000,00")]
//         public double Height {get;set;}

//     } // End of class Product.

// } // End of namespace Camisetas.Models.


using Camisetas.Models.BaseEntity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Camisetas.Models
{
    public class Tshirt : Base
    {

        [Required(ErrorMessage = "Please, insert a name")]
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z0-9/\s-]{1,50}$", 
            ErrorMessage = "Use only lowercase and uppercase letters, "
            +"numbers, white spaces and the following tokens: / and -."
            +" Max.length: 1 - 50 characters")]
        public override string Name {get;set;}

        [Required(ErrorMessage = "Please, insert a valid price")]
        [DisplayAttribute(Name = "Price")]
        [RegularExpression(@"^[0-9]{1,12}(,|.)[0-9]{1,2}$",
            ErrorMessage = "A positive number in the following pattern: 000000000000,00")]
        public decimal Price {get;set;}

        [Required(ErrorMessage = "Please, insert a size")]
        [DisplayAttribute(Name = "Size")]
        [RegularExpression(@"^[A-Z]{1,3}$",ErrorMessage = "Use only uppercase letters."
            + " Max.length: 1 - 3 characters")]
        public Size Size {get;set;}

        [Required(ErrorMessage = "Please, insert a color")]
        [DisplayAttribute(Name = "Color")]
        [RegularExpression(@"^[A-Za-z]{1,20}$",
            ErrorMessage = "Use only uppercase and lowercase letters."
            + " Max.length: 1 - 20 characters")]
        public Color Color {get;set;}

        [Required(ErrorMessage = "Please, insert a type")]
        [DisplayAttribute(Name = "Type")]
        [RegularExpression(@"^[A-Za-z]{1,20}$",
            ErrorMessage = "Use only uppercase and lowercase letters."
            + " Max.length: 1 - 20 characters")]
        public Type Type {get;set;} // Ex.: Social, Polo, Pullovers 

        [Required(ErrorMessage = "Please, insert a clothing")]
        [DisplayAttribute(Name = "Clothing")]
        [RegularExpression(@"^[A-Za-z]{1,20}$",
            ErrorMessage = "Use only uppercase and lowercase letters."
            + " Max.length: 1 - 20 characters")]

        public Clothing Clothing {get;set;}

        [DisplayAttribute(Name = "Width")]
        [RegularExpression("^[0-9]{0,3}(,|.)[0-9]{0,2}$",
            ErrorMessage = "Insert numbers as the following pattern: 000,00")]
        public double Width {get;set;}

        [DisplayAttribute(Name = "Height")]
        [RegularExpression("^[0-9]{0,3}(,|.)[0-9]{0,2}$",
            ErrorMessage = "Insert numbers as the following pattern: 000,00")]
        public double Height {get;set;}

    } // End of class Product.

} // End of namespace Camisetas.Models.