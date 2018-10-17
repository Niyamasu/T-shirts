using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Camisetas.Models;

namespace Camisetas.DAL
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices.GetService<AppDbContext>();
            context.Database.Migrate();
            if(!context.Tshirts.Any())
            {

                context.SaveChanges();
            }
        } // End of method EnsurePopulated.

    } // End of class SeedData.

} // End of namespace Camisetas.DAL.