IF NOT EXISTS (SELECT 1 FROM dbo.UnitConversion uc WHERE uc.FromUnitOfMeasurementId= 7 AND uc.ToUnitOfMeasurementId =6)
INSERT dbo.UnitConversion (FromUnitOfMeasurementId, ToUnitOfMeasurementId,ConversionRate,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES
(7,6,100,'Admin',getutcdate(),'Admin',getutcdate())
ELSE
UPDATE dbo.UnitConversion
SET dbo.UnitConversion.ConversionRate = 100,  dbo.UnitConversion.CreatedBy = 'Admin',
    dbo.UnitConversion.CreatedOn = getutcdate(), 
    dbo.UnitConversion.ModifiedBy = 'Admin',
    dbo.UnitConversion.ModifiedOn = getutcdate() 
 WHERE dbo.UnitConversion.FromUnitOfMeasurementId = 7 and dbo.UnitConversion.ToUnitOfMeasurementId =6
IF NOT EXISTS (SELECT 1 FROM dbo.UnitConversion uc WHERE uc.FromUnitOfMeasurementId= 6 AND uc.ToUnitOfMeasurementId =7)
INSERT dbo.UnitConversion (FromUnitOfMeasurementId, ToUnitOfMeasurementId,ConversionRate,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES
(6,7,100,'Admin',getutcdate(),'Admin',getutcdate())
ELSE
UPDATE dbo.UnitConversion
SET dbo.UnitConversion.ConversionRate = 100,  dbo.UnitConversion.CreatedBy = 'Admin',
    dbo.UnitConversion.CreatedOn = getutcdate(), 
    dbo.UnitConversion.ModifiedBy = 'Admin',
    dbo.UnitConversion.ModifiedOn = getutcdate() 
 WHERE dbo.UnitConversion.FromUnitOfMeasurementId = 6 and dbo.UnitConversion.ToUnitOfMeasurementId =7
IF NOT EXISTS (SELECT 1 FROM dbo.UnitConversion uc WHERE uc.FromUnitOfMeasurementId= 6 AND uc.ToUnitOfMeasurementId =3)
INSERT dbo.UnitConversion (FromUnitOfMeasurementId, ToUnitOfMeasurementId,ConversionRate,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES
(6,3,282.481053149606,'Admin',getutcdate(),'Admin',getutcdate())
ELSE
UPDATE dbo.UnitConversion
SET dbo.UnitConversion.ConversionRate = 282.481053149606,  dbo.UnitConversion.CreatedBy = 'Admin',
    dbo.UnitConversion.CreatedOn = getutcdate(), 
    dbo.UnitConversion.ModifiedBy = 'Admin',
    dbo.UnitConversion.ModifiedOn = getutcdate() 
 WHERE dbo.UnitConversion.FromUnitOfMeasurementId = 6 and dbo.UnitConversion.ToUnitOfMeasurementId =3
IF NOT EXISTS (SELECT 1 FROM dbo.UnitConversion uc WHERE uc.FromUnitOfMeasurementId= 3 AND uc.ToUnitOfMeasurementId =6)
INSERT dbo.UnitConversion (FromUnitOfMeasurementId, ToUnitOfMeasurementId,ConversionRate,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES
(3,6,282.481053149606,'Admin',getutcdate(),'Admin',getutcdate())
ELSE
UPDATE dbo.UnitConversion
SET dbo.UnitConversion.ConversionRate = 282.481053149606,  dbo.UnitConversion.CreatedBy = 'Admin',
    dbo.UnitConversion.CreatedOn = getutcdate(), 
    dbo.UnitConversion.ModifiedBy = 'Admin',
    dbo.UnitConversion.ModifiedOn = getutcdate() 
 WHERE dbo.UnitConversion.FromUnitOfMeasurementId = 3 and dbo.UnitConversion.ToUnitOfMeasurementId =6
IF NOT EXISTS (SELECT 1 FROM dbo.UnitConversion uc WHERE uc.FromUnitOfMeasurementId= 6 AND uc.ToUnitOfMeasurementId =5)
INSERT dbo.UnitConversion (FromUnitOfMeasurementId, ToUnitOfMeasurementId,ConversionRate,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES
(6,5,235.214584327527,'Admin',getutcdate(),'Admin',getutcdate())
ELSE
UPDATE dbo.UnitConversion
SET dbo.UnitConversion.ConversionRate = 235.214584327527,  dbo.UnitConversion.CreatedBy = 'Admin',
    dbo.UnitConversion.CreatedOn = getutcdate(), 
    dbo.UnitConversion.ModifiedBy = 'Admin',
    dbo.UnitConversion.ModifiedOn = getutcdate() 
 WHERE dbo.UnitConversion.FromUnitOfMeasurementId = 6 and dbo.UnitConversion.ToUnitOfMeasurementId =5
IF NOT EXISTS (SELECT 1 FROM dbo.UnitConversion uc WHERE uc.FromUnitOfMeasurementId= 5 AND uc.ToUnitOfMeasurementId =6)
INSERT dbo.UnitConversion (FromUnitOfMeasurementId, ToUnitOfMeasurementId,ConversionRate,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES
(5,6,235.214584327527,'Admin',getutcdate(),'Admin',getutcdate())
ELSE
UPDATE dbo.UnitConversion
SET dbo.UnitConversion.ConversionRate = 235.214584327527,  dbo.UnitConversion.CreatedBy = 'Admin',
    dbo.UnitConversion.CreatedOn = getutcdate(), 
    dbo.UnitConversion.ModifiedBy = 'Admin',
    dbo.UnitConversion.ModifiedOn = getutcdate() 
 WHERE dbo.UnitConversion.FromUnitOfMeasurementId = 5 and dbo.UnitConversion.ToUnitOfMeasurementId =6
