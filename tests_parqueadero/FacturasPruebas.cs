using lib_parqueadero.entidades;
using Microsoft.EntityFrameworkCore;

namespace tests_parqueadero
{
    [TestClass]
    public class FacturasPruebas : PruebaBase
    {
        private Facturas? entidad = null;

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
            this.entidad = new Facturas()
            {
                Numero = "F-" + Sufijo(8),
                Fecha = DateTime.Today,
                Subtotal = 10000m,
                Total = 11900m
            };
            this.conexion.Facturas!.Add(this.entidad!);
            this.conexion.SaveChanges();
            Registrar(this.entidad);
        }

        public void Consultar()
        {
            var lista = this.conexion.Facturas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Total = 12000m;
            var entry = this.conexion!.Entry<Facturas>(this.entidad!);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Facturas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
