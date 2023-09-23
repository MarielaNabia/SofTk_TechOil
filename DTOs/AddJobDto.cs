namespace SofTk_TechOil.DTOs
{
    public class AddJobDto
    {
        public DateTime Fecha { get; set; }
        public int CodProyecto { get; set; }
        public string ProjectNombre { get; set; } // Agregar propiedad para el nombre del proyecto
        public int CodServicio { get; set; }
        public string ServiceDescripcion { get; set; } // Agregar propiedad para la descripción del servicio
        public int CantHoras { get; set; }
        public decimal ValorHora { get; set; }
        public bool Activo { get; set; }

        // Agrega las propiedades que faltan, como CodTrabajo y Costo, si las necesitas.
        public int CodTrabajo { get; set; }
        public decimal Costo { get; set; }
    }
}
