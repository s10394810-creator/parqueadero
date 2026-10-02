using System.ComponentModel.DataAnnotations;

namespace lib_parqueadero.entidades
{
    public class Espacios
    {
        [Key]
        public int Id_espacio { get; set; }
        public int Numero { get; set; }
        public int? Id_nivel { get; set; }
        public int? Id_zona { get; set; }
        public string Tipo_espacio { get; set; } = string.Empty;
    }
}
