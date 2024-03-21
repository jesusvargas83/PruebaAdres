CREATE DATABASE ADQUISICIONES

USE ADQUISICIONES


CREATE TABLE HISTORIAL(
ID INT PRIMARY KEY IDENTITY(1,1),
ID_ADQUISICION INT,
TIPO CHAR(1),
DESCRIPCION VARCHAR(MAX),
FECHA DATE
)

CREATE TABLE ADQUISICION(
ID INT PRIMARY KEY IDENTITY(1,1),
PRESUPUESTO DECIMAL(10,2),
UNIDAD_ADMINISTRATIVA VARCHAR(500),
BIENES_SERVICIOS VARCHAR(500),
CANTIDAD INT,
VALOR_UNITARIO DECIMAL(10,2),
VALOR_TOTAL DECIMAL(10,2),
FECHA_ADQUISICION DATETIME,
ENTIDAD_PROVEEDORA VARCHAR(500),
DOCUMENTACION VARCHAR(500)
)