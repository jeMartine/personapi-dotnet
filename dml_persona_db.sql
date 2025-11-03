USE persona_db;
GO

-- DATOS DE PERSONA
INSERT INTO persona (cc, nombre, apellido, genero, edad)
VALUES 
(1001, 'Carlos', 'Pérez', 'M', 30),
(1002, 'Laura', 'Gómez', 'F', 25),
(1003, 'Andrés', 'Martínez', 'M', 40),
(1004, 'Sofía', 'Ramírez', 'F', 35);
GO

-- DATOS DE PROFESION
INSERT INTO profesion (id, nom, des)
VALUES
(1, 'Ingeniero de Sistemas', 'Diseña y desarrolla software.'),
(2, 'Médico', 'Profesional en medicina.'),
(3, 'Abogado', 'Especialista en derecho civil y penal.'),
(4, 'Arquitecto', 'Diseña y dirige proyectos arquitectónicos.');
GO

-- DATOS DE ESTUDIOS
-- (id_prof, cc_per, fecha, univer)
INSERT INTO estudios (id_prof, cc_per, fecha, univer)
VALUES
(1, 1001, '2018-06-20', 'Universidad Nacional'),
(2, 1002, '2020-07-15', 'Pontificia Universidad Javeriana'),
(4, 1004, '2015-11-30', 'Universidad del Valle'),
(3, 1003, '2010-05-10', 'Universidad de los Andes');
GO

-- DATOS DE TELEFONO
-- (num, oper, duenio)
INSERT INTO telefono (num, oper, duenio)
VALUES
('3001234567', 'Claro', 1001),
('3107654321', 'Movistar', 1002),
('3111112233', 'Tigo', 1003),
('3209998877', 'Claro', 1004);
GO
