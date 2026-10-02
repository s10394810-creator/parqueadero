using lib_parqueadero.entidades;
using Microsoft.EntityFrameworkCore;

namespace tests_parqueadero
{
    [TestClass]
    public class BoletosPruebas : PruebaBase
    {
        private Boletos? entidad = null;

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
            var vehiculo = CrearVehiculo();
            this.entidad = new Boletos()
            {
                Codigo = "T-" + Sufijo(8),
                Fecha_entrada = DateTime.Today,
                Hora_entrada = new TimeSpan(8, 30, 0),
                Id_vehiculo = vehiculo.Id_vehiculo
            };
            this.conexion.Boletos!.Add(this.entidad!);
            this.conexion.SaveChanges();
            Registrar(this.entidad);
        }

        public void Consultar()
        {
            var lista = this.conexion.Boletos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Hora_entrada = new TimeSpan(9, 0, 0);
            var entry = this.conexion!.Entry<Boletos>(this.entidad!);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Boletos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
