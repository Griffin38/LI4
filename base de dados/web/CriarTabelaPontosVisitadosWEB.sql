USE [LI4]
GO

/****** Object:  Table [dbo].[PontosVisitados]    Script Date: 18/06/2016 19:20:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PontosVisitados](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DataObservacao] [date] NULL,
	[TipoInfor] [int] NULL,
	[Comentario] [varchar](75) NULL,
	[Url] [varchar](75) NULL,
	[idViagem] [int] NOT NULL,
	[idPonto] [int] NOT NULL,
 CONSTRAINT [PK_Viagem_Ponto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PontosVisitados]  WITH CHECK ADD  CONSTRAINT [FK_PontosVisitados_PontosInteresse] FOREIGN KEY([idPonto])
REFERENCES [dbo].[Pontos_Interesse] ([idPonto])
GO

ALTER TABLE [dbo].[PontosVisitados] CHECK CONSTRAINT [FK_PontosVisitados_PontosInteresse]
GO

ALTER TABLE [dbo].[PontosVisitados]  WITH CHECK ADD  CONSTRAINT [FK_Viagem_Ponto_Viagem] FOREIGN KEY([idViagem])
REFERENCES [dbo].[Viagem] ([IdViagem])
GO

ALTER TABLE [dbo].[PontosVisitados] CHECK CONSTRAINT [FK_Viagem_Ponto_Viagem]
GO


