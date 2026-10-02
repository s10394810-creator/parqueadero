using System.ComponentModel.DataAnnotations;

namespace lib_parqueadero.entidades
{
    public class TipoVehiculos
    {
        [Key]
        public int Id_tipo { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Tarifa_Base { get; set; }
        public int Capacidad { get; set; }
    }
}
