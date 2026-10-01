create database db_parqueadero
go
use db_parqueadero
go

CREATE TABLE TipoVehiculos (
    Id_tipo INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NULL,
    Descripcion VARCHAR(255) NULL,
    Tarifa_Base DECIMAL(10,2) NOT NULL,
    Capacidad INT NOT NULL
);
CREATE TABLE Niveles (
    Id_nivel INT IDENTITY(1,1)  PRIMARY KEY,
    Nombre VARCHAR(100) NULL,
    Numero INT NOT NULL,
    Capacidad INT NOT NULL,
    Ubicacion VARCHAR(150) NULL
);
CREATE TABLE Zonas (
    Id_zona INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NULL,
    Descripcion VARCHAR(255) NULL,
    Tipo_Zona VARCHAR(100) NULL,
    Capacidad INT NOT NULL         
);
CREATE TABLE Espacios (
    Id_espacio INT IDENTITY(1,1)   PRIMARY KEY,
    Numero INT NOT NULL,
    Id_nivel INT FOREIGN KEY  REFERENCES Niveles(Id_nivel),
    Id_zona INT FOREIGN KEY  REFERENCES Zonas(Id_zona),
    Tipo_espacio VARCHAR(100) NOT   NULL
);
CREATE TABLE Vehiculos (
    Id_vehiculo INT IDENTITY(1,1) PRIMARY KEY,
    Placa VARCHAR(20)  UNIQUE,
    Marca VARCHAR(100) NULL,
    Modelo VARCHAR(100) NULL,
    Id_tipo INT FOREIGN KEY REFERENCES TipoVehiculos(Id_tipo)    
);
CREATE TABLE Boletos (
    Id_ticket INT IDENTITY(1,1)PRIMARY KEY,
    Codigo VARCHAR(50) UNIQUE,
    Fecha_entrada DATE NOT NULL,
    Hora_entrada TIME NOT NULL,
    Id_vehiculo INT  FOREIGN KEY REFERENCES Vehiculos(Id_vehiculo)
);
CREATE TABLE RegistroSalidas (
    Id_salida INT IDENTITY(1,1)  PRIMARY KEY,
    Id_ticket INT FOREIGN KEY REFERENCES Boletos(id_ticket),
    Fecha_salida DATE NOT NULL,
    Hora_salida TIME NOT NULL,
    Observacion VARCHAR(255) NULL
);
CREATE TABLE Penalizaciones (
    Id_penalizacion INT IDENTITY(1,1) PRIMARY KEY,
    Id_ticket INT  FOREIGN KEY REFERENCES Boletos(Id_ticket),
    Motivo VARCHAR(255) NULL,
    Valor DECIMAL(10,2) NOT NULL,
    Fecha DATE NOT NULL
);
CREATE TABLE Administrador (
    Id_administrador INT IDENTITY(1,1)  PRIMARY KEY,
    Nombres VARCHAR(100) NULL,
    Apellidos VARCHAR(100) NULL,
    Documento VARCHAR(30) UNIQUE,
    Telefono VARCHAR(30) NULL
);
CREATE TABLE Tarifas (
    Id_tarifa INT IDENTITY(1,1)  PRIMARY KEY,
    Nombre VARCHAR(100) NULL,
    Valor_hora DECIMAL(10,2) NOT NULL,
    Valor_dia DECIMAL(10,2) NOT NULL,
    Descripcion VARCHAR(255) NULL
);
CREATE TABLE Facturas (
    Id_factura INT IDENTITY(1,1) PRIMARY KEY ,
    Numero VARCHAR(50) UNIQUE ,
    Fecha DATE NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL,
    Total DECIMAL(10,2) NOT NULL
);
CREATE TABLE Pagos (
    Id_pago INT IDENTITY(1,1)   PRIMARY KEY ,
    Id_factura INT  FOREIGN KEY REFERENCES Facturas(Id_factura),
    Fecha DATE NOT NULL,
    Valor DECIMAL(10,2) NOT NULL,
    Metodo VARCHAR(50) NOT NULL
);
CREATE TABLE Clientes (
    Id_cliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombres VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    Documento VARCHAR(30) UNIQUE,
    Telefono VARCHAR(30) NOT NULL
);
CREATE TABLE Planes (
    Id_plan INT IDENTITY(1,1)PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Duracion_dias INT NOT NULL,
    Descripcion VARCHAR(255) NULL
);
CREATE TABLE Contratos (
    Id_contrato INT IDENTITY(1,1) PRIMARY KEY,
    Id_cliente INT FOREIGN KEY REFERENCES Clientes(Id_cliente),
    Id_plan INT FOREIGN KEY REFERENCES Planes(Id_plan),
    Fecha_inicio DATE NOT NULL,
    Fecha_fin DATE NOT NULL
);
CREATE TABLE Roles (
    Id_rol INT IDENTITY(1,1)PRIMARY KEY,
    Nombre VARCHAR(100) NULL
);
CREATE TABLE Trabajadores (
    Id_trabajador INT IDENTITY(1,1)  PRIMARY KEY,
    Nombres VARCHAR(100) NULL,
    Apellidos VARCHAR(100) NULL,
    Documento VARCHAR(30)  UNIQUE,
    Id_rol INT FOREIGN KEY REFERENCES Roles(Id_rol)
);
CREATE TABLE Turnos (
    Id_turno INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NULL,
    Hora_inicio TIME NOT NULL,
    Hora_fin TIME NOT NULL,
    Descripcion VARCHAR(255) NULL
);
CREATE TABLE CierreCaja (
    Id_caja INT IDENTITY(1,1) PRIMARY KEY,
    Numero VARCHAR(50)     UNIQUE,
    Fecha_apertura DATE NOT NULL,
    Saldo_inicial DECIMAL(10,2) NOT NULL,
    Saldo_final DECIMAL(10,2) NOT NULL
);
CREATE TABLE Promociones (
    Id_promocion INT IDENTITY(1,1) PRIMARY KEY ,
    Nombre VARCHAR(100) NULL,
    Descripcion VARCHAR(255) NULL,
    Descuento DECIMAL(5,2) NOT NULL,
    Fecha_vencimiento DATE NOT NULL
);


INSERT INTO TipoVehiculos
    ( Nombre, Descripcion, Tarifa_Base, Capacidad)
VALUES
    ( 'Carro', 'Vehiculo particular', 3000, 1),
    ( 'Moto', 'Motocicleta', 1500, 1),
    ( 'Bus', 'Vehiculo de transporte publico', 5000, 1),
    ( 'Camioneta', 'Vehiculo de carga liviana', 3500, 1),
    ( 'Bicicleta', 'Vehiculo no motorizado', 1000, 1);




INSERT INTO Niveles
    ( Nombre, Numero, Capacidad, Ubicacion)
VALUES
    ( 'Sotano 1', 1, 50, 'Subterraneo'),
    ( 'Sotano 2', 2, 50, 'Subterraneo'),
    ( 'Planta baja', 3, 40, 'Nivel calle'),
    ( 'Piso 1', 4, 30, 'Elevado'),
    ( 'Piso 2', 5, 30, 'Elevado');




INSERT INTO Zonas
    ( Nombre, Descripcion, Tipo_Zona, Capacidad)
VALUES
    ( 'Zona A', 'Cercana al ingreso', 'Techada', 20),
    ( 'Zona B', 'Cercana al ascensor', 'Techada', 20),
    ( 'Zona C', 'Descubierta', 'Descubierta', 25),
    ( 'Zona D', 'Motos', 'Techada', 15),
    ( 'Zona E', 'Discapacitados', 'Techada', 10);




INSERT INTO Espacios
    ( Numero, Id_Nivel, Id_Zona, Tipo_Espacio)
VALUES
    ( 101, 1, 1, 'Carro'),
    ( 102, 1, 1, 'Carro'),
    ( 201, 2, 2, 'Moto'),
    ( 301, 3, 3, 'Camioneta'),
    (401, 4, 5, 'Discapacitados');




INSERT INTO Clientes
    ( Nombres, Apellidos, Documento, Telefono)
VALUES
    ( 'Juan', 'Martinez', '2001234567', '3101112233'),
    ( 'Ana', 'Torres', '2002234567', '3102223344'),
    ( 'Pedro', 'Rojas', '2003234567', '3103334455'),
    ( 'Sofia', 'Castro', '2004234567', '3104445566'),
    ( 'Diego', 'Vargas', '2005234567', '3105556677');



INSERT INTO Vehiculos
    ( Placa, Marca, Modelo, Id_Tipo)
VALUES
    ( 'ABC123', 'Chevrolet', 'Spark', 1),
    ( 'XYZ987', 'Yamaha', 'FZ', 2),
    ( 'BUS456', 'Mercedes', 'Sprinter', 3),
    ( 'CAM789', 'Toyota', 'Hilux', 4),
    ( 'BIC001', 'GW', 'Trekking', 5);




INSERT INTO Boletos
    ( Codigo, Fecha_Entrada, Hora_Entrada, Id_Vehiculo)
VALUES
    ( 'TCK-001', '2026-08-20', '07:45:00', 1),
    ( 'TCK-002', '2026-08-21', '08:10:00', 2),
    ( 'TCK-003', '2026-08-22', '09:00:00', 3),
    ( 'TCK-004', '2026-08-23', '10:30:00', 4),
    ( 'TCK-005', '2026-08-24', '11:15:00', 5);




INSERT INTO RegistroSalidas
    ( Id_Ticket, Fecha_Salida, Hora_Salida, Observacion)
VALUES
    ( 1, '2026-08-20', '12:00:00', 'Salida normal'),
    ( 2, '2026-08-21', '13:20:00', 'Salida normal'),
    ( 3, '2026-08-22', '15:00:00', 'Pago con retraso'),
    ( 4, '2026-08-23', '16:45:00', 'Salida normal'),
    ( 5, '2026-08-24', '18:00:00', 'Vehiculo dañado');




INSERT INTO Administrador
    ( Nombres, Apellidos, Documento, Telefono)
VALUES
    ( 'Carlos', 'Ramirez', '1001234567', '3001112233'),
    ( 'Laura', 'Gomez', '1002234567', '3002223344'),
    ( 'Andres', 'Perez', '1003234567', '3003334455'),
    ( 'Maria', 'Diaz', '1004234567', '3004445566'),
    ( 'Jorge', 'Lopez', '1005234567', '3005556677');




INSERT INTO Tarifas
    ( Nombre, Valor_Hora, Valor_Dia, Descripcion)
VALUES
    ( 'Tarifa Carro', 3000, 25000, 'Aplica a carros'),
    ( 'Tarifa Moto', 1500, 12000, 'Aplica a motos'),
    ( 'Tarifa Bus', 5000, 40000, 'Aplica a buses'),
    ( 'Tarifa Camioneta', 3500, 28000, 'Aplica a camionetas'),
    ( 'Tarifa Bicicleta', 1000, 8000, 'Aplica a bicicletas');




INSERT INTO Penalizaciones
    ( Id_Ticket, Motivo, Valor, Fecha)
VALUES
    ( 1, 'Exceso de tiempo', 5000, '2026-08-20'),
    ( 2, 'Espacio incorrecto', 3000, '2026-08-21'),
    ( 3, 'Perdida de ticket', 10000, '2026-08-22'),
    ( 4, 'Daño a instalaciones', 20000, '2026-08-23'),
    ( 5, 'Exceso de tiempo', 5000, '2026-08-24');




INSERT INTO Facturas
    ( Numero, Fecha, Subtotal, Total)
VALUES
    ( 'FAC-001', '2026-08-20', 25000, 25000),
    ( 'FAC-002', '2026-08-21', 12000, 12000),
    ( 'FAC-003', '2026-08-22', 40000, 50000),
    ( 'FAC-004', '2026-08-23', 28000, 48000),
    ( 'FAC-005', '2026-08-24', 8000, 13000);




INSERT INTO Pagos
    ( Id_Factura, Fecha, Valor, Metodo)
VALUES
    ( 1, '2026-08-20', 25000, 'Efectivo'),
    ( 2, '2026-08-21', 12000, 'Tarjeta'),
    ( 3, '2026-08-22', 50000, 'Transferencia'),
    ( 4, '2026-08-23', 48000, 'Efectivo'),
    ( 5, '2026-08-24', 13000, 'Tarjeta');




INSERT INTO Planes
    ( Nombre, Precio, Duracion_Dias, Descripcion)
VALUES
    ( 'Plan Mensual', 150000, 30, 'Parqueo mensual'),
    ( 'Plan Quincenal', 80000, 15, 'Parqueo quincenal'),
    ( 'Plan Semanal', 40000, 7, 'Parqueo semanal'),
    ( 'Plan Anual', 1600000, 365, 'Parqueo anual'),
    ( 'Plan Empresarial', 300000, 30, 'Varios vehiculos');




INSERT INTO Contratos
    ( Id_Cliente, Id_Plan, Fecha_Inicio, Fecha_Fin)
VALUES
    ( 1, 1, '2026-08-01', '2026-08-31'),
    ( 2, 2, '2026-08-01', '2026-08-15'),
    ( 3, 3, '2026-08-10', '2026-08-17'),
    ( 4, 4, '2026-01-01', '2026-12-31'),
    ( 5, 5, '2026-08-01', '2026-08-31');




INSERT INTO Roles
    ( Nombre)
VALUES
    ( 'Administrador'),
    ( 'Cajero'),
    ( 'Vigilante'),
    ( 'Supervisor'),
    ( 'Auxiliar');



INSERT INTO Trabajadores
    ( Nombres, Apellidos, Documento, Id_Rol)
VALUES
    ( 'Luis', 'Mora', '3001234567', 1),
    ( 'Carla', 'Nieto', '3002234567', 2),
    ( 'Oscar', 'Reyes', '3003234567', 3),
    ( 'Paula', 'Ibarra', '3004234567', 4),
    ( 'Hugo', 'Salas', '3005234567', 5);




INSERT INTO Turnos
    ( Nombre, Hora_Inicio, Hora_Fin, Descripcion)
VALUES
    ( 'Turno Mañana', '06:00:00', '14:00:00', 'Turno diurno'),
    ( 'Turno Tarde', '14:00:00', '22:00:00', 'Turno vespertino'),
    ( 'Turno Noche', '22:00:00', '06:00:00', 'Turno nocturno'),
    ( 'Turno Fin de Semana', '08:00:00', '18:00:00', 'Sabados y domingos'),
    ( 'Turno Refuerzo', '12:00:00', '16:00:00', 'Horas pico');




INSERT INTO CierreCaja
    ( Numero, Fecha_Apertura, Saldo_Inicial, Saldo_Final)
VALUES
    ( 'CIERRE-001', '2026-08-20', 50000, 250000),
    ( 'CIERRE-002', '2026-08-21', 50000, 180000),
    ( 'CIERRE-003', '2026-08-22', 50000, 210000),
    ( 'CIERRE-004', '2026-08-23', 50000, 190000),
    ( 'CIERRE-005', '2026-08-24', 50000, 230000);




INSERT INTO Promociones
    ( Nombre, Descripcion, Descuento, Fecha_Vencimiento)
VALUES
    ( 'Descuento Fin de Semana', 'Aplica sabados y domingos', 10, '2026-12-31'),
    ( 'Descuento Estudiante', 'Presentando carnet', 15, '2026-12-31'),
    ( 'Cliente Frecuente', 'Mas de 20 visitas al mes', 20, '2026-12-31'),
    ( 'Descuento Apertura', 'Primer mes de operacion', 25, '2026-09-30'),
    ( 'Descuento Plan Anual', 'Al contratar plan anual', 30, '2026-12-31');