CREATE DATABASE BibliotecaVirtualBD;
GO

USE BibliotecaVirtualBD;
GO

CREATE TABLE [dbo].[Usuarios]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Nusuario] NVARCHAR(50) NULL,
    [Contrasena] NVARCHAR(50) NULL,
    [Rol] NVARCHAR(50) NULL
);
GO

CREATE TABLE [dbo].[Contactos]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Nombre] VARCHAR(50) NULL,
    [Apellido] VARCHAR(50) NULL,
    [Telefono] VARCHAR(50) NULL,
    [Correo] VARCHAR(50) NULL
);
GO

INSERT INTO Usuarios(Nusuario, Contrasena, Rol)
VALUES
('chacon', 'abc123', 'admin'),
('Bvalverde', '456', 'admin'),
('camacho', 'xyz', 'user');
GO

INSERT INTO Contactos(Nombre, Apellido, Telefono, Correo)
VALUES
('Juego de tronos', 'George RR Martin', 'Fantasia', 'F-107'),
('Dune', 'Frank Herbert', 'Sci Fi', 'SF-56'),
('Orgullo y prejuicio', 'Jane Austen', 'Romance', 'R-453'),
('El resplandor', 'Stephen King', 'Terror', 'T-340');
GO