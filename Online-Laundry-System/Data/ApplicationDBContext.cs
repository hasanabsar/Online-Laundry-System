using Online_Laundry_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Online_Laundry_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    email = "admin125@gmail.com",
                    password = "adminadmin"
                }
            );
        } 

        public DbSet<Order> Orders { get; set; }

        public DbSet<Resgistration> Resgistrations { get; set; }   

        public DbSet<Admin> Admins { get; set; } 
    }
} 
  