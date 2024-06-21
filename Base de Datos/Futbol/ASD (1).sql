-- Deshabilitar las restricciones de claves foráneas temporalmente
SET foreign_key_checks = 0;

-- Seguridad
ALTER USER 'root'@'localhost' IDENTIFIED WITH mysql_native_password BY 'root'; 

-- Eliminar las tablas en orden
DROP TABLE IF EXISTS Partidos;
DROP TABLE IF EXISTS Jugadores;
DROP TABLE IF EXISTS Entrenadores;
DROP TABLE IF EXISTS Divisiones;
DROP TABLE IF EXISTS Participaciones;

-- Habilitar las restricciones de claves foráneas nuevamente
SET foreign_key_checks = 1;

-- Crear base de datos
CREATE DATABASE IF NOT EXISTS Futbol;
USE Futbol;

-- Crear tabla de Divisiones
CREATE TABLE Divisiones (
    division_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre_division VARCHAR(50) NOT NULL
);

-- Crear tabla de Entrenadores
CREATE TABLE Entrenadores (
    entrenador_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NULL,
    apellido VARCHAR(100) NULL,
    nacionalidad VARCHAR(50) DEFAULT 'Desconocido',
    foto VARCHAR(300) NULL,
    fecha_contratacion DATE NULL,
    division_id INT NULL,
    FOREIGN KEY (division_id) REFERENCES Divisiones(division_id)
);

-- Crear tabla de Jugadores
CREATE TABLE Jugadores (
    jugador_id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) DEFAULT 'Desconocido',
    edad INT NOT NULL,
    posicion VARCHAR(50) NOT NULL,
    division_id INT NULL,
    nacionalidad VARCHAR(50) DEFAULT 'Desconocido',
    foto VARCHAR(300) NULL,
    FOREIGN KEY (division_id) REFERENCES Divisiones(division_id)
);

-- Crear tabla de Partidos
CREATE TABLE Partidos (
    partido_id INT AUTO_INCREMENT PRIMARY KEY,
    fecha_partido DATE NOT NULL,
    localizacion VARCHAR(255) NOT NULL,
    resultado VARCHAR(15) DEFAULT 'Pendiente'
);

-- Crear tabla de Participaciones
CREATE TABLE Participaciones (
    participacion_id INT AUTO_INCREMENT PRIMARY KEY,
    jugador_id INT NOT NULL,
    partido_id INT NOT NULL,
    minutos_jugados INT NOT NULL,
    goles INT DEFAULT 0,
    asistencias INT DEFAULT 0,
    FOREIGN KEY (jugador_id) REFERENCES Jugadores(jugador_id),
    FOREIGN KEY (partido_id) REFERENCES Partidos(partido_id)
);

-- Insertar registros en Divisiones
INSERT INTO Divisiones (nombre_division) VALUES 
('Primera División'), 
('Segunda División'), 
('Tercera División'),
('Cuarta División'), 
('Quinta División');

-- Insertar registros en Entrenadores
INSERT INTO Entrenadores (nombre, apellido, nacionalidad, foto, fecha_contratacion, division_id) VALUES 
('Carlos', 'Gomez', 'Ecuatoriana', 'http://example.com/fotos/carlos_gomez.jpg', '2020-01-15', 1), 
('Luis', 'Martinez', 'Ecuatoriana', 'http://example.com/fotos/luis_martinez.jpg', '2019-05-10', 2), 
('Juan', 'Perez', 'Ecuatoriana', 'http://example.com/fotos/juan_perez.jpg', '2021-03-20', 3),
('Federico', 'Ruiz', 'Ecuatoriana', 'http://example.com/fotos/federico_ruiz.jpg', '2021-07-22', 4), 
('Gabriel', 'Fernandez', 'Ecuatoriana', 'http://example.com/fotos/gabriel_fernandez.jpg', '2018-09-12', 5);

-- Insertar registros en Jugadores
INSERT INTO Jugadores (nombre, apellido, edad, posicion, division_id, nacionalidad, foto) VALUES 
('Jose', 'Ramirez', 21, 'Portero', 1, 'Española', 'http://example.com/fotos/jose_ramirez.jpg'), 
('Pedro', 'Lopez', 24, 'Defensa', 1, 'Argentina', 'http://example.com/fotos/pedro_lopez.jpg'), 
('Miguel', 'Hernandez', 25, 'Centrocampista', 1, 'Mexicana', 'http://example.com/fotos/miguel_hernandez.jpg'),
('Carlos', 'Diaz', 20, 'Delantero', 1, 'Chilena', 'http://example.com/fotos/carlos_diaz.jpg'), 
('Andres', 'Fernandez', 22, 'Portero', 2, 'Colombiana', 'http://example.com/fotos/andres_fernandez.jpg'), 
('Javier', 'Garcia', 24, 'Defensa', 2, 'Uruguaya', 'http://example.com/fotos/javier_garcia.jpg'), 
('Raul', 'Sanchez', 25, 'Centrocampista', 2, 'Brasileña', 'http://example.com/fotos/raul_sanchez.jpg'),
('Manuel', 'Martinez', 27, 'Delantero', 2, 'Peruana', 'http://example.com/fotos/manuel_martinez.jpg'), 
('Sergio', 'Gonzalez', 21, 'Portero', 3, 'Ecuatoriana', 'http://example.com/fotos/sergio_gonzalez.jpg'), 
('David', 'Rodriguez', 24, 'Defensa', 3, 'Venezolana', 'http://example.com/fotos/david_rodriguez.jpg'),
('Pablo', 'Cruz', 24, 'Centrocampista', 3, 'Paraguaya', 'http://example.com/fotos/pablo_cruz.jpg'), 
('Fernando', 'Morales', 22, 'Delantero', 3, 'Boliviana', 'http://example.com/fotos/fernando_morales.jpg'), 
('Luis', 'Vargas', 20, 'Portero', 1, 'Mexicana', 'http://example.com/fotos/luis_vargas.jpg'),
('Antonio', 'Castro', 25, 'Defensa', 2, 'Argentina', 'http://example.com/fotos/antonio_castro.jpg'), 
('Mario', 'Soto', 20, 'Centrocampista', 3, 'Española', 'http://example.com/fotos/mario_soto.jpg'),
('Diego', 'Alvarez', 21, 'Portero', 1, 'Colombiana', 'http://example.com/fotos/diego_alvarez.jpg'), 
('Martin', 'Paredes', 23, 'Defensa', 2, 'Uruguaya', 'http://example.com/fotos/martin_paredes.jpg'), 
('Victor', 'Ramos', 23, 'Centrocampista', 3, 'Brasileña', 'http://example.com/fotos/victor_ramos.jpg'),
('Jorge', 'Morales', 22, 'Delantero', 4, 'Peruana', 'http://example.com/fotos/jorge_morales.jpg'), 
('Luis', 'Perez', 21, 'Mediapunta', 1, 'Ecuatoriana', 'http://example.com/fotos/luis_perez.jpg'), 
('Fernando', 'Gonzalez', 25, 'Lateral', 2, 'Venezolana', 'http://example.com/fotos/fernando_gonzalez.jpg'), 
('Javier', 'Martinez', 22, 'Centrocampista', 3, 'Paraguaya', 'http://example.com/fotos/javier_martinez.jpg'),
('Carlos', 'Fernandez', 24, 'Delantero', 4, 'Boliviana', 'http://example.com/fotos/carlos_fernandez.jpg'), 
('Santiago', 'Gutierrez', 22, 'Portero', 5, 'Chilena', 'http://example.com/fotos/santiago_gutierrez.jpg'), 
('Daniel', 'Lopez', 20, 'Defensa', 1, 'Española', 'http://example.com/fotos/daniel_lopez.jpg'),
('Alejandro', 'Garcia', 21, 'Centrocampista', 2, 'Argentina', 'http://example.com/fotos/alejandro_garcia.jpg'), 
('Roberto', 'Sanchez', 26, 'Delantero', 3, 'Mexicana', 'http://example.com/fotos/roberto_sanchez.jpg'), 
('Miguel', 'Castro', 23, 'Mediapunta', 4, 'Colombiana', 'http://example.com/fotos/miguel_castro.jpg'),
('Oscar', 'Romero', 22, 'Lateral', 5, 'Brasileña', 'http://example.com/fotos/oscar_romero.jpg'), 
('Antonio', 'Navarro', 21, 'Lateral', 1, 'Venezolana', 'http://example.com/fotos/antonio_navarro.jpg');

-- Insertar registros en Partidos
INSERT INTO Partidos (fecha_partido, localizacion, resultado) VALUES 
('2022-01-15', 'Estadio Nacional', '2-1'), 
('2022-02-20', 'Estadio Municipal', '1-3'), 
('2022-03-10', 'Estadio Olímpico', '0-0'),
('2022-04-25', 'Estadio Regional', '3-2'), 
('2022-05-30', 'Estadio Central', '1-1'),
('2022-06-12', 'Estadio Nacional', '2-2'), 
('2022-07-20', 'Estadio Municipal', '3-1'), 
('2022-08-10', 'Estadio Olímpico', '1-1'),
('2022-09-25', 'Estadio Regional', '4-2'), 
('2022-10-30', 'Estadio Central', '0-0');

-- Insertar registros en Participaciones
INSERT INTO Participaciones (jugador_id, partido_id, minutos_jugados, goles, asistencias) VALUES
(1, 1, 90, 1, 0),
(2, 1, 85, 0, 1),
(3, 2, 70, 0, 2),
(4, 2, 90, 2, 1),
(5, 3, 75, 0, 0),
(6, 3, 90, 1, 1),
(7, 4, 90, 0, 0),
(8, 4, 80, 2, 0),
(9, 5, 85, 1, 1),
(10, 5, 90, 0, 0),
(11, 6, 90, 0, 0),
(12, 6, 70, 1, 1),
(13, 7, 80, 2, 0),
(14, 7, 90, 0, 1),
(15, 8, 90, 0, 0),
(16, 8, 85, 1, 1),
(17, 9, 90, 2, 1),
(18, 9, 75, 0, 0),
(19, 10, 90, 1, 0),
(20, 10, 85, 0, 1);