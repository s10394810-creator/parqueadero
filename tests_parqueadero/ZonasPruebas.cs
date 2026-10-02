using lib_parqueadero.entidades;
using Microsoft.EntityFrameworkCore;

namespace tests_parqueadero
{
    [TestClass]
    public class ZonasPruebas : PruebaBase
    {
        private Zonas? entidad = null;

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
            this.entidad = new Zonas()
            {
                Nombre = "Zona-" + Sufijo(6),
                Descripcion = "Cercana al ingreso",
                Tipo_Zona = "Techada",
                Capacidad = 20
            };
            this.conexion.Zonas!.Add(this.entidad!);
            this.conexion.SaveChanges();
            Registrar(this.entidad);
        }

        public void Consultar()
        {
            var lista = this.conexion.Zonas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Tipo_Zona = "Descubierta";
            var entry = this.conexion!.Entry<Zonas>(this.entidad!);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Zonas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
