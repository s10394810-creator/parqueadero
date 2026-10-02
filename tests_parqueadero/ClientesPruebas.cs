using lib_parqueadero.entidades;
using Microsoft.EntityFrameworkCore;

namespace tests_parqueadero
{
    [TestClass]
    public class ClientesPruebas : PruebaBase
    {
        private Clientes? entidad = null;

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
            this.entidad = new Clientes()
            {
                Nombres = "Juan",
                Apellidos = "Perez",
                Documento = Sufijo(10),
                Telefono = "3001234567"
            };
            this.conexion.Clientes!.Add(this.entidad!);
            this.conexion.SaveChanges();
            Registrar(this.entidad);
        }

        public void Consultar()
        {
            var lista = this.conexion.Clientes!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Telefono = "3109876543";
            var entry = this.conexion!.Entry<Clientes>(this.entidad!);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Clientes!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
