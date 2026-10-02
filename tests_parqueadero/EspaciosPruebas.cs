using lib_parqueadero.entidades;
using Microsoft.EntityFrameworkCore;

namespace tests_parqueadero
{
    [TestClass]
    public class EspaciosPruebas : PruebaBase
    {
        private Espacios? entidad = null;

        [TestMethod]
        public void Execute()
        {
            try
            {
                Insertar();
                Consultar();
                Actualizar();
                Borrar();
            }
            finally
            {
                Limpiar();
            }
        }

        public void Insertar()
        {
            var nivel = CrearNivel();
            var zona = CrearZona();
            this.entidad = new Espacios()
            {
                Numero = 999,
                Id_nivel = nivel.Id_nivel,
                Id_zona = zona.Id_zona,
                Tipo_espacio = "Carro"
            };
            this.conexion.Espacios!.Add(this.entidad!);
            this.conexion.SaveChanges();
            Registrar(this.entidad);
        }

        public void Consultar()
        {
            var lista = this.conexion.Espacios!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Tipo_espacio = "Moto";
            var entry = this.conexion!.Entry<Espacios>(this.entidad!);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Espacios!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
