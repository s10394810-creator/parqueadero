using lib_parqueadero.entidades;
using Microsoft.EntityFrameworkCore;

namespace tests_parqueadero
{
    [TestClass]
    public class TarifasPruebas : PruebaBase
    {
        private Tarifas? entidad = null;

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
            this.entidad = new Tarifas()
            {
                Nombre = "Tarifa-" + Sufijo(6),
                Valor_hora = 3000m,
                Valor_dia = 25000m,
                Descripcion = "Tarifa de prueba"
            };
            this.conexion.Tarifas!.Add(this.entidad!);
            this.conexion.SaveChanges();
            Registrar(this.entidad);
        }

        public void Consultar()
        {
            var lista = this.conexion.Tarifas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Valor_hora = 3500m;
            var entry = this.conexion!.Entry<Tarifas>(this.entidad!);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Tarifas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
