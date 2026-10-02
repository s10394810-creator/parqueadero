using System.ComponentModel.DataAnnotations;

namespace lib_parqueadero.entidades
{
    public class Roles
    {
        [Key]
        public int Id_rol { get; set; }
        public string? Nombre { get; set; }
    }
}
