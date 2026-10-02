using lib_parqueadero.entidades;
using Microsoft.EntityFrameworkCore;

namespace tests_parqueadero
{
    [TestClass]
    public class NivelesPruebas : PruebaBase
    {
        private Niveles? entidad = null;

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
            this.entidad = new Niveles()
            {
                Nombre = "Nivel-" + Sufijo(6),
                Numero = 99,
                Capacidad = 20,
                Ubicacion = "Elevado"
            };
            this.conexion.Niveles!.Add(this.entidad!);
            this.conexion.SaveChanges();
            Registrar(this.entidad);
        }

        public void Consultar()
        {
            var lista = this.conexion.Niveles!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Capacidad = 25;
            var entry = this.conexion!.Entry<Niveles>(this.entidad!);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Niveles!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
