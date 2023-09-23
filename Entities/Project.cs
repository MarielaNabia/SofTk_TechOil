using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SofTk_TechOil.Entities
{
    public class Project
    {
        public Project()
        {
        }

        [Key]      
        public int CodProyecto { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public int Estado { get; set; }

        [Required]
        public bool Activo { get; set; }

     
    }
}
