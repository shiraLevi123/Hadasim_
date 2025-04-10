USE [FamilyTreeDB]
GO
/****** Object:  Table [dbo].[FamilyTree]    Script Date: 02/04/2025 01:12:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamilyTree](
	[Person_Id] [int] NOT NULL,
	[Relative_Id] [int] NOT NULL,
	[Connection_Type] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Person_Id] ASC,
	[Relative_Id] ASC,
	[Connection_Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FamilyTree]  WITH CHECK ADD FOREIGN KEY([Person_Id])
REFERENCES [dbo].[Persons] ([Person_Id])
GO
ALTER TABLE [dbo].[FamilyTree]  WITH CHECK ADD FOREIGN KEY([Relative_Id])
REFERENCES [dbo].[Persons] ([Person_Id])
GO
