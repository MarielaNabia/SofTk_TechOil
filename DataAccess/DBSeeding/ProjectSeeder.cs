using Microsoft.EntityFrameworkCore;
using SofTk_TechOil.Entities;

namespace SofTk_TechOil.DataAccess.DBSeeding
{
    public class ProjectSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                 new Project
                 {
                     CodProyecto = 1,
                     Nombre = "Villa Carlos Paz III",
                     Direccion = "AV. Carcano 200, Cordoba",
                     Estado = EstadoTrabajo.Pendiente,
                     Activo = true
                 },
                 new Project
                 {
                     CodProyecto = 2,
                     Nombre = "Vaca Muerta",
                     Direccion = "Km 451, Rio Negro",
                     Estado = EstadoTrabajo.Confirmado,
                     Activo = true
                 },
                 new Project
                 {
                     CodProyecto = 3,
                     Nombre = "Sucursal 154",
                     Direccion = "Litoral 241, Rio Gallegos",
                     Estado = EstadoTrabajo.Terminado,
                     Activo = true
                 });
        }
    }
}
