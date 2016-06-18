USE [LI4]
GO

/****** Object:  Table [dbo].[Viagem]    Script Date: 18/06/2016 19:21:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Viagem](
	[IdViagem] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](75) NOT NULL,
	[DataInicio] [date] NULL,
	[DataFim] [date] NULL,
	[idUtilizador] [int] NOT NULL,
 CONSTRAINT [PK_Viagem] PRIMARY KEY CLUSTERED 
(
	[IdViagem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Viagem]  WITH CHECK ADD  CONSTRAINT [FK_Viagem_Utilizador] FOREIGN KEY([idUtilizador])
REFERENCES [dbo].[Utilizador] ([IdUtilizador])
GO

ALTER TABLE [dbo].[Viagem] CHECK CONSTRAINT [FK_Viagem_Utilizador]
GO


