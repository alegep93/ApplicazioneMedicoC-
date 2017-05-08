CREATE DATABASE IF NOT EXISTS [project_work]
USE [project_work]
GO
/****** Object:  Table [dbo].[certificato]    Script Date: 03/05/2017 10:54:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[certificato](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cod_paziente] [nvarchar](50) NOT NULL,
	[cod_medico] [nvarchar](50) NOT NULL,
	[data_emissione] [date] NOT NULL,
	[cod_patologia] [nvarchar](50) NOT NULL,
	[data_inizio] [date] NOT NULL,
	[data_fine] [date] NOT NULL,
	[note] [nvarchar](1024) NULL,
 CONSTRAINT [PK_certificato] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[medico]    Script Date: 03/05/2017 10:54:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[medico](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[cognome] [nvarchar](50) NOT NULL,
	[data_nascita] [date] NOT NULL,
	[luogo] [nvarchar](50) NOT NULL,
	[cod_fis] [char](16) NOT NULL,
	[residenza] [nvarchar](50) NOT NULL,
	[provincia] [nvarchar](50) NULL,
	[indirizzo] [nvarchar](50) NULL,
	[telefono] [nvarchar](50) NULL,
	[mobile] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[cod_albo] [nvarchar](50) NULL,
	[cod_medico] [nvarchar](50) NULL,
 CONSTRAINT [PK_medico] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[patologia]    Script Date: 03/05/2017 10:54:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patologia](
	[cod_patologia] [nvarchar](50) NOT NULL,
	[descrizione] [nvarchar](512) NULL,
	[nome] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_patologia] PRIMARY KEY CLUSTERED 
(
	[cod_patologia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[paziente]    Script Date: 03/05/2017 10:54:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[paziente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[cognome] [nvarchar](50) NOT NULL,
	[data_nascita] [date] NOT NULL,
	[luogo] [nvarchar](50) NOT NULL,
	[cod_fis] [char](16) NOT NULL,
	[residenza] [nvarchar](50) NOT NULL,
	[provincia] [nvarchar](50) NULL,
	[indirizzo] [nvarchar](50) NULL,
	[telefono] [nvarchar](50) NULL,
	[mobile] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[cod_sanitario] [nvarchar](50) NOT NULL,
	[cod_medico] [nvarchar](50) NULL,
	[data_update] [datetime] NOT NULL,
	[data_inserimento] [datetime] NOT NULL,
 CONSTRAINT [PK_paziente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[paziente] ADD  CONSTRAINT [DF_paziente_data_update]  DEFAULT (getdate()) FOR [data_update]
GO
ALTER TABLE [dbo].[paziente] ADD  CONSTRAINT [DF_paziente_data_inserimento]  DEFAULT (getdate()) FOR [data_inserimento]
GO
ALTER TABLE [dbo].[certificato]  WITH CHECK ADD  CONSTRAINT [FK_certificato_medico] FOREIGN KEY([cod_medico])
REFERENCES [dbo].[medico] ([cod_medico])
GO
ALTER TABLE [dbo].[certificato] CHECK CONSTRAINT [FK_certificato_medico]
GO
ALTER TABLE [dbo].[certificato]  WITH CHECK ADD  CONSTRAINT [FK_certificato_paziente] FOREIGN KEY([cod_paziente])
REFERENCES [dbo].[paziente] ([cod_sanitario])
GO
ALTER TABLE [dbo].[certificato] CHECK CONSTRAINT [FK_certificato_paziente]
GO
ALTER TABLE [dbo].[medico]  WITH CHECK ADD  CONSTRAINT [FK_medico_paziente] FOREIGN KEY([cod_medico])
REFERENCES [dbo].[paziente] ([cod_medico])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[medico] CHECK CONSTRAINT [FK_medico_paziente]
GO
