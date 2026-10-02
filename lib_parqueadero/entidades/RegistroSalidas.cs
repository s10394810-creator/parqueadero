using System.ComponentModel.DataAnnotations;

namespace lib_parqueadero.entidades
{
    public class RegistroSalidas
    {
        [Key]
        public int Id_salida { get; set; }
        public int? Id_ticket { get; set; }
        public DateTime Fecha_salida { get; set; }
        public TimeSpan Hora_salida { get; set; }
        public string? Observacion { get; set; }
    }
}
