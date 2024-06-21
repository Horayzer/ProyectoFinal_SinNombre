CREATE DATABASE ballenita;

USE ballenita;

-- Tabla CategoriaEquipo
CREATE TABLE CategoriaEquipo (
    ID_Categoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Categoria NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    Fundacion DATE,
    Ciudad NVARCHAR(100),
    Estadio NVARCHAR(100)
);

CREATE TABLE Jugador (
    ID_Jugador INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Jugador NVARCHAR(100) NOT NULL,
    Posicion NVARCHAR(50),
    Fecha_Nacimiento DATE,
    Nacionalidad NVARCHAR(50),
    ID_Categoria INT NULL, -- Clave foránea a CategoriaEquipo
    Foto_Jugador_URL NVARCHAR(MAX), -- Campo para almacenar la URL de la imagen del jugador
    FOREIGN KEY (ID_Categoria) REFERENCES CategoriaEquipo(ID_Categoria)
);

-- Tabla Partido
CREATE TABLE Partido (
    ID_Partido INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE NOT NULL,
    Hora TIME NOT NULL,
    Estadio NVARCHAR(100) NOT NULL,
    Resultado NVARCHAR(20),
    ID_Equipo INT NOT NULL, -- Equipo que juega el partido
    Es_Local BIT NOT NULL, -- 1 para local, 0 para visitante
    FOREIGN KEY (ID_Equipo) REFERENCES CategoriaEquipo(ID_Categoria)
);

-- Tabla Jugador_Partido
CREATE TABLE JugadorPartido (
    ID_Jugador INT NOT NULL,
    ID_Partido INT NOT NULL,
	Goles INT DEFAULT 0,
    PRIMARY KEY (ID_Jugador, ID_Partido),
    FOREIGN KEY (ID_Jugador) REFERENCES Jugador(ID_Jugador),
    FOREIGN KEY (ID_Partido) REFERENCES Partido(ID_Partido)
);

-- Tabla Entrenador
CREATE TABLE Entrenador (
    ID_Entrenador INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Entrenador NVARCHAR(100) NOT NULL,
    Nacionalidad NVARCHAR(50),
    ID_Categoria INT NULL,
	Foto_Entrenador_URL NVARCHAR(MAX), -- Campo para almacenar la URL de la imagen del jugador
    FOREIGN KEY (ID_Categoria) REFERENCES CategoriaEquipo(ID_Categoria)
);

-- Tabla Patrocinador
CREATE TABLE Patrocinador (
    ID_Patrocinador INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Patrocinador NVARCHAR(100) NOT NULL,
    Industria NVARCHAR(100),
    ID_Categoria INT NOT NULL,
    FOREIGN KEY (ID_Categoria) REFERENCES CategoriaEquipo(ID_Categoria)
);

-- Registros para CategoriaEquipo
INSERT INTO CategoriaEquipo (Nombre_Categoria, Descripcion, Fundacion, Ciudad, Estadio)
VALUES 
('Sub20', 'Equipo juvenil para jugadores menores de 20 años', '2005-07-15', 'Ciudad de México', 'Estadio Juvenil'),
('Amateur', 'Equipo amateur para jugadores aficionados', '1998-03-20', 'Guadalajara', 'Estadio Recreativo'),
('Femenino', 'Equipo femenino de fútbol', '2010-09-12', 'Monterrey', 'Estadio de Mujeres');

-- Registros para Entrenador
INSERT INTO Entrenador (Nombre_Entrenador, Nacionalidad, ID_Categoria, Foto_Entrenador_URL)
VALUES 
('Carlos López', 'Mexicana', 1,'https://w7.pngwing.com/pngs/134/386/png-transparent-chelsea-f-c-coach-football-player-portugal-santiago-bernabeu-stadium-others-business-formal-wear-football-player-thumbnail.png'),
('Laura Martínez', 'Mexicana', 2,'https://w7.pngwing.com/pngs/244/980/png-transparent-zinedine-zidane-real-madrid-c-f-coach-football-player-zidan.png'),
('Javier Hernández', 'Mexicana', 3,'https://w7.pngwing.com/pngs/978/1010/png-transparent-jose-mourinho-manchester-united-f-c-chelsea-f-c-coach-saying-microphone-business-formal-wear-thumbnail.png');

-- Registros para Jugador
INSERT INTO Jugador (Nombre_Jugador, Posicion, Fecha_Nacimiento, Nacionalidad, ID_Categoria, Foto_Jugador_URL)
VALUES 
('Diego Sánchez', 'Defensa', '1997-04-12', 'Mexicana', 1, 'https://i.pinimg.com/550x/41/8c/5c/418c5cd861393e75caf00f19bbc6c3e5.jpg'),
('Fernanda López', 'Delantera', '1998-09-22', 'Mexicana', 3, 'https://i.pinimg.com/originals/1a/8a/d9/1a8ad9068945f008dacd5850508564f0.jpg'),
('Ricardo Martínez', 'Portero', '1996-11-05', 'Mexicana', 2, 'https://i.pinimg.com/474x/a9/d4/fb/a9d4fb842196b7a0d57cf5fb5aab35bd.jpg'),
('Sofía García', 'Mediocampista', '1999-07-30', 'Mexicana', 1, 'https://pm1.aminoapps.com/6927/4365eb53cf2a70372698be3d04a46bd58ca1ac6br1-640-1136v2_uhq.jpg'),
('Javier Hernández', 'Defensa', '1995-03-18', 'Mexicana', 2, 'https://depor.com/resizer/8ln8SK3P_OnQ6Od1WZD1jaxZR4g=/1200x1200/smart/filters:format(jpeg):quality(75)/cloudfront-us-east-1.images.arcpublishing.com/elcomercio/LI6LM43EPBGIJNUWO7B3IJ5NHE.jpg'),
('Ana Ramírez', 'Delantera', '2000-06-25', 'Mexicana', 3, 'https://img.europapress.es/fotoweb/fotonoticia_20120109201612_1200.jpg'),
('Carlos Rodríguez', 'Portero', '1994-08-14', 'Mexicana', 1, 'https://phantom-marca.unidadeditorial.es/c08683ac43402a9b1d11a2a0d5d8fa8d/resize/828/f/jpg/assets/multimedia/imagenes/2024/01/05/17044502670832.jpg'),
('Laura Gómez', 'Mediocampista', '1997-01-20', 'Mexicana', 2, 'https://www.eluniversal.com.mx/resizer/MZ0X8mo3Cof4W415MjauQfE0-Y4=/1100x666/cloudfront-us-east-1.images.arcpublishing.com/eluniversal/XPSPNGRACZB7LOH2MDII27AGZI.jpg'),
('Pablo Martínez', 'Defensa', '2001-10-08', 'Mexicana', 1, 'https://e1.pxfuel.com/desktop-wallpaper/170/888/desktop-wallpaper-soccer-cool-soccer.jpg'),
('Marcela Pérez', 'Delantera', '1996-12-15', 'Mexicana', 3, 'https://e1.pxfuel.com/desktop-wallpaper/170/888/desktop-wallpaper-soccer-cool-soccer.jpg'),
('Andrés López', 'Portero', '1993-05-29', 'Mexicana', 2, 'https://e1.pxfuel.com/desktop-wallpaper/170/888/desktop-wallpaper-soccer-cool-soccer.jpg'),
('Valeria Hernández', 'Mediocampista', '1998-09-02', 'Mexicana', 1, 'https://e1.pxfuel.com/desktop-wallpaper/170/888/desktop-wallpaper-soccer-cool-soccer.jpg'),
('Gabriel Ramírez', 'Defensa', '2000-04-18', 'Mexicana', 2, 'https://e1.pxfuel.com/desktop-wallpaper/170/888/desktop-wallpaper-soccer-cool-soccer.jpg'),
('Jessica García', 'Delantera', '1997-11-10', 'Mexicana', 3, 'https://e1.pxfuel.com/desktop-wallpaper/170/888/desktop-wallpaper-soccer-cool-soccer.jpg'),
('Miguel Rodríguez', 'Portero', '1995-02-24', 'Mexicana', 1, 'https://e1.pxfuel.com/desktop-wallpaper/170/888/desktop-wallpaper-soccer-cool-soccer.jpg'),
('Carolina Gómez', 'Mediocampista', '1999-06-20', 'Mexicana', 2, 'https://e1.pxfuel.com/desktop-wallpaper/170/888/desktop-wallpaper-soccer-cool-soccer.jpg'),
('Alejandro Martínez', 'Defensa', '1994-10-12', 'Mexicana', 1, 'https://e1.pxfuel.com/desktop-wallpaper/170/888/desktop-wallpaper-soccer-cool-soccer.jpg'),
('Paola Pérez', 'Delantera', '1996-08-05', 'Mexicana', 3, 'https://e1.pxfuel.com/desktop-wallpaper/170/888/desktop-wallpaper-soccer-cool-soccer.jpg');

-- Registros para Partido
INSERT INTO Partido (Fecha, Hora, Estadio, Resultado, ID_Equipo, Es_Local)
VALUES 
('2024-05-10', '15:00:00', 'Estadio Juvenil', '2-1', 1, 1),
('2024-05-15', '17:30:00', 'Estadio Recreativo', '0-0', 2, 0),
('2024-05-20', '14:00:00', 'Estadio de Mujeres', NULL, 3, 1),
('2024-05-25', '16:45:00', 'Estadio Juvenil', '3-2', 1, 1),
('2024-05-30', '18:15:00', 'Estadio Recreativo', '1-1', 2, 0),
('2024-06-05', '13:30:00', 'Estadio de Mujeres', '2-0', 3, 1),
('2024-06-10', '19:00:00', 'Estadio Juvenil', NULL, 1, 1),
('2024-06-15', '20:30:00', 'Estadio Recreativo', '0-3', 2, 0),
('2024-06-20', '14:45:00', 'Estadio de Mujeres', '1-1', 3, 1),
('2024-06-25', '17:00:00', 'Estadio Juvenil', '2-1', 1, 1),
('2024-06-30', '18:45:00', 'Estadio Recreativo', '1-0', 2, 0),
('2024-07-05', '12:15:00', 'Estadio de Mujeres', NULL, 3, 1),
('2024-07-10', '20:00:00', 'Estadio Juvenil', '3-2', 1, 1),
('2024-07-15', '19:30:00', 'Estadio Recreativo', '0-0', 2, 0),
('2024-07-20', '14:45:00', 'Estadio de Mujeres', '2-1', 3, 1),
('2024-07-25', '17:30:00', 'Estadio Juvenil', '1-0', 1, 1),
('2024-07-30', '16:15:00', 'Estadio Recreativo', '0-2', 2, 0),
('2024-08-05', '13:00:00', 'Estadio de Mujeres', NULL, 3, 1),
('2024-08-10', '19:45:00', 'Estadio Juvenil', '2-2', 1, 1),
('2024-08-15', '20:30:00', 'Estadio Recreativo', '1-3', 2, 0);

-- Registros para Patrocinador
INSERT INTO Patrocinador (Nombre_Patrocinador, Industria, ID_Categoria)
VALUES 
('Tech Solutions', 'Tecnología', 1),
('Food Express', 'Alimentación', 2),
('Auto Parts', 'Automotriz', 3),
('Sport Gear', 'Deportes', 1),
('Healthy Life', 'Salud', 2),
('Travel Agency', 'Turismo', 3),
('Fashion Trends', 'Moda', 1),
('Green Energy', 'Energía', 2),
('Financial Services', 'Finanzas', 3),
('Entertainment World', 'Entretenimiento', 1),
('Construction Works', 'Construcción', 2),
('Education Hub', 'Educación', 3),
('Media Group', 'Medios', 1),
('Gaming Universe', 'Juegos', 2),
('Beauty Corner', 'Belleza', 3),
('Home Decor', 'Decoración', 1),
('Pet Care', 'Cuidado de mascotas', 2),
('Art Gallery', 'Arte', 3),
('Music Academy', 'Música', 1),
('Fitness Club', 'Fitness', 2);

-- Registros para Jugador_Partido
INSERT INTO JugadorPartido (ID_Jugador, ID_Partido)
VALUES 
(1, 1), -- Juan Pérez jugó en el partido 1
(2, 1), -- María García jugó en el partido 1
(3, 2), -- Ricardo Martínez jugó en el partido 2
(4, 2), -- Sofía García jugó en el partido 2
(5, 3), -- Javier Hernández jugó en el partido 3
(6, 3), -- Ana Ramírez jugó en el partido 3
(7, 4), -- Carlos Rodríguez jugó en el partido 4
(8, 4), -- Laura Gómez jugó en el partido 4
(9, 5), -- Pablo Martínez jugó en el partido 5
(10, 5), -- Marcela Pérez jugó en el partido 5
(11, 6), -- Andrés López jugó en el partido 6
(12, 6), -- Valeria Hernández jugó en el partido 6
(13, 7), -- Gabriel Ramírez jugó en el partido 7
(14, 7), -- Jessica García jugó en el partido 7
(15, 8), -- Miguel Rodríguez jugó en el partido 8
(16, 8), -- Carolina Gómez jugó en el partido 8
(17, 9), -- Alejandro Martínez jugó en el partido 9
(18, 9), -- Paola Pérez jugó en el partido 9
(7, 10), -- Diego Sánchez jugó en el partido 10
(18, 10), -- Fernanda López jugó en el partido 10
(1, 11), -- Juan Pérez jugó en el partido 11
(2, 11); -- María García jugó en el partido 11

Select * from JugadorPartido