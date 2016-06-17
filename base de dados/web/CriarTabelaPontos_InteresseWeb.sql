USE [LI4]
GO

/****** Object:  Table [dbo].[Pontos_Interesse]    Script Date: 17/06/2016 01:35:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Pontos_Interesse](
	[idPonto] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](75) NOT NULL,
	[Classificacao] [int] NOT NULL,
	[Mapa] [varchar](max) NOT NULL,
	[idCidade] [int] NOT NULL,
	[nrPessoasVisitaram] [int] NOT NULL,
	[longitude] [decimal](10, 5) NOT NULL,
	[latitude] [decimal](10, 5) NOT NULL,
 CONSTRAINT [PK_Pontos_Interesse] PRIMARY KEY CLUSTERED 
(
	[idPonto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [NomePonto] UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Pontos_Interesse]  WITH CHECK ADD  CONSTRAINT [FK_Pontos_Interesse_Cidade] FOREIGN KEY([idCidade])
REFERENCES [dbo].[Cidade] ([idCidade])
GO

ALTER TABLE [dbo].[Pontos_Interesse] CHECK CONSTRAINT [FK_Pontos_Interesse_Cidade]
GO


