using System;
using System.Collections.Generic;
using Camisetas.Models;

namespace Camisetas.DAL
{
    public interface ISizeRepository
    {
        // Indexer
        Size this[Guid guid] {get;}

        // Properties
        IEnumerable<Size> Sizes {get;}

        // Methods
        void SaveSize(Size size);
        Size DeleteSize(Guid guid);
    } // End of interface ISizeRepository.

} // End of namespace Camisetas.DAL.