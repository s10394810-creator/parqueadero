using System.ComponentModel.DataAnnotations;

namespace lib_parqueadero.entidades
{
    public class Facturas
    {
        [Key]
        public int Id_factura { get; set; }
        public string? Numero { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }
}
