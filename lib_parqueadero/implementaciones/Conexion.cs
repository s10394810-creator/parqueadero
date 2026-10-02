using lib_parqueadero.entidades;
using lib_parqueadero.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_parqueadero.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<TipoVehiculos>? TipoVehiculos { get; set; }
        public DbSet<Niveles>? Niveles { get; set; }
        public DbSet<Zonas>? Zonas { get; set; }
        public DbSet<Espacios>? Espacios { get; set; }
        public DbSet<Vehiculos>? Vehiculos { get; set; }
        public DbSet<Boletos>? Boletos { get; set; }
        public DbSet<RegistroSalidas>? RegistroSalidas { get; set; }
        public DbSet<Penalizaciones>? Penalizaciones { get; set; }
        public DbSet<Administrador>? Administrador { get; set; }
        public DbSet<Tarifas>? Tarifas { get; set; }
        public DbSet<Facturas>? Facturas { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Planes>? Planes { get; set; }
        public DbSet<Contratos>? Contratos { get; set; }
        public DbSet<Roles>? Roles { get; set; }
        public DbSet<Trabajadores>? Trabajadores { get; set; }
        public DbSet<Turnos>? Turnos { get; set; }
        public DbSet<CierreCaja>? CierreCaja { get; set; }
        public DbSet<Promociones>? Promociones { get; set; }
    }
}
