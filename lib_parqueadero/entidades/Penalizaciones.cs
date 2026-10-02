using System.ComponentModel.DataAnnotations;

namespace lib_parqueadero.entidades
{
    public class Penalizaciones
    {
        [Key]
        public int Id_penalizacion { get; set; }
        public int? Id_ticket { get; set; }
        public string? Motivo { get; set; }
        public decimal Valor { get; set; }
        public DateTime Fecha { get; set; }
    }
}
