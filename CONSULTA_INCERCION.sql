-- CONSULTAS PARA HACER INSECIONES EN UNA TABLE
INSERT INTO ServiceImages
(idService, imageUrl)
VALUES ('C2133C0A-06C4-4DF8-A862-9EB1A9D63825', 'http://')

-- CONSULTA PARA INSERCIONES MASIVAS INSER - SELECT
INSERT INTO ServiceImages (idService, imageUrl)
SELECT idService, imageUrl FROM ServiceImages

-- CREAR UNA TABLA A PARTIR DE UNA SELECT


SELECT * INTO ServicesImagesTemporal FROM ServiceImages

SELECT * FROM ServicesImagesTemporal