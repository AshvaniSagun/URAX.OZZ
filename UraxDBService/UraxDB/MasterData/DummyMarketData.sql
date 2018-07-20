/***********************************************************************************************/
/*Master Variable Declaration*/
DECLARE @CountryCodeId int =( SELECT cc.CountryCodeId FROM dbo.CountryCode cc WHERE cc.CountryCode='ZZ' )
DECLARE @CurrencyId int =(SELECT cd.CurrencyId FROM dbo.CurrencyDetails cd WHERE cd.CurrencyCode='INR')
DECLARE @User varchar(50)='URAX'

/*Market Table Start*/

IF NOT EXISTS(SELECT 1 FROM dbo.Market m WHERE m.TaxTerritory='URAX')
BEGIN
INSERT INTO dbo.Market ( CountryCodeId, TaxPartnerGroup, currencyId, IsActive,CreatedBy,CreatedOn, UpdatedBy, UpdatedOn,SubdivisionCode,TaxTerritory,FeatureLevelTax )
VALUES (@CountryCodeId, NULL, @CurrencyId, 1, @User, GETUTCDATE(), @User, GETUTCDATE(), NULL, 'URAX', 1)
END

/*Market Table End*/
/***********************************************************************************************/
/*TaxMaster Table Start*/
--1		BEFORE VAT
--2		VAT
--3		AFTER VAT

DECLARE @MarketId int =( SELECT m.MarketId FROM dbo.Market m WHERE m.TaxTerritory='URAX')
DECLARE @UraxBeforeVat varchar(50) ='BeforeVatTax'
DECLARE @UraxVat varchar(50) ='VatTax'
DECLARE @UraxAfterVat varchar(50) ='AfterVatTax'

IF NOT EXISTS (SELECT 1 FROM dbo.PartnerCodeMapper pcm WHERE pcm.PartnerCode='6ZZURAX')
INSERT INTO dbo.PartnerCodeMapper( PartnerCode, GCCTaxPartnerCode, MarketId, IsActive, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn)
VALUES( '6ZZURAX', '6ZZURAX', @MarketId, 1, @User, GETUTCDATE(), @User, GETUTCDATE())


IF NOT EXISTS(SELECT 1 FROM dbo.TaxMaster tm WHERE tm.MarketId= @MarketId AND tm.TaxName = @UraxBeforeVat)
BEGIN
INSERT INTO dbo.TaxMaster( MarketId, TaxName, TaxPositionId, Priority, IsActive, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn)
VALUES (@MarketId,@UraxBeforeVat, 1, 1, 1, @User, GETUTCDATE(), @User, GETUTCDATE() )
END

IF NOT EXISTS(SELECT 1 FROM dbo.TaxMaster tm WHERE tm.MarketId= @MarketId AND tm.TaxName = @UraxVat)
BEGIN
INSERT INTO dbo.TaxMaster( MarketId, TaxName, TaxPositionId, Priority, IsActive, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn)
VALUES (@MarketId,@UraxVat, 2, 5, 1, @User, GETUTCDATE(), @User, GETUTCDATE() )
END

IF NOT EXISTS(SELECT 1 FROM dbo.TaxMaster tm WHERE tm.MarketId= @MarketId AND tm.TaxName = @UraxAfterVat)
BEGIN
INSERT INTO dbo.TaxMaster( MarketId, TaxName, TaxPositionId, Priority, IsActive, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn)
VALUES (@MarketId, @UraxAfterVat , 3, 10, 1, @User, GETUTCDATE(), @User, GETUTCDATE() )
END
/*TaxMaster Table End*/

/***********************************************************************************************/

/*TaxVersion Table Start*/
--30		Draft
--31		Published

 DECLARE @BVTaxMasterId int =( SELECT tm.TaxMasterId FROM dbo.TaxMaster tm WHERE tm.MarketId = @MarketId AND tm.TaxName = @UraxBeforeVat)
 DECLARE @VTaxMasterId int =( SELECT tm.TaxMasterId FROM dbo.TaxMaster tm WHERE tm.MarketId = @MarketId AND tm.TaxName = @UraxVat)
 DECLARE @AVTaxMasterId int =( SELECT tm.TaxMasterId FROM dbo.TaxMaster tm WHERE tm.MarketId = @MarketId AND tm.TaxName = @UraxAfterVat)
 DECLARE @StartDate date ='2018-01-01'
 DECLARE @EndDate date ='9999-12-31'

IF NOT EXISTS(SELECT 1 FROM dbo.TaxVersion tv WHERE tv.TaxMasterId =@BVTaxMasterId AND tv.StartDate = @StartDate )
BEGIN
INSERT INTO dbo.TaxVersion( TaxMasterId, StartDate, EndDate, IsActive, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, TaxVersionStatusId, FeatureLevelTax)
VALUES
( @BVTaxMasterId, @StartDate, @EndDate, 1, @User, GETUTCDATE(), @User, GETUTCDATE(), 31, 0 )
END
---------------------
IF NOT EXISTS(SELECT 1 FROM dbo.TaxVersion tv WHERE tv.TaxMasterId =@VTaxMasterId AND tv.StartDate = @StartDate )
BEGIN
INSERT INTO dbo.TaxVersion( TaxMasterId, StartDate, EndDate, IsActive, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, TaxVersionStatusId, FeatureLevelTax)
VALUES
( @VTaxMasterId, @StartDate,@EndDate, 1, @User, GETUTCDATE(), @User, GETUTCDATE(), 31, 0 )
END
----------------------
IF NOT EXISTS(SELECT 1 FROM dbo.TaxVersion tv WHERE tv.TaxMasterId =@AVTaxMasterId AND tv.StartDate = @StartDate )
BEGIN
INSERT INTO dbo.TaxVersion( TaxMasterId, StartDate, EndDate, IsActive, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, TaxVersionStatusId, FeatureLevelTax)
VALUES( @AVTaxMasterId, @StartDate, @EndDate, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),31, 0 )
END
----------------------
/*TaxVersion Table End*/
/***********************************************************************************************/
/*Tax Table Start*/
--4		MSRP
--5		PRETAX

 DECLARE @BVTaxVersionId int =( SELECT tv.TaxVersionId FROM dbo.TaxVersion tv WHERE tv.TaxMasterId = @BVTaxMasterId AND tv.StartDate = @StartDate AND tv.EndDate = @EndDate )
 DECLARE @VTaxVersionId int =( SELECT tv.TaxVersionId FROM dbo.TaxVersion tv WHERE tv.TaxMasterId = @VTaxMasterId AND tv.StartDate = @StartDate AND tv.EndDate = @EndDate )
 DECLARE @AVTaxVersionId int =( SELECT tv.TaxVersionId FROM dbo.TaxVersion tv WHERE tv.TaxMasterId = @AVTaxMasterId AND tv.StartDate = @StartDate AND tv.EndDate = @EndDate )



IF NOT EXISTS(SELECT 1 FROM dbo.Tax t WHERE t.TaxVersionId = @BVTaxVersionId AND t.TaxFlowId =4)
BEGIN
INSERT INTO dbo.Tax( TaxVersionId, TaxFlowId, IsActive, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn)
VALUES( @BVTaxVersionId, 4, 1, @User, GETUTCDATE(), @User, GETUTCDATE())
END
IF NOT EXISTS(SELECT 1 FROM dbo.Tax t WHERE t.TaxVersionId = @BVTaxVersionId AND t.TaxFlowId =5)
BEGIN
INSERT INTO dbo.Tax( TaxVersionId, TaxFlowId, IsActive, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn)
VALUES( @BVTaxVersionId, 5, 1, @User, GETUTCDATE(), @User, GETUTCDATE())
END
------------
IF NOT EXISTS(SELECT 1 FROM dbo.Tax t WHERE t.TaxVersionId = @VTaxVersionId AND t.TaxFlowId =4)
BEGIN
INSERT INTO dbo.Tax( TaxVersionId, TaxFlowId, IsActive, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn)
VALUES( @VTaxVersionId, 4, 1, @User, GETUTCDATE(), @User, GETUTCDATE())
END
IF NOT EXISTS(SELECT 1 FROM dbo.Tax t WHERE t.TaxVersionId = @VTaxVersionId AND t.TaxFlowId =5)
BEGIN
INSERT INTO dbo.Tax( TaxVersionId, TaxFlowId, IsActive, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn)
VALUES( @VTaxVersionId, 5, 1, @User, GETUTCDATE(), @User, GETUTCDATE())
END
-----------
IF NOT EXISTS(SELECT 1 FROM dbo.Tax t WHERE t.TaxVersionId = @AVTaxVersionId AND t.TaxFlowId =4)
BEGIN
INSERT INTO dbo.Tax( TaxVersionId, TaxFlowId, IsActive, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn)
VALUES( @AVTaxVersionId, 4, 1, @User, GETUTCDATE(), @User, GETUTCDATE())
END
IF NOT EXISTS(SELECT 1 FROM dbo.Tax t WHERE t.TaxVersionId = @AVTaxVersionId AND t.TaxFlowId =5)
BEGIN
INSERT INTO dbo.Tax( TaxVersionId, TaxFlowId, IsActive, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn)
VALUES( @AVTaxVersionId, 5, 1, @User, GETUTCDATE(), @User, GETUTCDATE())
END

/*Tax Table End*/

/***********************************************************************************************/
/* Variable Table Start*/


 DECLARE @BVTaxMSRPId int =( SELECT t.TaxId FROM dbo.Tax t WHERE t.TaxVersionId = @BVTaxVersionId AND t.TaxFlowId = 4 )
 DECLARE @BVTaxPRETAXId int =(SELECT t.TaxId FROM dbo.Tax t WHERE t.TaxVersionId = @BVTaxVersionId AND t.TaxFlowId = 5 )

 DECLARE @VTaxMSRPId int =( SELECT t.TaxId FROM dbo.Tax t WHERE t.TaxVersionId = @VTaxVersionId AND t.TaxFlowId = 4 )
 DECLARE @VTaxPRETAXId int =( SELECT t.TaxId FROM dbo.Tax t WHERE t.TaxVersionId = @VTaxVersionId AND t.TaxFlowId = 5 )

 DECLARE @AVTaxMSRPId int =(SELECT t.TaxId FROM dbo.Tax t WHERE t.TaxVersionId = @AVTaxVersionId AND t.TaxFlowId = 4 )
 DECLARE @AVTaxPRETAXId int =( SELECT t.TaxId FROM dbo.Tax t WHERE t.TaxVersionId = @AVTaxVersionId AND t.TaxFlowId = 5 )
 ---
 DECLARE @VariableMsrp varchar(50) ='MSRP' 
 DECLARE @VariablePretax varchar(50) ='PRETAX' 
 DECLARE @VariableVat varchar(50) ='VATRATE' 
 DECLARE @VariableNEDCCo2 varchar(50) ='NEDC CO2 COMBINED' 
 DECLARE @Division_Factor varchar(50) = 'Division_Factor'
 DECLARE @CO2_Deduction varchar(50) ='CO2_Deduction'
--Variable Type Id
		DECLARE @Input int = 6
		DECLARE @Fixed	int = 7
		DECLARE @Output	int = 8
		DECLARE @Calculated	int = 9
		DECLARE @Lookup	int = 10

--Unit Type Id
		DECLARE @Percentage int = 11
		DECLARE @NULL int = 14
		DECLARE @Numeric int = 18
		DECLARE @Money int = 19
		DECLARE @Text int = 20
---**********************PRETAX*************************-------
 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = @VariableMsrp AND v.TaxId = @BVTaxMSRPId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @BVTaxMSRPId, @VariableMsrp, NULL, @Money, @Input, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END
 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = 'NOVA' AND v.TaxId = @BVTaxMSRPId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @BVTaxMSRPId, 'NOVA', NULL, @Money, @Calculated, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END
 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = 'NOVAResult' AND v.TaxId = @BVTaxMSRPId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @BVTaxMSRPId, 'NOVAResult', NULL, @Money, @Output, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END
 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = @VariableNEDCCo2 AND v.TaxId = @BVTaxMSRPId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @BVTaxMSRPId, @VariableNEDCCo2, NULL, @Money, @Input, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END
 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = @CO2_Deduction AND v.TaxId = @BVTaxMSRPId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @BVTaxMSRPId, @CO2_Deduction, '90', @NULL, @Fixed, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END
 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = @Division_Factor AND v.TaxId = @BVTaxMSRPId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @BVTaxMSRPId, @Division_Factor, '5', @NULL, @Fixed, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END
 

 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = @VariablePretax AND v.TaxId = @BVTaxPRETAXId)
 BEGIN
INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @BVTaxPRETAXId, @VariablePretax, NULL, @Money, @Input, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END

 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = 'NOVA' AND v.TaxId = @BVTaxPRETAXId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @BVTaxPRETAXId, 'NOVA', NULL, @Money, @Calculated, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END
 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = 'NOVAResult' AND v.TaxId = @BVTaxPRETAXId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @BVTaxPRETAXId, 'NOVAResult', NULL, @Money, @Output, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END
 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = @VariableNEDCCo2 AND v.TaxId = @BVTaxPRETAXId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @BVTaxPRETAXId, @VariableNEDCCo2, NULL, @Money, @Input, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END
 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = @CO2_Deduction AND v.TaxId = @BVTaxPRETAXId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @BVTaxPRETAXId, @CO2_Deduction, '90', @NULL, @Fixed, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END
 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = @Division_Factor AND v.TaxId = @BVTaxPRETAXId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @BVTaxPRETAXId, @Division_Factor, '5', @NULL, @Fixed, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END

 ---
 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = @VariableMsrp AND v.TaxId = @VTaxMSRPId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @VTaxMSRPId, @VariableMsrp, NULL, @Money, @Input, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END

 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = @VariableVat AND v.TaxId = @VTaxMSRPId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @VTaxMSRPId, @VariableVat, '20', @Percentage, @Fixed, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END

IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = 'VATResult' AND v.TaxId = @VTaxMSRPId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @VTaxMSRPId, 'VATResult', NULL, @Money, @Output, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END



 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = @VariablePretax AND v.TaxId = @VTaxPRETAXId)
 BEGIN
INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @VTaxPRETAXId, @VariablePretax, NULL, @Money, @Input, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END

 
IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = @VariableVat AND v.TaxId = @VTaxPRETAXId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @VTaxPRETAXId, @VariableVat, '20', @Percentage, @Fixed, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END
IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = 'VATResult' AND v.TaxId = @VTaxPRETAXId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @VTaxPRETAXId, 'VATResult', NULL, @Money, @Output, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END

 -------
 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = @VariableMsrp AND v.TaxId = @AVTaxMSRPId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @AVTaxMSRPId, @VariableMsrp, NULL, @Money, @Input, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END

 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = 'AFTERVATResult' AND v.TaxId = @AVTaxMSRPId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @AVTaxMSRPId, 'AFTERVATResult', NULL, @Money, @Output, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END


 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = @VariablePretax AND v.TaxId = @AVTaxPRETAXId)
 BEGIN
INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @AVTaxPRETAXId, @VariablePretax, NULL, @Money, @Input, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END

 IF NOT EXISTS(SELECT 1 FROM dbo.Variable v WHERE v.VariableName = 'AFTERVATResult' AND v.TaxId = @AVTaxPRETAXId)
 BEGIN
 INSERT INTO dbo.Variable ( TaxId, VariableName, [Value],UnitTypeId,VariableTypeId,IslookUp, IsActive,CreatedBy, CreatedOn,UpdatedBy, UpdatedOn,TestValue )
 VALUES ( @AVTaxPRETAXId, 'AFTERVATResult', NULL, @Money, @Output, 0, 1, @User, GETUTCDATE(), @User, GETUTCDATE(),NULL )
 END
 ---------------------

 /*Variable Table End*/

 /***********************************************************************************************/
/* Formula Table Start*/

--SELECT * FROM Formula f 
Declare @NovaMSRPId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='NOVA' AND v.TaxId=@BVTaxMSRPId )
Declare @NOVAResultMSRPId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='NOVAResult' AND v.TaxId=@BVTaxMSRPId )

Declare @NovaPRETAXPId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='NOVA' AND v.TaxId=@BVTaxPRETAXId )
Declare @NOVAResultPRETAXId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='NOVAResult' AND v.TaxId=@BVTaxPRETAXId )

IF NOT EXISTS(SELECT 1 FROM dbo.Formula f WHERE f.VariableId = @NovaMSRPId)
INSERT INTO dbo.Formula
( VariableId, FormulaDefination, MinValue, MaxValue, Priority, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, IsActive)
VALUES( @NovaMSRPId, '(NEDC CO2 Combined -CO2_Deduction) / Division_Factor /100', NULL, NULL, 1,@User, GETUTCDATE(), @User, GETUTCDATE(), 1 )

IF NOT EXISTS(SELECT 1 FROM dbo.Formula f WHERE f.VariableId = @NOVAResultMSRPId)
INSERT INTO dbo.Formula
( VariableId, FormulaDefination, MinValue, MaxValue, Priority, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, IsActive)
VALUES( @NOVAResultMSRPId, '(NoVa * MSRP ) - 250', NULL, NULL, 2,@User, GETUTCDATE(), @User, GETUTCDATE(), 1 )

IF NOT EXISTS(SELECT 1 FROM dbo.Formula f WHERE f.VariableId = @NovaPRETAXPId)
INSERT INTO dbo.Formula
( VariableId, FormulaDefination, MinValue, MaxValue, Priority, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, IsActive)
VALUES( @NovaPRETAXPId, '(NEDC CO2 Combined -CO2_Deduction) / Division_Factor /100', NULL, NULL, 1,@User, GETUTCDATE(), @User, GETUTCDATE(), 1 )

IF NOT EXISTS(SELECT 1 FROM dbo.Formula f WHERE f.VariableId = @NOVAResultPRETAXId)
INSERT INTO dbo.Formula
( VariableId, FormulaDefination, MinValue, MaxValue, Priority, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, IsActive)
VALUES( @NOVAResultPRETAXId, '(NoVa * PRETAX ) - 250', NULL, NULL, 2,@User, GETUTCDATE(), @User, GETUTCDATE(), 1 )
----------------------------------

DECLARE @FNovaMSRPId int =( SELECT f.FormulaId FROM dbo.Formula f WHERE f.VariableId = @NovaMSRPId)

DECLARE @FNovaPRETAXPId int =( SELECT f.FormulaId FROM dbo.Formula f WHERE f.VariableId = @NovaPRETAXPId)

Declare @VCO2MSRPId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='NEDC CO2 COMBINED' AND v.TaxId=@BVTaxMSRPId )

Declare @VCO2TPRETAXId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='NEDC CO2 COMBINED' AND v.TaxId=@BVTaxPRETAXId )

Declare @BCO2_DeductionVATMSRPId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='CO2_Deduction' AND v.TaxId=@BVTaxMSRPId )

Declare @BCO2_DeductionVATPRETAXId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='CO2_Deduction' AND v.TaxId=@BVTaxPRETAXId )

Declare @BDivision_FactorVATMSRPId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='Division_Factor' AND v.TaxId=@BVTaxMSRPId )

Declare @BDivision_FactorVATPRETAXId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='Division_Factor' AND v.TaxId=@BVTaxPRETAXId )



IF NOT EXISTS(SELECT 1 FROM FormulaDefinitionDependencyDetails ffd WHERE ffd.FormulaId=@FNovaMSRPId AND ffd.VariableId = @VCO2MSRPId)
BEGIN
INSERT INTO dbo.FormulaDefinitionDependencyDetails ( FormulaId, VariableId) VALUES( @FNovaMSRPId, @VCO2MSRPId )
END

IF NOT EXISTS(SELECT 1 FROM FormulaDefinitionDependencyDetails ffd WHERE ffd.FormulaId=@FNovaMSRPId AND ffd.VariableId = @BCO2_DeductionVATMSRPId)
BEGIN
INSERT INTO dbo.FormulaDefinitionDependencyDetails ( FormulaId, VariableId) VALUES( @FNovaMSRPId, @BCO2_DeductionVATMSRPId )
END

IF NOT EXISTS(SELECT 1 FROM FormulaDefinitionDependencyDetails ffd WHERE ffd.FormulaId=@FNovaMSRPId AND ffd.VariableId = @BDivision_FactorVATMSRPId)
BEGIN
INSERT INTO dbo.FormulaDefinitionDependencyDetails ( FormulaId, VariableId) VALUES( @FNovaMSRPId, @BDivision_FactorVATMSRPId )
END

IF NOT EXISTS(SELECT 1 FROM FormulaDefinitionDependencyDetails ffd WHERE ffd.FormulaId=@FNovaPRETAXPId AND ffd.VariableId = @VCO2TPRETAXId)
BEGIN
INSERT INTO dbo.FormulaDefinitionDependencyDetails ( FormulaId, VariableId) VALUES( @FNovaPRETAXPId, @VCO2TPRETAXId )
END

IF NOT EXISTS(SELECT 1 FROM FormulaDefinitionDependencyDetails ffd WHERE ffd.FormulaId=@FNovaPRETAXPId AND ffd.VariableId = @BCO2_DeductionVATPRETAXId)
BEGIN
INSERT INTO dbo.FormulaDefinitionDependencyDetails ( FormulaId, VariableId) VALUES( @FNovaPRETAXPId, @BCO2_DeductionVATPRETAXId )
END

IF NOT EXISTS(SELECT 1 FROM FormulaDefinitionDependencyDetails ffd WHERE ffd.FormulaId=@FNovaPRETAXPId AND ffd.VariableId = @BDivision_FactorVATPRETAXId)
BEGIN
INSERT INTO dbo.FormulaDefinitionDependencyDetails ( FormulaId, VariableId) VALUES( @FNovaPRETAXPId, @BDivision_FactorVATPRETAXId )
END

----------------------------------
DECLARE @FBVATResultMSRPId int =( SELECT f.FormulaId FROM dbo.Formula f WHERE f.VariableId = @NOVAResultMSRPId)

DECLARE @FBVATPRETAXPId int =( SELECT f.FormulaId FROM dbo.Formula f WHERE f.VariableId = @NOVAResultPRETAXId)

Declare @VBVATMSRPId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='MSRP' AND v.TaxId=@BVTaxMSRPId )

Declare @VBVATPRETAXId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='PRETAX' AND v.TaxId=@BVTaxPRETAXId )

Declare @BNOVAVATMSRPId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='NOVA' AND v.TaxId=@BVTaxMSRPId )

Declare @BNOVAVATPRETAXId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='NOVA' AND v.TaxId=@BVTaxPRETAXId )


IF NOT EXISTS(SELECT 1 FROM FormulaDefinitionDependencyDetails ffd WHERE ffd.FormulaId=@FBVATResultMSRPId AND ffd.VariableId = @VBVATMSRPId)
BEGIN
INSERT INTO dbo.FormulaDefinitionDependencyDetails ( FormulaId, VariableId) VALUES( @FBVATResultMSRPId, @VBVATMSRPId )
END

IF NOT EXISTS(SELECT 1 FROM FormulaDefinitionDependencyDetails ffd WHERE ffd.FormulaId=@FBVATPRETAXPId AND ffd.VariableId = @VBVATPRETAXId)
BEGIN
INSERT INTO dbo.FormulaDefinitionDependencyDetails ( FormulaId, VariableId) VALUES( @FBVATPRETAXPId, @VBVATPRETAXId )
END

IF NOT EXISTS(SELECT 1 FROM FormulaDefinitionDependencyDetails ffd WHERE ffd.FormulaId=@FBVATResultMSRPId AND ffd.VariableId = @BNOVAVATMSRPId)
BEGIN
INSERT INTO dbo.FormulaDefinitionDependencyDetails ( FormulaId, VariableId) VALUES( @FBVATResultMSRPId, @BNOVAVATMSRPId )
END

IF NOT EXISTS(SELECT 1 FROM FormulaDefinitionDependencyDetails ffd WHERE ffd.FormulaId=@FBVATPRETAXPId AND ffd.VariableId = @BNOVAVATPRETAXId)
BEGIN
INSERT INTO dbo.FormulaDefinitionDependencyDetails ( FormulaId, VariableId) VALUES( @FBVATPRETAXPId, @BNOVAVATPRETAXId )
END

-------------------------------
Declare @VATResultMSRPId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='VATResult' AND v.TaxId=@VTaxMSRPId )

Declare @VATPRETAXPId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='VATResult' AND v.TaxId=@VTaxPRETAXId )

IF NOT EXISTS(SELECT 1 FROM dbo.Formula f WHERE f.VariableId = @VATResultMSRPId)
INSERT INTO dbo.Formula
( VariableId, FormulaDefination, MinValue, MaxValue, Priority, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, IsActive)
VALUES( @VATResultMSRPId, 'MSRP -(MSRP/(1 + VATRATE))', NULL, NULL, 1,@User, GETUTCDATE(), @User, GETUTCDATE(), 1 )

IF NOT EXISTS(SELECT 1 FROM dbo.Formula f WHERE f.VariableId = @VATPRETAXPId)
INSERT INTO dbo.Formula
( VariableId, FormulaDefination, MinValue, MaxValue, Priority, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, IsActive)
VALUES( @VATPRETAXPId, 'VATRATE * PRETAX ', NULL, NULL, 1,@User, GETUTCDATE(), @User, GETUTCDATE(), 1 )


------------------------------
DECLARE @FVATResultMSRPId int =( SELECT f.FormulaId FROM dbo.Formula f WHERE f.VariableId = @VATResultMSRPId)

DECLARE @FVATPRETAXPId int =( SELECT f.FormulaId FROM dbo.Formula f WHERE f.VariableId = @VATPRETAXPId)

Declare @VVATMSRPId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='MSRP' AND v.TaxId=@VTaxMSRPId )

Declare @VVATPRETAXId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='PRETAX' AND v.TaxId=@VTaxPRETAXId )

Declare @VVATVATMSRPId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='VATRATE' AND v.TaxId=@VTaxMSRPId )

Declare @VVATVATPRETAXId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='VATRATE' AND v.TaxId=@VTaxPRETAXId )


IF NOT EXISTS(SELECT 1 FROM FormulaDefinitionDependencyDetails ffd WHERE ffd.FormulaId=@FVATResultMSRPId AND ffd.VariableId = @VVATMSRPId)
BEGIN
INSERT INTO dbo.FormulaDefinitionDependencyDetails ( FormulaId, VariableId) VALUES( @FVATResultMSRPId, @VVATMSRPId )
END

IF NOT EXISTS(SELECT 1 FROM FormulaDefinitionDependencyDetails ffd WHERE ffd.FormulaId=@FVATPRETAXPId AND ffd.VariableId = @VVATPRETAXId)
BEGIN
INSERT INTO dbo.FormulaDefinitionDependencyDetails ( FormulaId, VariableId) VALUES( @FVATPRETAXPId, @VVATPRETAXId )
END

IF NOT EXISTS(SELECT 1 FROM FormulaDefinitionDependencyDetails ffd WHERE ffd.FormulaId=@FVATResultMSRPId AND ffd.VariableId = @VVATVATMSRPId)
BEGIN
INSERT INTO dbo.FormulaDefinitionDependencyDetails ( FormulaId, VariableId) VALUES( @FVATResultMSRPId, @VVATVATMSRPId )
END

IF NOT EXISTS(SELECT 1 FROM FormulaDefinitionDependencyDetails ffd WHERE ffd.FormulaId=@FVATPRETAXPId AND ffd.VariableId = @VVATVATPRETAXId)
BEGIN
INSERT INTO dbo.FormulaDefinitionDependencyDetails ( FormulaId, VariableId) VALUES( @FVATPRETAXPId, @VVATVATPRETAXId )
END


-------------------------------------------------
Declare @AVATResultMSRPId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='AFTERVATResult' AND v.TaxId=@AVTaxMSRPId )

Declare @AVATPRETAXPId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='AFTERVATResult' AND v.TaxId=@AVTaxPRETAXId )

IF NOT EXISTS(SELECT 1 FROM dbo.Formula f WHERE f.VariableId = @AVATResultMSRPId)
INSERT INTO dbo.Formula
( VariableId, FormulaDefination, MinValue, MaxValue, Priority, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, IsActive)
VALUES( @AVATResultMSRPId, 'MSRP -(MSRP/(1.2))', NULL, NULL, 1,@User, GETUTCDATE(), @User, GETUTCDATE(), 1 )

IF NOT EXISTS(SELECT 1 FROM dbo.Formula f WHERE f.VariableId = @AVATPRETAXPId)
INSERT INTO dbo.Formula
( VariableId, FormulaDefination, MinValue, MaxValue, Priority, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, IsActive)
VALUES( @AVATPRETAXPId, 'PRETAX * 0.2 ', NULL, NULL, 1,@User, GETUTCDATE(), @User, GETUTCDATE(), 1 )



-------------------------------------
DECLARE @FAVATResultMSRPId int =( SELECT f.FormulaId FROM dbo.Formula f WHERE f.VariableId = @AVATResultMSRPId)

DECLARE @FAVATPRETAXPId int =( SELECT f.FormulaId FROM dbo.Formula f WHERE f.VariableId = @AVATPRETAXPId)


Declare @AVATMSRPId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='MSRP' AND v.TaxId=@AVTaxMSRPId )

Declare @AVATPRETAXId int = (SELECT v.VariableId FROM dbo.Variable v WHERE v.VariableName='PRETAX' AND v.TaxId=@AVTaxPRETAXId )
IF NOT EXISTS(SELECT 1 FROM FormulaDefinitionDependencyDetails ffd WHERE ffd.FormulaId=@FAVATResultMSRPId AND ffd.VariableId = @AVATMSRPId)
BEGIN
INSERT INTO dbo.FormulaDefinitionDependencyDetails ( FormulaId, VariableId) VALUES( @FAVATResultMSRPId, @AVATMSRPId )
END

IF NOT EXISTS(SELECT 1 FROM FormulaDefinitionDependencyDetails ffd WHERE ffd.FormulaId=@FAVATPRETAXPId AND ffd.VariableId = @AVATPRETAXId)
BEGIN
INSERT INTO dbo.FormulaDefinitionDependencyDetails ( FormulaId, VariableId) VALUES( @FAVATPRETAXPId, @AVATPRETAXId )
END

 /*Formula Table End*/