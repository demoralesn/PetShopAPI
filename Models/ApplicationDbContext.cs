using Microsoft.EntityFrameworkCore;

namespace PetShopAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Race> Races { get; set; }
        public DbSet<Color> Colors { get; set; }
    }
}
