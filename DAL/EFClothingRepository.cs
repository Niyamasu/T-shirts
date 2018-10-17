using System;
using System.Linq;
using System.Collections.Generic;
using Camisetas.Models;

namespace Camisetas.DAL
{
    public class EFClothingRepository : IClothingRepository
    {
        // Fields
        private Guid guid = default;
        private AppDbContext dbContext;

        // Indexers

        public Clothing this[Guid guid] => dbContext.Clothings.Find(guid);

        // Properties
        public IEnumerable<Clothing> Clothings => dbContext.Clothings.ToList();

        // Ctor
        public EFClothingRepository (AppDbContext context) => dbContext = context;

        // Methods

        public Clothing DeleteClothing(Guid guid)
        {
            if(guid != null)
            {
                Clothing clothingDelete = dbContext.Clothings.Find(guid);
                if(clothingDelete != null)
                {
                    dbContext.Clothings.Remove(clothingDelete);
                    dbContext.SaveChanges();
                    return clothingDelete;

                }else{
                    throw new ArgumentNullException(nameof(guid),
                    "Unable to find clothing to delete");
                }
            }else{
                throw new ArgumentNullException(nameof(guid),
                    "Clothing id to delete is empty");
            }
        } // End of method DeleteClothing.

        public void SaveClothing(Clothing clothing)
        {
            if(clothing != null)
            {
                if(clothing.Id == guid)
                {
                    dbContext.Clothings.Add(clothing);
                }
                else
                {
                    Clothing clothingEdit =  dbContext.Clothings
                        .FirstOrDefault(c => c.Id == clothing.Id);
                    if(clothingEdit != null)
                    {
                        clothingEdit.Name = clothing.Name;
                    }else{
                        throw new ArgumentNullException(nameof(clothingEdit),
                            "Unable to find clothing entity to save");
                    }
                }
                dbContext.SaveChanges();
            }else
            {
                throw new ArgumentNullException( nameof(clothing),
                    "Error while saving clothing");
            }
        } // End of method SaveClothing.

    } // End of class EFClothingRepository.

} // End of namespace Camisetas.DAL.