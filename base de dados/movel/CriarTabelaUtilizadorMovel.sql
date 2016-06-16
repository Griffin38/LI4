USE [LI4Movel]
GO

/****** Object:  Table [dbo].[Utilizador]    Script Date: 16/06/2016 21:56:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Utilizador](
	[IDUtilizador] [int] NOT NULL,
	[NickName] [nchar](75) NOT NULL,
	[PassWord] [nchar](75) NOT NULL,
	[Email] [nchar](75) NOT NULL,
 CONSTRAINT [PK_Utilizador] PRIMARY KEY CLUSTERED 
(
	[IDUtilizador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


