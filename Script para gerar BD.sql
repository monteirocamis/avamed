Use [master]
GO
CREATE DATABASE [Avamed]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Avamed', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Avamed.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Avamed_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Avamed_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Avamed] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Avamed].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Avamed] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Avamed] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Avamed] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Avamed] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Avamed] SET ARITHABORT OFF 
GO
ALTER DATABASE [Avamed] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Avamed] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Avamed] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Avamed] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Avamed] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Avamed] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Avamed] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Avamed] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Avamed] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Avamed] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Avamed] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Avamed] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Avamed] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Avamed] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Avamed] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Avamed] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Avamed] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Avamed] SET RECOVERY FULL 
GO
ALTER DATABASE [Avamed] SET  MULTI_USER 
GO
ALTER DATABASE [Avamed] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Avamed] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Avamed] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Avamed] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Avamed] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Avamed] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Avamed', N'ON'
GO
ALTER DATABASE [Avamed] SET QUERY_STORE = OFF
GO
USE [Avamed]
GO
/****** Object:  Table [dbo].[Agendamento]    Script Date: 12/19/2022 10:22:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agendamento](
	[idAgendamento] [int] IDENTITY(1,1) NOT NULL,
	[idHospital] [int] NOT NULL,
	[idEspecialidade] [int] NOT NULL,
	[idProfissional] [int] NOT NULL,
	[DataHoraAgendamento] [datetime] NOT NULL,
	[idBeneficiario] [int] NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Agendamento] PRIMARY KEY CLUSTERED 
(
	[idAgendamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_Agendamento] UNIQUE NONCLUSTERED 
(
	[idHospital] ASC,
	[idEspecialidade] ASC,
	[idProfissional] ASC,
	[idBeneficiario] ASC,
	[DataHoraAgendamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AgendamentoConfiguracao]    Script Date: 12/19/2022 10:22:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgendamentoConfiguracao](
	[IdConfiguracao] [int] IDENTITY(1,1) NOT NULL,
	[IdHospital] [int] NOT NULL,
	[IdEspecialidade] [int] NOT NULL,
	[IdProfissional] [int] NOT NULL,
	[DataHoraInicioAtendimento] [datetime] NOT NULL,
	[DataHoraFinalAtendimento] [datetime] NOT NULL,
 CONSTRAINT [PK_AgendamentoConfiguracao] PRIMARY KEY CLUSTERED 
(
	[IdConfiguracao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_AgendamentoConfiguracao] UNIQUE NONCLUSTERED 
(
	[IdHospital] ASC,
	[IdEspecialidade] ASC,
	[IdProfissional] ASC,
	[DataHoraInicioAtendimento] ASC,
	[DataHoraFinalAtendimento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Beneficiario]    Script Date: 12/19/2022 10:22:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficiario](
	[idBeneficiario] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](max) NOT NULL,
	[Cpf] [varchar](14) NOT NULL,
	[Telefone] [varchar](15) NULL,
	[Endereco] [varchar](250) NULL,
	[NumeroCarteirinha] [varchar](30) NOT NULL,
	[Ativo] [bit] NOT NULL,
	[email] [varchar](100) NOT NULL,
	[senha] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Beneficiario] PRIMARY KEY CLUSTERED 
(
	[idBeneficiario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DadosBancarios]    Script Date: 12/19/2022 10:22:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DadosBancarios](
	[IdDadosBancarios] [int] IDENTITY(1,1) NOT NULL,
	[NumeroBanco] [varchar](4) NOT NULL,
	[CodigoPix] [varchar](200) NULL,
	[Agencia] [varchar](10) NULL,
	[NumeroConta] [varchar](30) NULL,
	[Poupanca] [bit] NULL,
	[idProfissional] [int] NOT NULL,
 CONSTRAINT [PK_DadosBancarios] PRIMARY KEY CLUSTERED 
(
	[IdDadosBancarios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Especialidade]    Script Date: 12/19/2022 10:22:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especialidade](
	[IdEspecialidade] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Descrição] [varchar](max) NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Especialidade] PRIMARY KEY CLUSTERED 
(
	[IdEspecialidade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hospital]    Script Date: 12/19/2022 10:22:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hospital](
	[idHospital] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](max) NOT NULL,
	[CNPJ] [varchar](25) NULL,
	[Endereço] [varchar](max) NULL,
	[Telefone] [varchar](15) NULL,
	[CNES] [varchar](50) NULL,
	[Ativo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idHospital] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profissional]    Script Date: 12/19/2022 10:22:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profissional](
	[IdProfissional] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](max) NOT NULL,
	[Telefone] [varchar](15) NULL,
	[Endereço] [varchar](max) NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Profissional] PRIMARY KEY CLUSTERED 
(
	[IdProfissional] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Agendamento]  WITH CHECK ADD  CONSTRAINT [FK_Agendamento_Beneficiario] FOREIGN KEY([idBeneficiario])
REFERENCES [dbo].[Beneficiario] ([idBeneficiario])
GO
ALTER TABLE [dbo].[Agendamento] CHECK CONSTRAINT [FK_Agendamento_Beneficiario]
GO
ALTER TABLE [dbo].[Agendamento]  WITH CHECK ADD  CONSTRAINT [FK_Agendamento_Especialidade] FOREIGN KEY([idEspecialidade])
REFERENCES [dbo].[Especialidade] ([IdEspecialidade])
GO
ALTER TABLE [dbo].[Agendamento] CHECK CONSTRAINT [FK_Agendamento_Especialidade]
GO
ALTER TABLE [dbo].[Agendamento]  WITH CHECK ADD  CONSTRAINT [FK_Agendamento_Hospital] FOREIGN KEY([idHospital])
REFERENCES [dbo].[Hospital] ([idHospital])
GO
ALTER TABLE [dbo].[Agendamento] CHECK CONSTRAINT [FK_Agendamento_Hospital]
GO
ALTER TABLE [dbo].[Agendamento]  WITH CHECK ADD  CONSTRAINT [FK_Agendamento_Profissional] FOREIGN KEY([idProfissional])
REFERENCES [dbo].[Profissional] ([IdProfissional])
GO
ALTER TABLE [dbo].[Agendamento] CHECK CONSTRAINT [FK_Agendamento_Profissional]
GO
ALTER TABLE [dbo].[AgendamentoConfiguracao]  WITH CHECK ADD  CONSTRAINT [FK_AgendamentoConfiguracao_Especialidade] FOREIGN KEY([IdEspecialidade])
REFERENCES [dbo].[Especialidade] ([IdEspecialidade])
GO
ALTER TABLE [dbo].[AgendamentoConfiguracao] CHECK CONSTRAINT [FK_AgendamentoConfiguracao_Especialidade]
GO
ALTER TABLE [dbo].[AgendamentoConfiguracao]  WITH CHECK ADD  CONSTRAINT [FK_AgendamentoConfiguracao_Hospital] FOREIGN KEY([IdHospital])
REFERENCES [dbo].[Hospital] ([idHospital])
GO
ALTER TABLE [dbo].[AgendamentoConfiguracao] CHECK CONSTRAINT [FK_AgendamentoConfiguracao_Hospital]
GO
ALTER TABLE [dbo].[AgendamentoConfiguracao]  WITH CHECK ADD  CONSTRAINT [FK_AgendamentoConfiguracao_Profissional] FOREIGN KEY([IdProfissional])
REFERENCES [dbo].[Profissional] ([IdProfissional])
GO
ALTER TABLE [dbo].[AgendamentoConfiguracao] CHECK CONSTRAINT [FK_AgendamentoConfiguracao_Profissional]
GO
ALTER TABLE [dbo].[DadosBancarios]  WITH CHECK ADD  CONSTRAINT [FK_DadosBancarios_Profissional] FOREIGN KEY([idProfissional])
REFERENCES [dbo].[Profissional] ([IdProfissional])
GO
ALTER TABLE [dbo].[DadosBancarios] CHECK CONSTRAINT [FK_DadosBancarios_Profissional]
GO
USE [master]
GO
ALTER DATABASE [Avamed] SET  READ_WRITE 
GO
