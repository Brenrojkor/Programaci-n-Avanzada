-- Crear la base de datos
CREATE DATABASE IF NOT EXISTS Pokemon;

-- Usar la base de datos creada
USE Pokemon;

-- Crear la tabla Usuarios
CREATE TABLE Usuarios (
    IdUsuario INT AUTO_INCREMENT PRIMARY KEY, -- Identificador único
    Usuario VARCHAR(50) NOT NULL,             -- Nombre de usuario
    NombreUsuario VARCHAR(100) NOT NULL,             -- Nombre completo del usuario
    Contrasena VARCHAR(255) NOT NULL,         -- Contraseña (encriptar en la aplicación para seguridad)
    Rol ENUM('Admin', 'Entrenador', 'Enfermera') NOT NULL -- Rol del usuario con valores predefinidos
);

INSERT INTO Usuarios (Usuario, NombreUsuario, Contrasena, Rol)
VALUES ('Jose1', 'JoseA', '123', 'Entrenador');

CREATE TABLE Enfermeria (
	AtencionID INT PRIMARY KEY AUTO_INCREMENT,
    NombrePokemon VARCHAR(100),
    NombreDueño VARCHAR(100),
    Padecimiento VARCHAR(100),
    Estado VARCHAR(100)
);

INSERT INTO Enfermeria (NombrePokemon, NombreDueño, Padecimiento, Estado)
VALUES ('Pikachu', 'Ash', 'Fatiga', 'Pendiente');

select * FROM Enfermeria;
select * FROM Usuarios;
select * FROM Mensajes;

-- Crear la tabla Mensajes
CREATE TABLE Mensajes (
    IdMensaje INT AUTO_INCREMENT PRIMARY KEY, -- Identificador único del mensaje
    IdUsuario INT NOT NULL,                  -- ID del usuario que envía el mensaje
    Mensaje TEXT NOT NULL,                   -- Contenido del mensaje
    Fecha DATETIME DEFAULT CURRENT_TIMESTAMP, -- Fecha y hora del mensaje
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario) -- Relación con la tabla Usuarios
);

-- Crear la tabla de Equipo
CREATE TABLE Equipo(
NombreEquipo VARCHAR(100) PRIMARY KEY,
IdUsuario INT,
FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario) -- Relación con la tabla Usuarios
);

-- Crear la tabla de Entrenador
CREATE TABLE Entrenador (
IdEntrenador INT AUTO_INCREMENT PRIMARY KEY,
NombreEntrenador VARCHAR(100),
NombreEquipo VARCHAR(100),
Nivel INT,
Estado BOOLEAN,
 FOREIGN KEY (NombreEquipo) REFERENCES Equipo(NombreEquipo) -- Relación con la tabla Equipo
);