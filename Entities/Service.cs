using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SofTk_TechOil.Entities
{
    public class Service
    {
        [Key]      
        public int CodServicio { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public bool Estado { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorHora { get; set; }

        [Required]
        public bool Activo { get; set; }

      
    }
}
