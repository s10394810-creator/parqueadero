using System.ComponentModel.DataAnnotations;

namespace lib_parqueadero.entidades
{
    public class Trabajadores
    {
        [Key]
        public int Id_trabajador { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Documento { get; set; }
        public int? Id_rol { get; set; }
    }
}
