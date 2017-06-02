-- CREAMOS UN PROCEDIMIENTO ALMACENADO
ALTER PROCEDURE GET_COCHE_POR_MARCA
AS
BEGIN
SELECT Coches.*
, Marcas.denominacion as denominacionMarca
, TiposCombustibles.denominacion as denominacionTipoCombustible
FROM Marcas
    INNER JOIN Coches on Marcas.id = Coches.idMarca
    INNER JOIN TiposCombustibles on Coches.idTipoCombustible = TiposCombustibles.id

END