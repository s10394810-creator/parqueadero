using System.ComponentModel.DataAnnotations;

namespace lib_parqueadero.entidades
{
    public class Turnos
    {
        [Key]
        public int Id_turno { get; set; }
        public string? Nombre { get; set; }
        public TimeSpan Hora_inicio { get; set; }
        public TimeSpan Hora_fin { get; set; }
        public string? Descripcion { get; set; }
    }
}
