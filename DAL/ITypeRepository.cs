using System;
using System.Collections.Generic;
using TypeT = Camisetas.Models.Type;

namespace Camisetas.DAL
{
    public interface ITypeRepository
    {
        // Indexer
        TypeT this[Guid guid] {get;}

        // Properties
        IEnumerable <TypeT> Types {get;}

        // Methods
        void SaveType(TypeT type);
        TypeT DeleteType(Guid guid);
    } // End of interface ITypeRepository.

} // End of namespace Camisetas.DAL.