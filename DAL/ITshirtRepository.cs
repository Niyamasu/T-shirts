using System;
using System.Collections.Generic;
using Camisetas.Models.ViewModels;
using Camisetas.Models;
using Camisetas;

namespace Camisetas.DAL
{
    public interface ITshirtRepository
    {
        // Indexer
        Tshirt this[Guid id] {get;}

        // Properties
        IEnumerable<Tshirt> Tshirts {get;}

        // Methods

        void SaveTshirt(Tshirt tshirt);

        Tshirt DeleteTshirt(Guid tshirtGuid);
        
    } // End of interface ITshirtRepository.

} // End of namespace Camisetas.DAL. 