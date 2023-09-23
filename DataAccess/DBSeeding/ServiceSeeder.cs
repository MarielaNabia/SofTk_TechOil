using Microsoft.EntityFrameworkCore;
using SofTk_TechOil.Entities;

namespace SofTk_TechOil.DataAccess.DBSeeding
{
    public class ServiceSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    CodServicio = 1,
                    Descripcion = "PerforacionPozzo100",
                    Estado = true,
                    ValorHora = 1500,
                    Activo = true
                },
                new Service
                {
                    CodServicio = 2,
                    Descripcion = "ExtraccionCapa2",
                    Estado = true,
                    ValorHora = 1400,
                    Activo = true
                },
                new Service
                {
                    CodServicio = 3,
                    Descripcion = "TransporteKM",
                    Estado = true,
                    ValorHora = 1300,
                    Activo = true
                });
        }
        
        
    }
}
