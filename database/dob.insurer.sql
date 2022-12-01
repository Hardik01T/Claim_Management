USE [Claims]
GO

/****** Object:  Table [dbo].[Insurer]    Script Date: 11/30/2022 3:58:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Insurer](
	[InsurerID] [varchar](50) NOT NULL,
	[OrganizationCode] [varchar](50) NULL,
	[PolicyNumber] [varchar](50) NULL,
 CONSTRAINT [PK_Insurer] PRIMARY KEY CLUSTERED 
(
	[InsurerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


