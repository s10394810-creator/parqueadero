using System;
using System.Collections.Generic;
using System.Text;

namespace lib_parqueadero.Entidades
{
    public class Niveles
    {
        public int Id_nivel { get; set; }
        public string? Nombre { get; set; }
        public string? Ubicacion { get; set; }
        public int Numero { get; set; }
        public int Capacidad { get; set; }
    }
}
