-- CREAMOS UNA VISTA PARA CONTRAR EL Nº DE COCHES POR MARCAS

CREATE VIEW V_N_COCHES_POR_MARCA AS

SELECT M.denominacion as Marcas, count(C.id) as nCoches FROM Marcas M
				LEFT JOIN Coches C ON M.id = c.idMarca
				 
				GROUP BY M.denominacion