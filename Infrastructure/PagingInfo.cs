using System.Collections.Generic;
using System;

namespace Camisetas.Infrastructure
{
    public class PagingInfo
    {
        public int ItemsPerPage {get;set;} = default;

        public int TotalItems {get;set;} = default;

        // public int QtdPages => 
        // (int) System.Math.Ceiling((decimal)(TotalItems/ItemsPerPage));
        public int QtdPages 
        {
            get
            {
                int qtdPages = (int) System.Math.Ceiling((decimal)(TotalItems/ItemsPerPage));
                // if(TotalItems % 2 != 0){ ++qtdPages; }
                // int skpdItems = ( (CurrentPage - 1) * ItemsPerPage );
                // int totalItems = skpdItems + ItemsPerPage;

                // int pages = TotalItems / ItemsPerPage;
                // if( ( TotalItems / ItemsPerPage ) != 0 ) { qtdPages += 1; }
                // if( ( TotalItems % ItemsPerPage ) != 0 ) { qtdPages += 1; }
                // if(ItemsPerPage != 1)
                // {
                //     if ( ( TotalItems % ItemsPerPage ) != 0 ) { qtdPages += 1; }
                // }
                if ( ( TotalItems % ItemsPerPage ) != 0 ) { ++qtdPages; }
                return qtdPages;
            }
        } // End of prop QtdPages.

        public int CurrentPage {get;set;} = 1;

    } // End of class class ItemsPerPageViewModel.

} // End of namespace Camisetas.Models.ViewModels.
