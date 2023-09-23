using Microsoft.EntityFrameworkCore;
using SofTk_TechOil.DTOs;
using SofTk_TechOil.Entities;
using SofTk_TechOil.Helper;

namespace SofTk_TechOil.DataAccess.DBSeeding
{
    public class UserSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    CodUsuario = 1234,
                    Nombre = "Onur Dog",
                    DNI = 40123456,
                    Password = PassEncryptHelper.CreatePass("onurcito", 1234),
                    RoleId = 1
                });
        }       
    }
}
