using lib_parqueadero.entidades;
using Microsoft.EntityFrameworkCore;

namespace tests_parqueadero
{
    [TestClass]
    public class TipoVehiculosPruebas : PruebaBase
    {
        private TipoVehiculos? entidad = null;

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
            this.entidad = new TipoVehiculos()
            {
                Nombre = "Carro-" + Sufijo(6),
                Descripcion = "Vehiculo particular",
                Tarifa_Base = 3000m,
                Capacidad = 1
            };
            this.conexion.TipoVehiculos!.Add(this.entidad!);
            this.conexion.SaveChanges();
            Registrar(this.entidad);
        }

        public void Consultar()
        {
            var lista = this.conexion.TipoVehiculos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Tarifa_Base = 3500m;
            var entry = this.conexion!.Entry<TipoVehiculos>(this.entidad!);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.TipoVehiculos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
