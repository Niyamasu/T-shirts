using System;
using System.ComponentModel.DataAnnotations;

namespace Camisetas.Models.BaseEntity
{
    public interface IBase
    {
        Guid Id {get;set;}

        string Name {get;set;}
    } // End of interface IBase.

    public abstract class Base : IBase
    {
        [Key]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "An Id is Required")]
        public virtual Guid Id {get;set;} = default;
        public virtual string Name {get;set;}
    } // End of class Base.

} // End of namespace Camisetas.Models.BaseEntity.