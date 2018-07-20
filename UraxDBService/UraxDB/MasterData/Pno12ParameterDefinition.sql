DECLARE @Admin varchar(50)
SET @Admin = 'ADMIN'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='FuelType')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('Fuel Type','FuelType','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'Fuel Type',ppd.ShortName = 'FuelType',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='FuelType'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='CC')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('Cylinder Capacity','CC','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'Cylinder Capacity',ppd.ShortName = 'CC',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='CC'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='KW')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('kW','KW','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'kW',ppd.ShortName = 'KW',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='KW'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='HP')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('HP','HP','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'HP',ppd.ShortName = 'HP',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='HP'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NOX')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('NOX','NOX','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'NOX',ppd.ShortName = 'NOX',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NOX'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='CYL')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('No of Cylinders','CYL','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'No of Cylinders',ppd.ShortName = 'CYL',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='CYL'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='CarLength')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('Car Length','CarLength','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'Car Length',ppd.ShortName = 'CarLength',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='CarLength'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='EmissionClass')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('Emission Class','EmissionClass','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'Emission Class',ppd.ShortName = 'EmissionClass',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='EmissionClass'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='Propulsion')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('Propulsion','Propulsion','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'Propulsion',ppd.ShortName = 'Propulsion',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='Propulsion'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='ParticulateMatterWeight')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('PM Weight','ParticulateMatterWeight','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'PM Weight',ppd.ShortName = 'ParticulateMatterWeight',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='ParticulateMatterWeight'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='ParticulateMatterQuantity')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('PM Quantity','ParticulateMatterQuantity','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'PM Quantity',ppd.ShortName = 'ParticulateMatterQuantity',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='ParticulateMatterQuantity'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='PricelistType')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('Pricelist Type','PricelistType','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'Pricelist Type',ppd.ShortName = 'PricelistType',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='PricelistType'

IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_FC_Combined')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('NEDC Fuel Consumption Combined','NEDC_FC_Combined','String', 1,6,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'NEDC Fuel Consumption Combined',ppd.ShortName = 'NEDC_FC_Combined',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 6,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_FC_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_CO2_Combined')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('NEDC CO2 Combined','NEDC_CO2_Combined','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'NEDC CO2 Combined',ppd.ShortName = 'NEDC_CO2_Combined',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_CO2_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_CO2_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP CO2 Total','WLTP_CO2_Total','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP CO2 Total',ppd.ShortName = 'WLTP_CO2_Total',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_CO2_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_FC_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP Fuel Consumption Total','WLTP_FC_Total','String', 1,6,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP Fuel Consumption Total',ppd.ShortName = 'WLTP_FC_Total',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 6,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_FC_Total'

IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_EC_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP PHEV Electric Consumption Total','WLTP_PHEV_EC_Total','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP PHEV Electric Consumption Total',ppd.ShortName = 'WLTP_PHEV_EC_Total',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_EC_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_BEV_EC_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP BEV Electric Consumption Total','WLTP_BEV_EC_Total','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP BEV Electric Consumption Total',ppd.ShortName = 'WLTP_BEV_EC_Total',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_BEV_EC_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='TPMaxLadenMass')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('TP Max Laden Mass','TPMaxLadenMass','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'TP Max Laden Mass',ppd.ShortName = 'TPMaxLadenMass',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='TPMaxLadenMass'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='HomologationCurbWeightTotal')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('Homologation Curb Weight Total','HomologationCurbWeightTotal','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'Homologation Curb Weight Total',ppd.ShortName = 'HomologationCurbWeightTotal',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='HomologationCurbWeightTotal'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_PHEV_CO2_Weighted_Combined')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('NEDC PHEV CO2 Weighted Combined','NEDC_PHEV_CO2_Weighted_Combined','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'NEDC PHEV CO2 Weighted Combined',ppd.ShortName = 'NEDC_PHEV_CO2_Weighted_Combined',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_PHEV_CO2_Weighted_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_HEV_CO2_Combined')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('NEDC HEV CO2  Combined','NEDC_HEV_CO2_Combined','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'NEDC HEV CO2  Combined',ppd.ShortName = 'NEDC_HEV_CO2_Combined',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_HEV_CO2_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_PHEV_FC_Combined')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('NEDC PHEV Fuel Consumption','NEDC_PHEV_FC_Combined','String', 1,6,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'NEDC PHEV Fuel Consumption',ppd.ShortName = 'NEDC_PHEV_FC_Combined',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 6,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_PHEV_FC_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_PHEV_FC_Weighted_Combined')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('NEDC PHEV Fuel Consumption Weighted Combined','NEDC_PHEV_FC_Weighted_Combined','String', 1,6,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'NEDC PHEV Fuel Consumption Weighted Combined',ppd.ShortName = 'NEDC_PHEV_FC_Weighted_Combined',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 6,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_PHEV_FC_Weighted_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_PHEV_Electric_Range_Combined')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('NEDC PHEV Electric Range Combined','NEDC_PHEV_Electric_Range_Combined','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'NEDC PHEV Electric Range Combined',ppd.ShortName = 'NEDC_PHEV_Electric_Range_Combined',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_PHEV_Electric_Range_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_BEV_PER_Combined')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('NEDC BEV Pure Electric Range Combined','NEDC_BEV_PER_Combined','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'NEDC BEV Pure Electric Range Combined',ppd.ShortName = 'NEDC_BEV_PER_Combined',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_BEV_PER_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_PHEV_EC_Combined')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('NEDC PHEV Electric Consumption Combined','NEDC_PHEV_EC_Combined','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'NEDC PHEV Electric Consumption Combined',ppd.ShortName = 'NEDC_PHEV_EC_Combined',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_PHEV_EC_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_PHEV_EC_Weighted_Combined')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('NEDC PHEV Electric Consumption Weighted Combined','NEDC_PHEV_EC_Weighted_Combined','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'NEDC PHEV Electric Consumption Weighted Combined',ppd.ShortName = 'NEDC_PHEV_EC_Weighted_Combined',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_PHEV_EC_Weighted_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_CO2_Weighted_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP PHEV CO2 Weighted Total','WLTP_PHEV_CO2_Weighted_Total','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP PHEV CO2 Weighted Total',ppd.ShortName = 'WLTP_PHEV_CO2_Weighted_Total',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_CO2_Weighted_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_HEV_CO2_CS_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP HEV CO2 CS Total','WLTP_HEV_CO2_CS_Total','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP HEV CO2 CS Total',ppd.ShortName = 'WLTP_HEV_CO2_CS_Total',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_HEV_CO2_CS_Total'

IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_EC_AC_CD_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP PHEV Electric Consumption AC CD Total','WLTP_PHEV_EC_AC_CD_Total','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP PHEV Electric Consumption AC CD Total',ppd.ShortName = 'WLTP_PHEV_EC_AC_CD_Total',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_EC_AC_CD_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_EC_AC_Weighted_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP PHEV Electric Consumption Weighted Total','WLTP_PHEV_EC_AC_Weighted_Total','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP PHEV Electric Consumption Weighted Total',ppd.ShortName = 'WLTP_PHEV_EC_AC_Weighted_Total',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_EC_AC_Weighted_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='MassInRunningOrderTotal')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('Mass In Running Order Total','MassInRunningOrderTotal','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'Mass In Running Order Total',ppd.ShortName = 'MassInRunningOrderTotal',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='MassInRunningOrderTotal'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_HEV_FC_Combined')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('NEDC Fuel Consumption','NEDC_HEV_FC_Combined','String', 1,6,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'NEDC Fuel Consumption',ppd.ShortName = 'NEDC_HEV_FC_Combined',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 6,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_HEV_FC_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_BEV_EC_Combined')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,	ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('NEDC BEV Electric Consumption Combined','NEDC_BEV_EC_Combined','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'NEDC BEV Electric Consumption Combined',ppd.ShortName = 'NEDC_BEV_EC_Combined',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_BEV_EC_Combined'

IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_PHEV_Electric_Range_Combined')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('NEDC PHEV Electric Range Combined','NEDC_PHEV_Electric_Range_Combined','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'NEDC PHEV Electric Range Combined',ppd.ShortName = 'NEDC_PHEV_Electric_Range_Combined',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='NEDC_PHEV_Electric_Range_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='EuroNCAPRating')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('Euro NCAP Rating','EuroNCAPRating','String', 1,0,'NULL',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'Euro NCAP Rating',ppd.ShortName = 'EuroNCAPRating',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'NULL',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='EuroNCAPRating'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='MODEL')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('Model number','MODEL','String', 1,0,'Model number (also same as first 3 pos in PNO12/PNO34)',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'Model number',ppd.ShortName = 'MODEL',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'Model number (also same as first 3 pos in PNO12/PNO34)',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='MODEL'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WVTA')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WVTA Approved','WVTA','String', 1,0,'Defines whether the variant has been approved under the Whole Vehicle Type-Approval System (WVTA) or not.',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WVTA Approved',ppd.ShortName = 'WVTA',ppd.DataType = 'String',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = 'Defines whether the variant has been approved under the Whole Vehicle Type-Approval System (WVTA) or not.',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WVTA'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_BEV_PER_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP BEV Electric Range PER Total','WLTP_BEV_PER_Total','Numeric', 1,0,'',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP BEV Electric Range PER Total',ppd.ShortName = 'WLTP_BEV_PER_Total',ppd.DataType = 'Numeric',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = '',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_BEV_PER_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_HEV_FC_CS_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP HEV Fuel Consumption CS Total','WLTP_HEV_FC_CS_Total','Decimal', 1,0,'',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP HEV Fuel Consumption CS Total',ppd.ShortName = 'WLTP_HEV_FC_CS_Total',ppd.DataType = 'Decimal',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = '',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_HEV_FC_CS_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_AER_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP PHEV Electric Range AER Total','WLTP_PHEV_AER_Total','Numeric', 1,0,'',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP PHEV Electric Range AER Total',ppd.ShortName = 'WLTP_PHEV_AER_Total',ppd.DataType = 'Numeric',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = '',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_AER_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_EAER_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP PHEV Electric Range EAER Total','WLTP_PHEV_EAER_Total','Numeric', 1,0,'',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP PHEV Electric Range EAER Total',ppd.ShortName = 'WLTP_PHEV_EAER_Total',ppd.DataType = 'Numeric',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = '',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_EAER_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_FC_Weighted_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP PHEV Fuel Consumption Weighted Total','WLTP_PHEV_FC_Weighted_Total','Decimal', 1,0,'',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP PHEV Fuel Consumption Weighted Total',ppd.ShortName = 'WLTP_PHEV_FC_Weighted_Total',ppd.DataType = 'Decimal',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = '',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_FC_Weighted_Total'

IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_EC_AC_CD_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP PHEV Electric Consumption AC CD Total','WLTP_PHEV_EC_AC_CD_Total','Numeric', 1,0,'',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP PHEV Electric Consumption AC CD Total',ppd.ShortName = 'WLTP_PHEV_EC_AC_CD_Total',ppd.DataType = 'Numeric',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = '',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_EC_AC_CD_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_EC_AC_Weighted_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP PHEV Electric Consumption Weighted Total','WLTP_PHEV_EC_AC_Weighted_Total','Numeric', 1,0,'',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP PHEV Electric Consumption Weighted Total',ppd.ShortName = 'WLTP_PHEV_EC_AC_Weighted_Total',ppd.DataType = 'Numeric',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = '',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_EC_AC_Weighted_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_EC_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP PHEV Electric Consumption Total','WLTP_PHEV_EC_Total','Numeric', 1,0,'',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP PHEV Electric Consumption Total',ppd.ShortName = 'WLTP_PHEV_EC_Total',ppd.DataType = 'Numeric',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = '',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_PHEV_EC_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_BEV_EC_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP BEV Electric Consumption Total','WLTP_BEV_EC_Total','Numeric', 1,0,'',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP BEV Electric Consumption Total',ppd.ShortName = 'WLTP_BEV_EC_Total',ppd.DataType = 'Numeric',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = '',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_BEV_EC_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_HEV_CO2_CS_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP HEV CO2 CS Total','WLTP_HEV_CO2_CS_Total','Numeric', 1,0,'',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP HEV CO2 CS Total',ppd.ShortName = 'WLTP_HEV_CO2_CS_Total',ppd.DataType = 'Numeric',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = '',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_HEV_CO2_CS_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_FC_Total')
INSERT dbo.Pno12ParameterDefinition( DefinitionName,ShortName,DataType,Pno12PtId,Pno12UomId,Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn)
VALUES('WLTP Fuel Consumption Total','WLTP_FC_Total','Decimal', 1,0,'',@Admin,getutcdate(),@Admin,getutcdate())
ELSE 
UPDATE ppd SET ppd.DefinitionName = 'WLTP Fuel Consumption Total',ppd.ShortName = 'WLTP_FC_Total',ppd.DataType = 'Decimal',ppd.Pno12PtId = 1,
ppd.Pno12UomId = 0,ppd.Description = '',ppd.CreatedBy = @Admin, ppd.CreatedOn = getutcdate(),
ppd.ModifiedBy = @Admin,ppd.ModifiedOn = getutcdate() FROM dbo.Pno12ParameterDefinition ppd WHERE ppd.ShortName='WLTP_FC_Total'
