// using Camisetas.Models;

// namespace Camisetas.Models.ViewModels
// {
//     public class TshirtPropertyViewModel
//     {
//         public Color Color {get;set;} = default;
        
//         public Size Size {get;set;} = default;

//         public Type Type {get;set;} = default;

//         public Clothing Clothing {get;set;} = default;
//     } // End of class TshirtPropertyViewModel.

// } // End of namespace Camisetas.Models.ViewModels.

using System;
using System.ComponentModel.DataAnnotations;
using Camisetas.Models;

namespace Camisetas.Models.ViewModels
{
    public class TshirtPropertyViewModel
    {
        // Properties

        public Color Color
        {
            get{
                Color color = new Color();
                color.Id = ColorId;
                color.Name = ColorName;
                return color;
            }
            set{
                ColorId = value.Id;
                ColorName = value.Name;
            }
        }

        [Key]
        [Display(Name = "Id")]
        //[Required(ErrorMessage = "An Id is Required")]
        public Guid ColorId {get;set;} = default;

        //[Required(ErrorMessage = "Please, insert a color")]
        [DisplayAttribute(Name = "Color")]
        [RegularExpression(@"^[A-Za-z]{1,20}$",
            ErrorMessage = "Use only uppercase and lowercase letters."
            + " Max.length: 1 - 20 characters")]
        public string ColorName {get;set;}

        // [Key]
        // [Display(Name = "Id")]
        // //[Required(ErrorMessage = "An Id is Required")]
        // public Guid SizeId {get;set;} = default;

        // //[Required(ErrorMessage = "Please, insert a size")]
        // [DisplayAttribute(Name = "Size")]
        // [RegularExpression(@"^[A-Z]{1,3}$",ErrorMessage = "Use only uppercase letters."
        //     + " Max.length: 1 - 3 characters")]
        // public string SizeName {get;set;}

        // [Key]
        // [Display(Name = "Id")]
        // //[Required(ErrorMessage = "An Id is Required")]
        // public Guid TypeId {get;set;} = default;

        // //[Required(ErrorMessage = "Please, insert a type")]
        // [DisplayAttribute(Name = "Type")]
        // [RegularExpression(@"^[A-Za-z]{1,20}$",
        //     ErrorMessage = "Use only uppercase and lowercase letters."
        //     + " Max.length: 1 - 20 characters")]
        // public string TypeName {get;set;}

        // [Key]
        // [Display(Name = "Id")]
        // //[Required(ErrorMessage = "An Id is Required")]
        // public Guid ClothingId {get;set;} = default;


        // //[Required(ErrorMessage = "Please, insert a clothing")]
        // [DisplayAttribute(Name = "Clothing")]
        // [RegularExpression(@"^[A-Za-z]{1,20}$",
        //     ErrorMessage = "Use only uppercase and lowercase letters."
        //     + " Max.length: 1 - 20 characters")]
        // public string ClothingName {get;set;}
    } // End of class TshirtPropertyViewModel.

} // End of namespace Camisetas.Models.ViewModels.