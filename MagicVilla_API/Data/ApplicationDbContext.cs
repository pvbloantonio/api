using MagicVilla_API.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Test",
                    Description = "Test",
                    ImageUrl = "",
                    Occupants = 3,
                    SquareMeter = 3,
                    Amenity="",
                    Price = 3000,
                    Created_at = DateTime.UtcNow,
                    Updated_at = DateTime.UtcNow,
                },
                new Villa()
                {
                    Id = 2,
                    Name = "Test2",
                    Description = "Test2",
                    ImageUrl = "",
                    Occupants = 3,
                    SquareMeter = 3,
                    Amenity = "",
                    Price = 3000,
                    Created_at = DateTime.UtcNow,
                    Updated_at = DateTime.UtcNow,
                }
                );
        }
    }
}
