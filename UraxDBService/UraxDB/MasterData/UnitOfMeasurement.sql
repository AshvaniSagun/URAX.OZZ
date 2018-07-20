 
IF NOT EXISTS(SELECT 1 FROM dbo.Pno12UnitOfMeasurement puom WHERE puom.Name='null')
INSERT INTO dbo.Pno12UnitOfMeasurement
(Pno12UomId, Name,LongName)
VALUES
(0, 'null','null' ) 
ELSE
UPDATE puom
SET  puom.Name ='null', puom.LongName ='null' FROM dbo.Pno12UnitOfMeasurement puom  where puom.Name = 'null'
IF NOT EXISTS(SELECT 1 FROM dbo.Pno12UnitOfMeasurement puom WHERE puom.Name='mg')
INSERT INTO Pno12UnitOfMeasurement(Pno12UomId, Name,LongName)
VALUES(1, 'mg','Milli grams' ) 
ELSE 
UPDATE puom 
SET  puom.Name ='mg', puom.LongName ='Milli grams' FROM dbo.Pno12UnitOfMeasurement puom  where puom.Name = 'mg'
IF NOT EXISTS(SELECT 1 FROM dbo.Pno12UnitOfMeasurement puom WHERE puom.Name='mm')
INSERT INTO dbo.Pno12UnitOfMeasurement
(Pno12UomId, Name,LongName)
VALUES
(2, 'mm','Milli Meters' ) 
ELSE UPDATE puom
SET  puom.Name ='mm', puom.LongName ='Milli Meters' FROM dbo.Pno12UnitOfMeasurement puom  where puom.Name = 'mm'
IF NOT EXISTS(SELECT 1 FROM dbo.Pno12UnitOfMeasurement puom WHERE puom.Name='MPG-I')
INSERT INTO dbo.Pno12UnitOfMeasurement
(Pno12UomId, Name,LongName)
VALUES
(3, 'MPG-I','Miles per Gallon(Imperial)' ) 
ELSE UPDATE puom
SET  puom.Name ='MPG-I', puom.LongName ='Miles per Gallon(Imperial)' FROM dbo.Pno12UnitOfMeasurement puom   where puom.Name = 'MPG-I'
IF NOT EXISTS(SELECT 1 FROM dbo.Pno12UnitOfMeasurement puom WHERE puom.Name='km/l')
INSERT INTO dbo.Pno12UnitOfMeasurement
(Pno12UomId, Name,LongName)
VALUES
(4, 'km/l','Kilometers per Litre' ) 
ELSE UPDATE puom
SET  puom.Name ='km/l', puom.LongName ='Kilometers per Litre' FROM dbo.Pno12UnitOfMeasurement puom   where puom.Name = 'km/l'
IF NOT EXISTS(SELECT 1 FROM dbo.Pno12UnitOfMeasurement puom WHERE puom.Name='MPG-U')
INSERT INTO dbo.Pno12UnitOfMeasurement
(Pno12UomId, Name,LongName)
VALUES
(5, 'MPG-U','Miles per Gallon(US)' ) 
ELSE UPDATE puom
SET  puom.Name ='MPG-U', puom.LongName ='Miles per Gallon(US)'FROM dbo.Pno12UnitOfMeasurement puom   where puom.Name = 'MPG-U'
IF NOT EXISTS(SELECT 1 FROM dbo.Pno12UnitOfMeasurement puom WHERE puom.Name='l/100km')
INSERT INTO dbo.Pno12UnitOfMeasurement
(Pno12UomId, Name,LongName)
VALUES
(6, 'l/100km','Litre per 100 kilometers' ) 
ELSE UPDATE puom
SET  puom.Name ='l/100km', puom.LongName ='Litre per 100 kilometers' FROM dbo.Pno12UnitOfMeasurement puom  where puom.Name = 'l/100km'
IF NOT EXISTS(SELECT 1 FROM dbo.Pno12UnitOfMeasurement puom WHERE puom.Name='l/km')
INSERT INTO dbo.Pno12UnitOfMeasurement
(Pno12UomId, Name,LongName)
VALUES
(7, 'l/km','Litre per kilometers' ) 
ELSE UPDATE puom
SET  puom.Name ='l/km', puom.LongName ='Litre per kilometers' FROM dbo.Pno12UnitOfMeasurement puom  where puom.Name = 'l/km'
