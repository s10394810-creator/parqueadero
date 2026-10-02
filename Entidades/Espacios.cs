using System;

public class Class1
{
	public Class1()
	{
	}
}

/*
 * CREATE TABLE Espacios (
    Id_espacio INT IDENTITY(1,1)   PRIMARY KEY,
    Numero INT NOT NULL,
    Id_nivel INT FOREIGN KEY  REFERENCES Niveles(Id_nivel),
    Id_zona INT FOREIGN KEY  REFERENCES Zonas(Id_zona),
    Tipo_espacio VARCHAR(100) NOT   NULL