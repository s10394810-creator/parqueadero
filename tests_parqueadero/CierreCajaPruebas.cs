using lib_parqueadero.entidades;
using Microsoft.EntityFrameworkCore;

namespace tests_parqueadero
{
    [TestClass]
    public class CierreCajaPruebas : PruebaBase
    {
        private CierreCaja? entidad = null;

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
            this.entidad = new CierreCaja()
            {
                Numero = "C-" + Sufijo(8),
                Fecha_apertura = DateTime.Today,
                Saldo_inicial = 100000m,
                Saldo_final = 250000m
            };
            this.conexion.CierreCaja!.Add(this.entidad!);
            this.conexion.SaveChanges();
            Registrar(this.entidad);
        }

        public void Consultar()
        {
            var lista = this.conexion.CierreCaja!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Saldo_final = 300000m;
            var entry = this.conexion!.Entry<CierreCaja>(this.entidad!);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.CierreCaja!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
