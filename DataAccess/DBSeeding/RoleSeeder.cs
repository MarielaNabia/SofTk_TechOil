using Microsoft.EntityFrameworkCore;
using SofTk_TechOil.Entities;

namespace SofTk_TechOil.DataAccess.DBSeeding
{
    public class RoleSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    Description = "Administrador",
                    Activo = true,

                },
                 new Role
                 {
                     Id = 2,
                     Name = "Consultor",
                     Description = "Consultor",
                     Activo = true,
                 });
        }
    }
}
