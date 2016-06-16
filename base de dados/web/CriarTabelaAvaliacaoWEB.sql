USE [LI4]
GO

/****** Object:  Table [dbo].[Avaliacao]    Script Date: 16/06/2016 21:52:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Avaliacao](
	[IDAvaliacao] [int] IDENTITY(1,1) NOT NULL,
	[IDUtilizador] [int] NOT NULL,
	[IDPontoInteresse] [int] NOT NULL,
	[AvaliacaoP] [int] NOT NULL,
 CONSTRAINT [PK_Avaliacao] PRIMARY KEY CLUSTERED 
(
	[IDAvaliacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Avaliacao]  WITH CHECK ADD  CONSTRAINT [FK_Avaliacao_Pontos_Interesse] FOREIGN KEY([IDPontoInteresse])
REFERENCES [dbo].[Pontos_Interesse] ([idPonto])
GO

ALTER TABLE [dbo].[Avaliacao] CHECK CONSTRAINT [FK_Avaliacao_Pontos_Interesse]
GO

ALTER TABLE [dbo].[Avaliacao]  WITH CHECK ADD  CONSTRAINT [FK_Avaliacao_Utilizador] FOREIGN KEY([IDUtilizador])
REFERENCES [dbo].[Utilizador] ([IdUtilizador])
GO

ALTER TABLE [dbo].[Avaliacao] CHECK CONSTRAINT [FK_Avaliacao_Utilizador]
GO


