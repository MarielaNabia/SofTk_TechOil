using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using SofTk_TechOil.DTOs;
using SofTk_TechOil.Helper;

namespace SofTk_TechOil.Entities
{
    public class User
    {                 
            public User()
            {
            }

            public User(RegisterDto dto)
            {
                CodUsuario = dto.CodUsuario;
                Nombre = dto.Nombre;
                DNI = dto.DNI;
                RoleId = 2;
                Password = PassEncryptHelper.CreatePass(dto.Password, dto.CodUsuario);
            }

            public User(RegisterDto dto, int id)
            {
                Id = id;
                CodUsuario = dto.CodUsuario;
                Nombre = dto.Nombre;
                DNI = dto.DNI;
                RoleId = dto.RoleId;
                Password = PassEncryptHelper.CreatePass(dto.Password, dto.CodUsuario);
            }

            [Key]
            [Column("user_id")]
            public int Id { get; set; }
                              
            public int CodUsuario { get; set; }

            [Required]
            [StringLength(100)]
            public string Nombre { get; set; }
         
            [Required]           
            public int DNI { get; set; }

        
            public bool Activo { get; set; } 
        
            [Required]
            [Column("user_password", TypeName = "VARCHAR(250)")]
            public string Password { get; set; }

            public DateTime FechaBaja { get; set; }

            [Required]
            [Column("role_id")]
            public int RoleId { get; set; }

            public Role? Role { get; set; }
        
    }
}
