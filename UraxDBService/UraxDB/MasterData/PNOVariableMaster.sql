
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='FuelType')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'FuelType','FT','String',1,'ADMIN',getdate(),'ADMIN',getdate(),'Fuel Type',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='FuelType'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='CYL')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'Cylinders','CYL','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'No of Cylinders',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='CYL'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='CC')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'CylinderCapacity','CC','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'Cylinder Capacity',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='CC'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='KW')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'Kilowatt','KW','Decimal',1,'ADMIN',getdate(),'ADMIN',getdate(),'kW',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='KW'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='HP')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'Horsepower','HP','Decimal',1,'ADMIN',getdate(),'ADMIN',getdate(),'HP',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='HP'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='NOX')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'NOx','NOX','Decimal',1,'ADMIN',getdate(),'ADMIN',getdate(),'NOx',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='NOX'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='CYL')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'NoofCylinders','CYL','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'No of Cylinders',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='CYL'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='CL')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'CarLength','CL','Decimal',1,'ADMIN',getdate(),'ADMIN',getdate(),'Car Length',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='CL'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='EmissionClass')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'EmissionClass','EmissionClass','Decimal',1,'ADMIN',getdate(),'ADMIN',getdate(),'Emission Class',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='EmissionClass'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='PropulsionType')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'PropulsionType','PropulsionType','Decimal',1,'ADMIN',getdate(),'ADMIN',getdate(),'Propulsion Type',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='PropulsionType'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='PMQ')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'PMQuantity','PMQ','Decimal',1,'ADMIN',getdate(),'ADMIN',getdate(),'PM Quantity',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='PMQ'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='PricelistType')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'PricelistType','PricelistType','String',1,'ADMIN',getdate(),'ADMIN',getdate(),'Pricelist Type',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='PricelistType'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='FuelConsumption')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'FuelConsumption','FuelConsumption','',1,'ADMIN',getdate(),'ADMIN',getdate(),'Fuel Consumption',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='FuelConsumption'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='NEDC_CO2_Combined')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'NEDC_CO2_Combined','NEDC_CO2_Combined','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'NEDC CO2 Combined',33)
ELSE UPDATE cc SET cc.GroupTypeId = 33 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='NEDC_CO2_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='NEDC_FC_Combined')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'NEDC_FC_Combined','NEDC_FC_Combined','Decimal',1,'ADMIN',getdate(),'ADMIN',getdate(),'NEDC Fuel Consumption Combined',33)
ELSE UPDATE cc SET cc.GroupTypeId = 33 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='NEDC_FC_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='NEDC_HEV_FC_Combined')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'NEDC_HEV_FC_Combined','NEDC_HEV_FC_Combined','Decimal',1,'ADMIN',getdate(),'ADMIN',getdate(),'NEDC Fuel Consumption',33)
ELSE UPDATE cc SET cc.GroupTypeId = 33 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='NEDC_HEV_FC_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='NEDC_BEV_EC_Combined')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'NEDC_BEV_EC_Combined','NEDC_BEV_EC_Combined','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'NEDC BEV Electric Consumption Combined',33)
ELSE UPDATE cc SET cc.GroupTypeId = 33 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='NEDC_BEV_EC_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='WLTP_CO2_Total')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'WLTP_CO2_Total','WLTP_CO2_Total','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'WLTP CO2 Total',34)
ELSE UPDATE cc SET cc.GroupTypeId = 34 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='WLTP_CO2_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='WLTP_FC_Total')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'WLTP_FC_Total','WLTP_FC_Total','Decimal',1,'ADMIN',getdate(),'ADMIN',getdate(),'WLTP Fuel Consumption Total',34)
ELSE UPDATE cc SET cc.GroupTypeId = 34 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='WLTP_FC_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='WLTP_FC_HEV_CS_Total')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'WLTP_FC_HEV_CS_Total','WLTP_FC_HEV_CS_Total','Decimal',1,'ADMIN',getdate(),'ADMIN',getdate(),'WLTP Fuel Consumption HEV CS Total',34)
ELSE UPDATE cc SET cc.GroupTypeId = 34 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='WLTP_FC_HEV_CS_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='WLTP_PHEV_EC_Total')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'WLTP_PHEV_EC_Total','WLTP_PHEV_EC_Total','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'WLTP PHEV Electric Consumption Total',34)
ELSE UPDATE cc SET cc.GroupTypeId = 34 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='WLTP_PHEV_EC_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='WLTP_BEV_EC_Total')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'WLTP_BEV_EC_Total','WLTP_BEV_EC_Total','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'WLTP BEV Electric Consumption Total',34)
ELSE UPDATE cc SET cc.GroupTypeId = 34 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='WLTP_BEV_EC_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='TP_Max_Laden_Mass')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'TP_Max_Laden_Mass','TP_Max_Laden_Mass','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'TP Max Laden Mass',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='TP_Max_Laden_Mass'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='NEDC_PHEV_CO2_Weighted_Combined')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'NEDC_PHEV_CO2_Weighted_Combined','NEDC_PHEV_CO2_Weighted_Combined','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'NEDC PHEV CO2 Weighted Combined',33)
ELSE UPDATE cc SET cc.GroupTypeId = 33 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='NEDC_PHEV_CO2_Weighted_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='NEDC_HEV_CO2_Combined')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'NEDC_HEV_CO2_Combined','NEDC_HEV_CO2_Combined','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'NEDC HEV CO2  Combined',33)
ELSE UPDATE cc SET cc.GroupTypeId = 33 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='NEDC_HEV_CO2_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='NEDC_PHEV_FC_Combined')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'NEDC_PHEV_FC_Combined','NEDC_PHEV_FC_Combined','Decimal',1,'ADMIN',getdate(),'ADMIN',getdate(),'NEDC PHEV Fuel Consumption',33)
ELSE UPDATE cc SET cc.GroupTypeId = 33 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='NEDC_PHEV_FC_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='NEDC_PHEV_FC_Weighted_Combined')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'NEDC_PHEV_FC_Weighted_Combined','NEDC_PHEV_FC_Weighted_Combined','Decimal',1,'ADMIN',getdate(),'ADMIN',getdate(),'NEDC PHEV Fuel Consumption Weighted Combined',33)
ELSE UPDATE cc SET cc.GroupTypeId = 33 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='NEDC_PHEV_FC_Weighted_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='NEDC_PHEV_Electric_Range_Combined ')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'NEDC_PHEV_Electric_Range_Combined','NEDC_PHEV_Electric_Range_Combined ','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'NEDC PHEV Electric Range Combined',33)
ELSE UPDATE cc SET cc.GroupTypeId = 33 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='NEDC_PHEV_Electric_Range_Combined '
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='NEDC_BEV_PER_Combined')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'NEDC_BEV_PER_Combined','NEDC_BEV_PER_Combined','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'NEDC BEV Pure Electric Range Combined',33)
ELSE UPDATE cc SET cc.GroupTypeId = 33 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='NEDC_BEV_PER_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='NEDC_PHEV_EC_Combined')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'NEDC_PHEV_EC_Combined','NEDC_PHEV_EC_Combined','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'NEDC PHEV Electric Consumption Combined',33)
ELSE UPDATE cc SET cc.GroupTypeId = 33 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='NEDC_PHEV_EC_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='NEDC_PHEV_EC_Weighted_Combined')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'NEDC_PHEV_EC_Weighted_Combined','NEDC_PHEV_EC_Weighted_Combined','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'NEDC PHEV Electric Consumption Weighted Combined',33)
ELSE UPDATE cc SET cc.GroupTypeId = 33 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='NEDC_PHEV_EC_Weighted_Combined'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='WLTP_PHEV_CO2_Weighted_Total')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'WLTP_PHEV_CO2_Weighted_Total','WLTP_PHEV_CO2_Weighted_Total','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'WLTP PHEV CO2 Weighted Total',34)
ELSE UPDATE cc SET cc.GroupTypeId = 34 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='WLTP_PHEV_CO2_Weighted_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='WLTP_HEV_CO2_CS_Total')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'WLTP_HEV_CO2_CS_Total','WLTP_HEV_CO2_CS_Total','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'WLTP HEV CO2 CS Total',34)
ELSE UPDATE cc SET cc.GroupTypeId = 34 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='WLTP_HEV_CO2_CS_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='WLTP_FC_PHEV_Weighted_Total')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'WLTP_FC_PHEV_Weighted_Total','WLTP_FC_PHEV_Weighted_Total','Decimal',1,'ADMIN',getdate(),'ADMIN',getdate(),'WLTP Fuel Consumption PHEV Weighted Total',34)
ELSE UPDATE cc SET cc.GroupTypeId = 34 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='WLTP_FC_PHEV_Weighted_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='WLTP_ER_PHEV_AER_Total')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'WLTP_ER_PHEV_AER_Total','WLTP_ER_PHEV_AER_Total','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'WLTP Electric Range PHEV AER Total',34)
ELSE UPDATE cc SET cc.GroupTypeId = 34 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='WLTP_ER_PHEV_AER_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='WLTP_ER_PHEV_EAER_Total')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'WLTP_ER_PHEV_EAER_Total','WLTP_ER_PHEV_EAER_Total','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'WLTP Electric Range PHEV EAER Total',34)
ELSE UPDATE cc SET cc.GroupTypeId = 34 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='WLTP_ER_PHEV_EAER_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='WLTP_ER_BEV_PER_Total')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'WLTP_ER_BEV_PER_Total','WLTP_ER_BEV_PER_Total','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'WLTP Electric Range BEV PER Total',34)
ELSE UPDATE cc SET cc.GroupTypeId = 34 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='WLTP_ER_BEV_PER_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='WLTP_PHEV_EC_AC_CD_Total')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'WLTP_PHEV_EC_AC_CD_Total','WLTP_PHEV_EC_AC_CD_Total','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'WLTP PHEV Electric Consumption AC CD Total',34)
ELSE UPDATE cc SET cc.GroupTypeId = 34 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='WLTP_PHEV_EC_AC_CD_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='WLTP_PHEV_EC_AC_Weighted_Total')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'WLTP_PHEV_EC_AC_Weighted_Total','WLTP_PHEV_EC_AC_Weighted_Total','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'WLTP PHEV Electric Consumption Weighted Total',34)
ELSE UPDATE cc SET cc.GroupTypeId = 34 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='WLTP_PHEV_EC_AC_Weighted_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='Mass_In_Running_Order_Total')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'Mass_In_Running_Order_Total','Mass_In_Running_Order_Total','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'Mass In Running Order Total',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='Mass_In_Running_Order_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='Homologation_Curb_Weight_Total')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'Homologation_Curb_Weight_Total','Homologation_Curb_Weight_Total','Numeric',1,'ADMIN',getdate(),'ADMIN',getdate(),'Homologation Curb Weight Total',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='Homologation_Curb_Weight_Total'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='ParticulateMatterWeight')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'ParticulateMatterWeight','ParticulateMatterWeight','Decimal',1,'ADMIN',getdate(),'ADMIN',getdate(),'PM Weight',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='ParticulateMatterWeight'
IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='ParticulateMatterQuantity')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'ParticulateMatterQuantity','ParticulateMatterQuantity','Decimal',1,'ADMIN',getdate(),'ADMIN',getdate(),'PM Quantity',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='ParticulateMatterQuantity'

IF NOT EXISTS (SELECT 1 FROM dbo.PnoVariableMaster pvm WHERE pvm.VariableCode='EuroNCAPRating')
INSERT INTO dbo.PnoVariableMaster (PnoGroupId, VariableName,VariableCode,Datatype,Isactive,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,GuiName,GroupTypeId)
VALUES(1,'EuroNCAPRating','EuroNCAPRating','Decimal',1,'ADMIN',getdate(),'ADMIN',getdate(),'EuroNCAPRating',35)
ELSE UPDATE cc SET cc.GroupTypeId = 35 FROM dbo.PnoVariableMaster cc WHERE cc.VariableCode='EuroNCAPRating'

