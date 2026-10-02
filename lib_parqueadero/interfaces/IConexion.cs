using lib_parqueadero.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_parqueadero.interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<TipoVehiculos>? TipoVehiculos { get; set; }
        DbSet<Niveles>? Niveles { get; set; }
        DbSet<Zonas>? Zonas { get; set; }
        DbSet<Espacios>? Espacios { get; set; }
        DbSet<Vehiculos>? Vehiculos { get; set; }
        DbSet<Boletos>? Boletos { get; set; }
        DbSet<RegistroSalidas>? RegistroSalidas { get; set; }
        DbSet<Penalizaciones>? Penalizaciones { get; set; }
        DbSet<Administrador>? Administrador { get; set; }
        DbSet<Tarifas>? Tarifas { get; set; }
        DbSet<Facturas>? Facturas { get; set; }
        DbSet<Pagos>? Pagos { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Planes>? Planes { get; set; }
        DbSet<Contratos>? Contratos { get; set; }
        DbSet<Roles>? Roles { get; set; }
        DbSet<Trabajadores>? Trabajadores { get; set; }
        DbSet<Turnos>? Turnos { get; set; }
        DbSet<CierreCaja>? CierreCaja { get; set; }
        DbSet<Promociones>? Promociones { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
