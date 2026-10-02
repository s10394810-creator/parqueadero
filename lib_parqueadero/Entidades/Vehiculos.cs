using System;
using System.Collections.Generic;
using System.Text;

namespace lib_parqueadero.Entidades
{
    public class Vehiculo
    {
        public int Id_vehiculos { get; set; }
        public string? Placa { get; set; }
        public string? Marca { get; set; }
        public decimal? Modelo { get; set; }
        public int Id_tipó { get; set; }
    }
}
