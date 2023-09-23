using Microsoft.EntityFrameworkCore;
using SofTk_TechOil.Entities;

namespace SofTk_TechOil.DataAccess.DBSeeding
{
    public class JobSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            decimal costoCalculado = 10000 * 260;

            modelBuilder.Entity<Job>().HasData(
            new Job
            {
                codTrabajo = 1,
                Fecha = DateTime.Now,
                CodProyecto = 1,
                CodServicio = 2,
                CantHoras = 10000,
                ValorHora = 260,
                Costo = costoCalculado,
                Activo = true
            });    
        }
    }
}
