using System;
using System.Collections.Generic;
using System.Text;

namespace lib_parqueadero.Entidades
{
    public class Espacios
    {
        public int Id_espacio { get; set; }
        public string Tipo_espacio { get; set; }
        public int numero { get; set; }
        public int Id_nivel { get; set; } 
        public int Id_zona { get; set; }
    }
}
