CREATE PROCEDURE GET_COCHE_POR_MARCA_ID
	@id BIGINT = NULL 
AS
BEGIN
SELECT 
      Marcas.denominacion as denominacionMarca
    , TiposCombustibles.denominacion as denominacionTipoCombustible
    , Coches.idMarca
    , Coches.idTipoCombustible
    , Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
    , Coches.fechaMatriculacion, Coches.cilindrada
FROM Marcas
    INNER JOIN Coches on Marcas.id = Coches.idMarca
    INNER JOIN TiposCombustibles on Coches.idTipoCombustible = TiposCombustibles.id
	WHERE
		Coches.id = @id
GROUP BY 
      Marcas.denominacion
    , TiposCombustibles.denominacion
    , Coches.idMarca
    , Coches.idTipoCombustible
    , Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
    , Coches.fechaMatriculacion, Coches.cilindrada
ORDER BY Marcas.denominacion
END