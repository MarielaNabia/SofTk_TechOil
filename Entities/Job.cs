using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SofTk_TechOil.DTOs;

namespace SofTk_TechOil.Entities
{
    public class Job
    {
        public Job()
        {
        }
        public Job(AddJobDto dto)
        {
            Fecha = dto.Fecha;
            CodProyecto = dto.CodProyecto;
            CodServicio = dto.CodServicio;
            CantHoras = dto.CantHoras;
            ValorHora = dto.ValorHora;          
            Activo = true;
        }

        public Job(AddJobDto dto, int codTrabajo)
        {
            CodTrabajo = codTrabajo;
            Fecha = dto.Fecha;
            CodProyecto = dto.CodProyecto;
            CodServicio = dto.CodServicio;
            CantHoras = dto.CantHoras;
            ValorHora = dto.ValorHora;          
            Activo = dto.Activo;
        }

        [Key]       
        public int CodTrabajo { get; set; }

        [Required]
        public DateTime Fecha { get; set; } // Fecha del trabajo

        [Required]
       
        public int CodProyecto { get; set; } // Clave foránea que relaciona el trabajo con un proyecto

        [ForeignKey("CodProyecto")]
        public Project? Project { get; set; }
       
        [Required]
        
        public int CodServicio { get; set; } // Clave foránea que relaciona el trabajo con un servicio

        [ForeignKey("CodServicio")]
        public Service? Service { get; set; }
  
        [Required]
        public int CantHoras { get; set; } // Cantidad de horas del trabajo

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorHora { get; set; } // Valor por hora del servicio

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Costo
        {
            get
            {
                return CantHoras * ValorHora;
            }
        }

        public bool Activo { get; set; }
    }
}
