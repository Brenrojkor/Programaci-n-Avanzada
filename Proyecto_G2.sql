CREATE DATABASE IF NOT EXISTS Pokemons;

USE Pokemons;

CREATE TABLE Usuarios 
(
    IdUsuario			INT AUTO_INCREMENT PRIMARY KEY,
    Usuario 			VARCHAR(50) NOT NULL, 
    NombreUsuario 		VARCHAR(100) NOT NULL,
    Contrasena 			VARCHAR(255) NOT NULL,
    Rol 				ENUM('Admin', 'Entrenador', 'Enfermera') NOT NULL
);

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
('Butterfree', 'Misty', 'Escalofríos', 'Pendiente'),
('Pidgeotto', 'Todd', 'Fiebre', 'Pendiente'),
('Bulbasaur', 'Ash', 'Herida en hoja', 'Pendiente'),
('Squirtle', 'Misty', 'Deshidratación', 'Pendiente'),
('Jigglypuff', 'Jessie', 'Pérdida de voz', 'Pendiente'),
('Meowth', 'James', 'Estrés', 'Pendiente');

SELECT * FROM Enfermeria;

CREATE TABLE Mensajes 
(
    IdMensaje			INT AUTO_INCREMENT PRIMARY KEY,
    IdUsuario 			INT NOT NULL,
    Mensaje 			TEXT NOT NULL,
    Fecha 				DATETIME DEFAULT CURRENT_TIMESTAMP, 
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
);

SELECT * FROM Equipo;

CREATE TABLE Entrenador 
(
	IdEntrenador		INT AUTO_INCREMENT PRIMARY KEY,
	NombreEntrenador 	VARCHAR(100),
	NombreEquipo 		VARCHAR(100),
	Nivel 				INT,
	Estado 				BOOLEAN
);

INSERT INTO Entrenador (NombreEntrenador, NombreEquipo, Nivel, Estado)
VALUES
('Ash Ketchum', 'Pikachu Squad', 3, TRUE),
('Brock', 'Charizard Crew', 2, FALSE),
('Misty', 'Squirtle Squad', 1, TRUE),
('Tracey Sketchit', 'Dragonite Force', 4, TRUE),
('May', 'Blaziken Team', 2, FALSE),
('Dawn', 'Piplup Party', 3, TRUE),
('Iris', 'Haxorus Clan', 2, TRUE),
('Cilan', 'Leavanny League', 1, FALSE),
('Serena', 'Sylveon Squad', 4, TRUE),
('Clemont', 'Luxray Force', 3, TRUE);

SELECT * FROM Entrenador;