using lib_parqueadero.entidades;
using Microsoft.EntityFrameworkCore;

namespace tests_parqueadero
{
    [TestClass]
    public class PlanesPruebas : PruebaBase
    {
        private Planes? entidad = null;

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
            this.entidad = new Planes()
            {
                Nombre = "Plan-" + Sufijo(6),
                Precio = 50000m,
                Duracion_dias = 30,
                Descripcion = "Plan mensual"
            };
            this.conexion.Planes!.Add(this.entidad!);
            this.conexion.SaveChanges();
            Registrar(this.entidad);
        }

        public void Consultar()
        {
            var lista = this.conexion.Planes!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Precio = 55000m;
            var entry = this.conexion!.Entry<Planes>(this.entidad!);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Planes!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
