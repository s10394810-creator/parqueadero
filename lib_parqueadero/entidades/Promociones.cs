using System.ComponentModel.DataAnnotations;

namespace lib_parqueadero.entidades
{
    public class Promociones
    {
        [Key]
        public int Id_promocion { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Descuento { get; set; }
        public DateTime Fecha_vencimiento { get; set; }
    }
}
