using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SofTk_TechOil.Entities
{
    public class Job
    {
        public Job()
        {

        }

        [Key]       
        public int codTrabajo { get; set; }

        [Required]
        public DateTime Fecha { get; set; } // Fecha del trabajo

        [Required]
        public int CodProyecto { get; set; } // Clave foránea que relaciona el trabajo con un proyecto
        public Project? Project { get; set; }
       
        [Required]
        public int CodServicio { get; set; } // Clave foránea que relaciona el trabajo con un servicio
        public Service? Service { get; set; }
  
        [Required]
        public int CantHoras { get; set; } // Cantidad de horas del trabajo

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorHora { get; set; } // Valor por hora del servicio

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Costo { get; set; } // Costo total del trabajo

        public bool Activo { get; set; }
    }
}
