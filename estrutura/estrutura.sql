USE [master]
GO

/****** Object:  Database [desafio21EFMVC]    Script Date: 28/03/2022 10:39:54 ******/
CREATE DATABASE [desafio21EFMVC]

USE [desafio21EFMVC]
GO
/****** Object:  Table [dbo].[f_cli_for]    Script Date: 28/03/2022 10:38:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[f_cli_for](
	[cod_cfo] [int] IDENTITY(1,1) NOT NULL,
	[nome_fantasia] [varchar](150) NOT NULL,
	[razao] [varchar](150) NOT NULL,
	[cpf_cnpj] [varchar](50) NOT NULL,
	[endereco] [varchar](255) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_alunos]    Script Date: 28/03/2022 10:38:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[tb_alunos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](150) NOT NULL,
	[matricula] [varchar](8) NOT NULL,
	[notas] [text] NOT NULL,
 CONSTRAINT [PK_tb_alunos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_professores]    Script Date: 28/03/2022 10:38:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[tb_professores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](150) NOT NULL,
	[salario] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_tb_professores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
