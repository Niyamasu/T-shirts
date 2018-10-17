using System;
using System.Linq;
using System.Collections.Generic;
using Camisetas.Models;
using Camisetas.DAL;

namespace Camisetas.DAL
{
    public class EFSizeRepository : ISizeRepository
    {
        // Fields
        private AppDbContext dbContext;

        private Guid guid = default;

        // Ctor
        public EFSizeRepository(AppDbContext ctx)
            => dbContext = ctx;

        // Indexers
        public Size this[Guid guid] => dbContext.Sizes.Find(guid);

        // Properties
        public IEnumerable<Size> Sizes => dbContext.Sizes.ToList();

        public Size DeleteSize(Guid guid)
        {
            if(guid != null)
            {
                Size sizeDelete = dbContext.Sizes.Find(guid);
                if(sizeDelete != null)
                {
                    dbContext.Sizes.Remove(sizeDelete);
                    dbContext.SaveChanges();
                    return sizeDelete;

                }else{
                    throw new ArgumentNullException(nameof(guid),
                    "Unable to find size to delete");
                }
            }else{
                throw new ArgumentNullException(nameof(guid),
                    "Size id to delete is empty");
            }
        } // End of method DeleteColor.

        public void SaveSize(Size size)
        {
            if(size != null)
            {
                if(size.Id == guid)
                {
                    dbContext.Sizes.Add(size);
                }
                else
                {
                    Size sizeEdit =  dbContext.Sizes
                        .FirstOrDefault(s => s.Id == size.Id);
                    if(sizeEdit != null)
                    {
                        sizeEdit.Name = size.Name;
                    }else{
                        throw new ArgumentNullException(nameof(sizeEdit),
                            "Unable to find size entity to save");
                    }
                }
                dbContext.SaveChanges();
            }else
            {
                throw new ArgumentNullException( nameof(size),
                    "Error while saving size");
            }
        } // End of method SaveSize.

    } // End of class EFSizeRepository.

} // End of namespace Camisetas.DAL.