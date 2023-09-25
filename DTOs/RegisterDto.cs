namespace SofTk_TechOil.DTOs
{
    public class RegisterDto
    {
        public int CodUsuario { get; set; }
        public string Nombre { get; set; }
        public int DNI { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

       public bool Activo { get; set; }
    }
}
