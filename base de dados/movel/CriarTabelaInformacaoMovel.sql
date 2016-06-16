USE [LI4Movel]
GO

/****** Object:  Table [dbo].[Informacao]    Script Date: 16/06/2016 21:56:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Informacao](
	[IdInformacao] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [int] NOT NULL,
	[Comentario] [nchar](75) NULL,
	[URL] [nchar](75) NULL,
	[DataObservacao] [date] NULL,
	[IDUtilizador] [int] NOT NULL,
	[IDpontoInteresse] [int] NOT NULL,
	[IDwebSite] [int] NOT NULL,
 CONSTRAINT [PK_Informacao] PRIMARY KEY CLUSTERED 
(
	[IdInformacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IDwebInformacao] UNIQUE NONCLUSTERED 
(
	[IDwebSite] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Informacao]  WITH CHECK ADD  CONSTRAINT [FK_Informacao_Utilizador] FOREIGN KEY([IDUtilizador])
REFERENCES [dbo].[Utilizador] ([IDUtilizador])
GO

ALTER TABLE [dbo].[Informacao] CHECK CONSTRAINT [FK_Informacao_Utilizador]
GO


