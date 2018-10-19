using System.Collections.Generic;
using Camisetas.Infrastructure;

namespace Camisetas.Models.ViewModels
{
    public class GenericListViewModel <T>
    {
        public PagingInfo PagingInfo {get;set;}

        public IEnumerable <T> CollectionToSend {get;set;}

    } // End of class TshirtsViewModel.
} // End of namespace Camisetas.Models.ViewModels.