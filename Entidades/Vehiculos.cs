using System;

public class Class1
{
	public Class1()
	{
	}
}

/*
 * CREATE TABLE Vehiculos (
    Id_vehiculo INT IDENTITY(1,1) PRIMARY KEY,
    Placa VARCHAR(20)  UNIQUE,
    Marca VARCHAR(100) NULL,
    Modelo VARCHAR(100) NULL,
    Id_tipo INT FOREIGN KEY REFERENCES TipoVehiculos(Id_tipo)    