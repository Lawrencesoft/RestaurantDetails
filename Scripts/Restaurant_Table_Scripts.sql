USE [Restaurant]
GO

IF EXISTS(SELECT * FROM SYS.OBJECTS WHERE NAME = 'FK_Restaurant_RestaurantAvailability')
ALTER TABLE [dbo].[RestaurantAvailability] DROP CONSTRAINT [FK_Restaurant_RestaurantAvailability]
GO

/****** Object:  Table [dbo].[RestaurantAvailability]    Script Date: 4/7/2022 1:10:11 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RestaurantAvailability]') AND type in (N'U'))
DROP TABLE [dbo].[RestaurantAvailability]
GO

IF EXISTS(SELECT * FROM SYS.OBJECTS WHERE NAME = 'DF_Restaurant_IsActive')
ALTER TABLE [dbo].[Restaurant] DROP CONSTRAINT [DF_Restaurant_IsActive]
GO

/****** Object:  Table [dbo].[Restaurant]    Script Date: 4/7/2022 1:09:31 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Restaurant]') AND type in (N'U'))
DROP TABLE [dbo].[Restaurant]
GO

/****** Object:  Table [dbo].[Restaurant]    Script Date: 4/7/2022 1:09:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Restaurant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Address] [varchar](250) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Restaurant_ID] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Restaurant] ADD  CONSTRAINT [DF_Restaurant_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO


/****** Object:  Table [dbo].[RestaurantAvailability]    Script Date: 4/7/2022 1:10:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RestaurantAvailability](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RestaurantId] [int] NULL,
	[Day] [varchar](20) NULL,
	[FromTime] [time](7) NULL,
	[ToTime] [time](7) NULL,
 CONSTRAINT [PK_RestaurantAvailability_ID] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RestaurantAvailability]  WITH CHECK ADD  CONSTRAINT [FK_Restaurant_RestaurantAvailability] FOREIGN KEY([RestaurantId])
REFERENCES [dbo].[Restaurant] ([Id])
GO

ALTER TABLE [dbo].[RestaurantAvailability] CHECK CONSTRAINT [FK_Restaurant_RestaurantAvailability]
GO


