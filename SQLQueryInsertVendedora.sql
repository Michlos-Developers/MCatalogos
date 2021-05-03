DECLARE @EstadoCivilString VARCHAR(10) = 'Solteiro'
DECLARE @EstadoCivilInt INT
SELECT @EstadoCivilInt = EstadoCivilId FROM EstadosCivis WHERE EstadoCivil = @EstadoCivilString

DECLARE @EstadoString VARCHAR(2) = 'DF'
DECLARE @EstadoInt INT
SELECT @EstadoInt = EstadoId FROM Estados WHERE Uf = @EstadoString

DECLARE @CidadeString VARCHAR(300) = 'Brasília'
DECLARE @CidadeInt INT
SELECT @CidadeInt = CidadeId FROM Cidades WHERE Nome = @CidadeString

DECLARE @BairroString VARCHAR(300) = 'Riacho Fundo'
DECLARE @BairroInt INT
SELECT @BairroInt = BairroId FROM Bairros WHERE Nome = @BairroString

DECLARE @TipoTelefoneString VARCHAR(10) = 'Oi'
DECLARE @TipoTelefoneInt INT
SELECT @TipoTelefoneInt = TipoId FROM TiposTelefones WHERE TipoTelefone = @TipoTelefoneString

INSERT INTO Vendedoras 
(Nome,					Cpf,			Rg,			RgEmissor,	DataNascimento, Email,					NomePai,			NomeMae,		NomeConjuge,	Logradouro,			Numero,		Complemento,	Cep,			UfRgId,		EstadoCivilId,		RotaId, EstadoId,	CidadeId,	BairroId)
VALUES
--('Michael Xavier Lima', '71031111115', '2904237',	'SSP',		'1980/03/26',	'michlos@gmail.com',	'Raimundo Lima',	'Alvina Lima',	'Adriana Lima', 'QN 7, Conunto 3',	'25',		NULL,			'71805703',		@EstadoInt, @EstadoCivilInt,	NULL,	@EstadoInt, @CidadeInt, @BairroInt)
('Adriana de Araujo Lima', '82095175115', '040404',	'SSP',		'1976/10/30',	'adriana@gmail.com',	'Eduardo Lima',		'Genilza Lima',	'Michael Lima', 'QN 7, Conunto 2',	'15',		NULL,			'71805715',		@EstadoInt, @EstadoCivilInt,	NULL,	@EstadoInt, @CidadeInt, @BairroInt)