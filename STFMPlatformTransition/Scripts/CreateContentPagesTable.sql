USE [Vulcan]
GO

/****** Object:  Table [dbo].[ContentPages]    Script Date: 10/08/2012 15:01:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ContentPages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Page] [nvarchar](50) NOT NULL,
	[Section] [nvarchar](50) NOT NULL,
	[Active] [int] NOT NULL,
	[Title] [nvarchar](50) NULL
) ON [PRIMARY]

GO


