using lib_parqueadero.entidades;
using Microsoft.EntityFrameworkCore;

namespace tests_parqueadero
{
    [TestClass]
    public class AdministradorPruebas : PruebaBase
    {
        private Administrador? entidad = null;

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
            this.entidad = new Administrador()
            {
                Nombres = "Carlos",
                Apellidos = "Gomez",
                Documento = Sufijo(10),
                Telefono = "3001112233"
            };
            this.conexion.Administrador!.Add(this.entidad!);
            this.conexion.SaveChanges();
            Registrar(this.entidad);
        }

        public void Consultar()
        {
            var lista = this.conexion.Administrador!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Telefono = "3009998877";
            var entry = this.conexion!.Entry<Administrador>(this.entidad!);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Administrador!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
