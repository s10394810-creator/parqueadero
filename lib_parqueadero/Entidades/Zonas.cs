using System;
using System.Collections.Generic;
using System.Text;

namespace lib_parqueadero.Entidades
{
    public class Zonas
    {
        public int Id_zona { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Tipo_zona { get; set; }
        public int Capacidad { get; set; }
    }
}
