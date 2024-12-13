CREATE DATABASE IF NOT EXISTS Pokemon;

USE Pokemon;

CREATE TABLE Usuarios 
(
    IdUsuario			INT AUTO_INCREMENT PRIMARY KEY,
    Usuario 			VARCHAR(50) NOT NULL, 
    NombreUsuario 		VARCHAR(100) NOT NULL,
    Contrasena 			VARCHAR(255) NOT NULL,
    Rol 				ENUM('Admin', 'Entrenador', 'Enfermera') NOT NULL
);

INSERT INTO Usuarios (Usuario, NombreUsuario, Contrasena, Rol)
VALUES 
('Jose1', 'JoseA', '123', 'Entrenador'),
('Paola', 'Pao', '1234', 'Entrenador'),
('Bren', 'BrenK', '12345', 'Enfermera'),
('Cris', 'CrisR', '123456', 'Entrenador');

SELECT * FROM Usuarios;

CREATE TABLE Enfermeria 
(
	AtencionID			INT PRIMARY KEY AUTO_INCREMENT,
    NombrePokemon 		VARCHAR(100),
    NombreDueño 		VARCHAR(100),
    Padecimiento 		VARCHAR(100),
    Estado 				VARCHAR(100)
);

INSERT INTO Enfermeria (NombrePokemon, NombreDueño, Padecimiento, Estado)
VALUES 
('Pikachu', 'Ash', 'Fatiga', 'Pendiente'),
('Charizard', 'Brock', 'Insomnio', 'Pendiente'),
('Butterfree', 'Mitsy', 'Escalofríos', 'Pendiente'),
('Pidgeotto', 'Todd', 'Fiebre', 'Pendiente');

SELECT * FROM Enfermeria;

CREATE TABLE Mensajes 
(
    IdMensaje			INT AUTO_INCREMENT PRIMARY KEY,
    IdUsuario 			INT NOT NULL,
    Mensaje 			TEXT NOT NULL,
    Fecha 				DATETIME DEFAULT CURRENT_TIMESTAMP, 
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
);

CREATE TABLE Equipo 
(
	NombreEquipo		VARCHAR(100) PRIMARY KEY,
	IdUsuario			INT,
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario) 
);

INSERT INTO Equipo (NombreEquipo, IdUsuario)
VALUES
('Team A', '1'),
('Team B', '2'),
('Team C', '1'),
('Team D', '2');

SELECT * FROM Equipo;

CREATE TABLE Entrenador 
(
	IdEntrenador		INT AUTO_INCREMENT PRIMARY KEY,
	NombreEntrenador 	VARCHAR(100),
	NombreEquipo 		VARCHAR(100),
	Nivel 				INT,
	Estado 				BOOLEAN,
	FOREIGN KEY (NombreEquipo) REFERENCES Equipo(NombreEquipo)
);

INSERT INTO Entrenador (NombreEntrenador, NombreEquipo, Nivel, Estado)
VALUES
('Entrenador 1', 'Team A', 3, TRUE),
('Entrenador 2', 'Team B', 2, FALSE),
('Entrenador 3', 'Team A', 1, TRUE),
('Entrenador 4', 'Team B', 4, TRUE),
('Entrenador 5', 'Team A', 2, FALSE),
('Entrenador 6', 'Team B', 3, TRUE),
('Entrenador 7', 'Team A', 2, TRUE),
('Entrenador 8', 'Team B', 1, FALSE),
('Entrenador 9', 'Team A', 4, TRUE),
('Entrenador 10', 'Team B', 3, TRUE);

SELECT * FROM Entrenador;