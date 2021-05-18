USE MCatalogoDB
GO

INSERT INTO MCatalogoDB.dbo.Bairros (Nome, CidadeId)
SELECT B.NomeBairro, C.CidadeId FROM DbMigracao.dbo.BairrosIbge AS B LEFT JOIN MCatalogoDb.dbo.Cidades AS C ON B.CodIbgeCid = C.CodIbge
GO