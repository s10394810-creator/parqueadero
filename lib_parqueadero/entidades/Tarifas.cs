using System.ComponentModel.DataAnnotations;

namespace lib_parqueadero.entidades
{
    public class Tarifas
    {
        [Key]
        public int Id_tarifa { get; set; }
        public string? Nombre { get; set; }
        public decimal Valor_hora { get; set; }
        public decimal Valor_dia { get; set; }
        public string? Descripcion { get; set; }
    }
}
