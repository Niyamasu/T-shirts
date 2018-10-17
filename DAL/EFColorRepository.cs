using System;
using System.Linq;
using System.Collections.Generic;
using Camisetas.Models;

namespace Camisetas.DAL
{
    public class EFColorRepository : IColorRepository
    {
        // Fields
        private AppDbContext dbContext;

        private Guid guid = default;

        // Indexer
        public Color this[Guid guid] => dbContext.Colors.Find(guid);

        // Properties
        public IEnumerable<Color> Colors => dbContext.Colors.ToList();

        // Ctor
        public EFColorRepository (AppDbContext ctx) => dbContext = ctx;

        // Methods
        public Color DeleteColor(Guid guid)
        {
            if(guid != null)
            {
                Color colorDelete = dbContext.Colors.Find(guid);
                if(colorDelete != null)
                {
                    dbContext.Colors.Remove(colorDelete);
                    dbContext.SaveChanges();
                    return colorDelete;

                }else{
                    throw new ArgumentNullException(nameof(guid),
                    "Unable to find color to delete");
                }
            }else{
                throw new ArgumentNullException(nameof(guid),
                    "Color id to delete is empty");
            }
        } // End of method DeleteColor.

        public void SaveColor(Color color)
        {
            if(color != null)
            {
                if(color.Id == guid)
                {
                    dbContext.Colors.Add(color);
                }
                else
                {
                    Color colorEdit =  dbContext.Colors
                        .FirstOrDefault(c => c.Id == color.Id);
                    if(colorEdit != null)
                    {
                        colorEdit.Name = color.Name;
                    }else{
                        throw new ArgumentNullException(nameof(colorEdit),
                            "Unable to find color entity to save");
                    }
                }
                dbContext.SaveChanges();
            }else
            {
                throw new ArgumentNullException( nameof(color),
                    "Error while saving color");
            }
        } // End of method SaveColor.

    } // End of class EFColorRepository.

} // End of namespace Camisetas.DAL.