using lib_parqueadero.entidades;
using Microsoft.EntityFrameworkCore;

namespace tests_parqueadero
{
    [TestClass]
    public class TurnosPruebas : PruebaBase
    {
        private Turnos? entidad = null;

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
            this.entidad = new Turnos()
            {
                Nombre = "Turno-" + Sufijo(6),
                Hora_inicio = new TimeSpan(6, 0, 0),
                Hora_fin = new TimeSpan(14, 0, 0),
                Descripcion = "Turno diurno"
            };
            this.conexion.Turnos!.Add(this.entidad!);
            this.conexion.SaveChanges();
            Registrar(this.entidad);
        }

        public void Consultar()
        {
            var lista = this.conexion.Turnos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Hora_fin = new TimeSpan(15, 0, 0);
            var entry = this.conexion!.Entry<Turnos>(this.entidad!);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Turnos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
