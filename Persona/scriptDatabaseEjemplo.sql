CREATE DATABASE PersonasDB;
GO

USE PersonasDB;
GO

CREATE TABLE TipoUsuario (
    IdTipoUsuario INT PRIMARY KEY IDENTITY(1,1), 
    Descripcion NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    NombreUsuario NVARCHAR(50) NOT NULL,
    ClaveUsuario NVARCHAR(255) NOT NULL, -- Se recomienda almacenar contraseñas en formato hash
    IdTipoUsuario INT NOT NULL,
    Activo BIT NOT NULL DEFAULT 1, -- 1 para usuarios activos, 0 para desactivados
    FOREIGN KEY (IdTipoUsuario) REFERENCES TipoUsuario(IdTipoUsuario)
);
GO

INSERT INTO TipoUsuario (Descripcion)
VALUES ('Administrador'), ('UsuarioRegular');
GO

INSERT INTO Usuario (NombreUsuario, ClaveUsuario, IdTipoUsuario)
VALUES ('rgarcia', HASHBYTES('SHA2_256', 'admin123'), 1);
GO


SELECT * FROM dbo.TipoUsuario;

SELECT * FROM dbo.Usuario;