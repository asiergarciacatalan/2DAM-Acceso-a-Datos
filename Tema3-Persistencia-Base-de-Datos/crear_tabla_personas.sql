USE AccesoDatos;
GO

CREATE TABLE Personas (
    Id      INT IDENTITY(1,1) PRIMARY KEY,    -- autonumérico + clave primaria
    Nombre  NVARCHAR(100) NOT NULL,
    Email   NVARCHAR(150) NOT NULL,
    Edad    INT CHECK (Edad >= 0),            -- restricción: edad no negativa
    Activo  BIT NOT NULL DEFAULT 1            -- borrado lógico (§3.4.2)
);
GO

-- Datos de prueba
INSERT INTO Personas (Nombre, Email, Edad) VALUES
    (N'Ana López',  N'ana@correo.com',   22),
    (N'Luis Pérez', N'luis@correo.com',  17),
    (N'Marta Ruiz', N'marta@correo.com', 35);