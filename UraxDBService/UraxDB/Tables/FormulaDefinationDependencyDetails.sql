CREATE TABLE [dbo].[FormulaDefinitionDependencyDetails] (
    [FrmDepId]   BIGINT IDENTITY (1, 1) NOT NULL,
    [FormulaId]  BIGINT NOT NULL,
    [VariableId] BIGINT NOT NULL,
    CONSTRAINT [PK_FormulaDefDependDetails_FrmDepId] PRIMARY KEY CLUSTERED ([FrmDepId] ASC),
    CONSTRAINT [FK_FormulaDefDependDetails_FormulaId] FOREIGN KEY ([FormulaId]) REFERENCES [dbo].[Formula] ([FormulaId]),
    CONSTRAINT [FK_FormulaDefDependDetails_VariableId] FOREIGN KEY ([VariableId]) REFERENCES [dbo].[Variable] ([VariableId])
);
GO

