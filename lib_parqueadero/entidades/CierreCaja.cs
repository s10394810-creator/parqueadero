using System.ComponentModel.DataAnnotations;

namespace lib_parqueadero.entidades
{
    public class CierreCaja
    {
        [Key]
        public int Id_caja { get; set; }
        public string? Numero { get; set; }
        public DateTime Fecha_apertura { get; set; }
        public decimal Saldo_inicial { get; set; }
        public decimal Saldo_final { get; set; }
    }
}
