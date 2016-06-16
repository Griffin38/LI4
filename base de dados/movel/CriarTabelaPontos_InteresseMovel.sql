USE [LI4Movel]
GO

/****** Object:  Table [dbo].[Ponto_Interesse]    Script Date: 16/06/2016 21:56:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ponto_Interesse](
	[IdPonto] [int] NOT NULL,
	[Nome] [nchar](75) NOT NULL,
	[Mapa] [nchar](75) NOT NULL,
	[idPontoWeb] [int] NOT NULL,
	[Avaliacao] [int] NULL,
	[IDViagem] [int] IDENTITY(1,1) NOT NULL,
	[IDInformacao] [int] NOT NULL,
 CONSTRAINT [PK_Ponto_Interesse] PRIMARY KEY CLUSTERED 
(
	[IdPonto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IDPontoWeb] UNIQUE NONCLUSTERED 
(
	[idPontoWeb] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [NomePontoMovel] UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Ponto_Interesse]  WITH CHECK ADD  CONSTRAINT [FK_Ponto_Interesse_Informacao] FOREIGN KEY([IDInformacao])
REFERENCES [dbo].[Informacao] ([IdInformacao])
GO

ALTER TABLE [dbo].[Ponto_Interesse] CHECK CONSTRAINT [FK_Ponto_Interesse_Informacao]
GO

ALTER TABLE [dbo].[Ponto_Interesse]  WITH CHECK ADD  CONSTRAINT [FK_Ponto_Interesse_Viagem1] FOREIGN KEY([IDViagem])
REFERENCES [dbo].[Viagem] ([IdViagem])
GO

ALTER TABLE [dbo].[Ponto_Interesse] CHECK CONSTRAINT [FK_Ponto_Interesse_Viagem1]
GO


