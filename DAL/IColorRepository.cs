using System;
using System.Collections.Generic;
using Camisetas.Models;

namespace Camisetas.DAL
{
    public interface IColorRepository
    {
        // Indexer
        Color this[Guid guid] {get;}

        // Properties
        IEnumerable <Color> Colors {get;}

        // Methods
        void SaveColor(Color color);
        Color DeleteColor(Guid guid);
    } // End of interface IColorRepository.

} // End of namespace Camisetas.DAL.