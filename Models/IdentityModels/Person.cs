using Microsoft.AspNetCore.Identity;
using System;

namespace Camisetas.Models.IdentityModels
{
    public class Person : IdentityUser
    {
        public string LastName {get;set;}  

        public Gender Gender {get;set;}

        public string Cpf {get;set;}

        public string Rg {get;set;}

        public string Address {get;set;}

        public string Cep {get;set;}

        public string City {get;set;}

        public string Estate {get;set;}

        public string Country {get;set;}

        public DateTime Bithdate {get;set;}

    } // End of class Person

    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    } // End of enum Gender.

} // End of namespace Camisetas.Models.IdentityModels.