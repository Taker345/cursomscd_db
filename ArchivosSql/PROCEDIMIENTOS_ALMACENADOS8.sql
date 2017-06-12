CREATE PROCEDURE GET_MARCAS_API_ID
	@id BIGINT = NULL
AS

BEGIN
    SELECT id, denominacion
      
    FROM Marcas
	WHERE Marcas.id = @id

END