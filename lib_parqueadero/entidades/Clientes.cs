using System.ComponentModel.DataAnnotations;

namespace lib_parqueadero.entidades
{
    public class Clientes
    {
        [Key]
        public int Id_cliente { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string? Documento { get; set; }
        public string Telefono { get; set; } = string.Empty;
    }
}
