using lib_parqueadero.entidades;
using lib_parqueadero.implementaciones;
using lib_parqueadero.interfaces;
using lib_parqueadero.nucleo;
using Microsoft.EntityFrameworkCore;

namespace tests_parqueadero
{
    // Base comun de las pruebas: crea la conexion y arma los registros "padre" que piden las llaves foraneas.
    // Todo lo que se crea queda registrado y se borra al final (en orden inverso) con Limpiar().
    public abstract class PruebaBase
    {
        protected IConexion conexion;
        private readonly List<Action> limpieza = new List<Action>();

        protected PruebaBase()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.StringConexion();
        }

        // Texto aleatorio para las columnas UNIQUE (placa, documento, codigo...) para que las pruebas no se pisen entre si.
        protected static string Sufijo(int largo)
        {
            return Guid.NewGuid().ToString("N").Substring(0, largo).ToUpper();
        }

        protected void Registrar<T>(T entidad) where T : class
        {
            this.limpieza.Add(() =>
            {
                try
                {
                    this.conexion.Entry(entidad).State = EntityState.Deleted;
                    this.conexion.SaveChanges();
                }
                catch (Exception)
                {
                    // Si la fila ya fue borrada por la prueba, se suelta y se sigue con el resto.
                    this.conexion.Entry(entidad).State = EntityState.Detached;
                }
            });
        }

        protected T Guardar<T>(T entidad) where T : class
        {
            this.conexion.Entry(entidad).State = EntityState.Added;
            this.conexion.SaveChanges();
            Registrar(entidad);
            return entidad;
        }

        protected void Limpiar()
        {
            for (int i = this.limpieza.Count - 1; i >= 0; i--)
                this.limpieza[i]();
            this.limpieza.Clear();
        }

        protected TipoVehiculos CrearTipoVehiculo()
        {
            return Guardar(new TipoVehiculos()
            {
                Nombre = "Carro-" + Sufijo(6),
                Descripcion = "Prueba",
                Tarifa_Base = 3000m,
                Capacidad = 1
            });
        }

        protected Niveles CrearNivel()
        {
            return Guardar(new Niveles()
            {
                Nombre = "Nivel-" + Sufijo(6),
                Numero = 99,
                Capacidad = 10,
                Ubicacion = "Prueba"
            });
        }

        protected Zonas CrearZona()
        {
            return Guardar(new Zonas()
            {
                Nombre = "Zona-" + Sufijo(6),
                Descripcion = "Prueba",
                Tipo_Zona = "Techada",
                Capacidad = 10
            });
        }

        protected Vehiculos CrearVehiculo()
        {
            var tipo = CrearTipoVehiculo();
            return Guardar(new Vehiculos()
            {
                Placa = Sufijo(6),
                Marca = "Chevrolet",
                Modelo = "Spark",
                Id_tipo = tipo.Id_tipo
            });
        }

        protected Boletos CrearBoleto()
        {
            var vehiculo = CrearVehiculo();
            return Guardar(new Boletos()
            {
                Codigo = "T-" + Sufijo(8),
                Fecha_entrada = DateTime.Today,
                Hora_entrada = new TimeSpan(8, 0, 0),
                Id_vehiculo = vehiculo.Id_vehiculo
            });
        }

        protected Facturas CrearFactura()
        {
            return Guardar(new Facturas()
            {
                Numero = "F-" + Sufijo(8),
                Fecha = DateTime.Today,
                Subtotal = 10000m,
                Total = 11900m
            });
        }

        protected Clientes CrearCliente()
        {
            return Guardar(new Clientes()
            {
                Nombres = "Juan",
                Apellidos = "Perez",
                Documento = Sufijo(10),
                Telefono = "3001234567"
            });
        }

        protected Planes CrearPlan()
        {
            return Guardar(new Planes()
            {
                Nombre = "Plan-" + Sufijo(6),
                Precio = 50000m,
                Duracion_dias = 30,
                Descripcion = "Prueba"
            });
        }

        protected Roles CrearRol()
        {
            return Guardar(new Roles()
            {
                Nombre = "Rol-" + Sufijo(6)
            });
        }
    }
}
