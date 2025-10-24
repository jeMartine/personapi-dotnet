CREATE DATABASE persona_db;
GO

USE persona_db;
GO
  
-- TABLA: persona
CREATE TABLE persona (
    cc INT PRIMARY KEY,
    nombre VARCHAR(45) NOT NULL,
    apellido VARCHAR(45) NOT NULL,
    genero CHAR(1) CHECK (genero IN ('M', 'F')),
    edad INT CHECK (edad >= 0)
);
GO

-- TABLA: profesion
CREATE TABLE profesion (
    id INT PRIMARY KEY,
    nom VARCHAR(90) NOT NULL,
    des TEXT
);
GO

-- TABLA: estudios
CREATE TABLE estudios (
    id_prof INT NOT NULL,
    cc_per INT NOT NULL,
    fecha DATE,
    univer VARCHAR(50),
    CONSTRAINT pk_estudios PRIMARY KEY (id_prof, cc_per),
    CONSTRAINT fk_estudio_profesion FOREIGN KEY (id_prof)
        REFERENCES profesion(id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    CONSTRAINT fk_estudio_persona FOREIGN KEY (cc_per)
        REFERENCES persona(cc)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);
GO

-- TABLA: telefono
CREATE TABLE telefono (
    num VARCHAR(15) PRIMARY KEY,
    oper VARCHAR(45),
    duenio INT,
    CONSTRAINT fk_telefono_persona FOREIGN KEY (duenio)
        REFERENCES persona(cc)
        ON DELETE SET NULL
        ON UPDATE CASCADE
);
GO
