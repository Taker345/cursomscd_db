alter procedure GET_COCHE_POR_MARCA_MATRICULA_PLAZAS_2
	 @marca nvarchar(50) = NULL 
	,@nPlazas smallint = NULL 
AS
BEGIN
    SELECT 
         M.denominacion as Marca
        ,C.matricula
        ,C.nPlazas
    FROM Marcas M
        INNER JOIN Coches C ON M.id = C.idMarca
		where 
		(m.denominacion LIKE '%' + @marca + '%' or @marca is null)
		and	(C.nPlazas >= @nPlazas or @nPlazas is null)
    ORDER BY nPlazas
END