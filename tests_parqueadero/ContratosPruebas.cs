using lib_parqueadero.entidades;
using Microsoft.EntityFrameworkCore;

namespace tests_parqueadero
{
    [TestClass]
    public class ContratosPruebas : PruebaBase
    {
        private Contratos? entidad = null;

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
            var cliente = CrearCliente();
            var plan = CrearPlan();
            this.entidad = new Contratos()
            {
                Id_cliente = cliente.Id_cliente,
                Id_plan = plan.Id_plan,
                Fecha_inicio = DateTime.Today,
                Fecha_fin = DateTime.Today.AddDays(30)
            };
            this.conexion.Contratos!.Add(this.entidad!);
            this.conexion.SaveChanges();
            Registrar(this.entidad);
        }

        public void Consultar()
        {
            var lista = this.conexion.Contratos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Fecha_fin = DateTime.Today.AddDays(60);
            var entry = this.conexion!.Entry<Contratos>(this.entidad!);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Contratos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
