/*
CONSULTAS DE SELECCION
*/

-- SELECT campo_1, campo_2, campo_3, ..., campo_n 
-- FROM tabla

-- SELECT *
-- FROM tabla

-- SELECT campo_1, campo_2, campo_3, ..., campo_n 
-- FROM tabla
-- WHERE condicion

-- SELECT *
-- FROM tabla
-- WHERE condicion op_logico condicion 

-- SELECT *
-- FROM tabla
-- ORDER BY campo orden

-- SELECT *
-- FROM tabla
-- WHERE campo LIKE 'codicion'



SELECT id, nombre, apellido, edad
FROM personas

SELECT *
FROM personas

SELECT id, nombre, apellido, edad
FROM personas
WHERE edad > 25

SELECT *
FROM personas
WHERE id > 10 AND edad >= 51

SELECT *
FROM personas
ORDER BY edad ASC

SELECT *
FROM personas
WHERE apellido LIKE 'L%'

SELECT *
FROM personas
WHERE apellido LIKE '%S'

SELECT *
FROM personas
WHERE apellido LIKE '%A%'


/*
CONSULTAS DE INSERCION
*/

-- INSERT INTO tabla (campo_1, campo_2, campo_3, ..., campo_n)
-- VALUES (valor_1, valor_2, valor_3, ..., valor_n)

-- INSERT INTO tabla
-- VALUES (valor_1, valor_2, valor_3, ..., valor_n)

INSERT INTO personas (nombre, apellido, edad)
VALUES ('nombre_nuevo', 'apellido_nuevo', 88)


/*
CONSULTAS DE MODIFICACION
*/

-- UPDATE tabla
-- SET campo_1 = valor_1, campo_2 = valor_2, campo_3 = valor_3, ..., campo_n = valor_n
-- WHERE condicion

UPDATE personas
SET nombre = 'Estebancito', apellido = 'Maravilla', edad = 90
WHERE id = 23


/*
CONSULTAS DE ELIMINACION
*/

-- DELETE FROM tabla
-- WHERE condicion

DELETE FROM personas
WHERE id = 23


