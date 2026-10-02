using lib_parqueadero.entidades;
using Microsoft.EntityFrameworkCore;

namespace tests_parqueadero
{
    [TestClass]
    public class PenalizacionesPruebas : PruebaBase
    {
        private Penalizaciones? entidad = null;

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
            var boleto = CrearBoleto();
            this.entidad = new Penalizaciones()
            {
                Id_ticket = boleto.Id_ticket,
                Motivo = "Perdida de ticket",
                Valor = 15000m,
                Fecha = DateTime.Today
            };
            this.conexion.Penalizaciones!.Add(this.entidad!);
            this.conexion.SaveChanges();
            Registrar(this.entidad);
        }

        public void Consultar()
        {
            var lista = this.conexion.Penalizaciones!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Valor = 20000m;
            var entry = this.conexion!.Entry<Penalizaciones>(this.entidad!);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Penalizaciones!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
