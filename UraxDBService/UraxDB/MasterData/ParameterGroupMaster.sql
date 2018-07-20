IF NOT EXISTS(SELECT 1 FROM dbo.ParameterGroupMaster pgm WHERE pgm.ParameterGroupId=1)
INSERT INTO ParameterGroupMaster VALUES(1,'TaxFlow',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1 FROM dbo.ParameterGroupMaster pgm WHERE pgm.ParameterGroupId=2)
INSERT INTO ParameterGroupMaster VALUES(2,'TaxPosition',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1 FROM dbo.ParameterGroupMaster pgm WHERE pgm.ParameterGroupId=3)
INSERT INTO ParameterGroupMaster VALUES(3,'VariableType',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1 FROM dbo.ParameterGroupMaster pgm WHERE pgm.ParameterGroupId=4)
INSERT INTO ParameterGroupMaster VALUES(4,'LookupType',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1 FROM dbo.ParameterGroupMaster pgm WHERE pgm.ParameterGroupId=5)
INSERT INTO ParameterGroupMaster VALUES(5,'UnitType',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1 FROM dbo.ParameterGroupMaster pgm WHERE pgm.ParameterGroupId=6)
INSERT INTO ParameterGroupMaster VALUES(6,'MathRoundType',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1 FROM dbo.ParameterGroupMaster pgm WHERE pgm.ParameterGroupId=7)
INSERT INTO ParameterGroupMaster VALUES(7,'ContentType',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1 FROM dbo.ParameterGroupMaster pgm WHERE pgm.ParameterGroupId=8)
INSERT INTO ParameterGroupMaster VALUES(8,'UserRole',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1 FROM dbo.ParameterGroupMaster pgm WHERE pgm.ParameterGroupId=9)
INSERT INTO ParameterGroupMaster VALUES(9,'InputParameter',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1 FROM dbo.ParameterGroupMaster pgm WHERE pgm.ParameterGroupId=10)
INSERT INTO ParameterGroupMaster VALUES(10,'TaxVersionStatus',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1 FROM dbo.ParameterGroupMaster pgm WHERE pgm.ParameterGroupId=11)
INSERT INTO ParameterGroupMaster VALUES(11,'PnoVariableGroupType',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())