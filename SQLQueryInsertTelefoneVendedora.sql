--INSERT INTO Rotas VALUES
--('A', '01')
--GO

DECLARE @TipoFoneString VARCHAR(11) = 'Vivo'
DECLARE @TipoInt INT
SELECT @TipoInt = TiposTelefones.TipoId FROM TiposTelefones WHERE TipoTelefone = @TipoFoneString

INSERT INTO TelefonesVendedoras VALUES
('61983172660', @TipoInt, 4)
GO

SELECT * FROM TelefonesVendedoras
