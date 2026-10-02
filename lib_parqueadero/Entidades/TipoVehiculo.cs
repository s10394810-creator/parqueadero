using System;
using System.Collections.Generic;
using System.Text;

namespace lib_parqueadero.Entidades
{
    public class TipoVehiculo
    {
        public int Id_tipo { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Tarifa_base { get; set; }
        public int Capacidad { get; set; }

    }
}


