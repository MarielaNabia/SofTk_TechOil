using Microsoft.EntityFrameworkCore;
using SofTk_TechOil.DataAccess.DBSeeding;
using SofTk_TechOil.Entities;

namespace SofTk_TechOil.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           

            var seeders = new List<IEntitySeeder>
            {
                new UserSeeder(),
                new RoleSeeder(),
                new ServiceSeeder(),
                new ProjectSeeder(),
                new JobSeeder()
              
            };

            foreach (var seeder in seeders)
            {

                seeder.SeedDatabase(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
