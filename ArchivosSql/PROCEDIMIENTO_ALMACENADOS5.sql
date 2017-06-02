-- CREAMOS UN PROCEDIMIENTO ALMACENADO
ALTER PROCEDURE GET_COCHE_POR_MARCA
AS
BEGIN
SELECT 
      Marcas.denominacion as denominacionMarca
    , Coches.idMarca
    , Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
    , Coches.fechaMatriculacion, Coches.cilindrada
FROM Marcas
    INNER JOIN Coches on Marcas.id = Coches.idMarca
    INNER JOIN TiposCombustibles on Coches.idTipoCombustible = TiposCombustibles.id
GROUP BY 
      Marcas.denominacion
	 , Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
     , Coches.idMarca 
    , Coches.fechaMatriculacion, Coches.cilindrada
ORDER BY Marcas.denominacion
END