-- CREAMOS UN PROCEDIMIENTO ALMACENADO
ALTER PROCEDURE GET_COCHE_POR_MARCA
AS
BEGIN
    SELECT Coches.*, Marcas.denominacion as denominacionMarca
    FROM Marcas
        INNER JOIN Coches on Marcas.id = Coches.idMarca
    --PRINT 'MI PRIMER PROCEDIMIENTO ALMACENADO'
END