using SofTk_TechOil.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SofTk_TechOil.Entities
{
    public class Service
    {
        public Service()
        {
        }
        public Service(AddServiceDto dto)
        {
            Descripcion = dto.Descripcion;
            Estado = dto.Estado;
            ValorHora = dto.ValorHora;
            Activo = true;
        }
        public Service(AddServiceDto dto, int codServicio)
        {
            CodServicio = codServicio;
            Descripcion = dto.Descripcion;
            Estado = dto.Estado;
            ValorHora = dto.ValorHora;
            Activo = dto.Activo;
        }

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

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
