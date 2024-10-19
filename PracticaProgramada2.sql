<<<<<<< HEAD
/*Grupo2*/
=======
/*Grupo2*/

CREATE TABLE Usuarios (
Id_Usuario INT PRIMARY KEY,
Nombre VARCHAR(50) NOT NULL,
Apellidos VARCHAR(100) NOT NULL,
Correo VARCHAR(100) NOT NULL,
Telefono VARCHAR(20) NOT NULL,
Provincia VARCHAR(10) NOT NULL,
Fecha_Nacimiento DATE
);

INSERT INTO Usuarios (Id_Usuario, Nombre, Apellidos, Correo, Telefono, Provincia, Fecha_Nacimiento) VALUES 
(1, 'Carlos', 'Fernández García', 'carlos.fernandez@gmail.com', '82345678', 'Guanacaste', '1990-05-15'),
(2, 'Laura', 'Martínez Pérez', 'laura.martinez@yahoo.com', '78765432', 'Heredia', '1985-07-22'),
(3, 'María', 'López Sánchez', 'maria.lopez@hotmail.com', '85544433', 'Cartago', '1992-03-10'),
(4, 'Juan', 'González Rodríguez', 'juan.gonzalez@outlook.com', '61122233', 'Alajuela', '1988-12-01'),
(5, 'Ana', 'Ramírez Gómez', 'ana.ramirez@gmail.com', '74455566', 'Puntarenas', '1995-09-18'),
(6, 'Pedro', 'Torres Jiménez', 'pedro.torres@icloud.com', '22233344', 'Limon', '1991-11-03');
>>>>>>> Paola

CREATE TABLE Playlists (
    Id_Playlist INT AUTO_INCREMENT PRIMARY KEY,
    Nombre_Playlist VARCHAR(100) NOT NULL,
    Nombre_Creador VARCHAR(100) NOT NULL,
    Descripcion_Playlist VARCHAR(100) NOT NULL,
    Genero_Playlist VARCHAR(100) NOT NULL,
    Fecha_Creacion DATE
);

INSERT INTO Playlists (Id_Playlist, Nombre_Playlist, Nombre_Creador, Descripcion_Playlist, Genero_Playlist, Fecha_Creacion) VALUES
	(1, '50 Cent Hits', 'Yarious', 'Mejores temas de 50 Cent', 'Hip hop', '2019-01-12'),
	(2, 'Gym Worksongs', 'Verónica', 'Música para hacer gym', 'Varios', '2020-02-29'),
	(3, 'Cinema Songs', 'Fabián', 'Música popular de películas', 'Varios', '2021-03-25'),
	(4, 'Korean Hits', 'Brenda', 'Canciones del género regional de Korea', 'K-pop', '2022-04-15'),
	(5, 'Classic Rock', 'Daniel', 'Rock clásico de los 60s/70s/80s', 'rock', '2023-05-19'),
	(6, 'World Music', 'Mariana', 'Música del mundo', 'worldbeat', '2024-06-21');
