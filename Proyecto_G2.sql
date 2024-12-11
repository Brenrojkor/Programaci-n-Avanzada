CREATE DATABASE POKEMON;

-- Proyecto Progra Avanzada G2
USE POKEMON;

/* HEAD */

CREATE TABLE Usuarios (
	UsuarioID INT NOT NULL PRIMARY KEY,
    NombreUsuario VARCHAR(45) UNIQUE,
	Contraseña  VARCHAR(80) NOT NULL,
    NombreCompleto VARCHAR(100)
);

CREATE TABLE Pokedex (
    PokedexID INT PRIMARY KEY,
    NombrePokemon VARCHAR(50) NOT NULL,
    Tipo VARCHAR(50),
    Debilidad VARCHAR(50),
    EvolucionID INT,
    Peso DECIMAL(5,2),
    Numero INT,
    FOREIGN KEY (EvolucionID) REFERENCES G2_Pokedex(PokedexID)
);

/* Brenda */

CREATE TABLE Entrenadores (
	EntrnadorPokemonID INT PRIMARY KEY,
	NombreEntrenador VARCHAR(100),
    NombreEquipo VARCHAR(100),
	Nivel INT,
	Estado VARCHAR(50)
);

CREATE TABLE Equipos (
	EquipoID INT PRIMARY KEY,
    NombreEquipo VARCHAR(100),
	UsuarioID INT,
	FOREIGN KEY (UsuarioID) REFERENCES G2_Usuario(UsuarioID)
);

/* Paola */

CREATE TABLE Retos (
    RetoID INT PRIMARY KEY,
    EntrenadorRetadorID INT,
    EntrenadorRetadoID INT,
    EstadoReto VARCHAR(10) CHECK (EstadoReto IN ('Pendiente', 'Aceptado', 'Rechazado', 'Finalizado')),
    FechaReto DATE,
    FechaFinalizacion DATE,
    CONSTRAINT fk_entrenador_retador FOREIGN KEY (EntrenadorRetadorID) REFERENCES G2_Usuario(UsuarioID),
    CONSTRAINT fk_entrenador_retado FOREIGN KEY (EntrenadorRetadoID) REFERENCES G2_Usuario(UsuarioID)
);

CREATE TABLE Mensajes (
    MensajeID INT PRIMARY KEY,
    UsuarioOrigenID INT,
    UsuarioDestinoID INT,
    Contenido VARCHAR(1000),
    FechaEnvio DATE DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_usuario_origen FOREIGN KEY (UsuarioOrigenID) REFERENCES G2_Usuario(UsuarioID),
    CONSTRAINT fk_usuario_destino FOREIGN KEY (UsuarioDestinoID) REFERENCES G2_Usuario(UsuarioID)
);

/* Jose */

CREATE TABLE Enfermeria (
	AtencionID INT PRIMARY KEY AUTO_INCREMENT,
    NombrePokemon VARCHAR(100),
    NombreDueño VARCHAR(100),
    Padecimiento VARCHAR(100),
    Estado VARCHAR(100)
);

CREATE TABLE Historial (
	HistorialID INT PRIMARY KEY,
    NombrePokemon VARCHAR(100),
    NombreDueño VARCHAR(100),
    Padecimiento VARCHAR(100),
    Estado VARCHAR(100)
);

/* Cristopher */


INSERT INTO Enfermeria (AtencionID, NombrePokemon, NombreDueño, Padecimiento, Estado) VALUES
	('1', 'Pikachu', 'Ash Ketchum', 'Lesionado', 'Recuperado'),
	('2', 'Charmeleon', 'Ash Ketchum', 'Quemado', 'Pendiente'),
	('3', 'Squirtle', 'Ash Ketchum', 'Ahogado', 'Recuperado');
    
SELECT * FROM Enfermeria;