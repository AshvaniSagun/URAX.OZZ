IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 1)
INSERT INTO ParameterDetails VALUES(1,2,'BEFORE VAT',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 2)
INSERT INTO ParameterDetails VALUES(2,2,'VAT',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 3)
INSERT INTO ParameterDetails VALUES(3,2,'AFTER VAT',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 4)
INSERT INTO ParameterDetails VALUES(4,1,'MSRP',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 5)
INSERT INTO ParameterDetails VALUES(5,1,'PRETAX',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 6)
INSERT INTO ParameterDetails VALUES(6,3,'Input',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 7)
INSERT INTO ParameterDetails VALUES(7,3,'Fixed',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 8)
INSERT INTO ParameterDetails VALUES(8,3,'Output',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE pd SET pd.[Value] ='Output' FROM ParameterDetails pd WHERE pd.ParameterId=8

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 9)
INSERT INTO ParameterDetails VALUES(9,3,'Calculated',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 10)
INSERT INTO ParameterDetails VALUES(10,3,'Lookup',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE pd SET pd.[Value] ='Lookup' FROM ParameterDetails pd WHERE pd.ParameterId=10 

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 11)
INSERT INTO ParameterDetails VALUES(11,5,'%',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 14)
INSERT INTO ParameterDetails VALUES(14,5,'',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 12)
INSERT INTO ParameterDetails VALUES(12,4,'Range',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 13)
INSERT INTO ParameterDetails VALUES(13,4,'Fixed',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 15)
INSERT INTO ParameterDetails VALUES(15,6,'RoundUp',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 16)
INSERT INTO ParameterDetails VALUES(16,6,'RoundDown',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 17)
INSERT INTO ParameterDetails VALUES(17,6,'NotRound',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 18)
INSERT INTO ParameterDetails VALUES(18,5,'Numeric',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE pd SET pd.[Value]='Numeric', pd.ParameterGroupId=5 FROM dbo.ParameterDetails pd WHERE pd.ParameterId=18

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 19)
INSERT INTO ParameterDetails VALUES(19,5,'Money',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE pd SET pd.[Value]='Money', pd.ParameterGroupId=5 FROM dbo.ParameterDetails pd WHERE pd.ParameterId=19

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 20)
INSERT INTO ParameterDetails VALUES(20,5,'Text',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE pd SET pd.[Value]='Text', pd.ParameterGroupId=5 FROM dbo.ParameterDetails pd WHERE pd.ParameterId=20

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 21)
INSERT INTO ParameterDetails VALUES(21,7,'News',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE pd SET pd.[Value]='News', pd.ParameterGroupId=7 FROM dbo.ParameterDetails pd WHERE pd.ParameterId=21

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId=22)
INSERT INTO ParameterDetails VALUES(22,7,'Training Materials',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE pd SET pd.[Value]='Training Materials', pd.ParameterGroupId=7 FROM dbo.ParameterDetails pd WHERE pd.ParameterId=22
---
IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 23)
INSERT INTO ParameterDetails VALUES(23,8,'Editor',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE pd SET pd.[Value]='Editor', pd.ParameterGroupId=8 FROM dbo.ParameterDetails pd WHERE pd.ParameterId=23

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 24)
INSERT INTO ParameterDetails VALUES(24,8,'Viewer',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE pd SET pd.[Value]='Viewer', pd.ParameterGroupId=8 FROM dbo.ParameterDetails pd WHERE pd.ParameterId=24

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 25)
INSERT INTO ParameterDetails VALUES(25,8,'User Management',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE pd SET pd.[Value]='User Management', pd.ParameterGroupId=8 FROM dbo.ParameterDetails pd WHERE pd.ParameterId=25

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 26)
INSERT INTO ParameterDetails VALUES(26,9,'MSRP',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 27)
INSERT INTO ParameterDetails VALUES(27,9,'PRETAX',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 28)
INSERT INTO ParameterDetails VALUES(28,9,'CO2',0,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE pd SET pd.IsActive=0 FROM ParameterDetails pd WHERE pd.ParameterId=28 
IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 29)
INSERT INTO ParameterDetails VALUES(29,9,'FUELTYPE',0,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())
ELSE
UPDATE pd SET pd.IsActive=0 FROM ParameterDetails pd WHERE pd.ParameterId=29
IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 30)
INSERT INTO ParameterDetails VALUES(30,10,'Draft',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 31)
INSERT INTO ParameterDetails VALUES(31,10,'Published',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 33)
INSERT INTO ParameterDetails VALUES(33,11,'NEDC',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 34)
INSERT INTO ParameterDetails VALUES(34,11,'WLTP',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())

IF NOT EXISTS(SELECT 1  FROM ParameterDetails pd WHERE pd.ParameterId= 35)
INSERT INTO ParameterDetails VALUES(35,11,'NULL',1,'ADMIN',GETUTCDATE(),'ADMIN',GETUTCDATE())


