CREATE TABLE [dbo].[RozetkaFigures]
(
	[FigureId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[FigureHeader] varchar(MAX) NULL,
	[FigureEffect] varchar(MAX) NULL,
	[FigureImgSrc] varchar(MAX) NULL,
	[FigureCaptureHtml] varchar(MAX) NULL,
)
