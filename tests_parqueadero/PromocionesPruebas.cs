using lib_parqueadero.entidades;
using Microsoft.EntityFrameworkCore;

namespace tests_parqueadero
{
    [TestClass]
    public class PromocionesPruebas : PruebaBase
    {
        private Promociones? entidad = null;

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
            this.entidad = new Promociones()
            {
                Nombre = "Promo-" + Sufijo(6),
                Descripcion = "Descuento de prueba",
                Descuento = 10m,
                Fecha_vencimiento = DateTime.Today.AddMonths(1)
            };
            this.conexion.Promociones!.Add(this.entidad!);
            this.conexion.SaveChanges();
            Registrar(this.entidad);
        }

        public void Consultar()
        {
            var lista = this.conexion.Promociones!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Descuento = 15m;
            var entry = this.conexion!.Entry<Promociones>(this.entidad!);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Promociones!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
