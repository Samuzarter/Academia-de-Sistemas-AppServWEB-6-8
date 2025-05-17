CREATE DATABASE [Academia_Sistemas]
GO

USE [Academia_Sistemas]
GO

CREATE TABLE [Proveedores](
IdProveedor INT IDENTITY(1,1) PRIMARY KEY,
Nombre NVARCHAR(100) NOT NULL,
Telefono NVARCHAR(20) NOT NULL, 
Correo NVARCHAR(100) NOT NULL,
Direccion NVARCHAR(150) NOT NULL,
);
GO

CREATE TABLE [CategoriasCursos](
IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
Nombre NVARCHAR(100) NOT NULL,
Descripcion NVARCHAR(200),
);
GO

CREATE TABLE [Modalidades](
IdModalidad INT IDENTITY(1,1) PRIMARY KEY,
Nombre NVARCHAR(100) NOT NULL,
);
GO

CREATE TABLE [Estudiantes](
IdEstudiante INT IDENTITY(1,1) PRIMARY KEY,
Nombre NVARCHAR(100) NOT NULL,
Apellido NVARCHAR(100) NOT NULL,
Correo NVARCHAR(100) NOT NULL,
Telefono NVARCHAR(20) NOT NULL, 
Direccion NVARCHAR(150) NOT NULL,
);
GO

CREATE TABLE [Instructores](
Idinstructor INT IDENTITY(1,1) PRIMARY KEY,
Nombre NVARCHAR(100) NOT NULL,
Apellido NVARCHAR(100) NOT NULL,
Correo NVARCHAR(100) NOT NULL,
Telefono NVARCHAR(20) NOT NULL, 
Especialidad NVARCHAR(100) NOT NULL,
);
GO

CREATE TABLE [Sedes](
IdSede INT IDENTITY(1,1) PRIMARY KEY,
Nombre NVARCHAR(100) NOT NULL,
Ciudad NVARCHAR(100) NOT NULL,
Direccion NVARCHAR(150) NOT NULL,
Telefono NVARCHAR(20) NOT NULL, 
);
GO

CREATE TABLE [Equipos](
IdEquipo INT IDENTITY(1,1) PRIMARY KEY,
Nombre NVARCHAR(100) NOT NULL,
Descripcion NVARCHAR(200) NOT NULL,
Categoria NVARCHAR(100) NOT NULL,
);
GO

-------FK-------------
CREATE TABLE [Compras](
IdCompra INT IDENTITY(1,1) PRIMARY KEY,
IdProveedor INT,
IdEquipo INT,
FechaCompra DATETIME NOT NULL, 
Cantidad INT NOT NULL,
CostoUnitario DECIMAL(10,2) NOT NULL,

FOREIGN KEY (IdProveedor) REFERENCES Proveedores(IdProveedor),
FOREIGN KEY (IdEquipo) REFERENCES Equipos(IdEquipo),
);
GO

CREATE TABLE [InventarioEquipos](
IdInventario INT IDENTITY(1,1) PRIMARY KEY,
IdEquipo INT,
IdSede INT, 
Cantidad INT NOT NULL,
FechaAsignacion DATETIME NOT NULL,

FOREIGN KEY (IdEquipo) REFERENCES Equipos(IdEquipo),
FOREIGN KEY (IdSede) REFERENCES Sedes(IdSede),
);
GO

CREATE TABLE [Cursos](
IdCurso INT IDENTITY(1,1) PRIMARY KEY,
IdModalidad INT,
IdCategoria INT,
Nombre NVARCHAR(100) NOT NULL,
Descripcion NVARCHAR(200) NOT NULL,
Duracion INT NOT NULL,
Costo DECIMAL(10,2) NOT NULL,

FOREIGN KEY (IdModalidad) REFERENCES Modalidades(IdModalidad),
FOREIGN KEY (IdCategoria) REFERENCES CategoriasCursos(IdCategoria),
);
GO

CREATE TABLE [ProgramacionesCursos](
IdProgramacion INT IDENTITY(1,1) PRIMARY KEY,
IdCurso INT,
IdSede INT,
FechaInicio DATETIME NOT NULL, 
FechaFin DATETIME NOT NULL,
Cupos INT NOT NULL,

FOREIGN KEY (IdCurso) REFERENCES Cursos(IdCurso),
FOREIGN KEY (IdSede) REFERENCES Sedes(IdSede),
);
GO

CREATE TABLE [AsignacionInstructores](
IdAsignacion INT IDENTITY(1,1) PRIMARY KEY,
IdInstructor INT,
IdProgramacion INT,
FechaAsignacion DATETIME NOT NULL, 

FOREIGN KEY (IdInstructor) REFERENCES Instructores(IdInstructor),
FOREIGN KEY (IdProgramacion) REFERENCES ProgramacionesCursos(IdProgramacion),
);
GO

CREATE TABLE [Inscripciones](
IdInscripcion INT IDENTITY(1,1) PRIMARY KEY,
IdEstudiante INT,
IdProgramacion INT,
FechaInscripcion DATETIME NOT NULL, 

FOREIGN KEY (IdEstudiante) REFERENCES Estudiantes(IdEstudiante),
FOREIGN KEY (IdProgramacion) REFERENCES ProgramacionesCursos(IdProgramacion),
);
GO

CREATE TABLE [Calificaciones](
IdCalificacion INT IDENTITY(1,1) PRIMARY KEY,
IdInscripcion INT,
Nota DECIMAL(5,2) NOT NULL,
Observaciones NVARCHAR(200) NOT NULL,

FOREIGN KEY (IdInscripcion) REFERENCES Inscripciones(IdInscripcion),
);
GO

CREATE TABLE [Pagos](
IdCPago INT IDENTITY(1,1) PRIMARY KEY,
IdInscripcion INT,
FechaPago DATETIME NOT NULL, 
Monto DECIMAL(10,2) NOT NULL,
MetodoPago NVARCHAR(50) NOT NULL,

FOREIGN KEY (IdInscripcion) REFERENCES Inscripciones(IdInscripcion),
);
GO


