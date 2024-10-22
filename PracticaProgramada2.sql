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

CREATE TABLE Canciones (
Id_Cancion INT PRIMARY KEY,
Titulo VARCHAR(50) NOT NULL,
Artista VARCHAR(100) NOT NULL,
Id_Usuario INT, FOREIGN KEY (Id_Usuario) REFERENCES Usuarios(Id_Usuario)
);

INSERT INTO Usuarios (Id_Usuario, Nombre, Apellidos, Correo, Telefono, Provincia, Fecha_Nacimiento) VALUES 
(1, 'Carlos', 'Fernández García', 'carlos.fernandez@gmail.com', '82345678', 'Guanacaste', '1990-05-15'),
(2, 'Laura', 'Martínez Pérez', 'laura.martinez@yahoo.com', '78765432', 'Heredia', '1985-07-22'),
(3, 'María', 'López Sánchez', 'maria.lopez@hotmail.com', '85544433', 'Cartago', '1992-03-10'),
(4, 'Juan', 'González Rodríguez', 'juan.gonzalez@outlook.com', '61122233', 'Alajuela', '1988-12-01'),
(5, 'Ana', 'Ramírez Gómez', 'ana.ramirez@gmail.com', '74455566', 'Puntarenas', '1995-09-18'),
(6, 'Pedro', 'Torres Jiménez', 'pedro.torres@icloud.com', '22233344', 'Limon', '1991-11-03');

INSERT INTO Canciones (Id_Cancion,Titulo, Artista, Id_Usuario ) VALUES 
(1, 'Espresso', 'Sabrina Carpenter', 2),
(2, 'Neva Play', 'Megan the Stallion ft RM', 5),
(3, 'Black Out', 'Park Chanyeol', 3),
(4, 'Burbujas de Cristal', 'Cartel de Santa', 1),
(5, 'Older', 'Isabel LaRosa', 4),
(6, 'do re mi', 'blackbear', 6);