using lib_parqueadero.implementaciones;
using lib_parqueadero.interfaces;
using lib_parqueadero.nucleo;

try
{
    IConexion conexion = new Conexion();
    conexion.StringConexion = DatosGenerales.StringConexion();

    Console.WriteLine("Tipos de vehiculo:");
    foreach (var t in conexion.TipoVehiculos!.ToList())
        Console.WriteLine($"  {t.Id_tipo} - {t.Nombre} - {t.Tarifa_Base}");

    Console.WriteLine("\nClientes:");
    foreach (var c in conexion.Clientes!.ToList())
        Console.WriteLine($"  {c.Id_cliente} - {c.Nombres} {c.Apellidos} - {c.Documento}");

    Console.WriteLine("\nVehiculos:");
    foreach (var v in conexion.Vehiculos!.ToList())
        Console.WriteLine($"  {v.Id_vehiculo} - {v.Placa} - {v.Marca} {v.Modelo}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
