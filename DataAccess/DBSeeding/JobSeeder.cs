using Microsoft.EntityFrameworkCore;
using SofTk_TechOil.Entities;

namespace SofTk_TechOil.DataAccess.DBSeeding
{
    public class JobSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Job>().HasData(
            new Job
            {
                CodTrabajo = 1,
                Fecha = DateTime.Now,
                CodProyecto = 1,
                CodServicio = 2,
                CantHoras = 10000,
                ValorHora = 260,                
                Activo = true
            });    
        }
    }
}
