-- Proyecto Progra Avanzada G2
USE u484426513_pac324;

<<<<<<< HEAD
=======
CREATE TABLE RolG2P (
	RolID INT NOT NULL PRIMARY KEY,
	NombreRol VARCHAR(50) NOT NULL
);


CREATE TABLE UsuariosG2P (
	UsuarioID INT NOT NULL PRIMARY KEY,
    NombreUsuario VARCHAR(45) UNIQUE,
	Contraseña  VARCHAR(80) NOT NULL,
    NombreCompleto VARCHAR(100),
    RolID INT, FOREIGN KEY (RolID) REFERENCES RolG2P(RolID)
);

CREATE TABLE Pokedex (
    PokedexID INT PRIMARY KEY,
    NombrePokemon VARCHAR(50) NOT NULL,
    Tipo VARCHAR(50),
    Debilidad VARCHAR(50),
    EvolucionID INT,
    Peso DECIMAL(5,2),
    Numero INT,
    FOREIGN KEY (EvolucionID) REFERENCES Pokedex(PokedexID)
);

>>>>>>> Brenda

CREATE TABLE EntrenadoresPokemons (
	EntrnadorPokemonID INT PRIMARY KEY,
	UsuarioID INT,
	PokedexID INT,
	Nivel INT,
	Estado VARCHAR(50),
	FOREIGN KEY (UsuarioID) REFERENCES UsuariosG2P(UsuarioID),
	FOREIGN KEY (PokedexID) REFERENCES Pokedex(PokedexID)
);

CREATE TABLE EquipoLucha (
	EquipoID INT PRIMARY KEY,
	UsuarioID INT,
	EntrenadorPokemonID INT,
	FOREIGN KEY (UsuarioID) REFERENCES UsuariosG2P(UsuarioID),
	FOREIGN KEY (EntrenadorPokemonID) REFERENCES EntrenadoresPokemons(EntrenadorPokemonID)
);

>>>>>>> Paola

CREATE TABLE G2_Retos (
    RetoID INT PRIMARY KEY,
    EntrenadorRetadorID INT,
    EntrenadorRetadoID INT,
    EstadoReto VARCHAR2(10) CHECK (EstadoReto IN ('Pendiente', 'Aceptado', 'Rechazado', 'Finalizado')),
    FechaReto DATE DEFAULT SYSDATE,
    FechaFinalizacion DATE,
    CONSTRAINT fk_entrenador_retador FOREIGN KEY (EntrenadorRetadorID) REFERENCES Usuarios(UsuarioID),
    CONSTRAINT fk_entrenador_retado FOREIGN KEY (EntrenadorRetadoID) REFERENCES Usuarios(UsuarioID)
);

CREATE TABLE G2_Mensajes (
    MensajeID INT PRIMARY KEY,
    UsuarioOrigenID INT,
    UsuarioDestinoID INT,
    Contenido VARCHAR(1000),
    FechaEnvio DATE DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_usuario_origen FOREIGN KEY (UsuarioOrigenID) REFERENCES Usuarios(UsuarioID),
    CONSTRAINT fk_usuario_destino FOREIGN KEY (UsuarioDestinoID) REFERENCES Usuarios(UsuarioID)
);

>>>>>>> Jose

CREATE TABLE G2_AtencionEnfermeria (
	AtencionID INT PRIMARY KEY,
    EntrnadorPokemonID INT
    FechaSolicitud DATE
    FOREIGN KEY (EntrenadorPokemonID) REFERENCES EntrenadoresPokemons(EntrenadorPokemonID)
);

CREATE TABLE G2_HistorialAtenciones (
	HistorialID INT PRIMARY KEY,
    AtencionID INT,
    FOREIGN KEY (AtencionID) REFERENCES AtencionEnfermeria(AntencionID),
    FechaAtencion DATE,
    DescripcionAtencion VARCHAR(1000)
);
