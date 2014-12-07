CREATE TABLE [dbo].[StoreItems]
(
	[ItemId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ItemKnd] int NULL,
	[ItemLnk] varchar(MAX) NULL,
	[ItemFileUrl] varchar(MAX) NULL,
	[ItemHtmlDesc] varchar(MAX) NULL,
)
