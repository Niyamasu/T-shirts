using System;
using System.Collections.Generic;
using Camisetas.Models;

namespace Camisetas.DAL
{
    public interface IClothingRepository
    {
        // Indexer
        Clothing this[Guid guid] {get;}

        // Properties
        IEnumerable <Clothing> Clothings {get;}

        // Methods
        void SaveClothing(Clothing clothing);
        Clothing DeleteClothing(Guid guid);
    } // End of interface IClothingRepository.

} // End of namespace Camisetas.DAL