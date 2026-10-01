-- Script de ejemplo para probar el repositorio.
-- Cada colaborador puede agregar su nombre abajo y hacer git push para verificar acceso.

CREATE DATABASE parqueadero;
GO

USE parqueadero;
GO

CREATE TABLE Colaboradores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);
GO

INSERT INTO Colaboradores (Nombre) VALUES ('Colaborador 1');
GO
