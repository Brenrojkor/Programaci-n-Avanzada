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

>>>>>>> Brenda
