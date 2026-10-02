using lib_parqueadero.entidades;
using Microsoft.EntityFrameworkCore;

namespace tests_parqueadero
{
    [TestClass]
    public class TrabajadoresPruebas : PruebaBase
    {
        private Trabajadores? entidad = null;

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
            var rol = CrearRol();
            this.entidad = new Trabajadores()
            {
                Nombres = "Luis",
                Apellidos = "Ramirez",
                Documento = Sufijo(10),
                Id_rol = rol.Id_rol
            };
            this.conexion.Trabajadores!.Add(this.entidad!);
            this.conexion.SaveChanges();
            Registrar(this.entidad);
        }

        public void Consultar()
        {
            var lista = this.conexion.Trabajadores!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Apellidos = "Rodriguez";
            var entry = this.conexion!.Entry<Trabajadores>(this.entidad!);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Trabajadores!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
