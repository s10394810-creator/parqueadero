using System.ComponentModel.DataAnnotations;

namespace lib_parqueadero.entidades
{
    public class Vehiculos
    {
        [Key]
        public int Id_vehiculo { get; set; }
        public string? Placa { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int? Id_tipo { get; set; }
    }
}
