using System.ComponentModel.DataAnnotations;

namespace lib_parqueadero.entidades
{
    public class Pagos
    {
        [Key]
        public int Id_pago { get; set; }
        public int? Id_factura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public string Metodo { get; set; } = string.Empty;
    }
}
