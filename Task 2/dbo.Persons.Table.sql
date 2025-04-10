USE [FamilyTreeDB]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 02/04/2025 01:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[Person_Id] [int] NOT NULL,
	[Personal_Name] [varchar](50) NULL,
	[Family_Name] [varchar](50) NULL,
	[Gender] [varchar](10) NULL,
	[Father_Id] [int] NULL,
	[Mother_Id] [int] NULL,
	[Spouse_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Person_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD FOREIGN KEY([Father_Id])
REFERENCES [dbo].[Persons] ([Person_Id])
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD FOREIGN KEY([Mother_Id])
REFERENCES [dbo].[Persons] ([Person_Id])
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD FOREIGN KEY([Spouse_Id])
REFERENCES [dbo].[Persons] ([Person_Id])
GO
