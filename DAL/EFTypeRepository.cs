using System;
using System.Linq;
using System.Collections.Generic;
using Camisetas.Models;

namespace Camisetas.DAL
{
    public class EFTypeRepository : ITypeRepository
    {
        // Fields
        private AppDbContext dbContext;

        private Guid guid = default;

        // Indexers
        public Models.Type this[Guid guid] => dbContext.Types.Find(guid);
        
        // Properties
        public IEnumerable<Models.Type> Types => dbContext.Types.ToList();

        // Ctor
        public EFTypeRepository(AppDbContext ctx) => dbContext = ctx;

        // Methods

        public Models.Type DeleteType(Guid typeGuid)
        {
            if(typeGuid != null)
            {
                Models.Type typeRemove = 
                    dbContext.Types.FirstOrDefault(t => t.Id == typeGuid);
                if(typeRemove != null)
                {
                    dbContext.Types.Remove(typeRemove);
                    dbContext.SaveChanges();
                    return typeRemove;
                }else{
                    throw new ArgumentNullException(nameof(typeRemove),
                        "Unable to find type to delete");
                }   
            }
            else{ throw new ArgumentNullException(nameof(typeGuid),
                "Unable to find an empty Id"); }
        } // End of method DeleteType.

        public void SaveType(Models.Type type)
        {
            if(type != null)
            {
                if( type.Id == guid)
                {
                    dbContext.Types.Add(type);
                }else
                {
                    Models.Type typeEdit = dbContext.Types
                        .FirstOrDefault(t => t.Id == type.Id);
                    if(typeEdit != null)
                    {
                        typeEdit.Name = type.Name;
                        dbContext.SaveChanges();
                    }else{
                        throw new ArgumentNullException(nameof(typeEdit),
                            "Unable to find type entity to save");
                    }
                }
                dbContext.SaveChanges();
            }else{ throw new ArgumentNullException(nameof(type),
                "Unable to save an empty type"); }
        } // End of method SaveType.

    } // End of class EFTypeRepository.

} // End of namespace Camisetas.DAL.