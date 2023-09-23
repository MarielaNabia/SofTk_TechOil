using Microsoft.Extensions.Hosting;
using SofTk_TechOil.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SofTk_TechOil.Entities
{
    public class Project
    {
        public Project()
        {
        }

        public Project(AddProjectDto dto)
        {
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;

            // Realiza una conversión explícita del entero a EstadoTrabajo
            Estado = (EstadoTrabajo)dto.Estado;

            Activo = true;
        }

        public Project(AddProjectDto dto, int codProyecto)
        : this(dto)
        {
            CodProyecto = codProyecto;
            Activo = dto.Activo;
        }


        [Key]      
        public int CodProyecto { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public EstadoTrabajo Estado { get; set; }

        [Required]
        public bool Activo { get; set; }

       
    }
    public enum EstadoTrabajo
    {
        Pendiente = 1,
        Confirmado = 2,
        Terminado = 3
    }
}
