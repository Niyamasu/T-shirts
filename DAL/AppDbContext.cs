using Microsoft.EntityFrameworkCore;
using Camisetas.Models;

namespace Camisetas.DAL
{
    public class AppDbContext : DbContext
    {
        // Ctor
        public AppDbContext(DbContextOptions options)
            : base (options) {}

        // Properties

        public DbSet<Tshirt> Tshirts {get;set;}

        public DbSet<Color> Colors {get;set;}

        public DbSet<Size> Sizes {get;set;}

        public DbSet<Type> Types {get;set;}

        public DbSet<Clothing> Clothings {get;set;}

    } // End of class AppDbContext.

} // End of namespace Camisetas.DAL.