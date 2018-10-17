using System;
using System.Linq;
using System.Collections.Generic;
using Camisetas.Models;

namespace Camisetas.DAL
{
    public class EFTshirtRepository : ITshirtRepository
    {
        // Fields
        private Guid guid = default;
        private AppDbContext dbContext;

        // Indexers
        public Tshirt this[Guid id] => dbContext.Tshirts.Find(id);

        // Properties
        public IEnumerable<Tshirt> Tshirts => dbContext.Tshirts.ToList();

        // Ctor
        public EFTshirtRepository (AppDbContext ctx) 
        {
            dbContext = ctx;
        } // End of ctor

        // Methods
        public void SaveTshirt(Tshirt tshirt)
        {
            if(tshirt != null)
            {
                if( tshirt.Id == guid)
                {
                    dbContext.Tshirts.Add(tshirt);
                }else
                {
                    Tshirt tshirtUpdate = dbContext.Tshirts
                        .FirstOrDefault(t => t.Id == tshirt.Id);
                    if(tshirtUpdate != null)
                    {
                        tshirtUpdate.Name = tshirt.Name;
                        tshirtUpdate.Price = tshirt.Price;
                        tshirtUpdate.Size = tshirt.Size;
                        tshirtUpdate.Color = tshirt.Color;
                        tshirtUpdate.Type = tshirt.Type;
                        tshirtUpdate.Clothing = tshirt.Clothing;
                        tshirtUpdate.Height = tshirt.Height;
                        tshirtUpdate.Width = tshirt.Width;
                    }else{
                        throw new ArgumentNullException(nameof(tshirtUpdate),
                            "Unable to find tshirt entity to save");
                    }
                }
                dbContext.SaveChanges();
            }else{ throw new ArgumentNullException(nameof(tshirt),
                "Unable to save an empty tshirt"); }
            
        } // End of method SaveTshirt.

        public Tshirt DeleteTshirt(Guid tshirtGuid)
        {
            if(tshirtGuid != null)
            {
                Tshirt tshirtToRemove = dbContext.Tshirts.FirstOrDefault(t => t.Id == tshirtGuid);
                if(tshirtToRemove != null)
                {
                    dbContext.Tshirts.Remove(tshirtToRemove);
                    dbContext.SaveChanges();
                    return tshirtToRemove;
                }else{
                    throw new ArgumentNullException(nameof(tshirtToRemove),
                        "Unable to find tshirt to delete");
                }   
            }
            else{ throw new ArgumentNullException(nameof(tshirtGuid),
                "Unable to find an empty Id"); }
        } // End of method DeleteTshirt.S

    } // End of class TshirtRepository.

} // End of namespace Camisetas.DAL.