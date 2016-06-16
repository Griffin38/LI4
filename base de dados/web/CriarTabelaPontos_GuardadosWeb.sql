USE [LI4]
GO

/****** Object:  Table [dbo].[PontosGuardados]    Script Date: 16/06/2016 22:51:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PontosGuardados](
	[ID] [int] NOT NULL,
	[IDPontoInteresse] [int] IDENTITY(1,1) NOT NULL,
	[IDUtilizador] [int] NOT NULL,
 CONSTRAINT [PK_PontosGuardados] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PontosGuardados]  WITH CHECK ADD  CONSTRAINT [FK_PontosGuardados_Pontos_Interesse] FOREIGN KEY([IDPontoInteresse])
REFERENCES [dbo].[Pontos_Interesse] ([idPonto])
GO

ALTER TABLE [dbo].[PontosGuardados] CHECK CONSTRAINT [FK_PontosGuardados_Pontos_Interesse]
GO

ALTER TABLE [dbo].[PontosGuardados]  WITH CHECK ADD  CONSTRAINT [FK_PontosGuardados_Utilizador] FOREIGN KEY([IDUtilizador])
REFERENCES [dbo].[Utilizador] ([IdUtilizador])
GO

ALTER TABLE [dbo].[PontosGuardados] CHECK CONSTRAINT [FK_PontosGuardados_Utilizador]
GO


