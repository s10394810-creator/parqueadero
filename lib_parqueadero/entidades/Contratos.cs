using System.ComponentModel.DataAnnotations;

namespace lib_parqueadero.entidades
{
    public class Contratos
    {
        [Key]
        public int Id_contrato { get; set; }
        public int? Id_cliente { get; set; }
        public int? Id_plan { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_fin { get; set; }
    }
}
