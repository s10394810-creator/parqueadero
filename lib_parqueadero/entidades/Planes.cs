using System.ComponentModel.DataAnnotations;

namespace lib_parqueadero.entidades
{
    public class Planes
    {
        [Key]
        public int Id_plan { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Duracion_dias { get; set; }
        public string? Descripcion { get; set; }
    }
}
